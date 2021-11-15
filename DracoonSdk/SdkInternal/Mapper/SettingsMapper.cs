using Dracoon.Sdk.Model;
using Dracoon.Sdk.SdkInternal.ApiModel;
using Dracoon.Sdk.SdkInternal.ApiModel.Requests;
using Dracoon.Sdk.SdkInternal.Util;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Dracoon.Sdk.SdkInternal.Mapper {
    internal static class SettingsMapper {
        internal static ServerGeneralSettings FromApiGeneralSettings(ApiGeneralSettings apiGeneralConfig) {
            if (apiGeneralConfig == null) {
                return null;
            }

            ServerGeneralSettings general = new ServerGeneralSettings {
                CryptoEnabled = apiGeneralConfig.CryptoEnabled,
                EmailNotificationButtonEnabled = apiGeneralConfig.EmailNotificationButtonEnabled,
                EulaEnabled = apiGeneralConfig.EulaEnabled,
                SharePasswordSmsEnabled = apiGeneralConfig.SharePasswordSmsEnabled,
                UseS3Storage = apiGeneralConfig.UseS3Storage,
                S3TagsEnabled = apiGeneralConfig.S3TagsEnabled,
                HomeRoomsActive = apiGeneralConfig.HomeRoomsActive,
                HomeRoomParentId = apiGeneralConfig.HomeRoomParentId,
                SubscriptionPlan = EnumConverter.ConvertValueToSubscriptionPlanEnum(apiGeneralConfig.SubscriptionPlan)
            };
            return general;
        }
        internal static ServerGeneralConfiguration FromApiGeneralConfiguration(ApiGeneralConfiguration apiGeneralConfig) {
            if (apiGeneralConfig == null) {
                return null;
            }

            ServerGeneralConfiguration general = new ServerGeneralConfiguration {
                CryptoEnabled = apiGeneralConfig.CryptoEnabled,
                EmailNotificationButtonEnabled = apiGeneralConfig.EmailNotificationButtonEnabled,
                EulaEnabled = apiGeneralConfig.EulaEnabled,
                SharePasswordSmsEnabled = apiGeneralConfig.SharePasswordSmsEnabled,
                UseS3Storage = apiGeneralConfig.UseS3Storage,
                S3TagsEnabled = apiGeneralConfig.S3TagsEnabled,
                HideLoginInputFields = apiGeneralConfig.HideLoginInputFields,
                AuthTokenRestrictions = FromApiAuthTokenRestrictions(apiGeneralConfig.AuthTokenRestrictions)
            };
            return general;
        }
        internal static ApiUpdateSystemGeneralConfigRequest ToApiUpdateSystemGeneralConfigRequest(UpdateSystemGeneralConfigRequest updateRequest) {
            if (updateRequest == null) {
                return null;
            }

            ApiUpdateSystemGeneralConfigRequest apiUpdateRequest = new ApiUpdateSystemGeneralConfigRequest {
                CryptoEnabled = updateRequest.CryptoEnabled,
                EmailNotificationButtonEnabled = updateRequest.EmailNotificationButtonEnabled,
                EulaEnabled = updateRequest.EulaEnabled,
                SharePasswordSmsEnabled = updateRequest.SharePasswordSmsEnabled,
                S3TagsEnabled = updateRequest.S3TagsEnabled,
                HideLoginInputFields = updateRequest.HideLoginInputFields,
                AuthTokenRestrictions = ToApiUpdateAuthTokenRestrictionsRequest(updateRequest.AuthTokenRestrictions)
            };
            return apiUpdateRequest;
        }

        internal static AuthTokenRestrictions FromApiAuthTokenRestrictions(ApiAuthTokenRestrictions apiAuthTokenRestrictions) {
            if (apiAuthTokenRestrictions == null) {
                return null;
            }

            AuthTokenRestrictions authTokenRestrictions = new AuthTokenRestrictions {
                RestrictionEnabled = apiAuthTokenRestrictions.RestrictionEnabled,
                AccessTokenValidity = apiAuthTokenRestrictions.AccessTokenValidity,
                RefreshTokenValidity = apiAuthTokenRestrictions.RefreshTokenValidity
            };

            return authTokenRestrictions;
        }
        internal static ApiUpdateAuthTokenRestrictionsRequest ToApiUpdateAuthTokenRestrictionsRequest(UpdateAuthTokenRestrictionsRequest updateRequest) {
            if (updateRequest == null) {
                return null;
            }

            ApiUpdateAuthTokenRestrictionsRequest apiUpdateRequest = new ApiUpdateAuthTokenRestrictionsRequest {
                OverwriteEnabled = updateRequest.OverwriteEnabled,
                AccessTokenValidity = updateRequest.AccessTokenValidity,
                RefreshTokenValidity = updateRequest.RefreshTokenValidity
            };

            return apiUpdateRequest;
        }

        internal static ServerInfrastructureSettings FromApiInfrastructureSettings(ApiInfrastructureSettings apiInfrastructureConfig) {
            if (apiInfrastructureConfig == null) {
                return null;
            }

            ServerInfrastructureSettings infrastructure = new ServerInfrastructureSettings {
                MediaServerConfigEnabled = apiInfrastructureConfig.MediaServerConfigEnabled,
                S3DefaultRegion = apiInfrastructureConfig.S3DefaultRegion,
                SmsConfigEnabled = apiInfrastructureConfig.SmsConfigEnabled,
                S3EnforceDirectUpload = apiInfrastructureConfig.S3EnforceDirectUpload,
                DracoonCloud = apiInfrastructureConfig.DracoonCloud,
                TenantUuid = apiInfrastructureConfig.TenantUuid
            };
            return infrastructure;
        }

        internal static ServerDefaultSettings FromApiDefaultsSettings(ApiDefaultsSettings apiDefaultsConfig) {
            if (apiDefaultsConfig == null) {
                return null;
            }

            ServerDefaultSettings defaults = new ServerDefaultSettings {
                LanguageDefault = string.IsNullOrEmpty(apiDefaultsConfig.LanguageDefault) ? CultureInfo.InvariantCulture : CultureInfo.GetCultureInfo(apiDefaultsConfig.LanguageDefault),
                DownloadShareDefaultExpirationPeriodInDays = apiDefaultsConfig.DownloadShareDefaultExpirationPeriodInDays,
                FileUploadDefaultExpirationPeriodInDays = apiDefaultsConfig.FileUploadDefaultExpirationPeriodInDays,
                UploadShareDefaultExpirationPeriodInDays = apiDefaultsConfig.UploadShareDefaultExpirationPeriodInDays,
                NonmemberViewerDefault = apiDefaultsConfig.NonmemberViewerDefault,
                HideLoginInputFields = apiDefaultsConfig.HideLoginInputFields
            };
            return defaults;
        }

        internal static PasswordSharePolicies FromApiPasswordSharePolicies(ApiSharePasswordSettings apiPolicies) {
            if (apiPolicies == null) {
                return null;
            }

            PasswordSharePolicies policies = new PasswordSharePolicies {
                CharacterPolicies = FromApiPasswordCharacterPolicies(apiPolicies.CharacterRules),
                MinimumPasswordLength = apiPolicies.MinimumPasswordLength,
                RejectDictionaryWords = apiPolicies.RejectDictionaryWords,
                RejectKeyboardPatterns = apiPolicies.RejectKeyboardPatterns,
                RejectOwnUserInfo = apiPolicies.RejectUserInfo,
                UpdatedAt = apiPolicies.UpdatedAt,
                UpdatedBy = UserMapper.FromApiUserInfo(apiPolicies.UpdatedBy)
            };
            return policies;
        }

        internal static PasswordEncryptionPolicies FromApiPasswordEncryptionPolicies(ApiEncryptionPasswordSettings apiPolicies) {
            if (apiPolicies == null) {
                return null;
            }

            PasswordEncryptionPolicies policies = new PasswordEncryptionPolicies {
                CharacterPolicies = FromApiPasswordCharacterPolicies(apiPolicies.CharacterRules),
                MinimumPasswordLength = apiPolicies.MinimumPasswordLength,
                RejectKeyboardPatterns = apiPolicies.RejectKeyboardPatterns,
                RejectOwnUserInfo = apiPolicies.RejectUserInfo,
                UpdatedAt = apiPolicies.UpdatedAt,
                UpdatedBy = UserMapper.FromApiUserInfo(apiPolicies.UpdatedBy)
            };
            return policies;
        }

        internal static PasswordCharacterPolicies FromApiPasswordCharacterPolicies(ApiCharacterRules apiPolicies) {
            if (apiPolicies == null) {
                return null;
            }

            PasswordCharacterPolicies policies = new PasswordCharacterPolicies {
                NumberOfMustContainCharacteristics = apiPolicies.NumberOfCharacteristicsToEnforce
            };

            policies.PredefinedCharacterSets = new List<PasswordCharacterSet>();
            foreach (string current in apiPolicies.MustContainCharacters) {
                if (current != "alpha") {
                    PasswordCharacterSetType type = EnumConverter.ConvertValueToCharacterSetTypeEnum(current);
                    policies.PredefinedCharacterSets.Add(new PasswordCharacterSet {
                        Type = type,
                        Set = GeneratePasswordPoliciesSet(type)
                    });
                }
            }

            // Convert "alpha" value to uppercase & lowercase if one of them are not included yet
            if (apiPolicies.MustContainCharacters.Contains("alpha")) {
                if (!apiPolicies.MustContainCharacters.Contains("lowercase")) {
                    PasswordCharacterSetType type = PasswordCharacterSetType.Lowercase;
                    policies.PredefinedCharacterSets.Add(new PasswordCharacterSet {
                        Type = type,
                        Set = GeneratePasswordPoliciesSet(type)
                    });
                }

                if (!apiPolicies.MustContainCharacters.Contains("uppercase")) {
                    PasswordCharacterSetType type = PasswordCharacterSetType.Uppercase;
                    policies.PredefinedCharacterSets.Add(new PasswordCharacterSet {
                        Type = type,
                        Set = GeneratePasswordPoliciesSet(type)
                    });
                }
            }

            return policies;
        }

        internal static char[] GeneratePasswordPoliciesSet(PasswordCharacterSetType type) {
            switch (type) {
                case PasswordCharacterSetType.Lowercase:
                    return ApiConfig.LOWERCASE_SET;
                case PasswordCharacterSetType.Uppercase:
                    return ApiConfig.UPPERCASE_SET;
                case PasswordCharacterSetType.Numeric:
                    return ApiConfig.NUMERIC_SET;
                case PasswordCharacterSetType.Special:
                    return ApiConfig.SPECIAL_SET;
                default:
                    return new char[0];
            }
        }

        internal static ServerAuthenticationConfiguration FromApiAuthenticationConfiguration(ApiAuthenticationConfiguration apiAuthenticationConfig) {
            if (apiAuthenticationConfig == null) {
                return null;
            }
            var authMethods = Enumerable.Empty<ServerAuthenticationMethod>();
            if (apiAuthenticationConfig.AuthMethods != null) {
                authMethods = apiAuthenticationConfig.AuthMethods.Select(x => FromApiAuthenticationMethod(x)).Where(x => x != null);
            }
            ServerAuthenticationConfiguration authentication = new ServerAuthenticationConfiguration() {
                AuthMethods = authMethods.ToArray()
            };
            return authentication;
        }

        internal static ServerAuthenticationMethod FromApiAuthenticationMethod(ApiAuthenticationMethod apiAuthenticationMethod) {
            if (apiAuthenticationMethod == null || string.IsNullOrEmpty(apiAuthenticationMethod.Name)) {
                return null;
            }

            var authMethodType = EnumConverter.ConvertValueToUserAuthMethodEnum(apiAuthenticationMethod.Name);

            ServerAuthenticationMethod authMethod = new ServerAuthenticationMethod() {
                AuthMethod = authMethodType,
                IsEnabled = apiAuthenticationMethod.IsEnabled,
                Priority = apiAuthenticationMethod.Priority
            };
            return authMethod;
        }

        internal static ActiveDirectoryConfigList FromApiActiveDirectoryConfigList(ApiActiveDirectoryConfigList apiActiveDirectoryConfigList) {
            if (apiActiveDirectoryConfigList == null) {
                return null;
            }

            ActiveDirectoryConfigList activeDirectoryConfigList = new ActiveDirectoryConfigList();
            CommonMapper.FromApiSimpleList(apiActiveDirectoryConfigList, activeDirectoryConfigList, FromApiActiveDirectoryConfig);
            return activeDirectoryConfigList;
        }

        internal static ActiveDirectoryConfig FromApiActiveDirectoryConfig(ApiActiveDirectoryConfig apiActiveDirectoryConfig) {
            if (apiActiveDirectoryConfig == null) {
                return null;
            }

            ActiveDirectoryConfig activeDirectoryConfig = new ActiveDirectoryConfig {
                Id = apiActiveDirectoryConfig.Id,
                Name = apiActiveDirectoryConfig.Name,
                ServerIp = apiActiveDirectoryConfig.ServerIp,
                ServerPort = apiActiveDirectoryConfig.ServerPort,
                ServerAdminName = apiActiveDirectoryConfig.ServerAdminName,
                LdapUsersDomain = apiActiveDirectoryConfig.LdapUsersDomain,
                UserFilter = apiActiveDirectoryConfig.UserFilter,
                UserImport = apiActiveDirectoryConfig.UserImport,
                AdExportGroup = apiActiveDirectoryConfig.AdExportGroup,
                UseLdaps = apiActiveDirectoryConfig.UseLdaps,
                UserImportGroupId = apiActiveDirectoryConfig.UserImportGroupId,
                SslFingerprint = apiActiveDirectoryConfig.SslFingerprint
            };

            return activeDirectoryConfig;
        }

        internal static OpenIdIdpConfigList FromApiOpenIdIpdConfigList(IEnumerable<ApiOpenIdIdpConfig> apiOpenIdIdpConfigs) {
            if (apiOpenIdIdpConfigs == null) {
                return null;
            }

            OpenIdIdpConfigList openIdIdpConfigList = new OpenIdIdpConfigList {
                Items = apiOpenIdIdpConfigs.Select(FromApiOpenIdIdpConfig).ToArray()
            };

            return openIdIdpConfigList;
        }

        internal static OpenIdIdpConfig FromApiOpenIdIdpConfig(ApiOpenIdIdpConfig apiOpenIdIdpConfig) {
            if (apiOpenIdIdpConfig == null) {
                return null;
            }

            OpenIdIdpConfig openIdIdpConfig = new OpenIdIdpConfig {
                Id = apiOpenIdIdpConfig.Id,
                Name = apiOpenIdIdpConfig.Name,
                Issuer = apiOpenIdIdpConfig.Issuer,
                AuthorizationEndPointUrl = apiOpenIdIdpConfig.AuthorizationEndPointUrl,
                TokenEndPointUrl = apiOpenIdIdpConfig.TokenEndPointUrl,
                UserInfoEndPointUrl = apiOpenIdIdpConfig.UserInfoEndPointUrl,
                JwksEndPointUrl = apiOpenIdIdpConfig.JwksEndPointUrl,
                ClientId = apiOpenIdIdpConfig.ClientId,
                ClientSecret = apiOpenIdIdpConfig.ClientSecret,
                Flow = FromApiAuthFlowType(apiOpenIdIdpConfig.Flow),
                Scopes = apiOpenIdIdpConfig.Scopes?.ToArray(),
                RedirectUris = apiOpenIdIdpConfig.RedirectUris?.ToArray(),
                PkceEnabled = apiOpenIdIdpConfig.PkceEnabled,
                PkceChallengeMethod = apiOpenIdIdpConfig.PkceChallengeMethod,
                MappingClaim = apiOpenIdIdpConfig.MappingClaim,
                FallbackMappingClaim = apiOpenIdIdpConfig.FallbackMappingClaim,
                UserImportEnabled = apiOpenIdIdpConfig.UserImportEnabled,
                UserImportGroupId = apiOpenIdIdpConfig.UserImportGroupId,
                UserUpdateEnabled = apiOpenIdIdpConfig.UserUpdateEnabled,
                UserManagementUrl = apiOpenIdIdpConfig.UserManagementUrl
            };

            return openIdIdpConfig;
        }

        private static AuthFlowType FromApiAuthFlowType(string flow) {
            if (StringComparer.OrdinalIgnoreCase.Equals(flow, "authorization_code"))
                return AuthFlowType.AuthorizationCode;
            if (StringComparer.OrdinalIgnoreCase.Equals(flow, "authorization_code"))
                return AuthFlowType.AuthorizationCode;
#if DEBUG
            throw new DracoonException($"Unknwon auth flow type {flow}!");
#else
            return AuthFlowType.None;
#endif
        }

        internal static RadiusConfig FromApiRadiusConfiguration(ApiRadiusConfig apiRadiusConfig) {
            if (apiRadiusConfig == null) {
                return null;
            }

            RadiusConfig radiusConfig = new RadiusConfig {
                IpAddress = apiRadiusConfig.IpAddress,
                Port = apiRadiusConfig.Port,
                OtpPinFirst = apiRadiusConfig.OtpPinFirst,
                SharedSecret = apiRadiusConfig.SharedSecret,
                FailoverServer = FromApiFailoverServer(apiRadiusConfig.FailoverServer)
            };

            return radiusConfig;
        }

        internal static OAuthClientConfigList FromApiOAuthClientConfigList(IEnumerable<ApiOAuthClientConfiguration> apiOAuthClientConfigs) {
            if (apiOAuthClientConfigs == null) {
                return null;
            }

            OAuthClientConfigList oauthClientConfigList = new OAuthClientConfigList {
                Items = apiOAuthClientConfigs.Select(FromApiOAuthClientConfiguration).ToArray()
            };

            return oauthClientConfigList;
        }

        internal static OAuthClientConfiguration FromApiOAuthClientConfiguration(ApiOAuthClientConfiguration apiOAuthClientConfig) {
            if (apiOAuthClientConfig == null) {
                return null;
            }

            OAuthClientConfiguration oauthClientConfig = new OAuthClientConfiguration {
                ClientId = apiOAuthClientConfig.ClientId,
                ClientName = apiOAuthClientConfig.ClientName,
                ClientSecret = apiOAuthClientConfig.ClientSecret,
                ClientType = EnumConverter.ConvertValueToOAuthClientTypeEnum(apiOAuthClientConfig.ClientType),
                IsStandard = apiOAuthClientConfig.IsStandard,
                IsExternal = apiOAuthClientConfig.IsExternal,
                IsEnabled = apiOAuthClientConfig.IsEnabled,
                GrantTypes = EnumConverter.ConvertValueToAuthorizedGrantTypesEnum(apiOAuthClientConfig.GrantTypes),
                RedirectUris = apiOAuthClientConfig.RedirectUris?.ToArray(),
                AccessTokenValidity = apiOAuthClientConfig.AccessTokenValidity,
                RefreshTokenValidity = apiOAuthClientConfig.RefreshTokenValidity,
                ApprovalValidity = apiOAuthClientConfig.ApprovalValidity
            };

            return oauthClientConfig;
        }

        internal static ApiCreateOAuthClientRequest ToApiCreateOAuthClientRequest(CreateOAuthClientRequest createRequest) {
            if (createRequest == null) {
                return null;
            }
            ApiCreateOAuthClientRequest apiCreateRequest = new ApiCreateOAuthClientRequest() {
                ClientId = createRequest.ClientId,
                ClientName = createRequest.ClientName,
                ClientSecret = createRequest.ClientSecret,
                ClientType = EnumConverter.ConvertOAuthClientTypeEnumToValue(createRequest.ClientType),
                GrantTypes = EnumConverter.ConvertAuthorizedGrantTypesEnumToValue(createRequest.GrantTypes),
                RedirectUris = createRequest.RedirectUris?.ToArray(),
                AccessTokenValidity = createRequest.AccessTokenValidity,
                RefreshTokenValidity = createRequest.RefreshTokenValidity,
                ApprovalValidity = createRequest.ApprovalValidity
            };
            return apiCreateRequest;
        }

        internal static ApiUpdateOAuthClientRequest ToApiUpdateOAuthClientRequest(UpdateOAuthClientRequest updateRequest) {
            if (updateRequest == null) {
                return null;
            }
            ApiUpdateOAuthClientRequest apiUpdateRequest = new ApiUpdateOAuthClientRequest() {
                ClientName = updateRequest.ClientName,
                ClientSecret = updateRequest.ClientSecret,
                ClientType = EnumConverter.ConvertOAuthClientTypeEnumToValue(updateRequest.ClientType),
                IsEnabled = updateRequest.IsEnabled,
                GrantTypes = EnumConverter.ConvertAuthorizedGrantTypesEnumToValue(updateRequest.GrantTypes),
                RedirectUris = updateRequest.RedirectUris?.ToArray(),
                AccessTokenValidity = updateRequest.AccessTokenValidity,
                RefreshTokenValidity = updateRequest.RefreshTokenValidity,
                ApprovalValidity = updateRequest.ApprovalValidity
            };
            return apiUpdateRequest;
        }

        internal static FailoverServer FromApiFailoverServer(ApiFailoverServer apiFailoverServer) {
            if (apiFailoverServer == null) {
                return null;
            }

            FailoverServer failoverServer = new FailoverServer {
                FailoverEnabled = apiFailoverServer.FailoverEnabled,
                FailoverIpAddress = apiFailoverServer.FailoverIpAddress,
                FailoverPort = apiFailoverServer.FailoverPort
            };

            return failoverServer;
        }
        internal static List<FileKeyAlgorithmData> FromApiFileKeyAlgorithms(List<ApiAlgorithm> apiFileKeyAlgorithms) {
            if (apiFileKeyAlgorithms == null) {
                return new List<FileKeyAlgorithmData>(0);
            }

            List<FileKeyAlgorithmData> fileKeyAlgorithms = new List<FileKeyAlgorithmData>(apiFileKeyAlgorithms.Count);
            foreach (ApiAlgorithm current in apiFileKeyAlgorithms) {
                fileKeyAlgorithms.Add(new FileKeyAlgorithmData() {
                    Algorithm = FileMapper.FromApiFileKeyVersion(current.Version),
                    State = EnumConverter.ConvertValueToAlgorithmState(current.Status)
                });
            }

            return fileKeyAlgorithms;
        }

        internal static List<UserKeyPairAlgorithmData> FromApiUserKeyPairAlgorithms(List<ApiAlgorithm> apiUserKeyPairAlgorithms) {
            if (apiUserKeyPairAlgorithms == null) {
                return new List<UserKeyPairAlgorithmData>(0);
            }

            List<UserKeyPairAlgorithmData> userKeyPairAlgorithms = new List<UserKeyPairAlgorithmData>(apiUserKeyPairAlgorithms.Count);
            foreach (ApiAlgorithm current in apiUserKeyPairAlgorithms) {
                userKeyPairAlgorithms.Add(new UserKeyPairAlgorithmData() {
                    Algorithm = UserMapper.FromApiUserKeyPairVersion(current.Version),
                    State = EnumConverter.ConvertValueToAlgorithmState(current.Status)
                });
            }

            return userKeyPairAlgorithms;
        }

        internal static ClassificationPolicies FromApiClassificationPolicies(ApiClassificationPolicies apiClassificationPolicies) {
            if (apiClassificationPolicies == null) {
                return null;
            }

            ClassificationPolicies classificationPolicies = new ClassificationPolicies {
                ShareClassificationPolicy = FromApiShareClassificationPolicy(apiClassificationPolicies.SharePolicy)
            };

            return classificationPolicies;
        }

        internal static ShareClassificationPolicy FromApiShareClassificationPolicy(ApiShareClassificationPolicy apiShareClassificationPolicy) {
            if (apiShareClassificationPolicy == null) {
                return null;
            }

            ShareClassificationPolicy shareClassificationPolicy = new ShareClassificationPolicy {
                ClassificationMinimumForSharePasswort = EnumConverter.ConvertValueToClassificationEnum(apiShareClassificationPolicy.PasswordRequirementMinimumClassification)
            };

            return shareClassificationPolicy;
        }
    }
}
