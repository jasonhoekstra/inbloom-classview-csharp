using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Net;

namespace SLCApiLibrary
{
    class ExtendedWebClient : WebClient
    {
        private WebRequest _Request = null;
        private HttpStatusCode _statusCode;

        public HttpStatusCode StatusCode {
            get { return _statusCode; }
        }

        protected override WebRequest GetWebRequest(Uri address) {
            this._Request = base.GetWebRequest(address);

            if (this._Request is HttpWebRequest) {
                ((HttpWebRequest)this._Request).AllowAutoRedirect = false;
            }

            //try {
            //    HttpWebResponse response = base.GetWebResponse(this._Request) as HttpWebResponse;
            //    if (response != null) {
            //        _statusCode = response.StatusCode;
            //    }
            //} catch (HttpListenerException ex) {
            //    throw ex;
            //}



            return this._Request;
        }

    }
}
