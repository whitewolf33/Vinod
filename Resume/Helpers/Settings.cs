// Helpers/Settings.cs
using Plugin.Settings;
using Plugin.Settings.Abstractions;

namespace Resume.Helpers
{
	/// <summary>
	/// This is the Settings static class that can be used in your Core solution or in any
	/// of your client applications. All settings are laid out the same exact way with getters
	/// and setters. 
	/// </summary>
	public static class Settings
	{
		private static ISettings AppSettings
		{
			get
			{
				return CrossSettings.Current;
			}
		}

		#region Setting Constants

		private const string TouchID_SettingsKey = nameof(UseTouchID);
		private static readonly bool TouchID_DefaultValue = false;

		#endregion


		public static bool UseTouchID
		{
			get
			{
				return AppSettings.GetValueOrDefault<bool>(TouchID_SettingsKey, TouchID_DefaultValue);
			}
			set
			{
				AppSettings.AddOrUpdateValue<bool>(TouchID_SettingsKey, value);
			}
		}
	}
}