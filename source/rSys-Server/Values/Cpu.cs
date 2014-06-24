using System.Management;
using System.Runtime.Serialization;

namespace rSysServer.Values
{
    [DataContract]
    public class Cpu
    {
        [DataMember(Name = "Name", Order = 1)]
        public string Name { get; set; }

        [DataMember(Name = "NumberOfCores", Order = 2)]
        public int NumberOfCores { get; set; }

        [DataMember(Name = "NumberOfLogicalProcessors", Order = 3)]
        public int NumberOfLogicalProcessors { get; set; }

        [DataMember(Name = "L2CacheSize", Order = 4)]
        public int L2CacheSize { get; set; }

        [DataMember(Name = "L3CacheSize", Order = 5)]
        public int L3CacheSize { get; set; }

        [DataMember(Name = "VirtualizationFirmwareEnabled", Order = 6)]
        public bool VirtualizationFirmwareEnabled { get; set; }

        public Cpu()
        {
            try
            {
                using (ManagementObjectSearcher searcher = new ManagementObjectSearcher("root\\CIMV2", "SELECT Name, NumberOfCores, NumberOfLogicalProcessors, L2CacheSize, L3CacheSize, VirtualizationFirmwareEnabled FROM Win32_Processor"))
                {
                    foreach (ManagementObject queryObj in searcher.Get())
                    {
                        if (queryObj != null)
                        {
                            this.Name = (queryObj["Name"] == null ? "" : queryObj["Name"].ToString());
                            this.NumberOfCores = (queryObj["NumberOfCores"] == null ? 0 : int.Parse(queryObj["NumberOfCores"].ToString()));
                            this.NumberOfLogicalProcessors = (queryObj["NumberOfLogicalProcessors"] == null ? 0 : int.Parse(queryObj["NumberOfLogicalProcessors"].ToString()));
                            this.L2CacheSize = (queryObj["L2CacheSize"] == null ? 0 : int.Parse(queryObj["L2CacheSize"].ToString()));
                            this.L3CacheSize = (queryObj["L3CacheSize"] == null ? 0 : int.Parse(queryObj["L3CacheSize"].ToString()));
                            this.VirtualizationFirmwareEnabled = (queryObj["VirtualizationFirmwareEnabled"] == null ? false : bool.Parse(queryObj["VirtualizationFirmwareEnabled"].ToString()));
                        }
                    }
                }
            }
            catch (ManagementException e)
            {
                throw e;
            }
        }

        public override string ToString()
        {
            return string.Format("Name: {0} (Cores: {1}/{2})", this.Name, this.NumberOfCores, this.NumberOfLogicalProcessors);
        }
    }
}
