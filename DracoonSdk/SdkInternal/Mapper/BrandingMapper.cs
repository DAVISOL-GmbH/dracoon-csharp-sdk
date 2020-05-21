using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Dracoon.Sdk.Model;
using Dracoon.Sdk.SdkInternal.ApiModel;

namespace Dracoon.Sdk.SdkInternal.Mapper {
    internal static class BrandingMapper {

        internal static CacheableBrandingResponse FromApiCacheableBrandingResponse(ApiCacheableBrandingResponse apiCacheableBrandingResponse) {
            CacheableBrandingResponse cacheableBrandingResponse = new CacheableBrandingResponse() {
                AppearanceLoginBox = apiCacheableBrandingResponse.AppearanceLoginBox,
                ChangedAt = apiCacheableBrandingResponse.ChangedAt,
                ColorizeHeader = apiCacheableBrandingResponse.ColorizeHeader,
                Colors = FromApiColors(apiCacheableBrandingResponse.Colors).ToArray(),
                CreatedAt = apiCacheableBrandingResponse.CreatedAt,
                EmailContact = apiCacheableBrandingResponse.EmailContact,
                EmailSender = apiCacheableBrandingResponse.EmailSender,
                Images = FromApiSimpleImageResponses(apiCacheableBrandingResponse.Images).ToArray(),
                ImprintUrl = apiCacheableBrandingResponse.ImprintUrl,
                PositionLoginBox = apiCacheableBrandingResponse.PositionLoginBox,
                PrivacyUrl = apiCacheableBrandingResponse.PrivacyUrl,
                ProductName = apiCacheableBrandingResponse.ProductName,
                SupportUrl = apiCacheableBrandingResponse.SupportUrl,
                Texts = FromApiTexts(apiCacheableBrandingResponse.Texts).ToArray()
            };
            return cacheableBrandingResponse;

        }

        internal static UpdateBrandingResponse FromApiUpdateBrandingResponse(ApiUpdateBrandingResponse apiUpdateBrandingResponse) {

            UpdateBrandingResponse updateBrandingResponse = new UpdateBrandingResponse() {
                AppearanceLoginBox = apiUpdateBrandingResponse.AppearanceLoginBox,
                ColorizeHeader = apiUpdateBrandingResponse.ColorizeHeader,
                Colors = FromApiColors(apiUpdateBrandingResponse.Colors).ToArray(),
                EmailContact = apiUpdateBrandingResponse.EmailContact,
                EmailSender = apiUpdateBrandingResponse.EmailSender,
                Images = FromApiSimpleImageResponses(apiUpdateBrandingResponse.Images).ToArray(),
                ImprintUrl = apiUpdateBrandingResponse.ImprintUrl,
                PositionLoginBox = apiUpdateBrandingResponse.PositionLoginBox,
                PrivacyUrl = apiUpdateBrandingResponse.PrivacyUrl,
                ProductName = apiUpdateBrandingResponse.ProductName,
                SupportUrl = apiUpdateBrandingResponse.SupportUrl,
                Texts = FromApiTexts(apiUpdateBrandingResponse.Texts).ToArray()
            };
            return updateBrandingResponse;
        }

        private static IEnumerable<Color> FromApiColors(IEnumerable<ApiColor> apiColors) {
            if (apiColors == null)
                yield break;

            foreach (ApiColor apiColor in apiColors) {
                Color color = new Color() {
                    ColorDetails = FromApiColorDetails(apiColor.ColorDetails).ToArray(),
                    Type = apiColor.Type
                };
                yield return color;
            }
        }

        private static IEnumerable<ColorDetails> FromApiColorDetails(IEnumerable<ApiColorDetails> apiColorDetails) {
            if (apiColorDetails == null)
                yield break;

            foreach (ApiColorDetails apiColorDetailsItem in apiColorDetails) {
                ColorDetails colorDetails = new ColorDetails() {
                    Rgba = apiColorDetailsItem.Rgba,
                    Type = apiColorDetailsItem.Type
                };
                yield return colorDetails;
            }
        }

        private static IEnumerable<SimpleImageResponse> FromApiSimpleImageResponses(IEnumerable<ApiSimpleImageResponse> apiSimpleImageResponses) {
            if (apiSimpleImageResponses == null)
                yield break;

            foreach (ApiSimpleImageResponse apiSimpleImageResponse in apiSimpleImageResponses) {
                SimpleImageResponse simpleImageResponse = new SimpleImageResponse() {
                    Type = apiSimpleImageResponse.Type,
                    Files = FromApiImageFileReponse(apiSimpleImageResponse.Files).ToArray()
                };
                yield return simpleImageResponse;
            }
        }

        private static IEnumerable<ImageFileResponse> FromApiImageFileReponse(IEnumerable<ApiImageFileResponse> apiImageFileResponses) {
            if (apiImageFileResponses == null)
                yield break;

            foreach (ApiImageFileResponse apiImageFileResponse in apiImageFileResponses) {
                ImageFileResponse imageFileResponse = new ImageFileResponse() {
                    Size = apiImageFileResponse.Size,
                    Url = apiImageFileResponse.Url
                };
                yield return imageFileResponse;
            }
        }

        private static IEnumerable<Text> FromApiTexts(IEnumerable<ApiText> apiTexts) {
            if (apiTexts == null)
                yield break;

            foreach (ApiText apiText in apiTexts) {
                Text text = new Text() {
                    Languages = FromApiLanguages(apiText.Languages).ToArray(),
                    Type = apiText.Type
                };
                yield return text;
            }
        }

        private static IEnumerable<Language> FromApiLanguages(IEnumerable<ApiLanguage> apiLanguages) {
            if (apiLanguages == null)
                yield break;

            foreach (ApiLanguage apiLanguage in apiLanguages) {
                Language language = new Language() {
                    Content = apiLanguage.Content,
                    LanguageTag = string.IsNullOrEmpty(apiLanguage.LanguageTag) ? CultureInfo.InvariantCulture : CultureInfo.GetCultureInfo(apiLanguage.LanguageTag)
                };
                yield return language;
            }
        }

        internal static SoftwareVersionData FromApiSoftwareVersionData(ApiSoftwareVersionData apiSoftwareVersionData) {
            SoftwareVersionData softwareVersionData = new SoftwareVersionData() {
                BuildTimestamp = apiSoftwareVersionData.BuildTimestamp,
                Version = apiSoftwareVersionData.Version
            };
            return softwareVersionData;
        }
    }
}
