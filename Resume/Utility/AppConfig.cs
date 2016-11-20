using System;
namespace Resume
{
	public static class AppConfig
	{
		public static string APP_NAME = "Vinod";

		public static string APP_VERSION { get; set; }

		public static int SCREEN_WIDTH { get; set; }

		public static int SCREEN_HEIGHT { get; set; }

#if RELEASE
		public static string API_URL = "";
#elif NPD
		public static string API_URL = "";
#else
		public static string API_URL = "";
#endif
	}
}
