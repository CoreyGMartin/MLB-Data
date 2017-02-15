using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MLB_Data {
	public class MLBCache : Dictionary<int, Dictionary<string, string>> {
		private static MLBCache cache;
		public static MLBCache Instance() {
			if (cache == null) {
				//IO Operations
				
			}
			return cache;
		}

	}
}
