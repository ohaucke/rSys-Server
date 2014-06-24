using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Runtime.Serialization;

namespace rSysServer.Values
{
    [DataContract]
    public class Processes
    {
        [DataMember(Name = "Count", Order = 1)]
        public int Count { get; set; }

        [DataMember(Name = "Threads", Order = 2)]
        public long Threads { get; set; }

        [DataMember(Name = "Handles", Order = 3)]
        public long Handles { get; set; }

        [DataMember(Name = "Processes", Order = 3)]
        public List<Process> AllProcesses { get; set; }

        public Processes()
        {
            this.AllProcesses = new List<Process>();

            this.Update();
        }

        public void Update()
        {
            List<Process> lp = new List<Process>();
            try
            {
                using (ManagementObjectSearcher searcher = new ManagementObjectSearcher("root\\CIMV2", "SELECT Name, CommandLine, ProcessId, WorkingSetSize, ThreadCount, HandleCount FROM Win32_Process"))
                {
                    foreach (ManagementObject queryObj in searcher.Get())
                    {
                        if (queryObj != null)
                        {
                            lp.Add(new Process(queryObj));
                        }
                    }
                }
            }
            catch (ManagementException e)
            {
                throw e;
            }
            this.AllProcesses = lp.OrderBy(x => x.Pid).ToList();
            this.Count = this.AllProcesses.Count;
            this.Threads = this.AllProcesses.Sum(x => x.Threads);
            this.Handles = this.AllProcesses.Sum(x => x.Handles);
        }

        public override string ToString()
        {
            return string.Format("Count: {0} - Threads: {1} - Handles: {2}", this.Count, this.Threads, this.Handles);
        }
    }
}
