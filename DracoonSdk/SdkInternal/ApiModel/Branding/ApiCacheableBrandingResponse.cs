using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Dracoon.Sdk.SdkInternal.ApiModel {
    internal class ApiCacheableBrandingResponse {
        [JsonProperty("appearanceLoginBox", NullValueHandling = NullValueHandling.Ignore)]
        public string AppearanceLoginBox {
            get; internal set;
        }
        [JsonProperty("changedAt", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime ChangedAt {
            get; internal set;
        }
        [JsonProperty("colorizeHeader", NullValueHandling = NullValueHandling.Ignore)]
        public bool ColorizeHeader {
            get; internal set;
        }
        [JsonProperty("colors", NullValueHandling = NullValueHandling.Ignore)]
        public List<ApiColor> Colors {
            get; internal set;
        }
        [JsonProperty("createdAt", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime CreatedAt {
            get; internal set;
        }
        [JsonProperty("emailContact", NullValueHandling = NullValueHandling.Ignore)]
        public string EmailContact {
            get; internal set;
        }
        [JsonProperty("emailSender", NullValueHandling = NullValueHandling.Ignore)]
        public string EmailSender {
            get; internal set;
        }
        [JsonProperty("images", NullValueHandling = NullValueHandling.Ignore)]
        public List<ApiCacheableBrandingImageResponse> Images {
            get; internal set;
        }
        [JsonProperty("imprintUrl", NullValueHandling = NullValueHandling.Ignore)]
        public string ImprintUrl {
            get; internal set;
        }
        [JsonProperty("positionLoginBox", NullValueHandling = NullValueHandling.Ignore)]
        public int PositionLoginBox {
            get; internal set;
        }
        [JsonProperty("privacyUrl", NullValueHandling = NullValueHandling.Ignore)]
        public string PrivacyUrl {
            get; internal set;
        }
        [JsonProperty("productName", NullValueHandling = NullValueHandling.Ignore)]
        public string ProductName {
            get; internal set;
        }
        [JsonProperty("supportUrl", NullValueHandling = NullValueHandling.Ignore)]
        public string SupportUrl {
            get; internal set;
        }
        [JsonProperty("texts", NullValueHandling = NullValueHandling.Ignore)]
        public List<ApiText> Texts {
            get; internal set;
        }
    }
}
