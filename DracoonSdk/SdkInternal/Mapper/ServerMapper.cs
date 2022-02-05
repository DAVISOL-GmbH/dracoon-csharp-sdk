using Dracoon.Sdk.Model;
using Dracoon.Sdk.SdkInternal.ApiModel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Dracoon.Sdk.SdkInternal.Mapper {
    internal static class ServerMapper {

        internal static PublicDownloadShare FromApiPublicDownloadShare(ApiPublicDownloadShare apiPublicDownloadShare) {
            if (apiPublicDownloadShare == null) {
                return null;
            }

            PublicDownloadShare publicDownloadShare = new PublicDownloadShare() {
                IsProtected = apiPublicDownloadShare.IsProtected,
                Name = apiPublicDownloadShare.Name,
                FileName = apiPublicDownloadShare.FileName,
                MediaType = apiPublicDownloadShare.MediaType,
                Size = apiPublicDownloadShare.Size,
                HasDownloadLimit = apiPublicDownloadShare.HasDownloadLimit,
                LimitReached = apiPublicDownloadShare.LimitReached,
                CreatedAt = apiPublicDownloadShare.CreatedAt,
                CreatorName = apiPublicDownloadShare.CreatorName,
                CreatorUsername = apiPublicDownloadShare.CreatorUsername,
                Notes = apiPublicDownloadShare.Notes,
                IsEncrypted = apiPublicDownloadShare.IsEncrypted,
                ExpireAt = apiPublicDownloadShare.ExpireAt
            };
            return publicDownloadShare;
        }

        internal static PublicUploadShare FromApiPublicUploadShare(ApiPublicUploadShare apiPublicUploadShare) {
            if (apiPublicUploadShare == null) {
                return null;
            }

            PublicUploadShare publicUploadShare = new PublicUploadShare() {
                IsProtected = apiPublicUploadShare.IsProtected,
                Name = apiPublicUploadShare.Name,
                ShowUploadedFiles = apiPublicUploadShare.ShowUploadedFiles,
                RemainingSlots = apiPublicUploadShare.RemainingSlots,
                RemainingSize = apiPublicUploadShare.RemainingSize,
                CreatedAt = apiPublicUploadShare.CreatedAt,
                CreatorName = apiPublicUploadShare.CreatorName,
                CreatorUsername = apiPublicUploadShare.CreatorUsername,
                Notes = apiPublicUploadShare.Notes,
                IsEncrypted = apiPublicUploadShare.IsEncrypted,
                ExpireAt = apiPublicUploadShare.ExpireAt,

                UploadedFiles = apiPublicUploadShare.ShowUploadedFiles
                    ? apiPublicUploadShare.UploadedFiles?.Select(x => FromApiPublicUploadedFileData(x))?.Where(x => x != null)?.ToArray()
                    : null,
            };
            return publicUploadShare;
        }

        private static PublicUploadedFileData FromApiPublicUploadedFileData(ApiPublicUploadedFileData apiPublicUploadedFileData) {
            if (apiPublicUploadedFileData == null) {
                return null;
            }

            PublicUploadedFileData publicUploadedFileData = new PublicUploadedFileData() {
                Name = apiPublicUploadedFileData.Name,
                Size = apiPublicUploadedFileData.Size,
                CreatedAt = apiPublicUploadedFileData.CreatedAt,
                Hash = apiPublicUploadedFileData.Hash
            };
            return publicUploadedFileData;
        }

        internal static SystemInfo FromApiSystemInfo(ApiSystemInfo apiSystemInfo) {
            if (apiSystemInfo == null) {
                return null;
            }

            SystemInfo systemInfo = new SystemInfo() {
                LanguageDefault = apiSystemInfo.LanguageDefault,
                HideLoginInputFields = apiSystemInfo.HideLoginInputFields,
                S3Hosts = apiSystemInfo.S3Hosts?.ToArray() ?? Array.Empty<string>(),
                S3EnforceDirectUpload = apiSystemInfo.S3EnforceDirectUpload,
                UseS3Storage = apiSystemInfo.UseS3Storage
            };

#pragma warning disable CS0618 // Type or member is obsolete
            if (apiSystemInfo.AuthMethods != null && apiSystemInfo.AuthMethods.Any()) {
                systemInfo.AuthMethods = apiSystemInfo.AuthMethods.Select(x => SettingsMapper.FromApiAuthenticationMethod(x)).Where(x => x != null).ToArray();
            }
#pragma warning restore CS0618 // Type or member is obsolete

            return systemInfo;
        }

        internal static ActiveDirectoryAuthInfo FromApiActiveDirectoryAuthInfo(ApiActiveDirectoryAuthInfo apiActiveDirectoryAuthInfo) {
            if (apiActiveDirectoryAuthInfo == null)
                return null;

            ActiveDirectoryAuthInfo activeDirectoryAuthInfo = new ActiveDirectoryAuthInfo() {
                Items = FromApiActiveDirectoryAuthInfoItems(apiActiveDirectoryAuthInfo).ToArray()
            };

            return activeDirectoryAuthInfo;
        }

        private static IEnumerable<ActiveDirectoryAuthProvider> FromApiActiveDirectoryAuthInfoItems(ApiActiveDirectoryAuthInfo apiActiveDirectoryAuthInfo) {
            if (apiActiveDirectoryAuthInfo == null || apiActiveDirectoryAuthInfo.Items == null)
                yield break;

            foreach (var item in apiActiveDirectoryAuthInfo.Items) {
                ActiveDirectoryAuthProvider activeDirectoryAuthProvider = FromApiActiveDirectory(item);
                if (activeDirectoryAuthProvider != null)
                    yield return activeDirectoryAuthProvider;
            }

            yield break;
        }

        internal static ActiveDirectoryAuthProvider FromApiActiveDirectory(ApiActiveDirectory apiActiveDirectory) {
            if (apiActiveDirectory == null) {
                return null;
            }

            ActiveDirectoryAuthProvider activeDirectoryAuthProvider = new ActiveDirectoryAuthProvider() {
                Id = apiActiveDirectory.Id,
                Name = apiActiveDirectory.Name,
                IsGlobalAvailable = apiActiveDirectory.IsGlobalAvailable
            };

            if (string.IsNullOrEmpty(activeDirectoryAuthProvider.Name))
                activeDirectoryAuthProvider.Name = apiActiveDirectory.Alias;

            return activeDirectoryAuthProvider;
        }

        internal static OpenIdAuthInfo FromApiOpenIdAuthInfo(ApiOpenIdAuthInfo apiOpenIdAuthInfo) {
            if (apiOpenIdAuthInfo == null)
                return null;

            OpenIdAuthInfo openIdAuthInfo = new OpenIdAuthInfo() {
                Items = FromApiOpenIdAuthInfoItems(apiOpenIdAuthInfo).ToArray()
            };

            return openIdAuthInfo;
        }

        private static IEnumerable<OpenIdAuthProvider> FromApiOpenIdAuthInfoItems(ApiOpenIdAuthInfo apiOpenIdAuthInfo) {
            if (apiOpenIdAuthInfo == null || apiOpenIdAuthInfo.Items == null)
                yield break;

            foreach (var item in apiOpenIdAuthInfo.Items) {
                OpenIdAuthProvider openIdAuthProvider = FromApiOpenIdProvider(item);
                if (openIdAuthProvider != null)
                    yield return openIdAuthProvider;
            }

            yield break;
        }

        internal static OpenIdAuthProvider FromApiOpenIdProvider(ApiOpenIdProvider apiOpenIdProvider) {
            if (apiOpenIdProvider == null) {
                return null;
            }

            OpenIdAuthProvider openIdAuthProvider = new OpenIdAuthProvider() {
                Id = apiOpenIdProvider.Id,
                Name = apiOpenIdProvider.Name,
                Issuer = apiOpenIdProvider.Issuer,
                MappingClaim = apiOpenIdProvider.MappingClaim,
                UserManagementUrl = apiOpenIdProvider.UserManagementUrl,
                IsGlobalAvailable = apiOpenIdProvider.IsGlobalAvailable
            };

            if (string.IsNullOrEmpty(openIdAuthProvider.Name))
                openIdAuthProvider.Name = apiOpenIdProvider.Alias;

            return openIdAuthProvider;
        }
    }
}
