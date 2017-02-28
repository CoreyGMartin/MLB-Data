using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MLBDataLibrary {
	public class Settings {
		private const string SETTINGS = "../../settings.json";

		private static Settings settings; //singleton
		private int lastSelectedYear;
		private List<int> cachedYears = new List<int>();

		public int LastSelectedYear { get { return lastSelectedYear; } set { lastSelectedYear = value; SaveSettings(); } }
		public List<int> CachedYears { get { return cachedYears; } set { CachedYears = value; SaveSettings();  } }

		public static Settings GetInstance() {
			if (settings == null) {
				//Open settings
				settings = JsonConvert.DeserializeObject<Settings>(File.ReadAllText(SETTINGS));
			}
			return settings;
		}
		public void AddYear(int year) {
			CachedYears.Add(year);
			SaveSettings();
		}
		private void SaveSettings() {
			File.WriteAllText(SETTINGS, JsonConvert.SerializeObject(settings));
		}
	}
}
