using System;
using System.Collections.Generic;

namespace Common
{
	public interface IReportingService
	{
		void Identify(string name, Dictionary<string, string> userDetailsDictionary);

		void Report(Exception ex);
	}
}
