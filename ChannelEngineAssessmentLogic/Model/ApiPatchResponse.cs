using System.Collections.Generic;
using System.Net;

namespace ChannelEngineAssessmentLogic.Model
{
    public class ApiPatchResponse
    {
        public int RejectedCount { get; set; }
        public int AcceptedCount { get; set; }
        public IEnumerable<ProductMessage> ProductMessages { get; set; }
        public int LogId { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; }
        public Dictionary<string, List<string>> ValidationErrors { get; set; }
        public HttpStatusCode StatusCode { get; set; }
    }
}
