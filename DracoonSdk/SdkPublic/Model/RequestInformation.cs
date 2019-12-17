using RestSharp;

namespace Dracoon.Sdk.SdkPublic.Model {
    public sealed class RequestInformation {

        internal RequestInformation(RestClient client, RestRequest request, IRestResponse response) {
            Client = client;
            Request = request;
            Response = response;
        }

        public RestClient Client { get; private set; }

        public RestRequest Request { get; private set; }

        public IRestResponse Response { get; private set; }
    }
}
