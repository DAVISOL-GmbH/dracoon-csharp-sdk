using System.Collections.Generic;
using System.Linq;
using Dracoon.Sdk.Model;
using Dracoon.Sdk.SdkInternal.ApiModel;
using Dracoon.Sdk.SdkInternal.ApiModel.Requests;

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
    }
}
