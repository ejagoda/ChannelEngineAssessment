using System.Collections.Generic;
using System.Net;

namespace ChannelEngineAssessmentLogic.Model
{
    public class ApiGetResponse
    {
        public int Count { get; set; }
        public int TotalCount { get; set; }
        public int ItemsPerPage { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; }
        public Dictionary<string, List<string>> ValidationErrors { get; set; }
        public string Content { get ; set ; }
        public HttpStatusCode StatusCode { get ; set ; }

    }
}
