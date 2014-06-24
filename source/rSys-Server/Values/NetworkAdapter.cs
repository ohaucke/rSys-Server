using System.Diagnostics;
using System.Net.NetworkInformation;
using System.Runtime.Serialization;
using System.Linq;

namespace rSysServer.Values
{
    [DataContract]
    public class NetworkAdapter
    {
        [DataMember(Name = "Name", Order = 1)]
        public string Name { get; set; }

        [DataMember(Name = "CurrentBandwidth", Order = 2)]
        public ulong CurrentBandwidth { get; set; }

        [DataMember(Name = "BytesSentPerSec", Order = 3)]
        public ulong BytesSentPerSec { get; set; }

        [DataMember(Name = "BytesReceivedPerSec", Order = 4)]
        public ulong BytesReceivedPerSec { get; set; }

        [DataMember(Name = "BytesTotalPerSec", Order = 5)]
        public ulong BytesTotalPerSec { get; set; }

        [DataMember(Name = "BytesTotalSent", Order = 6)]
        public ulong BytesTotalSent { get; set; }

        [DataMember(Name = "BytesTotalReceived", Order = 7)]
        public ulong BytesTotalReceived { get; set; }

        [DataMember(Name = "PacketsSendPerSec", Order = 8)]
        public ulong PacketsSendPerSec { get; set; }

        [DataMember(Name = "PacketsReceivedPerSec", Order = 9)]
        public ulong PacketsReceivedPerSec { get; set; }

        [DataMember(Name = "PacketsTotalPerSec", Order = 10)]
        public ulong PacketsTotalPerSec { get; set; }

        private string instance;
        private NetworkInterface networkInterface;
        private PerformanceCounter currentBandwidth;
        private PerformanceCounter bytesSentPerSec;
        private PerformanceCounter bytesReceivedPerSec;
        private PerformanceCounter bytesTotalPerSec;
        private PerformanceCounter packetsSendPerSec;
        private PerformanceCounter packetsReceivedPerSec;
        private PerformanceCounter packetsTotalPerSec;

        public NetworkAdapter(string instance)
        {
            this.Name = instance.Replace("_", "#").Replace("[", "(").Replace("]", ")");
            this.instance = instance;
            this.networkInterface = NetworkInterface.GetAllNetworkInterfaces().First(x => x.Description == this.Name);
            this.currentBandwidth = new PerformanceCounter("Network Adapter", "Current Bandwidth", this.instance);
            this.bytesSentPerSec = new PerformanceCounter("Network Adapter", "Bytes Sent/sec", this.instance);
            this.bytesReceivedPerSec = new PerformanceCounter("Network Adapter", "Bytes Received/sec", this.instance);
            this.bytesTotalPerSec = new PerformanceCounter("Network Adapter", "Bytes Total/sec", this.instance);
            this.packetsSendPerSec = new PerformanceCounter("Network Adapter", "Packets Received/sec", this.instance);
            this.packetsReceivedPerSec = new PerformanceCounter("Network Adapter", "Packets Sent/sec", this.instance);
            this.packetsTotalPerSec = new PerformanceCounter("Network Adapter", "Packets/sec", this.instance);

            this.Update();
        }

        public void Update()
        {
            if (this.networkInterface == null)
            {
                this.BytesTotalSent = 0;
                this.BytesTotalReceived = 0;
            }
            else
            {
                IPv4InterfaceStatistics stats = this.networkInterface.GetIPv4Statistics();
                this.BytesTotalSent = (ulong)stats.BytesSent;
                this.BytesTotalReceived = (ulong)stats.BytesReceived;
            }

            this.CurrentBandwidth = (ulong)this.currentBandwidth.NextValue();
            this.BytesSentPerSec = (ulong)this.bytesSentPerSec.NextValue();
            this.BytesReceivedPerSec = (ulong)this.bytesReceivedPerSec.NextValue();
            this.BytesTotalPerSec = (ulong)this.bytesTotalPerSec.NextValue();
            this.PacketsSendPerSec = (ulong)this.packetsSendPerSec.NextValue();
            this.PacketsReceivedPerSec = (ulong)this.packetsReceivedPerSec.NextValue();
            this.PacketsTotalPerSec = (ulong)this.packetsTotalPerSec.NextValue();
        }

        public override string ToString()
        {
            return string.Format("Instance: {0} - Bytes Sent: {1}/sec - Bytes Received: {2}/sec - Bandwidth: {3}/sec", this.Name.ToLower(), this.BytesSentPerSec.ToHumanReadable(), this.BytesReceivedPerSec.ToHumanReadable(), this.CurrentBandwidth.ToHumanReadable()); //string.Format("Instance: {0} - Read: {1} - Write: {2}", this.Name.ToLower(), this.ReadDelta.ToHumanReadable(), this.WriteDelta.ToHumanReadable());
        }
    }
}