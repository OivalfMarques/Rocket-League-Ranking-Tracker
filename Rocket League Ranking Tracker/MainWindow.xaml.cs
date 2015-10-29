﻿using Rocket_League_Ranking_Tracker.Controller;
using Rocket_League_Ranking_Tracker.Model;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Rocket_League_Ranking_Tracker
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            string connectionString = @"Data Source =" + Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + @"\Data\database.db;Version=3;";
            SQLiteConnection dbConnection = new SQLiteConnection(connectionString);
            dbConnection.Open();
            

            RankingModel solo = new SoloRanking(dbConnection);
            RankingModel duals = new DualsRanking(dbConnection);
            RankingModel standard = new StandardRanking(dbConnection);

            ProcessController pc = new ProcessController();

            pc.AddRankingModel(solo);
            pc.AddRankingModel(duals);
            pc.AddRankingModel(standard);

            soloRanking.DataContext = solo;
            dualsRanking.DataContext = duals;
            standardRanking.DataContext = standard;

            //rm.RocketLeagueProcess = Process.GetProcessesByName("RocketLeague")[0];
            //rm.updateRanking();
            //;
        }
    }
}
