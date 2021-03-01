using System;
using System.Runtime.CompilerServices;

namespace TR.ATSPI
{
	class LogToDebug : ILogger
	{

		public void PrintLog(in string comment = "", [CallerMemberName] in string CallerMemberName = "") => printLog(comment, CallerMemberName);

		public void PrintLog(in int value, [CallerMemberName] in string CallerMemberName = "") => printLog(value.ToString(), CallerMemberName);

		private void printLog(in string comment, in string CallerMemberName) => System.Diagnostics.Debug.WriteLine($"{DateTime.Now:HH:mm:ss.fffff}\t{CallerMemberName}\t{comment}");
		
	}
}
