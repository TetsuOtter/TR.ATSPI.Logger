//extern alias ref : https://www.atmarkit.co.jp/fdotnet/csharp20/csharp20_07/csharp20_07_02.html
extern alias direct;

using System;
using System.Runtime.InteropServices;

using NUnit.Framework;

namespace TR.ATSPI.Logger.Test
{
#if !ANYCPU
	public class UnmanagedIFTests
	{
		const string AssemblyName =
#if X64
			"TR.ATSPI.Logger.x64.dll";
#else
			"TR.ATSPI.Logger.x86.dll";
#endif

		[DllImport(AssemblyName, CallingConvention = CallingConvention.StdCall)]
		static extern void Dispose();
		[DllImport(AssemblyName, CallingConvention = CallingConvention.StdCall)]
		static extern void DoorClose();
		[DllImport(AssemblyName, CallingConvention = CallingConvention.StdCall)]
		static extern void DoorOpen();
		[DllImport(AssemblyName, CallingConvention = CallingConvention.StdCall)]
		static extern direct.Hand Elapse(direct.State s, IntPtr Pa, IntPtr So);
		[DllImport(AssemblyName, CallingConvention = CallingConvention.StdCall)]
		static extern uint GetPluginVersion();
		[DllImport(AssemblyName, CallingConvention = CallingConvention.StdCall)]
		static extern void HornBlow(int k);
		[DllImport(AssemblyName, CallingConvention = CallingConvention.StdCall)]
		static extern void Initialize(int s);
		[DllImport(AssemblyName, CallingConvention = CallingConvention.StdCall)]
		static extern void KeyDown(int k);
		[DllImport(AssemblyName, CallingConvention = CallingConvention.StdCall)]
		static extern void KeyUp(int k);
		[DllImport(AssemblyName, CallingConvention = CallingConvention.StdCall)]
		static extern void Load();
		[DllImport(AssemblyName, CallingConvention = CallingConvention.StdCall)]
		static extern void SetBeaconData(direct.Beacon b);
		[DllImport(AssemblyName, CallingConvention = CallingConvention.StdCall)]
		static extern void SetBrake(int b);
		[DllImport(AssemblyName, CallingConvention = CallingConvention.StdCall)]
		static extern void SetPower(int p);
		[DllImport(AssemblyName, CallingConvention = CallingConvention.StdCall)]
		static extern void SetReverser(int r);
		[DllImport(AssemblyName, CallingConvention = CallingConvention.StdCall)]
		static extern void SetSignal(int s);
		[DllImport(AssemblyName, CallingConvention = CallingConvention.StdCall)]
		static extern void SetVehicleSpec(direct.Spec s);

		[Test]
		public void Test_Load()
		{
			Load();
			Assert.Pass();//Exceptionさえ投げられなければOK
		}

		[Test]
		public void Test_Dispose()
		{
			Dispose();
			Assert.Pass();//Exceptionさえ投げられなければOK
		}
	}
#endif
}
