using MLBDataLibrary;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.Remoting.Messaging;
using System.Threading;
using System.Windows;

namespace MLB_Scoreboard {
	public partial class MainWindow : Window {
		private MLBCache cache;
		private Settings settings;
		private BackgroundWorker bw;
		public MainWindow() {
			InitializeComponent();

			settings = Settings.GetInstance();
			cache = new MLBCache();

			//Configure Background Workers
			bw = new BackgroundWorker();
			bw.WorkerReportsProgress = true;
			bw.DoWork += Bw_DoWork;
			bw.RunWorkerCompleted += Bw_RunWorkerCompleted;
			bw.ProgressChanged += Bw_ProgressChanged; 
		}

		private void Bw_ProgressChanged(object sender, ProgressChangedEventArgs e) {
			//Need Backgroundwork to update progress bar
			switch (e.ProgressPercentage) {
				case 25:
					statusTextLbl.Content = "Opening scoreboards from cache";
					break;
				case 50:
					statusTextLbl.Content = "Updating cache";
					break;
				case 75:
					statusTextLbl.Content = "No cache available for selected year, creating cache, please wait";
					break;
				case 100:
					statusTextLbl.Content = "Scoreboards Loaded";
					break;
			}
		}

		private void Bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) {
			ObservableCollection<ScoreBoardData> scores = new ObservableCollection<ScoreBoardData>((List<ScoreBoardData>)e.Result);

			if (scores != null) {
				if (scores.Count == 0) {
					settings.LastSelectedYear = int.Parse(yearsCmbBx.SelectedItem.ToString());
					//No games available for that year
					DataContext = null;
					gameCmbBx.ItemsSource = null;
					statusTextLbl.Content = "No games available for this year";
				} else {
					settings.LastSelectedYear = int.Parse(yearsCmbBx.SelectedItem.ToString());
					DataContext = scores;
					datesLstBx.SelectedItem = datesLstBx.Items[0]; //first item
				}
			}

			//Enable combox box
			yearsCmbBx.IsEnabled = true;
		}

		private void Bw_DoWork(object sender, DoWorkEventArgs e) {
			List<ScoreBoardData> scores;
			scores = cache.GetScoreBoardDataByYear((int)e.Argument, settings, sender as BackgroundWorker);
			e.Result = scores;
		}

		private void Window_Loaded(object sender, RoutedEventArgs e) {
			//Create content for year combo box Starting with 1910. TODO change year to a sooner year!
			List<int> years = new List<int>();
			int currentYear = DateTime.Now.Year;
			for (int year = 1910; year <= currentYear; ++year)
				years.Add(year);
			years.Reverse();
			yearsCmbBx.ItemsSource = years;

			//Load scores using previously selected year
			if (settings.LastSelectedYear != 0) {
				yearsCmbBx.SelectedItem = settings.LastSelectedYear;
			}
		}

		private void yearsCmbBx_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e) {
			//reset status of program
			statusTextLbl.Content = "";
			//disable while thread is working
			yearsCmbBx.IsEnabled = false;
			bw.RunWorkerAsync((int)yearsCmbBx.SelectedItem);
		}

		private void datesLstBx_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e) {
			if (datesLstBx.SelectedItem != null) {
				gameCmbBx.ItemsSource = ((ScoreBoardData)datesLstBx.SelectedItem).data.games.game;
				gameCmbBx.SelectedItem = gameCmbBx.Items[0]; //first item
			}
		}
	}
}
