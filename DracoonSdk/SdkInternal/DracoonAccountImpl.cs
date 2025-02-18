using Dracoon.Crypto.Sdk;
using Dracoon.Crypto.Sdk.Model;
using Dracoon.Sdk.Error;
using Dracoon.Sdk.Model;
using Dracoon.Sdk.SdkInternal.ApiModel;
using Dracoon.Sdk.SdkInternal.ApiModel.Requests;
using Dracoon.Sdk.SdkInternal.Mapper;
using Dracoon.Sdk.SdkInternal.User;
using Dracoon.Sdk.SdkInternal.Validator;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using static Dracoon.Sdk.SdkInternal.DracoonRequestExecutor;
using Attribute = Dracoon.Sdk.Model.Attribute;

namespace Dracoon.Sdk.SdkInternal {
    internal class DracoonAccountImpl : IAccount {
        internal const string Logtag = nameof(DracoonAccountImpl);
        private readonly IInternalDracoonClient _client;

        internal DracoonAccountImpl(IInternalDracoonClient client) {
            _client = client;
        }

        public UserAccount GetUserAccount() {
            _client.Executor.CheckApiServerVersion();
            RestRequest request = _client.Builder.GetUserAccount();
            ApiUserAccount result = _client.Executor.DoSyncApiCall<ApiUserAccount>(request, RequestType.GetUserAccount);
            return UserMapper.FromApiUserAccount(result);
        }

        public CustomerAccount GetCustomerAccount() {
            _client.Executor.CheckApiServerVersion();
            RestRequest request = _client.Builder.GetCustomerAccount();
            ApiCustomerAccount result = _client.Executor.DoSyncApiCall<ApiCustomerAccount>(request, RequestType.GetCustomerAccount);
            return CustomerMapper.FromApiCustomerAccount(result);
        }

        public void SetUserKeyPair(UserKeyPairAlgorithm algorithm) {
            _client.Executor.CheckApiServerVersion();

            UserKeyPair cryptoPair = GenerateNewUserKeyPair(algorithm, _client.EncryptionPassword);
            ApiUserKeyPair apiUserKeyPair = UserMapper.ToApiUserKeyPair(cryptoPair);
            RestRequest request = _client.Builder.SetUserKeyPair(apiUserKeyPair);
            _client.Executor.DoSyncApiCall<VoidResponse>(request, RequestType.SetUserKeyPair);
        }

        public bool CheckUserKeyPairPassword(UserKeyPairAlgorithm algorithm) {
            _client.Executor.CheckApiServerVersion();

            try {
                GetAndCheckUserKeyPair(algorithm);
                return true;
            } catch (DracoonCryptoException cryptoError) {
                if (cryptoError.ErrorCode.Code == DracoonCryptoCode.INVALID_PASSWORD_ERROR.Code) {
                    return false;
                }

                throw;
            }
        }

        public void DeleteUserKeyPair(UserKeyPairAlgorithm algorithm) {
            _client.Executor.CheckApiServerVersion();

            string algorithmString = UserMapper.ToApiUserKeyPairVersion(algorithm);
            RestRequest request = _client.Builder.DeleteUserKeyPair(algorithmString);
            _client.Executor.DoSyncApiCall<VoidResponse>(request, RequestType.DeleteUserKeyPair);
        }

        internal UserKeyPair GenerateNewUserKeyPair(UserKeyPairAlgorithm algorithm, string encryptionPassword) {
            try {
                return Crypto.Sdk.Crypto.GenerateUserKeyPair(algorithm, encryptionPassword);
            } catch (CryptoException ce) {
                _client.Log.Debug(Logtag, "Generation of user key pair failed with " + ce.Message);
                throw new DracoonCryptoException(CryptoErrorMapper.ParseCause(ce), ce);
            }
        }

        internal UserKeyPair GetAndCheckUserKeyPair(UserKeyPairAlgorithm algorithm) {
            try {
                UserKeyPair userKeyPair = GetUserKeyPair(algorithm);
                CheckKeyPair(userKeyPair);
                return userKeyPair;
            } catch (CryptoException ce) {
                _client.Log.Debug(Logtag, $"Check of user key pair failed with '{ce.Message}'!");
                throw new DracoonCryptoException(CryptoErrorMapper.ParseCause(ce), ce);
            }
        }

