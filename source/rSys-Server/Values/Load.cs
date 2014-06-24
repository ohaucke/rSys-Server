using System.Diagnostics;
using System.Linq;
using System.Runtime.Serialization;

namespace rSysServer.Values
{
    [DataContract]
    public class Load
    {
        [DataMember(Name = "OneMinute", Order = 1)]
        public decimal OneMinute { get; set; }

        [DataMember(Name = "FiveMinutes", Order = 2)]
        public decimal FiveMinutes { get; set; }

        [DataMember(Name = "FifeteenMinutes", Order = 3)]
        public decimal FifeteenMinutes { get; set; }

        private PerformanceCounter processorTime;
        private FixedSizedQueue<decimal> values;

        public Load()
        {
            this.processorTime = new PerformanceCounter("Processor", "% Processor Time", "_Total");
            this.values = new FixedSizedQueue<decimal>(900);
            this.Update();
        }

        public void Update()
        {
            this.values.Enqueue(((decimal)this.processorTime.NextValue() / 100));
            this.OneMinute = this.values.Reverse().Take(60).Average().Round();
            this.FiveMinutes = this.values.Reverse().Take(300).Average().Round();
            this.FifeteenMinutes = this.values.Average().Round();
        }

        public override string ToString()
        {
            return string.Format("count: {0} - first five values: {1}", this.values.Count, string.Join(" | ", this.values.Take(5).Select(x => x.Round())));
        }
    }
}
