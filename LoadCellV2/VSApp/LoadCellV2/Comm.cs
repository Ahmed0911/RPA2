﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace LoadCellV2
{
    struct SCommEthData
    {
        public uint LoopCounter;
        public uint ADCValue;
        public uint DataBufferIndex;
        public float BATTVoltage;
        // Launch
        public ushort LaunchStatus1;
        public ushort LaunchStatus2;
    };

    struct SCommLaunch
    {
        public byte Command;
        public byte Index;
        public byte _dummy1;
        public byte _dummy2;
        public uint CodeTimer;
    };

    struct SCommDownloaderRequest
    {
        public uint Offset;
        public uint Size;
    };

    class Comm
    {
        public static byte[] GetBytes(object str)
        {
            int size = Marshal.SizeOf(str);
            byte[] arr = new byte[size];

            IntPtr ptr = Marshal.AllocHGlobal(size);
            Marshal.StructureToPtr(str, ptr, true);
            Marshal.Copy(ptr, arr, 0, size);
            Marshal.FreeHGlobal(ptr);
            return arr;
        }

        public static object FromBytes(byte[] arr, object str)
        {
            int size = Marshal.SizeOf(str);
            IntPtr ptr = Marshal.AllocHGlobal(size);

            Marshal.Copy(arr, 0, ptr, size);

            str = Marshal.PtrToStructure(ptr, str.GetType());
            Marshal.FreeHGlobal(ptr);

            return str;
        }
    }
}
