using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace ChannelEngineAssessmentLogic.Model
{
    public class PatchRequest<T>
    {
        public T value { get; set; }
        public string path { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public PatchOperation op { get; set; }
    }
}
