using System;
using System.Collections.Generic;
using Xamarin;
using Xamarin.Forms;

namespace Common
{
	public static class MyInsights
	{
		/// <summary>
		/// Direct Mapping to  Xamarin Insights Serverity Enum
		/// </summary>
		public enum Severity
		{
			Critical = 0,
			Error = 1,
			Warning = 2
		}

		public static void Identify(string name, Dictionary<string, string> userDetailsDictionary)
		{
			var reportingService = DependencyService.Get<IReportingService>();
			if (reportingService != null)
				reportingService.Identify(name, userDetailsDictionary);
		}

		public static void Track(string message)
		{
			// Raygun does not support Tracking Yet
		}

		public static void Report(Exception ex, Severity severity = Severity.Critical)
		{
			//MyInsights.Report (ex, CastToInsightsSeverity (severity));
			var reportingService = DependencyService.Get<IReportingService>();
			if (reportingService != null)
				reportingService.Report(ex);
		}

		//		private static Insights.Severity CastToInsightsSeverity (Severity severity)
		//		{
		//			switch (severity) {
		//			case Severity.Critical:
		//				return Insights.Severity.Critical;
		//			case Severity.Error:
		//				return Insights.Severity.Error;
		//			case Severity.Warning:
		//				return Insights.Severity.Warning;
		//			default:
		//				return Insights.Severity.Warning;
		//			}
		//		}
	}
}
