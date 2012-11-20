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
    public class APIResponse
    {
        private HttpStatusCode _statusCode;
        private string _errorMessage = string.Empty;
        private JArray _responseObject = null;
        private string _responseString = string.Empty;

        public HttpStatusCode StatusCode {
            get { return _statusCode; }
            set { _statusCode = value; }
        }
        public string ErrorMessage {
            get { return _errorMessage; }
            set { _errorMessage = value; }
        }
        public JArray ResponseObject {
            get { return _responseObject; }
            set { _responseObject = value; }
        }
        public string ResponseString {
            get { return _responseString; }
            set { _responseString = value; }
        }
    }
}
