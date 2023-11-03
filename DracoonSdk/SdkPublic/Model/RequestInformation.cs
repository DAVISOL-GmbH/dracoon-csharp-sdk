using RestSharp;

namespace Dracoon.Sdk.Model {
    public sealed class RequestInformation {

        internal RequestInformation(RestClient client, RestRequest request, RestResponse response) {
            Client = client;
            Request = request;
            Response = response;
        }

        public RestClient Client { get; private set; }

        public RestRequest Request { get; private set; }

        public RestResponse Response { get; private set; }
    }
}
