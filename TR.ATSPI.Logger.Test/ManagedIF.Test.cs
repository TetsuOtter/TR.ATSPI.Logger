extern alias LoggerDLL;

using System;
using System.Runtime.CompilerServices;

using NUnit.Framework;

namespace TR.ATSPI.Logger.Test
{
	public class ManagedIFTests
	{
		LoggerDLL.TR.ATSPI.ManagedIF? PI = null;
		LoggerToTest? logger = null;
		internal class LoggerToTest : LoggerDLL.TR.ATSPI.ILogger
		{
			public string LastOutput { get; private set; } = string.Empty;
			readonly DateTime DummyDateTime = new DateTime(2021, 12, 31, 13, 59, 22, 127);

			public void PrintLog(in string comment = "", [CallerMemberName] in string CallerMemberName = "") => printLog(comment, CallerMemberName);

			public void PrintLog(in int value, [CallerMemberName] in string CallerMemberName = "") => printLog(value.ToString(), CallerMemberName);

			private void printLog(in string comment, in string CallerMemberName) => LastOutput = $"{DummyDateTime:HH:mm:ss.fffff}\t{CallerMemberName}\t{comment}";
		}
		static public string GetExceptedOutput(in string MethodName, in string comment)
			=> "13:59:22.12700\t" + MethodName + "\t" + comment;

		[SetUp]
		public void Setup()
		{
			logger = new();
			PI = new(logger);
		}

		[Test]
		public void Test_Load()
			=> ExecPluginFunction(() => PI?.Load(), nameof(PI.Load), string.Empty);
		[Test]
		public void Test_Dispose()
			=> ExecPluginFunction(() => PI?.Dispose(), nameof(PI.Dispose), string.Empty);
		[Test]
		public void Test_DoorClose()
			=> ExecPluginFunction(() => PI?.DoorClose(), nameof(PI.DoorClose), string.Empty);
		[Test]
		public void Test_DoorOpen()
			=> ExecPluginFunction(() => PI?.DoorOpen(), nameof(PI.DoorOpen), string.Empty);
		[Test]
		public void Test_Elapse()
			=> ExecPluginFunction(() => PI?.Elapse(new() { BC = 1.23F, BP = 2.34F, ER = 3.45F, I = 45.67F, MR = 890F, SAP = 1023.45F, T = (int)new DateTime(2021, 12, 31, 1, 23, 45, 679).TimeOfDay.TotalMilliseconds, V = -12.345F, Z = 345.67890 }, IntPtr.Zero, IntPtr.Zero), nameof(PI.Elapse),
				"Location:345.6789, Speed:-12.345, Time:01:23:45.679, BC:1.23, MR:890, BP:2.34, ER:3.45, SAP:1023.45, Current:45.67");
		[Test]
		public void Test_GetPluginVersion()
			=> ExecPluginFunction(() => PI?.GetPluginVersion(), nameof(PI.GetPluginVersion), string.Empty);
		[Test]
		public void Test_HornBlow()
			=> ExecPluginFunction(() => PI?.HornBlow(1), nameof(PI.HornBlow), "1");
		[Test]
		public void Test_Initialize()
			=> ExecPluginFunction(() => PI?.Initialize(2), nameof(PI.Initialize), "2");
		[Test]
		public void Test_KeyDown()
			=> ExecPluginFunction(() => PI?.KeyDown(3), nameof(PI.KeyDown), "3");
		[Test]
		public void Test_KeyUp()
			=> ExecPluginFunction(() => PI?.KeyUp(4), nameof(PI.KeyUp), "4");
		[Test]
		public void Test_SetBeaconData()
			=> ExecPluginFunction(() => PI?.SetBeaconData(new() { Data = 123, Num = 99, Sig = 3, Z = 34.56F }), nameof(PI.SetBeaconData),
				"DistanceToConnectedSection:34.56, BeaconType:99, Signal:3, Data:123");
		[Test]
		public void Test_SetBrake()
			=> ExecPluginFunction(() => PI?.SetBrake(5), nameof(PI.SetBrake), "5");
		[Test]
		public void Test_SetPower()
			=> ExecPluginFunction(() => PI?.SetPower(6), nameof(PI.SetPower), "6");
		[Test]
		public void Test_SetReverser()
			=> ExecPluginFunction(() => PI?.SetReverser(7), nameof(PI.SetReverser), "7");
		[Test]
		public void Test_SetSignal()
			=> ExecPluginFunction(() => PI?.SetSignal(8), nameof(PI.SetSignal), "8");
		public void Test_SetVehicleSpec()
			=> ExecPluginFunction(() => PI?.SetVehicleSpec(new() { A = 1, B = 9, C = 5, J = 3, P = 2 }), nameof(PI.SetVehicleSpec),
				"Brake:9, Power:2, ATS:1, B67:2, CarCount:5");

		[Test]
		public void Test_GetPluginVersion_Return()
			=> Assert.AreEqual(0x20000, PI?.GetPluginVersion());

		[TestCase(1, 2, 3)]
		public void Test_Elapse_Return(in int brake, in int power, in int reverser)
		{
			PI?.SetBrake(brake);
			PI?.SetPower(power);
			PI?.SetReverser(reverser);
			var tmp = PI?.Elapse(default, default, default);
			var excepted = tmp;//Œ^‚Ì•sˆê’v‘Îô
			excepted = new() { B = brake, C = 0, P = power, R = reverser };
			Assert.AreEqual(excepted, tmp);
		}

		private void ExecPluginFunction(Action act, in string MethodName, in string comment)
		{
			act.Invoke();
			Assert.AreEqual(GetExceptedOutput(MethodName, comment), logger?.LastOutput);
		}
	}
}