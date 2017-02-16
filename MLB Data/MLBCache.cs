using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

namespace MLB_Data {
	public class MLBCache {
		private Dictionary<int, Dictionary<DateTime, ScoreBoardData>> cache;
		private const string FILE_NAME = "MLBCache.json";
		public MLBCache() {
			cache = new Dictionary<int, Dictionary<DateTime, ScoreBoardData>>();
		}
		public void Add(int key, Dictionary<DateTime, ScoreBoardData> value) {
			cache.Add(key, value);
		}
		public void Save() {
			string contents = JsonConvert.SerializeObject(cache);

			File.WriteAllText(FILE_NAME, contents);
		}
	}
}
