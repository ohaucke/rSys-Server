using System.IO;
using System.Runtime.Serialization;

namespace rSysServer.Values
{
    [DataContract]
    public class LogicalDisk
    {
        [DataMember(Name = "Name", Order = 1)]
        public string Name { get; set; }

        [DataMember(Name = "VolumeLabel", Order = 2)]
        public string VolumeLabel { get; set; }

        [DataMember(Name = "DriveType", Order = 3)]
        public string DriveType { get; set; }

        [DataMember(Name = "DriveFormat", Order = 3)]
        public string DriveFormat { get; set; }

        [DataMember(Name = "Total", Order = 4)]
        public ulong Total { get; set; }

        [DataMember(Name = "Free", Order = 5)]
        public ulong Free { get; set; }

        [DataMember(Name = "Used", Order = 6)]
        public ulong Used { get; set; }

        private string instance;
        private DriveInfo driveInfo;

        public LogicalDisk(string instance)
        {
            this.Name = instance;
            this.instance = instance;
            this.driveInfo = new DriveInfo(instance);

            this.Update();
        }

        public void Update()
        {
            this.VolumeLabel = this.driveInfo.VolumeLabel;
            this.DriveType = this.driveInfo.DriveType.ToString();
            this.DriveFormat = this.driveInfo.DriveFormat;
            this.Total = (ulong)this.driveInfo.TotalSize;
            this.Free = (ulong)this.driveInfo.AvailableFreeSpace;
            this.Used = this.Total - this.Free;
        }

        public override string ToString()
        {
            return string.Format("Instance: {0} - Total: {1} - Free: {2} - Used: {3}", this.Name.ToLower(), this.Total.ToHumanReadable(), this.Free.ToHumanReadable(), this.Used.ToHumanReadable());
        }
    }
}
