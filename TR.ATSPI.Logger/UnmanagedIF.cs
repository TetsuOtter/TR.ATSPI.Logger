using System;
using System.Runtime.InteropServices;

using TR.ATSPI.Logger;

namespace TR.ATSPI
{
	public static class UnmanagedIF
	{
		static readonly IAtsPI pi = new ManagedIF();

		[DllExport(CallingConvention = CallingConvention.StdCall)]
		public static void Dispose() => pi.Dispose();

		[DllExport(CallingConvention = CallingConvention.StdCall)]
		public static void DoorClose() => pi.DoorClose();

		[DllExport(CallingConvention = CallingConvention.StdCall)]
		public static void DoorOpen() => pi.DoorOpen();

		[DllExport(CallingConvention = CallingConvention.StdCall)]
		public static Hand Elapse(State s, IntPtr Pa, IntPtr So) => pi.Elapse(s, Pa, So);

		[DllExport(CallingConvention = CallingConvention.StdCall)]
		public static uint GetPluginVersion() => pi.GetPluginVersion();

		[DllExport(CallingConvention = CallingConvention.StdCall)]
		public static void HornBlow(int k) => pi.HornBlow(k);

		[DllExport(CallingConvention = CallingConvention.StdCall)]
		public static void Initialize(int s) => pi.Initialize(s);

		[DllExport(CallingConvention = CallingConvention.StdCall)]
		public static void KeyDown(int k) => pi.KeyDown(k);

		[DllExport(CallingConvention = CallingConvention.StdCall)]
		public static void KeyUp(int k) => pi.KeyUp(k);

		[DllExport(CallingConvention = CallingConvention.StdCall)]
		public static void Load() => pi.Load();

		[DllExport(CallingConvention = CallingConvention.StdCall)]
		public static void SetBeaconData(Beacon b) => pi.SetBeaconData(b);

		[DllExport(CallingConvention = CallingConvention.StdCall)]
		public static void SetBrake(int b) => pi.SetBrake(b);

		[DllExport(CallingConvention = CallingConvention.StdCall)]
		public static void SetPower(int p) => pi.SetPower(p);

		[DllExport(CallingConvention = CallingConvention.StdCall)]
		public static void SetReverser(int r) => pi.SetReverser(r);

		[DllExport(CallingConvention = CallingConvention.StdCall)]
		public static void SetSignal(int s) => pi.SetSignal(s);

		[DllExport(CallingConvention = CallingConvention.StdCall)]
		public static void SetVehicleSpec(Spec s) => pi.SetVehicleSpec(s);
	}
}
