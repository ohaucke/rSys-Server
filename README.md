rSys-Server (v0.1 Beta)
===========

Remote system monitoring server 

## Output
Output of the current development state
```javascript
{
	"CpuUsage" : [{
			"Name" : "#Total",
			"IdleTime" : 83.09217,
			"ProcessorTime" : 10.84794,
			"UserTime" : 2.991683
		}, {
			"Name" : "0",
			"IdleTime" : 88.46978,
			"ProcessorTime" : 9.145773,
			"UserTime" : 6.375735
		}, {
			"Name" : "1",
			"IdleTime" : 82.25298,
			"ProcessorTime" : 17.11544,
			"UserTime" : 1.592305
		}, {
			"Name" : "2",
			"IdleTime" : 66.28512,
			"ProcessorTime" : 28.2731,
			"UserTime" : 0
		}, {
			"Name" : "3",
			"IdleTime" : 96.8318,
			"ProcessorTime" : 0,
			"UserTime" : 0
		}, {
			"Name" : "4",
			"IdleTime" : 87.29379,
			"ProcessorTime" : 5.958059,
			"UserTime" : 4.77689
		}, {
			"Name" : "5",
			"IdleTime" : 97.13535,
			"ProcessorTime" : 1.176618,
			"UserTime" : 1.593925
		}, {
			"Name" : "6",
			"IdleTime" : 83.87111,
			"ProcessorTime" : 9.146246,
			"UserTime" : 7.969627
		}, {
			"Name" : "7",
			"IdleTime" : 62.65007,
			"ProcessorTime" : 17.11587,
			"UserTime" : 1.593925
		}
	],
	"Load" : {
		"OneMinute" : 0.08,
		"FiveMinutes" : 0.08,
		"FifeteenMinutes" : 0.08
	},
	"LogicalDisk" : [{
			"Name" : "C:\\",
			"VolumeLabel" : "Windows",
			"DriveFormat" : "NTFS",
			"DriveType" : "Fixed",
			"Total" : 249690058752,
			"Free" : 174601195520,
			"Used" : 75088863232
		}, {
			"Name" : "D:\\",
			"VolumeLabel" : "Data",
			"DriveFormat" : "NTFS",
			"DriveType" : "Fixed",
			"Total" : 500104687616,
			"Free" : 254446940160,
			"Used" : 245657747456
		}
	],
	"Memory" : {
		"Total" : 8492482560,
		"Free" : 4835676160,
		"Used" : 3656806400
	},
	"NetworkAdapters" : [{
			"Name" : "JMicron Gigabit-Ethernet-Adapter (PCI Express)",
			"CurrentBandwidth" : 1000000000,
			"BytesSentPerSec" : 110,
			"BytesReceivedPerSec" : 299,
			"BytesTotalPerSec" : 397,
			"BytesTotalSent" : 595492143,
			"BytesTotalReceived" : 8388251146,
			"PacketsSendPerSec" : 3,
			"PacketsReceivedPerSec" : 1,
			"PacketsTotalPerSec" : 5
		}, {
			"Name" : "TAP-Windows Adapter V9",
			"CurrentBandwidth" : 10000000,
			"BytesSentPerSec" : 0,
			"BytesReceivedPerSec" : 0,
			"BytesTotalPerSec" : 0,
			"BytesTotalSent" : 0,
			"BytesTotalReceived" : 0,
			"PacketsSendPerSec" : 0,
			"PacketsReceivedPerSec" : 0,
			"PacketsTotalPerSec" : 0
		}, {
			"Name" : "TAP-Windows Adapter V9 #2",
			"CurrentBandwidth" : 10000000,
			"BytesSentPerSec" : 0,
			"BytesReceivedPerSec" : 0,
			"BytesTotalPerSec" : 0,
			"BytesTotalSent" : 0,
			"BytesTotalReceived" : 0,
			"PacketsSendPerSec" : 0,
			"PacketsReceivedPerSec" : 0,
			"PacketsTotalPerSec" : 0
		}, {
			"Name" : "VMware Virtual Ethernet Adapter for VMnet1",
			"CurrentBandwidth" : 100000000,
			"BytesSentPerSec" : 0,
			"BytesReceivedPerSec" : 0,
			"BytesTotalPerSec" : 0,
			"BytesTotalSent" : 140073,
			"BytesTotalReceived" : 0,
			"PacketsSendPerSec" : 0,
			"PacketsReceivedPerSec" : 0,
			"PacketsTotalPerSec" : 0
		}, {
			"Name" : "VMware Virtual Ethernet Adapter for VMnet8",
			"CurrentBandwidth" : 100000000,
			"BytesSentPerSec" : 0,
			"BytesReceivedPerSec" : 0,
			"BytesTotalPerSec" : 0,
			"BytesTotalSent" : 140457,
			"BytesTotalReceived" : 0,
			"PacketsSendPerSec" : 0,
			"PacketsReceivedPerSec" : 0,
			"PacketsTotalPerSec" : 0
		}
	],
	"PhysicalDisk" : [{
			"Name" : "#Total",
			"BytesReadPerSec" : 0,
			"BytesWritePerSec" : 49813
		}, {
			"Name" : "0 C:",
			"BytesReadPerSec" : 0,
			"BytesWritePerSec" : 49831
		}, {
			"Name" : "1 D:",
			"BytesReadPerSec" : 0,
			"BytesWritePerSec" : 0
		}
	],
	"Processes" : {
		"Count" : 76,
		"Threads" : 983,
		"Handles" : 28942,
		"Processes" : [{
				"ProcessName" : "System Idle Process",
				"CommandLine" : "",
				"PID" : 0,
				"Memory" : 4096,
				"Threads" : 8,
				"Handles" : 0
			}, {
				"ProcessName" : "System",
				"CommandLine" : "",
				"PID" : 4,
				"Memory" : 1544192,
				"Threads" : 144,
				"Handles" : 1216
			}
		]
	},
	"SystemInformations" : {
		"Hostname" : "MY-COMPUTER",
		"Now" : "2014-06-24T22:45:59.748Z",
		"UpTime" : "0:07:09:20",
		"OperatingSystem" : {
			"Name" : "Microsoft Windows 8.1 Pro",
			"Architecture" : "64-Bit",
			"ServicePack" : ""
		},
		"Cpu" : {
			"Name" : "Intel(R) Core(TM) i7-2630QM CPU @ 2.00GHz",
			"NumberOfCores" : 4,
			"NumberOfLogicalProcessors" : 8,
			"L2CacheSize" : 1024,
			"L3CacheSize" : 6144,
			"VirtualizationFirmwareEnabled" : true
		}
	}
}
```

## Requirements
* [.Net Framework 4.0](http://www.microsoft.com/de-de/download/details.aspx?id=17718)

## General
Name: rSys-Server  
Description: Remote system monitoring server 
Version: 0.1 (Beta)  
Author: Oliver Haucke  
Author URI: http://gadean.de/  
E-Mail: ohaucke@gadean.de  
License: BSD 2-Clause  
License URI: http://opensource.org/licenses/BSD-2-Clause
