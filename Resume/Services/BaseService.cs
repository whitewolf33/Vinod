using System;
using Common;

namespace Resume
{
	public abstract class BaseService
	{
		protected RestClientHelper _restClient;

		protected readonly object _locker;

		protected BaseService()
		{
			_locker = new object();

			_restClient = new RestClientHelper(AppConfig.API_URL);
		}
	}
}
