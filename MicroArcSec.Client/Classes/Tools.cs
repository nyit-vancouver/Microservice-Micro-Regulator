using MicroArcSec.Client.Data;
using YamlDotNet.Serialization.NamingConventions;
using YamlDotNet.Serialization;

namespace MicroArcSec.Client.Classes
{
    public static class Tools
    {
        public static async Task<List<SigmaRuleModel>> GetAllRules()
        {
            var rules = new List<SigmaRuleModel>();

            string directoryPath = @"./Files/";
            string[] fileEntries = Directory.GetFiles(directoryPath);
            fileEntries = fileEntries.OrderByDescending(f => Path.GetFileName(f)).ToArray();

            foreach (string fileName in fileEntries)
            {
                var yaml = await File.ReadAllTextAsync(fileName);
                var deserializer = new DeserializerBuilder()
                    .WithNamingConvention(UnderscoredNamingConvention.Instance)
                    .Build();
                try
                {
                    var rule = deserializer.Deserialize<SigmaRuleModel>(yaml);
                    rule.fileName = fileName.Replace("./Files/", "").Replace(".yaml", "");
                    rules.Add(rule);
                }
                catch (Exception ex)
                {

                    throw;
                }
            }

            return rules;
        }

        public static SigmaRuleModel GetRuleByName(string fileName)
        {
            var yaml = File.ReadAllText(@"./Files/" + fileName + ".yaml");
            var deserializer = new DeserializerBuilder()
                .WithNamingConvention(UnderscoredNamingConvention.Instance)
                .Build();
            try
            {
                var rule = deserializer.Deserialize<SigmaRuleModel>(yaml);
                rule.fileName = fileName;
                return rule;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
