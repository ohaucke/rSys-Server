using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.Serialization;

namespace rSysServer
{
    [DataContract]
    public class Data
    {
        private System.Timers.Timer serviceTimer;

        [DataMember(Name = "Memory")]
        public Values.Memory Memory { get; private set; }

        [DataMember(Name = "PhysicalDisk")]
        public List<Values.PhysicalDisk> PhysicalDisks { get; private set; }

        [DataMember(Name = "LogicalDisk")]
        public List<Values.LogicalDisk> LogicalDisks { get; private set; }

        [DataMember(Name = "CpuUsage")]
        public List<Values.CpuUsage> CpuUsage { get; private set; }

        [DataMember(Name = "NetworkAdapters")]
        public List<Values.NetworkAdapter> NetworkAdapters { get; private set; }

        [DataMember(Name = "Load")]
        public Values.Load Load { get; private set; }

        [DataMember(Name = "Processes")]
        public Values.Processes Processes { get; private set; }

        [DataMember(Name = "SystemInformations")]
        public Values.SystemInformations SystemInformations { get; private set; }

        public Data()
        {
            this.Memory = new Values.Memory();
            this.Load = new Values.Load();
            this.SystemInformations = new Values.SystemInformations();
            this.Processes = new Values.Processes();
            this.PhysicalDisks = this.InitPhysicalDisks();
            this.LogicalDisks = this.InitLogicalDisks();
            this.CpuUsage = this.InitCpuUsage();
            this.NetworkAdapters = this.InitNetworkAdapters();
        }

        public void Start()
        {
            this.serviceTimer = new System.Timers.Timer(1000);
            this.serviceTimer.Elapsed += serviceTimer_Elapsed;
            this.serviceTimer.Start();
        }

        private void serviceTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            //rSysServer.Utilities.DebugOutput("Data: Update Values...");
            this.Memory.Update();
            this.Load.Update();
            this.SystemInformations.Update();
            this.Processes.Update();
            this.UpdatePhysicalDisks();
            this.UpdateLogicalDisks();
            this.UpdateCpuUsage();
            this.UpdateNetworkAdapters();
        }

        private List<Values.PhysicalDisk> InitPhysicalDisks()
        {
            List<Values.PhysicalDisk> pd = new List<Values.PhysicalDisk>();
            PerformanceCounterCategory pcc = new PerformanceCounterCategory("PhysicalDisk");
            foreach (string item in pcc.GetInstanceNames())
            {
                pd.Add(new Values.PhysicalDisk(item));
            }
            return pd.OrderBy(x => x.Name).ToList();
        }

        private void UpdatePhysicalDisks()
        {
            foreach (Values.PhysicalDisk item in this.PhysicalDisks)
            {
                item.Update();
            }
        }

        private List<Values.LogicalDisk> InitLogicalDisks()
        {
            List<Values.LogicalDisk> ld = new List<Values.LogicalDisk>();
            DriveInfo[] di = DriveInfo.GetDrives();
            foreach (DriveInfo item in di)
            {
                ld.Add(new Values.LogicalDisk(item.Name));
            }
            return ld.OrderBy(x => x.Name).ToList();
        }

        private void UpdateLogicalDisks()
        {
            foreach (Values.LogicalDisk item in this.LogicalDisks)
            {
                item.Update();
            }
        }

        private List<Values.CpuUsage> InitCpuUsage()
        {
            List<Values.CpuUsage> p = new List<Values.CpuUsage>();
            PerformanceCounterCategory pcc = new PerformanceCounterCategory("Processor");
            foreach (string item in pcc.GetInstanceNames())
            {
                p.Add(new Values.CpuUsage(item));
            }
            return p.OrderBy(x => x.Name).ToList();
        }

        private void UpdateCpuUsage()
        {
            foreach (Values.CpuUsage item in this.CpuUsage)
            {
                item.Update();
            }
        }

        private List<Values.NetworkAdapter> InitNetworkAdapters()
        {
            List<Values.NetworkAdapter> p = new List<Values.NetworkAdapter>();
            string[] interfaces = NetworkInterface.GetAllNetworkInterfaces().Where(x => x.NetworkInterfaceType == NetworkInterfaceType.Ethernet).Select(x => x.Description.Replace("#", "_").Replace("(", "[").Replace(")", "]")).ToArray();
            foreach (string item in interfaces)
            {
                p.Add(new Values.NetworkAdapter(item));
            }
            return p.OrderBy(x => x.Name).ToList();
        }

        private void UpdateNetworkAdapters()
        {
            foreach (Values.NetworkAdapter item in this.NetworkAdapters)
            {
                item.Update();
            }
        }
    }
}