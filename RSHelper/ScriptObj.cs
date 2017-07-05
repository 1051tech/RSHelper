using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RSHelperUI
{
    public class ScriptObj
    {
        private string filePath;

        public List<string> Code;
        public readonly Guid UID;

        public string Author { get; set; }
        public string Name { get; set; }
        public string Version { get; set; }

        public ScriptObj(string file)
        {
            UID = Guid.NewGuid();
            filePath = file;
            Code = File.ReadAllLines(file).ToList();
            var result = Parallel.ForEach(this.GetType()
                .GetProperties(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance), (prop) => ParseValue(prop.Name));
            while (!result.IsCompleted)
                Thread.Sleep(20);
        }

        public string GetCode()
        {
            var temp = "";
            foreach (var line in Code)
                temp += line + "\n";
            return temp;
        }

        private void ParseValue(string key)
        {
            var result = Parallel.ForEach(Code, (line) =>
            {
                if (!line.Contains($"///<{key.ToLower()}>"))
                    return;

                var bIndex = line.IndexOf($"<{key.ToLower()}>") + ($"{key.ToLower()}> ".Count());
                var eIndex = line.IndexOf($"</{key.ToLower()}>");
                var value = line.Substring(bIndex, eIndex - bIndex);
                this.GetType().GetProperty(key).SetValue(this, value);
            });
        }
    }
}
