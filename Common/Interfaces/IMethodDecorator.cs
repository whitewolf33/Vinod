using System;
using System.Reflection;

namespace Common
{
	public interface IMethodDecorator
	{
		void Init(object instance, MethodBase method, object[] args);
		void OnEntry();
		void OnExit();
		void OnException(Exception exception);
		//void OnTaskContinuation(Task task);
	}
}
