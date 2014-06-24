using System.Management;
using System.Runtime.Serialization;

namespace rSysServer.Values
{
    [DataContract]
    public class Process
    {
        [DataMember(Name = "ProcessName", Order = 1)]
        public string ProcessName { get; set; }

        [DataMember(Name = "CommandLine", Order = 2)]
        public string CommandLine { get; set; }

        [DataMember(Name = "PID", Order = 3)]
        public int Pid { get; set; }

        [DataMember(Name = "Memory", Order = 4)]
        public long Memory { get; set; }

        [DataMember(Name = "Threads", Order = 5)]
        public long Threads { get; set; }

        [DataMember(Name = "Handles", Order = 6)]
        public long Handles { get; set; }

        public Process(ManagementObject p)
        {
            this.ProcessName = p["Name"].ToString();
            this.CommandLine = (p["CommandLine"] != null ? p["CommandLine"].ToString() : "");
            this.Pid = (p["ProcessId"] != null ? int.Parse(p["ProcessId"].ToString()) : 0); // ?? 0;
            this.Memory = (p["WorkingSetSize"] != null ? long.Parse(p["WorkingSetSize"].ToString()) : 0);
            this.Threads = (p["ThreadCount"] != null ? long.Parse(p["ThreadCount"].ToString()) : 0);
            this.Handles = (p["HandleCount"] != null ? long.Parse(p["HandleCount"].ToString()) : 0);
        }

        public override string ToString()
        {
            return string.Format("PID: {0} - Name: {1} - Memory: {2}", this.Pid, this.ProcessName, this.Memory.ToHumanReadable());
        }
    }
}
