//CÔNG TY TNHH GIẢI PHÁP THỊ GIÁC MÁY TÍNH
//support@viscomsolution.com
//0939.825.125

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Management;
using System.Net;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;
using System.Text;

namespace TGMTcs
{
    public class TGMThardware
    {
        public static string GetCpuId()
        {
            //must add reference to System.Management
            ManagementObjectCollection mbsList = null;
            ManagementObjectSearcher mbs = new ManagementObjectSearcher("Select ProcessorID From Win32_processor");
            mbsList = mbs.Get();
            string id = "";
            foreach (ManagementObject mo in mbsList)
            {
                if (mo["ProcessorID"] != null)
                    id = mo["ProcessorID"].ToString();
            }
            return id;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static string GetCpuName()
        {
            string cpuName = "";

            using(var searcher = new ManagementObjectSearcher(
                "SELECT Name FROM Win32_Processor"))
            {
                foreach(ManagementObject obj in searcher.Get())
                {
                    cpuName = obj["Name"]?.ToString().Trim();
                    break;
                }
            }

            int maxMHz = 0;

            using(var searcher = new ManagementObjectSearcher(
                "SELECT MaxClockSpeed FROM Win32_Processor"))
            {
                foreach(ManagementObject obj in searcher.Get())
                {
                    maxMHz = Convert.ToInt32(obj["MaxClockSpeed"]);
                    break;
                }
            }

            if(maxMHz > 0)
            {
                cpuName += $" : {maxMHz} MHz";
            }

            return cpuName;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static string GetMainboardId()
        {
            ManagementObjectSearcher mos = new ManagementObjectSearcher("SELECT SerialNumber FROM Win32_BaseBoard");
            ManagementObjectCollection moc = mos.Get();
            string serial = "";
            foreach (ManagementObject mo in moc)
            {
                serial = (string)mo["SerialNumber"];
            }
            if (serial == "To be filled by O.E.M.")
                return "";
            return serial;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static string GetDiskId()
        {
            TGMTregistry reg = new TGMTregistry();
            reg.Init("Microsoft");

            string saveModel = reg.ReadString("model");
            if (saveModel != "")
                return saveModel;

            var searcher = new ManagementObjectSearcher("SELECT * FROM Win32_DiskDrive");
            if (searcher == null)
                return "";

            ManagementObjectCollection disks = searcher.Get();
            if (disks == null || disks.Count == 0)
                return "";

            foreach (ManagementObject wmi_HD in disks)
            {
                //string model = wmi_HD["Model"].ToString();
                //string interfaceType = wmi_HD["InterfaceType"].ToString();
                //string caption = wmi_HD["Caption"].ToString();
                object obj = wmi_HD.GetPropertyValue("SerialNumber");
                if (obj == null) 
                    continue;

                string serialNo = obj.ToString();//get the serailNumber of diskdrive
                if (serialNo != null && serialNo != "")
                {
                    reg.SaveValue("model", serialNo);
                    return serialNo;
                }
            }
            return "";
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static string GetPartitionId(string partition)
        {
            ManagementObject dsk = new ManagementObject(@"win32_logicaldisk.deviceid=""" + partition + "\"");
            dsk.Get();
            string diskid = dsk["VolumeSerialNumber"].ToString();
            return diskid;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static string GetMacAddress()
        {
            //TGMTregistry reg = new TGMTregistry();
            //reg.Init("Microsoft");

            //const string macRegistryKey = "mac";
            //string savedMac = reg.ReadString(macRegistryKey);
            //if(!string.IsNullOrEmpty(savedMac))
            //    return savedMac;

            // Prefer WMI physical adapters
            using(var searcher = new ManagementObjectSearcher(
                "SELECT MACAddress, PhysicalAdapter, NetEnabled FROM Win32_NetworkAdapter WHERE MACAddress IS NOT NULL"))
            {
                foreach(ManagementObject obj in searcher.Get())
                {
                    bool isPhysical = obj["PhysicalAdapter"] != null && (bool)obj["PhysicalAdapter"];
                    bool isEnabled = obj["NetEnabled"] != null && (bool)obj["NetEnabled"];

                    if(!isPhysical || !isEnabled)
                        continue;

                    string mac = obj["MACAddress"].ToString().Replace(":", "").Replace("-", "");
                    if(!string.IsNullOrEmpty(mac))
                    {
                        //reg.SaveValue(macRegistryKey, mac);
                        return mac;
                    }
                }
            }

            // Fallback if WMI does not return data
            foreach(NetworkInterface nic in NetworkInterface.GetAllNetworkInterfaces())
            {
                if(nic.NetworkInterfaceType == NetworkInterfaceType.Loopback ||
                    nic.NetworkInterfaceType == NetworkInterfaceType.Tunnel)
                    continue;

                if(nic.OperationalStatus != OperationalStatus.Up)
                    continue;

                string desc = (nic.Description ?? "").ToLowerInvariant();
                if(desc.Contains("virtual") || desc.Contains("vmware") || desc.Contains("hyper-v"))
                    continue;

                string mac = nic.GetPhysicalAddress().ToString();
                if(!string.IsNullOrEmpty(mac))
                {
                    //reg.SaveValue(macRegistryKey, mac);
                    return mac;
                }
            }

            return "";
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static string GetUDID()
        {
            string udid = GetCpuId();
            string diskID = GetDiskId();
            if(diskID != "")
                udid += diskID;
            else
            {
                string mac = GetMacAddress();
                udid += mac;
            }



            udid.Replace(" ", "");

            udid = TGMTutil.ConvertToAlphanumeric(udid);
            udid = udid.ToLower();
            return udid;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static string GetIPAddress()
        {
            string macAddress = GetMacAddress();

            // First: find IP from the exact adapter selected by GetMacAddress()
            if(!string.IsNullOrEmpty(macAddress))
            {
                foreach(NetworkInterface nic in NetworkInterface.GetAllNetworkInterfaces())
                {
                    if(nic.OperationalStatus != OperationalStatus.Up)
                        continue;

                    string nicMac = nic.GetPhysicalAddress().ToString();
                    if(!string.Equals(nicMac, macAddress, StringComparison.OrdinalIgnoreCase))
                        continue;

                    foreach(var unicast in nic.GetIPProperties().UnicastAddresses)
                    {
                        if(unicast.Address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork &&
                            !IPAddress.IsLoopback(unicast.Address))
                        {
                            return unicast.Address.ToString();
                        }
                    }
                }
            }

            // Fallback: any active non-virtual adapter with IPv4
            foreach(NetworkInterface nic in NetworkInterface.GetAllNetworkInterfaces())
            {
                if(nic.NetworkInterfaceType == NetworkInterfaceType.Loopback ||
                    nic.NetworkInterfaceType == NetworkInterfaceType.Tunnel)
                    continue;

                if(nic.OperationalStatus != OperationalStatus.Up)
                    continue;

                string desc = (nic.Description ?? "").ToLowerInvariant();
                if(desc.Contains("virtual") || desc.Contains("vmware") || desc.Contains("hyper-v"))
                    continue;

                foreach(var unicast in nic.GetIPProperties().UnicastAddresses)
                {
                    if(unicast.Address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork &&
                        !IPAddress.IsLoopback(unicast.Address))
                    {
                        return unicast.Address.ToString();
                    }
                }
            }

            return "";
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static string GetPCname()
        {
            return Environment.MachineName;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [StructLayout(LayoutKind.Sequential)]
        public struct MEMORYSTATUSEX
        {
            public uint dwLength;
            public uint dwMemoryLoad;
            public ulong ullTotalPhys;
            public ulong ullAvailPhys;
            public ulong ullTotalPageFile;
            public ulong ullAvailPageFile;
            public ulong ullTotalVirtual;
            public ulong ullAvailVirtual;
            public ulong ullAvailExtendedVirtual;
        }

        [DllImport("kernel32.dll")]
        static extern bool GlobalMemoryStatusEx(ref MEMORYSTATUSEX lpBuffer);

        public static void GetMemory(
            out double usedMB,
            out double totalMB,
            out double percent)
        {
            MEMORYSTATUSEX mem = new MEMORYSTATUSEX();
            mem.dwLength = (uint)Marshal.SizeOf(mem);

            GlobalMemoryStatusEx(ref mem);

            totalMB = mem.ullTotalPhys / 1024.0 / 1024.0;
            usedMB = (mem.ullTotalPhys - mem.ullAvailPhys) / 1024.0 / 1024.0;

            percent = mem.dwMemoryLoad;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DllImport("nvml.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int nvmlInit_v2();
        [DllImport("nvml.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int nvmlDeviceGetHandleByIndex_v2(uint index, out IntPtr device);
        [DllImport("nvml.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int nvmlDeviceGetName(IntPtr device, StringBuilder name, uint length);

        public static string GetGPUname() 
        {
            string GPUname = "";

            string nvmlPath = @"C:\Windows\System32\nvml.dll";
            if(File.Exists(nvmlPath))
            {
                nvmlInit_v2();

                IntPtr device;
                nvmlDeviceGetHandleByIndex_v2(0, out device);

                StringBuilder name = new StringBuilder(100);

                nvmlDeviceGetName(device, name, (uint)name.Capacity);
                GPUname = name.ToString();
            }

            return GPUname;
        }
    }
}
