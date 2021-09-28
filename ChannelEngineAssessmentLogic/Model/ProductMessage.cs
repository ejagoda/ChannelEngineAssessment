using System.Collections.Generic;

namespace ChannelEngineAssessmentLogic.Model
{
    public class ProductMessage
    {
        public string Name { get; set; }
        public string Reference { get; set; }
        public IEnumerable<string> Warnings { get; set; }
        public IEnumerable<string> Errors { get; set; }

    }
}
