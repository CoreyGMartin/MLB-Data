using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MLB_Data {
	class Program {
		static void Main(string[] args) {
			MLBWebClient client = new MLBWebClient();

			List<ScoreBoardData> scores = new List<ScoreBoardData>();
			for (int month = 7; month <= 12; ++month)
				for (int day = 1; day < 28; ++day) {
					scores.Add(client.GetScoreBoard(2016, month, day));
					//foreach (var game in scores.Last().data.games.game)
					//	if (game != null)
					//		if (game.game_media != null)
					//			if (game.game_media.media != null)
					//				Console.WriteLine(game.game_media.media.Count);
					//Console.WriteLine("");
				}
		}
	}
}
