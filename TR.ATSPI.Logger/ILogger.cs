namespace TR.ATSPI
{
	public interface ILogger
	{
		void PrintLog(in string comment = "", [System.Runtime.CompilerServices.CallerMemberName] in string CallerMemberName = "");
		void PrintLog(in int value, [System.Runtime.CompilerServices.CallerMemberName] in string CallerMemberName = "");
	}
}
