using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Management.Automation;
using System.Management.Automation.Runspaces;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClarityConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string jsonConfiguration = File.ReadAllText(@"C:\github\ClarityConsole\ClarityConsole\TempFile.json");
                List<PsTasks> obj = JsonConvert.DeserializeObject<List<PsTasks>>(jsonConfiguration);


            }
            catch (Exception ex)
            {


            }
        }

        public void RunScript(string scriptPath, Task task)
        {
            PowerShell psinstance = PowerShell.Create();

            psinstance.AddCommand(scriptPath);

            foreach (var item in task.Params)
            {
                psinstance.AddParameter(item.PSParamName, item.Value);
            }

            PSDataCollection<PSObject> output = new PSDataCollection<PSObject>();

        }
    }

    public class Param
    {
        public string key { get; set; }
        public string PSParamName { get; set; }
        public string Value { get; set; }
        public string Type { get; set; }
    }

    public class Task
    {
        public string Id { get; set; }
        public string Powershell { get; set; }
        public List<Param> Params { get; set; }
    }

    public class PsTasks
    {
        public string Id { get; set; }
        public List<Task> Tasks { get; set; }
    }
}
