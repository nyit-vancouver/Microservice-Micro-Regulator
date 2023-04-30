using AntDesign;
using AntDesign.Charts;
using YamlDotNet.Serialization;

namespace MicroArcSec.Client.Data
{
    public class SigmaRuleModel
    {
        public string fileName { get; set; }
        public string title { get; set; }
        public string id { get; set; }
        public RelatedSigmaRule related { get; set; }
        public string status { get; set; }
        public string description { get; set; }
        public string author { get; set; }
        public string references { get; set; }
        public SigmaLogSource logsource { get; set; }
        public Detection detection { get; set; }
        public string fields { get; set; }
        public string falsepositives { get; set; }
        public string level { get; set; }
        public string tags { get; set; }
        public DateTime? date { get; set; }
    }
}
