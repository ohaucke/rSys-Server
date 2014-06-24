using System;
using System.Runtime.Serialization;

namespace rSysServer.Values
{
    [DataContract]
    public class SystemInformations
    {
        [DataMember(Name = "Hostname", Order = 1)]
        public string Hostname { get; set; }

        [DataMember(Name = "Now", Order = 2)]
        public string Now { get; set; }

        [DataMember(Name = "UpTime", Order = 3)]
        public string UpTime { get; set; }

        [DataMember(Name = "OperatingSystem", Order = 4)]
        public OperatingSystem OperatingSystem { get; set; }

        [DataMember(Name = "Cpu", Order = 5)]
        public Cpu Cpu { get; set; }

        public SystemInformations()
        {
            this.Hostname = System.Environment.MachineName;
            this.OperatingSystem = new OperatingSystem();
            this.Cpu = new Cpu();

            this.Update();
        }

        public void Update()
        {
            this.Now = DateTime.Now.ToUniversalTime().ToString("yyyy\\-MM\\-dd\\THH\\:mm\\:ss\\.fff\\Z");
            this.UpTime = TimeSpan.FromMilliseconds(System.Environment.TickCount).ToString("d\\:hh\\:mm\\:ss");
        }

        public override string ToString()
        {
            return string.Format("Hostname: {0} - Now: {1} - UpTime: {2} - {3} - {4}", this.Hostname, this.Now, this.UpTime, this.OperatingSystem, this.Cpu);
        }
    }
}
