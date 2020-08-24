using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Dracoon.Sdk.Error;
using Dracoon.Sdk.Model;
using Dracoon.Sdk.SdkInternal.ApiModel;
using Dracoon.Sdk.SdkInternal.Util;

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
                MediaServerEnabled = apiGeneralConfig.MediaServerEnabled,
                SharePasswordSmsEnabled = apiGeneralConfig.SharePasswordSmsEnabled,
                UseS3Storage = apiGeneralConfig.UseS3Storage,
                WeakPasswordEnabled = apiGeneralConfig.WeakPasswordEnabled,
                S3TagsEnabled = apiGeneralConfig.S3TagsEnabled,
                HideLoginInputFields = apiGeneralConfig.HideLoginInputFields,
                AuthTokenRestrictions = FromApiAuthTokenRestrictions(apiGeneralConfig.AuthTokenRestrictions)
            };
            return general;
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

        internal static PasswordPolicies FromApiPasswordPolicies(ApiPasswordSettings apiPolicies) {
            if (apiPolicies == null) {
                return null;
            }

            PasswordPolicies policies = new PasswordPolicies {
                EncryptionPolicies = FromApiPasswordEncryptionPolicies(apiPolicies.EncryptionPasswordSettings),
                LoginPolicies = FromApiPasswordLoginPolicies(apiPolicies.LoginPasswordSettings),
                SharePolicies = FromApiPasswordSharePolicies(apiPolicies.SharePasswordSettings)
            };
            return policies;
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

        internal static PasswordLoginPolicies FromApiPasswordLoginPolicies(ApiLoginPasswordSettings apiPolicies) {
            if (apiPolicies == null) {
                return null;
            }

            PasswordLoginPolicies policies = new PasswordLoginPolicies {
                CharacterPolicies = FromApiPasswordCharacterPolicies(apiPolicies.CharacterRules),
                MinimumPasswordLength = apiPolicies.MinimumPasswordLength,
                RejectDictionaryWords = apiPolicies.RejectDictionaryWords,
                RejectKeyboardPatterns = apiPolicies.RejectKeyboardPatterns,
                RejectOwnUserInfo = apiPolicies.RejectUserInfo,
                NumberOfArchivedPasswords = apiPolicies.NumberOfArchivedPasswords,
                UpdatedAt = apiPolicies.UpdatedAt,
                UpdatedBy = UserMapper.FromApiUserInfo(apiPolicies.UpdatedBy),
                LoginFailurePolicies = FromApiPasswordLoginFailurePolicies(apiPolicies.UserLockoutRules),
                PasswordExpirationPolicies = FromApiPasswordExpirationPolicies(apiPolicies.PasswordExpirationRules)
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

        internal static PasswordExpiration FromApiPasswordExpirationPolicies(ApiPasswordExpiration apiPolicies) {
            if (apiPolicies == null) {
                return null;
            }

            PasswordExpiration policies = new PasswordExpiration {
                IsEnabled = apiPolicies.ExpirationIsEnabled,
                ExpiresAfterDays = apiPolicies.MaximumPasswordAgeInDays
            };
            return null;
        }

        internal static PasswordLoginFailurePolicies FromApiPasswordLoginFailurePolicies(ApiUserLockout apiPolicies) {
            if (apiPolicies == null) {
                return null;
            }

            PasswordLoginFailurePolicies policies = new PasswordLoginFailurePolicies {
                IsEnabled = apiPolicies.Enabled,
                LoginRetryPeriodMinutes = apiPolicies.MinutesToNextLoginAttempt,
                MaximumNumberOfLoginFailures = apiPolicies.MaximumLoginFailureAttempts
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

        internal static ServerAuthenticationSettings FromApiAuthenticationSettings(ApiAuthenticationSettings apiAuthenticationConfig) {
            if (apiAuthenticationConfig == null) {
                return null;
            }
            var authMethods = Enumerable.Empty<ServerAuthenticationMethod>();
            if (apiAuthenticationConfig.AuthMethods != null) {
                authMethods = apiAuthenticationConfig.AuthMethods.Select(x => FromApiAuthenticationMethod(x)).Where(x => x != null);
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

        internal static OpenIdIdpConfigList FromApiOpenIdIpdConfigs(IEnumerable<ApiOpenIdIdpConfig> apiOpenIdIdpConfigs) {
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

        internal static RadiusConfig FromApiRadiusConfig(ApiRadiusConfig apiRadiusConfig) {
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
    }
}
