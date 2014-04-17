namespace Volans.Common {
	using System;
	using System.Collections;
	using System.Diagnostics;
	using System.Configuration;
	using System.Xml;
	using System.Collections.Specialized;

	/// <summary>
	/// Summary description for AppConfig.
	/// </summary>
	public class AppConfig : IConfigurationSectionHandler {

		private const String DATAACCESS_CONNECTIONSTRING   = "Volans.DataAccess.ConnectionString";

		private const String DATAACCESS_CONNECTIONSTRING_DEFAULT   = "server=localhost; User ID=dbo;database=BSSE";
		public static String dbConnString;
		private static bool isConfigLoaded = false;


		public AppConfig() {
		}

		public Object Create(Object parent, object configContext, XmlNode section) {
            
			NameValueCollection settings;
            
			try {
				NameValueSectionHandler baseHandler = new NameValueSectionHandler();
				settings = (NameValueCollection)baseHandler.Create(parent, configContext, section);
			} catch {
				settings = null;
			}
            
			if ( settings == null ) {
				throw new ConfigurationException("Incorrect or absent application configuration section");
			} else {
				dbConnString = AppConfig.ReadSetting(settings, DATAACCESS_CONNECTIONSTRING, DATAACCESS_CONNECTIONSTRING_DEFAULT);
			}
			return settings;
		}
		
		public static String ReadSetting(NameValueCollection logSetings, String key, String defaultValue) {
			try {
				Object setting = logSetings[key];
				return (setting == null) ? defaultValue : (String)setting;
			} catch {
				return defaultValue;
			}
		}

		/// <summary>
		///     int version of ReadSetting.
		/// </summary>
		public static int ReadSetting(NameValueCollection logSetings, String key, int defaultValue) {
			try {
				Object setting = logSetings[key];
                
				return (setting == null) ? defaultValue : Convert.ToInt32((String)setting);
			} catch {
				return defaultValue;
			}
		}

		/// <summary>
		///     bool version of ReadSetting.
		/// </summary>
		public static bool ReadSetting(NameValueCollection logSetings, String key, bool defaultValue) {
			try {
				Object setting = logSetings[key];
                
				return (setting == null) ? defaultValue : Convert.ToBoolean((String)setting);
			} catch {
				return defaultValue;
			}
		}
		public static void OnApplicationStart() {
			if (!isConfigLoaded) {
				lock(typeof(AppConfig)) {
					System.Configuration.ConfigurationSettings.GetConfig("AppConfiguration");
					isConfigLoaded = true;
				}
			}
		}

	}
}
