//extern alias ref : https://www.atmarkit.co.jp/fdotnet/csharp20/csharp20_07/csharp20_07_02.html
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

		[SetUp]
		public void Setup()
		{
			logger = new LoggerToTest();
			PI = new LoggerDLL.TR.ATSPI.ManagedIF(logger);
		}

		[Test]
		public void Test_Load()
		{
			PI?.Load();
			Assert.AreEqual("13:59:22.127000\tLoad\t", logger?.LastOutput);
		}
	}
}