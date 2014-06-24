using System.Diagnostics;
using System.Runtime.Serialization;

namespace rSysServer.Values
{
    [DataContract]
    public class CpuUsage
    {
        [DataMember(Name = "Name", Order = 1)]
        public string Name { get; set; }

        [DataMember(Name = "IdleTime", Order = 2)]
        public decimal IdleTime { get; set; }

        [DataMember(Name = "ProcessorTime", Order = 3)]
        public decimal ProcessorTime { get; set; }

        [DataMember(Name = "UserTime", Order = 4)]
        public decimal UserTime { get; set; }

        private string instance;
        private PerformanceCounter idleTime;
        private PerformanceCounter processorTime;
        private PerformanceCounter userTime;

        public CpuUsage(string instance)
        {
            this.Name = instance.Replace("_", "#");
            this.instance = instance;
            this.idleTime = new PerformanceCounter("Processor", "% Idle Time", this.instance);
            this.processorTime = new PerformanceCounter("Processor", "% Processor Time", this.instance);
            this.userTime = new PerformanceCounter("Processor", "% User Time", this.instance);

            this.Update();
        }

        public void Update()
        {
            this.IdleTime = (decimal)this.idleTime.NextValue();
            this.ProcessorTime = (decimal)this.processorTime.NextValue();
            this.UserTime = (decimal)this.userTime.NextValue();
        }

        public override string ToString()
        {
            return string.Format("Instance: {0} - IdleTime: {1}% - ProcessorTime: {2}% - UserTime: {3}%", this.Name.ToLower(), this.IdleTime.Round(), this.ProcessorTime.Round(), this.UserTime.Round());
        }
    }
}
