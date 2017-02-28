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

			//Configure Background Worker
			bw = new BackgroundWorker();
			bw.WorkerReportsProgress = true;
			bw.DoWork += Bw_DoWork;
			bw.RunWorkerCompleted += Bw_RunWorkerCompleted;
			bw.ProgressChanged += Bw_ProgressChanged;
		}

		private void Bw_ProgressChanged(object sender, ProgressChangedEventArgs e) {
			progressBar.Value = e.ProgressPercentage;
		}

		private void Bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) {
			ObservableCollection<ScoreBoardData> scores = new ObservableCollection<ScoreBoardData>((List<ScoreBoardData>)e.Result);

			DataContext = scores;
			listBox.SelectedItem = listBox.Items[0]; //first item

			//Enable combox box
			yearsCmbBx.IsEnabled = true;
			gameCmbBx.IsEnabled = true;
		}

		private void Bw_DoWork(object sender, DoWorkEventArgs e) {
			List<ScoreBoardData> scores;
			scores = cache.GetScoreBoardDataByYear(settings.LastSelectedYear, settings);
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
			//disable while thread is working
			yearsCmbBx.IsEnabled = false; 
			gameCmbBx.IsEnabled = false;

			settings.LastSelectedYear = int.Parse(yearsCmbBx.SelectedItem.ToString());
			bw.RunWorkerAsync();
		}

		private void listBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e) {
			if (listBox.SelectedItem != null) {
				gameCmbBx.ItemsSource = ((ScoreBoardData)listBox.SelectedItem).data.games.game;
				gameCmbBx.SelectedItem = gameCmbBx.Items[0]; //first item
			}
		}
	}
}
