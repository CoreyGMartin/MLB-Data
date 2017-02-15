using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace MLB_Data {
	public class MLBWebClient {
		private const string YEAR = "year_";
		private const string MONTH = "month_";
		private const string DAY = "day_";
		private const string FILE_NAME = "master_scoreboard.json";
		private const string ENDPOINT = @"http://gd2.mlb.com/components/game/mlb/";

		private WebClient webClient;
		public StringBuilder endPointBuilder;

		public MLBWebClient() {
			webClient = new WebClient();
			endPointBuilder = new StringBuilder(ENDPOINT, 100);
		}
		public string GetScoreBoard(int year, int month, int day) {
			return webClient.DownloadString(
					endPointBuilder
						.Append(GenerateYearPath(year))
						.Append(GenerateMonthPath(month))
						.Append(GenerateDayPath(day))
						.Append(FILE_NAME)
						.ToString()
					);
		}
		private string GenerateYearPath(int year) {
			return YEAR + year + "/";
		}
		private string GenerateMonthPath(int month) {
			return MONTH + month + "/";
		}
		private string GenerateDayPath(int day) {
			return DAY + day + "/";
		}
	}
}
