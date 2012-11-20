using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Net;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace SLCApiLibrary
{
    public class APIClient
    {
        public static APIResponse Request(string apiEndpoint, string accessToken, RequestType requestType = RequestType.JSONObject) {
            APIResponse apiResponse = new APIResponse();
            ExtendedWebClient restClient = new ExtendedWebClient();
            string slcResponse = string.Empty;
            JArray studentJArray = null;

            string bearerToken = string.Format("bearer {0}", accessToken);

            restClient.Headers.Add("Authorization", bearerToken);

            if (requestType == RequestType.XML) {
                restClient.Headers.Add("Content-Type", "application/vnd.slc+json");
                restClient.Headers.Add("Accept", "application/vnd.slc+xml");
            } else {
                restClient.Headers.Add("Content-Type", "application/vnd.slc+json");
                restClient.Headers.Add("Accept", "application/vnd.slc+json");
            }

            try {
                slcResponse = restClient.DownloadString(apiEndpoint);

                if (slcResponse.Substring(0,1) == "[") {
                     //studentJArray = String.Format("{{" + :{0}}}", slcResponse);
                } else if (slcResponse.Substring(0,1) =="{") {
                    //studentJArray = String.Format("{{arrayObject:[{0}]}}", slcResponse);
                }


                if (slcResponse != string.Empty) {
                    switch (requestType) {
                        case RequestType.JSONObject:
                            JArray jsonResponse = JArray.Parse(slcResponse);    
                            apiResponse.ResponseObject = jsonResponse;
                            break;
                        case RequestType.JSON:
                        case RequestType.XML:
                            apiResponse.ResponseString = slcResponse;
                            break;
                    }
                }
            } catch (Exception ex) {
                apiResponse.ErrorMessage = ex.Message;
                throw ex;
            }

            apiResponse.StatusCode = restClient.StatusCode;

            return apiResponse;
        }

    }
}
