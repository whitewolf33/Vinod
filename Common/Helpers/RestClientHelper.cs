using System;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using Newtonsoft.Json;
using ModernHttpClient;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Xamarin.Forms;

namespace Common
{
	public class RestClientHelper
	{
		readonly string _baseUrl;

		bool _isAuthTokenEnabled;

		bool _isBasicHttpAuth;

		string _userName;

		string _password;

		/// <summary>
		/// This Constructor will be used by IDPService to Authenticate with ContextSpace
		/// </summary>
		/// <param name="baseUrl">Base URL.</param>
		/// <param name="username">Username.</param>
		/// <param name="password">Password.</param>
		public RestClientHelper(string baseUrl, string username, string password)
			: this(baseUrl, false)
		{
			_userName = username;
			_password = password;
		}

		public RestClientHelper(string baseUrl, bool useAuthToken = true)
		{
			_isAuthTokenEnabled = false;
			_isBasicHttpAuth = false;
			_baseUrl = baseUrl;

			if (useAuthToken)
			{
				_isAuthTokenEnabled = true;
			}
			else {
				_isBasicHttpAuth = true;
			}
		}

		HttpClient CreateRestClient(List<KeyValuePair<string, string>> specificRequestHeadersList = null)
		{
			HttpClient httpClient = new HttpClient(new NativeMessageHandler());

			httpClient.BaseAddress = new Uri(_baseUrl);

			httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

			if (specificRequestHeadersList != null && specificRequestHeadersList.Any())
			{
				foreach (var kvp in specificRequestHeadersList)
				{
					if (!String.IsNullOrWhiteSpace(kvp.Key) && !String.IsNullOrWhiteSpace(kvp.Value))
						httpClient.DefaultRequestHeaders.Add(kvp.Key, kvp.Value);
				}
			}
			return httpClient;
		}

		#region Get Call

		[InsightsLogger]
		public virtual async Task<T> GetHttpResponse<T>(string extraParam, List<KeyValuePair<string, string>> headerList = null)
		{
			try
			{
				using (var httpClient = CreateRestClient(headerList))
				{
					var webApiUri = string.Format("{0}{1}", _baseUrl, extraParam);
					Debug.WriteLine("GET - Request " + webApiUri);
					Debug.WriteLine("GET - Header " + httpClient.DefaultRequestHeaders);
					//Stopwatch.StartNew();
					var response = await httpClient.GetAsync(webApiUri);
					//Debug.WriteLine(Stopwatch.GetTimestamp());
					// this will handle the 400 exception
					response.EnsureSuccessStatusCode();
					var result = JsonConvert.DeserializeObject<T>(response.Content.ReadAsStringAsync().Result);
					Debug.WriteLine("GET - Result " + result);
					return result;
				}
			}
			catch (WebException webEx)
			{
				CheckForSSLIssues(webEx);
				throw;
			}
			catch (Exception ex)
			{
				Debug.WriteLine("Rest Client -GET- Exception Occured " + ex.Message + " " + ex.StackTrace);
				MyInsights.Report(ex);
				throw;
			}
		}

		#endregion

		#region Post Call

		[InsightsLogger]
		public virtual async Task<T> PostHttpResponse<T>(string extraParam, string data, List<KeyValuePair<string, string>> headerList = null) where T : new()
		{
			try
			{
				using (var httpClient = CreateRestClient(headerList))
				{
					Debug.WriteLine("POST - Request " + _baseUrl + extraParam);
					Debug.WriteLine("POST - Header " + httpClient.DefaultRequestHeaders);
					Debug.WriteLine("POST - Body " + data);
					//Stopwatch.StartNew();
					var response = await httpClient.PostAsync(_baseUrl + extraParam, new StringContent(data, Encoding.UTF8, "application/json"));
					//Debug.WriteLine(Stopwatch.GetTimestamp());
					// this will handle the 400 exception
					response.EnsureSuccessStatusCode();
					Debug.WriteLine("POST - Response " + response.Content.ReadAsStringAsync().Result);
					var result = JsonConvert.DeserializeObject<T>(response.Content.ReadAsStringAsync().Result);
					return result;
				}
			}
			catch (WebException webEx)
			{
				CheckForSSLIssues(webEx);
				throw;
			}
			catch (Exception ex)
			{
				Debug.WriteLine("Rest Client - POST - Exception Occured " + ex.Message + " " + ex.StackTrace);
				MyInsights.Report(ex);
				throw;
			}
		}

