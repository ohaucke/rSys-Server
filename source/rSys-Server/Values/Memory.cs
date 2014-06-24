using System.Management;
using System.Runtime.Serialization;

namespace rSysServer.Values
{
    [DataContract]
    public class Memory
    {
        [DataMember(Name = "Total", Order = 1)]
        public ulong Total { get; set; }

        [DataMember(Name = "Free", Order = 2)]
        public ulong Free { get; set; }

        [DataMember(Name = "Used", Order = 3)]
        public ulong Used { get; set; }

        public Memory()
        {
            this.Update();
        }

        public void Update()
        {
            try
            {
                using(ManagementObjectSearcher searcher = new ManagementObjectSearcher("root\\CIMV2", "SELECT TotalVisibleMemorySize, FreePhysicalMemory FROM Win32_OperatingSystem"))
                {
                    foreach(ManagementObject queryObj in searcher.Get())
                    {
                        this.Total = (ulong)queryObj["TotalVisibleMemorySize"] * 1024;
                        this.Free = (ulong)queryObj["FreePhysicalMemory"] * 1024;
                        this.Used = this.Total - this.Free;
                    }
                }
            }
            catch(ManagementException e)
            {
                throw e;
            }
        }

        public override string ToString()
        {
            return string.Format("Total: {0} - Free: {1} - Used: {2}", this.Total.ToHumanReadable(), this.Free.ToHumanReadable(), this.Used.ToHumanReadable());
        }

    }
}
