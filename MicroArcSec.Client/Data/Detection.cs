using YamlDotNet.Serialization;

namespace MicroArcSec.Client.Data
{
    public class Detection
    {
        public Detection()
        {
            fields = new List<string>();
            FalsePositives= new List<string>();
            tags= new List<string>();
        }
        public Selection Selection { get; set; }
        public string condition { get; set; }

        public List<string> fields { get; set; }

        [YamlMember(Alias = "false_positives")]
        public List<string> FalsePositives { get; set; }

        public string level { get; set; }

        public List<string> tags { get; set; }

        public string timeframe { get; set; }
        public string window { get; set; }
    }
}
