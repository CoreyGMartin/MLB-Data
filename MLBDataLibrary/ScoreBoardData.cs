﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MLBDataLibrary {
	public class ScoreBoardData {
		public DateTime date { get; set; } //added by Corey Martin, you can config JSON .NET to ignore this field!
		public string subject { get; set; }
		//public string copyright { get; set; } //Waste of memory
		public Data data { get; set; }
		public class Away {
			public string tv { get; set; }
			public string radio { get; set; }
		}

		public class Home {
			public string tv { get; set; }
			public string radio { get; set; }
		}

		public class Broadcast {
			public Away away { get; set; }
			public Home home { get; set; }
		}

		public class SavePitcher {
			public string id { get; set; }
			public string last { get; set; }
			public string saves { get; set; }
			public string losses { get; set; }
			public string era { get; set; }
			public string name_display_roster { get; set; }
			public string number { get; set; }
			public string svo { get; set; }
			public string first { get; set; }
			public string wins { get; set; }
		}
		public class Status {
			public string is_no_hitter { get; set; }
			public string top_inning { get; set; }
			public string s { get; set; }
			public string b { get; set; }
			public string reason { get; set; }
			public string ind { get; set; }
			public string status { get; set; }
			public string is_perfect_game { get; set; }
			public string o { get; set; }
			public string inning { get; set; }
			public string inning_state { get; set; }
			public string note { get; set; }
		}
		public class WinningPitcher {
			public string id { get; set; }
			public string last { get; set; }
			public string losses { get; set; }
			public string era { get; set; }
			public string number { get; set; }
			public string name_display_roster { get; set; }
			public string first { get; set; }
			public string wins { get; set; }
		}
		public class Medium {
			public string free { get; set; }
			public string title { get; set; }
			public string thumbnail { get; set; }
			public string media_state { get; set; }
			public string start { get; set; }
			public string has_mlbtv { get; set; }
			public string calendar_event_id { get; set; }
			public string enhanced { get; set; }
			public string type { get; set; }
			public string headline { get; set; }
			public string content_id { get; set; }
			public string topic_id { get; set; }
		}
		public class GameMedia {
			[JsonConverter(typeof(SingleOrArrayConverter<Medium>))]
			public List<Medium> media { get; set; }
		}

		public class Hr {
			public string home { get; set; }
			public string away { get; set; }
		}

		public class E {
			public string home { get; set; }
			public string away { get; set; }
		}

		public class So {
			public string home { get; set; }
			public string away { get; set; }
		}

		public class R {
			public string home { get; set; }
			public string away { get; set; }
			public string diff { get; set; }
		}

		public class Sb {
			public string home { get; set; }
			public string away { get; set; }
		}

		public class Inning {
			public string home { get; set; }
			public string away { get; set; }
		}

		public class H {
			public string home { get; set; }
			public string away { get; set; }
		}

		public class Linescore {
			public Hr hr { get; set; }
			public E e { get; set; }
			public So so { get; set; }
			public R r { get; set; }
			public Sb sb { get; set; }
			[JsonConverter(typeof(SingleOrArrayConverter<Inning>))]
			public List<Inning> inning { get; set; }
			public H h { get; set; }
		}

		public class Links {
			public string away_audio { get; set; }
			public string wrapup { get; set; }
			public string preview { get; set; }
			public string home_preview { get; set; }
			public string away_preview { get; set; }
			public string tv_station { get; set; }
			public string home_audio { get; set; }
			public string mlbtv { get; set; }
		}

		public class LosingPitcher {
			public string id { get; set; }
			public string last { get; set; }
			public string losses { get; set; }
			public string era { get; set; }
			public string number { get; set; }
			public string name_display_roster { get; set; }
			public string first { get; set; }
			public string wins { get; set; }
		}

		public class Thumbnail {
			public string content { get; set; }
			public string height { get; set; }
			public string scenario { get; set; }
			public string width { get; set; }
		}

		public class VideoThumbnails {
			[JsonConverter(typeof(SingleOrArrayConverter<Thumbnail>))]
			public List<Thumbnail> thumbnail { get; set; }
		}

		public class HomeRuns {
			public object player { get; set; }
		}

		public class Game {
			public string game_type { get; set; }
			public string double_header_sw { get; set; }
			public string location { get; set; }
			public string away_time { get; set; }
			public Broadcast broadcast { get; set; }
			public string away_league_id_spring { get; set; }
			public string time { get; set; }
			public string home_time { get; set; }
			public string home_team_name { get; set; }
			public string description { get; set; }
			public string original_date { get; set; }
			public string home_team_city { get; set; }
			public string venue_id { get; set; }
			public string gameday_sw { get; set; }
			public string away_win { get; set; }
			public string home_games_back_wildcard { get; set; }
			public SavePitcher save_pitcher { get; set; }
			public string home_league_id_spring { get; set; }
			public string away_team_id { get; set; }
			public string tz_hm_lg_gen { get; set; }
			public Status status { get; set; }
			public string home_loss { get; set; }
			public string home_games_back { get; set; }
			public string home_code { get; set; }
			public string away_sport_code { get; set; }
			public string home_win { get; set; }
			public string time_hm_lg { get; set; }
			public string away_name_abbrev { get; set; }
			public string league { get; set; }
			public string time_zone_aw_lg { get; set; }
			public string away_games_back { get; set; }
			public string away_split_squad { get; set; }
			public string home_file_code { get; set; }
			public string game_data_directory { get; set; }
			public string time_zone { get; set; }
			public string away_league_id { get; set; }
			public string home_team_id { get; set; }
			public string day { get; set; }
			public string time_aw_lg { get; set; }
			public string away_team_city { get; set; }
			public string tbd_flag { get; set; }
			public string tz_aw_lg_gen { get; set; }
			public string away_code { get; set; }
			public WinningPitcher winning_pitcher { get; set; }
			public GameMedia game_media { get; set; }
			public string game_nbr { get; set; }
			public string time_date_aw_lg { get; set; }
			public string away_games_back_wildcard { get; set; }
			public string scheduled_innings { get; set; }
			public Linescore linescore { get; set; }
			public string venue_w_chan_loc { get; set; }
			public string first_pitch_et { get; set; }
			public string away_team_name { get; set; }
			public string time_date_hm_lg { get; set; }
			public string id { get; set; }
			public string home_name_abbrev { get; set; }
			public string tiebreaker_sw { get; set; }
			public string ampm { get; set; }
			public string home_division { get; set; }
			public string home_split_squad { get; set; }
			public string home_time_zone { get; set; }
			public string away_time_zone { get; set; }
			public string hm_lg_ampm { get; set; }
			public string home_sport_code { get; set; }
			public string time_date { get; set; }
			public Links links { get; set; }
			public string home_ampm { get; set; }
			public string game_pk { get; set; }
			public string venue { get; set; }
			public string home_league_id { get; set; }
			public string video_thumbnail { get; set; }
			public string away_loss { get; set; }
			public string resume_date { get; set; }
			public string away_file_code { get; set; }
			public LosingPitcher losing_pitcher { get; set; }
			public string aw_lg_ampm { get; set; }
			public VideoThumbnails video_thumbnails { get; set; }
			public string time_zone_hm_lg { get; set; }
			public string away_ampm { get; set; }
			public string gameday { get; set; }
			public string away_division { get; set; }
			public HomeRuns home_runs { get; set; }
			public override string ToString() {
				return home_team_city + ", " + home_team_name + " vs " + away_team_city + ", " + away_team_name;
			}
		}

		public class Games {
			public string next_day_date { get; set; }
			public string modified_date { get; set; }
			public string month { get; set; }
			public string year { get; set; }
			[JsonConverter(typeof(SingleOrArrayConverter<Game>))]
			public List<Game> game { get; set; }
			public string day { get; set; }
		}

		public class Data {
			public Games games { get; set; }
		}
		public override string ToString() {
			return date.ToLongDateString();
		}
	}
}
