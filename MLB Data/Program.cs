using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MLB_Data {
	class Program {
		static void Main(string[] args) {
			MLBWebClient client = new MLBWebClient();
			MLBCache cache = new MLBCache();

			Dictionary<DateTime, ScoreBoardData> scores = new Dictionary<DateTime, ScoreBoardData>();

			var watch = System.Diagnostics.Stopwatch.StartNew();

			// MLB season starts beginning of April (first sunday) and ends first sunday in October. 
			// Playoffs begin right after and end near the first week of November
			int year = 2015;
			DateTime date = new DateTime(year, 3, 1);
			DateTime endDate = new DateTime(year, 11, 1);

			for (; date < endDate; date = date.AddDays(1)) {
				ScoreBoardData score = client.GetScoreBoard(date.Year, date.Month, date.Day);
				if (score.data.games.game != null && score.data.games.game.Count != 0)
					scores.Add(date, score);
			}

			watch.Stop();

			cache.Add(year, scores);
			cache.Save();

			Console.WriteLine("{0} MLB baseball games in {1}", scores.Count, year);
			Console.WriteLine(watch.ElapsedMilliseconds / 1000.0);

		}
	}
}