        private UserKeyPair GetUserKeyPair(UserKeyPairAlgorithm algorithm) {
            string algorithmString = UserMapper.ToApiUserKeyPairVersion(algorithm);
            RestRequest request = _client.Builder.GetUserKeyPair(algorithmString);
            ApiUserKeyPair result = _client.Executor.DoSyncApiCall<ApiUserKeyPair>(request, RequestType.GetUserKeyPair);
            UserKeyPair userKeyPair = UserMapper.FromApiUserKeyPair(result);
            return userKeyPair;
        }

        public List<UserKeyPairAlgorithm> GetUserKeyPairAlgorithms() {
            _client.Executor.CheckApiServerVersion();


            List<UserKeyPair> userKeyPairs = GetUserKeyPairs();
            List<UserKeyPairAlgorithm> result = new List<UserKeyPairAlgorithm>(userKeyPairs.Count);

            foreach (UserKeyPair current in userKeyPairs) {
                result.Add(current.UserPrivateKey.Version);
            }
            return result;
        }

        public void ValidateTokenValidity() {
            _client.Executor.CheckApiServerVersion();
            RestRequest request = _client.Builder.GetAuthenticatedPing();
            _client.Executor.DoSyncApiCall<VoidResponse>(request, RequestType.GetAuthenticatedPing);
        }


        internal UserKeyPair GetPreferredUserKeyPair() {
            List<UserKeyPairAlgorithmData> algorithms = _client.ServerImpl.ServerSettings.GetAvailableUserKeyPairAlgorithms();

            algorithms = algorithms.OrderBy(x => x.State).ToList();

            List<UserKeyPair> keyPairs = GetAndCheckUserKeyPairs();

            foreach (UserKeyPairAlgorithmData currentAlgorithm in algorithms) {
                try {
                    UserKeyPair found = keyPairs.Single(o => o.UserPublicKey.Version == currentAlgorithm.Algorithm);
                    if (found != null) {
                        return found;
                    }
                } catch {
                    // No key pair found -> next key pair
                }
            }

            throw new DracoonApiException(DracoonApiCode.SERVER_USER_KEY_PAIR_NOT_FOUND);
        }

        internal UserKeyPairAlgorithm GetPreferredUserKeyPairAlgorithm() {
            List<UserKeyPairAlgorithmData> algorithms = _client.ServerImpl.ServerSettings.GetAvailableUserKeyPairAlgorithms();
            algorithms = algorithms.OrderBy(x => x.State).ToList();

            if (algorithms.Count > 0) {
                return algorithms[0].Algorithm;
            }

            return UserKeyPairAlgorithm.RSA2048;
        }

        private List<UserKeyPair> GetUserKeyPairs() {
            List<UserKeyPair> returnValue = new List<UserKeyPair>();
            // Check if api supports this api endpoint. If not only provide the keypair using the "old" api.
            _client.Executor.CheckApiServerVersion();

            RestRequest request = _client.Builder.GetUserKeyPairs();
            List<ApiUserKeyPair> result = _client.Executor.DoSyncApiCall<List<ApiUserKeyPair>>(request, RequestType.GetUserKeyPairs);

            foreach (ApiUserKeyPair apiUserKeyPair in result) {
                UserKeyPair userKeyPair = UserMapper.FromApiUserKeyPair(apiUserKeyPair);
                returnValue.Add(userKeyPair);
            }
            return returnValue;
        }

        internal List<UserKeyPair> GetAndCheckUserKeyPairs() {
            List<UserKeyPair> userKeyPairs = GetUserKeyPairs();
            foreach (UserKeyPair userKeyPair in userKeyPairs) {
                CheckKeyPair(userKeyPair);
            }
            return userKeyPairs;
        }

        private void CheckKeyPair(UserKeyPair keyPair) {
            if (!Crypto.Sdk.Crypto.CheckUserKeyPair(keyPair, _client.EncryptionPassword)) {
                throw new DracoonCryptoException(DracoonCryptoCode.INVALID_PASSWORD_ERROR);
            }
        }

        #region Avatar functions

        public byte[] GetAvatar() {
            ApiAvatarInfo apiAvatarInfo = GetApiAvatarInfoInternally();

            using (WebClient avatarClient = _client.Builder.ProvideAvatarDownloadWebClient()) {
                byte[] avatarImageBytes =
                    _client.Executor.ExecuteWebClientDownload(avatarClient, new Uri(apiAvatarInfo.AvatarUri), RequestType.GetUserAvatar);
                return avatarImageBytes;
            }
        }