		#endregion

		#region Delete Call

		[InsightsLogger]
		public virtual async Task<string> DeleteHttpResponse(string extraParam, List<KeyValuePair<string, string>> headerList = null)
		{
			try
			{
				using (var httpClient = CreateRestClient(headerList))
				{
					Debug.WriteLine("DELETE - Request " + _baseUrl + extraParam);
					HttpResponseMessage httpresponse = await httpClient.DeleteAsync(_baseUrl + extraParam);
					var result = await httpresponse.Content.ReadAsStringAsync();
					Debug.WriteLine("DELETE - Result " + result);
					return result;
				}
			}
			catch (WebException webEx)
			{
				CheckForSSLIssues(webEx);
				throw;
			}
			catch (Exception ex)
			{
				Debug.WriteLine("Rest Client - DELETE - Exception Occured " + ex.Message + " " + ex.StackTrace);
				MyInsights.Report(ex);
				throw;
			}
		}

		[InsightsLogger]
		public virtual async Task<T> DeleteHttpResponse<T>(string extraParam, string data, List<KeyValuePair<string, string>> headerList = null)
		{
			try
			{
				using (var httpClient = CreateRestClient(headerList))
				{

					Debug.WriteLine("DELETE - Request " + _baseUrl + extraParam + data);
					var response = await httpClient.DeleteAsync(_baseUrl + extraParam + data);
					var result = JsonConvert.DeserializeObject<T>(response.Content.ReadAsStringAsync().Result);
					Debug.WriteLine("DELETE - Result " + result);
					return result;
				}
			}
			catch (WebException webEx)
			{
				CheckForSSLIssues(webEx);
				throw;
			}
			catch (Exception ex)
			{
				Debug.WriteLine("Rest Client - DELETE - Exception Occured " + ex.Message + " " + ex.StackTrace);
				MyInsights.Report(ex);
				throw;
			}
		}

		#endregion

		#region Put Call

		[InsightsLogger]
		public virtual async Task<T> PutHttpResponse<T>(string extraParam, string data, List<KeyValuePair<string, string>> headerList = null) where T : new()
		{
			try
			{
				using (var httpClient = CreateRestClient(headerList))
				{
					Debug.WriteLine("PUT - Request " + _baseUrl + extraParam);
					Debug.WriteLine("PUT - Header " + httpClient.DefaultRequestHeaders);
					Debug.WriteLine("PUT - Body " + data);
					//Stopwatch.StartNew();
					var response = await httpClient.PutAsync(_baseUrl + extraParam, new StringContent(data, Encoding.UTF8, "application/json"));
					//Debug.WriteLine(Stopwatch.GetTimestamp());
					Debug.WriteLine("PUT - Result " + response.Content.ReadAsStringAsync().Result);
					var result = JsonConvert.DeserializeObject<T>(response.Content.ReadAsStringAsync().Result);
					return result;
				}
			}
			catch (WebException webEx)
			{
				CheckForSSLIssues(webEx);
				throw;
			}
			catch (Exception ex)
			{
				Debug.WriteLine("Rest Client - PUT - Exception Occured " + ex.Message + " " + ex.StackTrace);
				MyInsights.Report(ex);
				throw;
			}
		}

		#endregion

		private bool CheckForSSLIssues(WebException webEx)
		{
			if ((int)webEx.Status == 9)//Trust Failure -> Not available as Enum
			{
				MessagingCenter.Send<RestClientHelper>(this, "LockApp");
				Application.Current.MainPage.DisplayAlert("Security Alert", "We cannot establish a trusted connection to HealthGateway at the moment. For security reasons we cannot proceed.", "OK");
				return true;
			}
			return false;
		}
	}
}

