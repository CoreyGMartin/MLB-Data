using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MLB_Data {
	class Program {
		static void Main(string[] args) {
			MLBWebClient client = new MLBWebClient();
			Console.WriteLine(client.GetScoreBoard(2015, 12, 12));
		}
	}
}
