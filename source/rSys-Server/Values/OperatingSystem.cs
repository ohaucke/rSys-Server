using System.Management;
using System.Runtime.Serialization;

namespace rSysServer.Values
{
    [DataContract]
    public class OperatingSystem
    {
        [DataMember(Name = "Name", Order = 1)]
        public string Name { get; set; }

        [DataMember(Name = "Architecture", Order = 2)]
        public string Architecture { get; set; }

        [DataMember(Name = "ServicePack", Order = 3)]
        public string ServicePack { get; set; }

        public OperatingSystem()
        {
            try
            {
                using (ManagementObjectSearcher searcher = new ManagementObjectSearcher("root\\CIMV2", "SELECT Caption, OSArchitecture, CSDVersion FROM Win32_OperatingSystem"))
                {
                    foreach (ManagementObject queryObj in searcher.Get())
                    {
                        if (queryObj != null)
                        {
                            this.Name = (queryObj["Caption"] == null ? "" : queryObj["Caption"].ToString());
                            this.Architecture = (queryObj["OSArchitecture"] == null ? "" : queryObj["OSArchitecture"].ToString());
                            this.ServicePack = (queryObj["CSDVersion"] == null ? "" : queryObj["CSDVersion"].ToString());
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
            return string.Format("OS: {0} {1} {2}", this.Name, this.Architecture, this.ServicePack);
        }
    }
}
