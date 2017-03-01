using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;
using System.ComponentModel;

namespace MLBDataLibrary {
	public class MLBCache {
		//private List<ScoreBoardData> cache;
		private MLBWebClient client;
		private const string FOLDER_NAME = "../../data/";
		private const string EXT = ".json";
		public Settings Settings { get; set; }
		public MLBCache() {
			//Initilize web client
			client = new MLBWebClient();
		}
		public List<ScoreBoardData> GetScoreBoardDataByYear(int year, Settings settings, BackgroundWorker bw) {
			List<ScoreBoardData> scores = null;

			if (settings.CachedYears.Contains(year)) {
				//ScoreBoard is in cache
				bw.ReportProgress(25);
				scores = OpenFile(year);

				//Check if cache update is necessary
				//NOTE: When the MLB website adds a day it doesn't add ALL the informationat once!
				if (year == DateTime.Now.Year) {
					bw.ReportProgress(50);

					DateTime lastDay = scores.Last().date;
					DateTime now = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);

					if (lastDay < now) {
						//Update cache
						lastDay = lastDay.AddDays(1);
						scores.AddRange(GetScoreBoardData(year, lastDay.Month, lastDay.Day));
						Save(year, scores);
					}
				}

			} else {
				//No cache available
				bw.ReportProgress(75);
				scores = GetScoreBoardData(year, 1, 1);

				//Add to cache.
				settings.AddYear(year);
				Save(year, scores);
			}

			bw.ReportProgress(100);

			return scores;
		}
		public List<ScoreBoardData> GetScoreBoardDataByYear(int year, Settings settings) {
			List<ScoreBoardData> scores = null;

			if (settings.CachedYears.Contains(year)) {
				//ScoreBoard is in cache
				scores = OpenFile(year);

				//Check if cache update is necessary
				if (year == DateTime.Now.Year) {

					DateTime lastDay = scores.Last().date;
					DateTime now = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);

					if (lastDay < now) {
						//Update cache
						lastDay = lastDay.AddDays(1);
						scores.AddRange(GetScoreBoardData(year, lastDay.Month, lastDay.Day));
						Save(year, scores);
					}
				}

			} else {
				//No cache available
				scores = GetScoreBoardData(year, 1, 1);

				//Add to cache.
				settings.AddYear(year);
				Save(year, scores);
			}

			return scores;
		}
		private List<ScoreBoardData> GetScoreBoardData(int year, int month, int day) {
			DateTime date = new DateTime(year, month, day);
			DateTime endDate = new DateTime(year, 12, 31);

			List<ScoreBoardData> scores = new List<ScoreBoardData>();
			for (; date < endDate && date < DateTime.Now; date = date.AddDays(1)) {
				ScoreBoardData score = client.GetScoreBoardsFromDay(date.Year, date.Month, date.Day);
				if (score != null && score.data.games.game != null && score.data.games.game.Count != 0)
					scores.Add(score);
			}

			return scores;
		}
		private List<ScoreBoardData> OpenFile(int year) {
			return JsonConvert.DeserializeObject<List<ScoreBoardData>>(File.ReadAllText(FOLDER_NAME + year + EXT));
		}
		private void Save(int year, List<ScoreBoardData> scores) {
			File.WriteAllText(FOLDER_NAME + year + EXT, JsonConvert.SerializeObject(scores));
		}
	}
}
