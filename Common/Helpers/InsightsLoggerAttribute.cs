using System;
using System.Reflection;
using Common;

[module: InsightsLogger]
namespace Common
{
	[AttributeUsage(AttributeTargets.Method | AttributeTargets.Constructor | AttributeTargets.Assembly | AttributeTargets.Module)]
	public class InsightsLoggerAttribute : Attribute, IMethodDecorator
	{
		private string _methodName;


		public void Init(object instance, MethodBase method, object[] args)
		{
			_methodName = method.DeclaringType.FullName + "." + method.Name;
		}


		public void OnEntry()
		{
			var message = string.Format("OnEntry: {0}", _methodName);
			MyInsights.Track(message);
		}


		public void OnExit()
		{
			var message = string.Format("OnExit: {0}", _methodName);
			MyInsights.Track(message);
		}


		public void OnException(Exception exception)
		{
			MyInsights.Report(exception, MyInsights.Severity.Error);
		}
	}
}