        public AvatarInfo GetAvatarInfo() {
            ApiAvatarInfo apiAvatarInfo = GetApiAvatarInfoInternally();
            return UserMapper.FromApiAvatarInfo(apiAvatarInfo);
        }

        private ApiAvatarInfo GetApiAvatarInfoInternally() {
            _client.Executor.CheckApiServerVersion();

            RestRequest request = _client.Builder.GetAvatar();
            ApiAvatarInfo apiAvatarInfo = _client.Executor.DoSyncApiCall<ApiAvatarInfo>(request, RequestType.GetUserAvatar);
            return apiAvatarInfo;
        }

        public AvatarInfo ResetAvatar() {
            _client.Executor.CheckApiServerVersion();

            RestRequest request = _client.Builder.DeleteAvatar();
            ApiAvatarInfo defaultAvatarInfo = _client.Executor.DoSyncApiCall<ApiAvatarInfo>(request, RequestType.DeleteUserAvatar);
            return UserMapper.FromApiAvatarInfo(defaultAvatarInfo);
        }

        public AvatarInfo UpdateAvatar(byte[] newAvatar) {
            _client.Executor.CheckApiServerVersion();
            _client.Executor.MustNotNull(nameof(newAvatar));

            #region Build multipart

            string formDataBoundary = "---------------------------" + Guid.NewGuid();
            byte[] packageHeader = ApiConfig.ENCODING.GetBytes(
                $"--{formDataBoundary}\r\nContent-Disposition: form-data; name=\"{"file"}\"; filename=\"{"avatarImage"}\"\r\n\r\n");
            byte[] packageFooter = ApiConfig.ENCODING.GetBytes(string.Format("\r\n--" + formDataBoundary + "--"));
            byte[] multipartFormatedChunkData = new byte[packageHeader.Length + packageFooter.Length + newAvatar.Length];
            Buffer.BlockCopy(packageHeader, 0, multipartFormatedChunkData, 0, packageHeader.Length);
            Buffer.BlockCopy(newAvatar, 0, multipartFormatedChunkData, packageHeader.Length, newAvatar.Length);
            Buffer.BlockCopy(packageFooter, 0, multipartFormatedChunkData, packageHeader.Length + newAvatar.Length, packageFooter.Length);

            #endregion

            ApiAvatarInfo resultAvatarInfo;
            using (WebClient avatarClient = _client.Builder.ProvideAvatarUploadWebClient(formDataBoundary)) {
                byte[] resultAvatarInfoBytes = _client.Executor.ExecuteWebClientChunkUpload(avatarClient,
                    new Uri(_client.ServerUri, ApiConfig.ApiPostAvatar), multipartFormatedChunkData, RequestType.PostUserAvatar);
                resultAvatarInfo = JsonConvert.DeserializeObject<ApiAvatarInfo>(Encoding.UTF8.GetString(resultAvatarInfoBytes));
            }

            return UserMapper.FromApiAvatarInfo(resultAvatarInfo);
        }

        #endregion

        #region Profile-Attributes

        public AttributeList GetUserProfileAttributeList() {
            _client.Executor.CheckApiServerVersion();

            RestRequest request = _client.Builder.GetUserProfileAttributes();
            ApiAttributeList apiAttributeList = _client.Executor.DoSyncApiCall<ApiAttributeList>(request, RequestType.GetUserProfileAttributes);
            return AttributeMapper.FromApiAttributeList(apiAttributeList);
        }

        public Attribute GetUserProfileAttribute(string attributeKey) {
            _client.Executor.CheckApiServerVersion();

            #region Parameter Validation

            attributeKey.MustNotNullOrEmptyOrWhitespace(nameof(attributeKey));

            #endregion

            RestRequest request = _client.Builder.GetUserProfileAttribute(attributeKey);
            ApiAttributeList apiAttributeList = _client.Executor.DoSyncApiCall<ApiAttributeList>(request, RequestType.GetUserProfileAttributes);
            if (apiAttributeList.Range.Total == 0) {
                throw new DracoonApiException(DracoonApiCode.SERVER_ATTRIBUTE_NOT_FOUND);
            }

            return AttributeMapper.FromApiAttributeList(apiAttributeList).Items[0];
        }

