﻿using Dracoon.Sdk.Model;
using Dracoon.Sdk.SdkInternal.ApiModel;

namespace Dracoon.Sdk.UnitTest.Factory {
    internal static class FactoryCustomer {
        internal static CustomerAccount CustomerAccount {
            get {
                return new CustomerAccount {
                    Id = 34576,
                    Name = "Customer1",
                    AccountsUsed = 10,
                    AccountsLimit = 25,
                    SpaceUsed = 364345,
                    SpaceLimit = 3654637324,
                    CountRooms = 4,
                    CountFolders = 56,
                    CountFiles = 567,
                    HasEncryptionEnabled = true
                };
            }
        }

        internal static ApiCustomerAccount ApiCustomerAccount {
            get {
                return new ApiCustomerAccount {
                    Id = 34576,
                    Name = "Customer1",
                    AccountsUsed = 10,
                    AccountsLimit = 25,
                    SpaceUsed = 364345,
                    SpaceLimit = 3654637324,
                    CountRooms = 4,
                    CountFolders = 56,
                    CountFiles = 567,
                    IsProviderCustomer = true
                };
            }
        }
    }
}