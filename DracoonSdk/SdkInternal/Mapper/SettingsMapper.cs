using System;
using System.Linq;
using Dracoon.Sdk.Model;
using Dracoon.Sdk.SdkInternal.ApiModel;

namespace Dracoon.Sdk.SdkInternal.Mapper {
    internal static class SettingsMapper {
        internal static ServerGeneralSettings FromApiGeneralSettings(ApiGeneralSettings apiGeneralConfig) {
            if (apiGeneralConfig == null) {
                return null;
            }
            ServerGeneralSettings general = new ServerGeneralSettings() {
                CryptoEnabled = apiGeneralConfig.CryptoEnabled,
                EmailNotificationButtonEnabled = apiGeneralConfig.EmailNotificationButtonEnabled,
                EulaEnabled = apiGeneralConfig.EulaEnabled,
                MediaServerEnabled = apiGeneralConfig.MediaServerEnabled,
                SharePasswordSmsEnabled = apiGeneralConfig.SharePasswordSmsEnabled,
                UseS3Storage = apiGeneralConfig.UseS3Storage,
                WeakPasswordEnabled = apiGeneralConfig.WeakPasswordEnabled
            };
            return general;
        }

        internal static ServerInfrastructureSettings FromApiInfrastructureSettings(ApiInfrastructureSettings apiInfrastructureConfig) {
            if (apiInfrastructureConfig == null) {
                return null;
            }
            ServerInfrastructureSettings infrastructure = new ServerInfrastructureSettings() {
                MediaServerConfigEnabled = apiInfrastructureConfig.MediaServerConfigEnabled,
                S3DefaultRegion = apiInfrastructureConfig.S3DefaultRegion,
                SmsConfigEnabled = apiInfrastructureConfig.SmsConfigEnabled
            };
            return infrastructure;
        }

        internal static ServerDefaultSettings FromApiDefaultsSettings(ApiDefaultsSettings apiDefaultsConfig) {
            if (apiDefaultsConfig == null) {
                return null;
            }
            ServerDefaultSettings defaults = new ServerDefaultSettings() {
                LanguageDefault = apiDefaultsConfig.LanguageDefault,
                DownloadShareDefaultExpirationPeriodInDays = apiDefaultsConfig.DownloadShareDefaultExpirationPeriodInDays,
                FileUploadDefaultExpirationPeriodInDays = apiDefaultsConfig.FileUploadDefaultExpirationPeriodInDays,
                UploadShareDefaultExpirationPeriodInDays = apiDefaultsConfig.UploadShareDefaultExpirationPeriodInDays
            };
            return defaults;
        }

        internal static ServerAuthenticationSettings FromApiAuthenticationSettings(ApiAuthenticationSettings apiAuthenticationConfig, ILog log) {
            var LOGTAG = nameof(SettingsMapper);
            if (apiAuthenticationConfig == null) {
                log.Warn(LOGTAG, "Api auth config model is null.");
                return null;
            }
            var authMethods = Enumerable.Empty<ServerAuthenticationMethod>();
            if (apiAuthenticationConfig.AuthMethods != null) {
                log.Info(LOGTAG, $"Api auth config model item enumeration has {apiAuthenticationConfig.AuthMethods.Count} items.");
                authMethods = apiAuthenticationConfig.AuthMethods.Select(x => FromApiAuthenticationMethod(x)).Where(x => x != null);
            } else {
                log.Warn(LOGTAG, "Api auth config model item enumeration is empty.");
            }
            ServerAuthenticationSettings authentication = new ServerAuthenticationSettings() {
                AuthMethods = authMethods.ToArray()
            };
            return authentication;
        }

        internal static ServerAuthenticationMethod FromApiAuthenticationMethod(ApiAuthenticationMethod apiAuthenticationMethod) {
            if (apiAuthenticationMethod == null || string.IsNullOrEmpty(apiAuthenticationMethod.Name)) {
                return null;
            }
            var authMethodType = AuthMethodType.BasicOrSql;
            if (string.Compare(apiAuthenticationMethod.Name, "active_directory", StringComparison.OrdinalIgnoreCase) == 0)
                authMethodType = AuthMethodType.ActiveDirectory;
            else if (string.Compare(apiAuthenticationMethod.Name, "radius", StringComparison.OrdinalIgnoreCase) == 0)
                authMethodType = AuthMethodType.Radius;
            else if (string.Compare(apiAuthenticationMethod.Name, "openid", StringComparison.OrdinalIgnoreCase) == 0)
                authMethodType = AuthMethodType.OpenId;
            //else if (string.Compare(apiAuthenticationMethod.Name, "basic", StringComparison.OrdinalIgnoreCase) != 0 && string.Compare(apiAuthenticationMethod.Name, "sql", StringComparison.OrdinalIgnoreCase) != 0)
            //    return null;

            ServerAuthenticationMethod authMethod = new ServerAuthenticationMethod() {
                AuthMethod = authMethodType,
                IsEnabled = apiAuthenticationMethod.IsEnabled,
                Priority = apiAuthenticationMethod.Priority
            };
            return authMethod;
        }

    }
}
