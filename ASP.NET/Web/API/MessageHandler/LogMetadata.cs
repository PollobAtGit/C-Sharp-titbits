using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace API.MessageHandler
{
    public class LogMetadata
    {
        public string RequestAcceptType { get; set; }
        public string RequestUri { get; set; }
        public string RequestMethod { get; set; }
        public DateTime? RequestTimeStamp { get; set; }
        public string ResponseContentType { get; set; }
        public HttpStatusCode ResponseStatusCode { get; set; }
        public DateTime? ResponseTimeStamp { get; set; }
        public string ResponseBodyContent { get; set; }

        public override string ToString() =>
            $@" => { RequestAcceptType }
                    | { RequestUri }
                    | { RequestMethod }
                    | { RequestTimeStamp.GetValueOrDefault().ToLocalTime() }
                    | { ResponseContentType }
                    | { ResponseStatusCode.ToString() }
                    | { ResponseTimeStamp.GetValueOrDefault().ToString() }
                    | { ResponseBodyContent }";
    }
}