#if !ANYCPU
using System;
using System.Runtime.InteropServices;

using NUnit.Framework;

namespace TR.ATSPI.Logger.Test
{
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
		//static extern direct.Hand Elapse(direct.State s, IntPtr Pa, IntPtr So);
		static extern Hand Elapse(State s, IntPtr Pa, IntPtr So);
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
		//static extern void SetBeaconData(direct.Beacon b);
		static extern void SetBeaconData(Beacon b);
		[DllImport(AssemblyName, CallingConvention = CallingConvention.StdCall)]
		static extern void SetBrake(int b);
		[DllImport(AssemblyName, CallingConvention = CallingConvention.StdCall)]
		static extern void SetPower(int p);
		[DllImport(AssemblyName, CallingConvention = CallingConvention.StdCall)]
		static extern void SetReverser(int r);
		[DllImport(AssemblyName, CallingConvention = CallingConvention.StdCall)]
		static extern void SetSignal(int s);
		[DllImport(AssemblyName, CallingConvention = CallingConvention.StdCall)]
		//static extern void SetVehicleSpec(direct.Spec s);
		static extern void SetVehicleSpec(Spec s);

		[Test]
		public void Test_Dispose() => Exec(Dispose);
		[Test]
		public void Test_DoorClose() => Exec(DoorClose);
		[Test]
		public void Test_DoorOpen() => Exec(DoorOpen);
		[Test]
		public void Test_Elapse() => Exec(() => Elapse(default, default, default));
		[Test]
		public void Test_GetPluginVersion() => Exec(() => GetPluginVersion());
		[Test]
		public void Test_HornBlow() => Exec(HornBlow, 1);
		[Test]
		public void Test_Initialize() => Exec(Initialize, 2);
		[Test]
		public void Test_KeyDown() => Exec(KeyDown, 3);
		[Test]
		public void Test_KeyUp() => Exec(KeyUp, 4);
		[Test]
		public void Test_Load() => Exec(Load);
		[Test]
		public void Test_SetBeaconData() => Exec(() => SetBeaconData(default));
		[Test]
		public void Test_SetBrake() => Exec(SetBrake, 5);
		[Test]
		public void Test_SetPower() => Exec(SetPower, 6);
		[Test]
		public void Test_SetReverser() => Exec(SetReverser, 0);
		[Test]
		public void Test_SetSignal() => Exec(SetSignal, 8);
		[Test]
		public void Test_SetVehicleSpec() => Exec(() => SetVehicleSpec(default));

		private static void Exec(Action act)
		{
			act.Invoke();
			Assert.Pass();//Exceptionさえ投げられなければOK
		}
		private static void Exec(Action<int> act, int arg)
		{
			act.Invoke(arg);
			Assert.Pass();//Exceptionさえ投げられなければOK
		}
	}
}
#endif
