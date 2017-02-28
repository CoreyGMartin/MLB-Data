using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using Newtonsoft.Json;

namespace MLB_Data {
	public class MLBWebClient {
		private const string YEAR = "year_";
		private const string MONTH = "month_";
		private const string DAY = "day_";
		private const string FILE_NAME = "master_scoreboard.json";
		private const string ENDPOINT = @"http://gd2.mlb.com/components/game/mlb/";

		private WebClient webClient;

		public MLBWebClient() {
			webClient = new WebClient();
		}
		public ScoreBoardData GetScoreBoard(int year, int month, int day) {
			StringBuilder endPointBuilder = new StringBuilder(ENDPOINT, 90);
			string address = endPointBuilder.Append(GenerateYearPath(year)).Append(GenerateMonthPath(month)).Append(GenerateDayPath(day)).Append(FILE_NAME).ToString();
			string json = webClient.DownloadString(address).Replace("{}", "null"); //MLB api treats {} as null

			ScoreBoardData score = JsonConvert.DeserializeObject<ScoreBoardData>(json);
			/**
			JsonSerializerSettings settings = new JsonSerializerSettings();
			settings.MissingMemberHandling = MissingMemberHandling.Error;
			settings.CheckAdditionalContent = true;
			ScoreBoardData score = null;

			try {
				score = JsonConvert.DeserializeObject<ScoreBoardData>(json, settings);
			} catch (Exception ex) {
				Console.WriteLine(ex.Message);
			}
			*/

			return score;
		}
		private string GenerateYearPath(int year) {
			return YEAR + year + "/";
		}
		private string GenerateMonthPath(int month) {
			if (month < 10)
				return MONTH +  "0" + month + "/";
			else 
				return MONTH + month + "/";
		}
		private string GenerateDayPath(int day) {
			if (day < 10)
				return DAY + "0" + day + "/";
			else
				return DAY + day + "/";
		}
	}
}
