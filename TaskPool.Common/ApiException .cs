using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace TaskPool.Common
{
    public class ApiException : Exception
    {

        public HttpStatusCode StatusCode { get; set; }
        public string Error { get; set; }
        public object Response { get; set; }

        public ApiException(HttpStatusCode code, string error, object response) : base(error)
        {
            StatusCode = code;
            Error = error;
            Response = response;
        }

    }
}