        public void AddOrUpdateUserProfileAttributes(List<Attribute> attributes) {
            _client.Executor.CheckApiServerVersion();

            #region Parameter Validation

            List<string> attributeKeys = new List<string>();
            foreach (Attribute currentAttribute in attributes) {
                currentAttribute.Key.MustNotNullOrEmptyOrWhitespace(nameof(currentAttribute.Key));
                currentAttribute.Value.MustNotNull(nameof(currentAttribute.Value));
                if (attributeKeys.Contains(currentAttribute.Key)) {
                    throw new ArgumentException("List cannot contain attributes with same attribute key.");
                }

                attributeKeys.Add(currentAttribute.Key);
            }

            #endregion

            ApiAddOrUpdateAttributeRequest apiAttributes = AttributeMapper.ToApiAddOrUpdateAttributeRequest(attributes);
            RestRequest request = _client.Builder.PutUserProfileAttributes(apiAttributes);
            _client.Executor.DoSyncApiCall<VoidResponse>(request, RequestType.PutUserProfileAttributes);
        }

        public void DeleteProfileAttribute(string attributeKey) {
            _client.Executor.CheckApiServerVersion();

            #region Parameter Validation

            attributeKey.MustNotNullOrEmptyOrWhitespace(nameof(attributeKey));

            #endregion

            RestRequest request = _client.Builder.DeleteUserProfileAttributes(attributeKey);
            _client.Executor.DoSyncApiCall<VoidResponse>(request, RequestType.DeleteUserProfileAttributes);
        }

        #endregion

        #region Subscriptions

        public ShareSubscriptionList GetDownloadShareSubscriptions(long? offset = null, long? limit = null) {
            _client.Executor.CheckApiServerVersion();

            #region Parameter Validation

            offset.NullableMustNotNegative(nameof(offset));
            limit.NullableMustPositive(nameof(limit));

            #endregion

            RestRequest restRequest = _client.Builder.GetDownloadShareSubscriptions(offset, limit);
            ApiShareSubscriptionList result = _client.Executor.DoSyncApiCall<ApiShareSubscriptionList>(restRequest, RequestType.GetDownloadShareSubscriptions);
            return UserMapper.FromApiShareSubscriptionList(result);
        }

        public void RemoveDownloadShareSubscription(long shareId) {
            _client.Executor.CheckApiServerVersion();

            #region Parameter Validation

            shareId.MustPositive(nameof(shareId));

            #endregion

            RestRequest restRequest = _client.Builder.RemoveDownloadShareSubscription(shareId);
            _client.Executor.DoSyncApiCall<VoidResponse>(restRequest, RequestType.DeleteDownloadShareSubscription);
        }

        public ShareSubscription AddDownloadShareSubscription(long shareId) {
            _client.Executor.CheckApiServerVersion();

            #region Parameter Validation

            shareId.MustPositive(nameof(shareId));

            #endregion

            RestRequest restRequest = _client.Builder.AddDownloadShareSubscription(shareId);
            ApiShareSubscription result = _client.Executor.DoSyncApiCall<ApiShareSubscription>(restRequest, RequestType.PostDownloadShareSubscription);
            return UserMapper.FromApiShareSubscription(result);
        }

        public ShareSubscriptionList GetUploadShareSubscriptions(long? offset = null, long? limit = null) {
            _client.Executor.CheckApiServerVersion();

            #region Parameter Validation

            offset.NullableMustNotNegative(nameof(offset));
            limit.NullableMustPositive(nameof(limit));

            #endregion

            RestRequest restRequest = _client.Builder.GetUploadShareSubscriptions(offset, limit);
            ApiShareSubscriptionList result = _client.Executor.DoSyncApiCall<ApiShareSubscriptionList>(restRequest, RequestType.GetUploadShareSubscriptions);
            return UserMapper.FromApiShareSubscriptionList(result);
        }

        public void RemoveUploadShareSubscription(long shareId) {
            _client.Executor.CheckApiServerVersion();

            #region Parameter Validation

            shareId.MustPositive(nameof(shareId));

            #endregion

            RestRequest restRequest = _client.Builder.RemoveUploadShareSubscription(shareId);
            _client.Executor.DoSyncApiCall<VoidResponse>(restRequest, RequestType.DeleteUploadShareSubscription);
        }

        public ShareSubscription AddUploadShareSubscription(long shareId) {
            _client.Executor.CheckApiServerVersion();

            #region Parameter Validation

            shareId.MustPositive(nameof(shareId));

            #endregion

            RestRequest restRequest = _client.Builder.AddUploadShareSubscription(shareId);
            ApiShareSubscription result = _client.Executor.DoSyncApiCall<ApiShareSubscription>(restRequest, RequestType.PostUploadShareSubscription);
            return UserMapper.FromApiShareSubscription(result);
        }

        #endregion
    }
}
