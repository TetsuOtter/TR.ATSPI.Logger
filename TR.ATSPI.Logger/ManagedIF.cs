using System;

namespace TR.ATSPI
{
	public class ManagedIF : IAtsPI
	{
		readonly ILogger logger = new LogToDebug();
		public ManagedIF(ILogger? _logger = null) => logger = _logger ?? new LogToDebug();

		public void Dispose() => logger.PrintLog();

		public void DoorClose() => logger.PrintLog();

		public void DoorOpen() => logger.PrintLog();

		int PowerPos = 0;
		int BrakePos = 999;
		int ReverserPos = 1;
		public Hand Elapse(State s, IntPtr Pa, IntPtr So)
		{
			logger.PrintLog($"Location:{s.Z}, Speed:{s.V}, Time:{TimeSpan.FromMilliseconds(s.T):hh\\:mm\\:ss\\.fff}, BC:{s.BC}, MR:{s.MR}, BP:{s.BP}, ER:{s.ER}, SAP:{s.SAP}, Current:{s.I}");
			return new Hand() { B = BrakePos, P = PowerPos, R = ReverserPos };
		}

		public uint GetPluginVersion()
		{
			logger.PrintLog();
			return IAtsPIClass.VersionNum;
		}

		public void HornBlow(int k) => logger.PrintLog(k);

		public void Initialize(int s) => logger.PrintLog(s);

		public void KeyDown(int k) => logger.PrintLog(k);

		public void KeyUp(int k) => logger.PrintLog(k);

		public void Load()
		{
#if DEBUG
			if (!System.Diagnostics.Debugger.IsAttached)
				System.Diagnostics.Debugger.Launch();
#endif

			logger.PrintLog();
		}

		public void SetBeaconData(Beacon b) => logger.PrintLog($"Location:{b.Z}, Number:{b.Num}, Signal:{b.Sig}, Data:{b.Data}");

		public void SetBrake(int b)
		{
			BrakePos = b;
			logger.PrintLog(b);
		}

		public void SetPower(int p)
		{
			PowerPos = p;
			logger.PrintLog(p);
		}

		public void SetReverser(int r)
		{
			ReverserPos = r;
			logger.PrintLog(r);
		}

		public void SetSignal(int s) => logger.PrintLog(s);

		public void SetVehicleSpec(Spec s) => logger.PrintLog($"Brake:{s.B}, Power:{s.P}, ATS:{s.A}, B67:{s.J}, CarCount:{s.C}");
	}
}
