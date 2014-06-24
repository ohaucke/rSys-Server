using System.Diagnostics;
using System.Runtime.Serialization;

namespace rSysServer.Values
{
    [DataContract]
    public class PhysicalDisk
    {
        [DataMember(Name = "Name", Order = 1)]
        public string Name { get; set; }

        [DataMember(Name = "BytesReadPerSec", Order = 2)]
        public ulong BytesReadPerSec { get; set; }

        [DataMember(Name = "BytesWritePerSec", Order = 3)]
        public ulong BytesWritePerSec { get; set; }

        private string instance;
        private PerformanceCounter read;
        private PerformanceCounter write;

        public PhysicalDisk(string instance)
        {
            this.Name = instance.Replace("_", "#");
            this.instance = instance;
            this.read = new PerformanceCounter("PhysicalDisk", "Disk Read Bytes/sec", this.instance);
            this.write = new PerformanceCounter("PhysicalDisk", "Disk Write Bytes/sec", this.instance);

            this.Update();
        }

        public void Update()
        {
            this.BytesReadPerSec = (ulong)this.read.NextValue();
            this.BytesWritePerSec = (ulong)this.write.NextValue();
        }

        public override string ToString()
        {
            return string.Format("Instance: {0} - Read: {1} - Write: {2}", this.Name.ToLower(), this.BytesReadPerSec.ToHumanReadable(), this.BytesWritePerSec.ToHumanReadable());
        }
    }
}
