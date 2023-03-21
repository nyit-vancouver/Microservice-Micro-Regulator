namespace MicroArcSec.Client.Data
{
    public class Selection
    {
        public Selection()
        {
            curi = new List<string>();
            cmd = new List<string>();
            ip = new List<string>();
        }
        public List<string> curi { get; set; }
        public List<string> cmd { get; set; }
        public List<string> ip { get; set; }
    }
}
