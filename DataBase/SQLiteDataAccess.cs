using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using Dapper;

namespace ir_planner
{
    internal class SQLiteDataAccess
    {
        public static List<CarModel> LoadCars()
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<CarModel>("select * from Cars order by Name", new DynamicParameters());
                return output.ToList();
            }
        }

        public static List<TrackModel> LoadTracks()
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<TrackModel>("select * from Tracks order by Name", new DynamicParameters());
                return output.ToList();
            }
        }

        public static List<LeagueModel> LoadLeagues()
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<LeagueModel>("select * from LeaguesDataView", new DynamicParameters());
                return output.ToList();
            }
        }

        public static List<CarModel> LoadLeagueCars(LeagueModel league)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<CarModel>("SELECT Cars.ID,Cars.Name,Cars.isOwned FROM Cars_Leagues INNER JOIN Cars ON Car_ID = Cars.ID WHERE League_ID = @ID ORDER BY Name", league);
                return output.ToList();
            }
        }

        public static List<StatsModel> LoadMostUsedCar()
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<StatsModel>("select * from MostUsedCars", new DynamicParameters());
                return output.ToList();
            }
        }

        public static List<StatsModel> LoadMostUsedTrack()
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<StatsModel>("select * from MostUsedTracks", new DynamicParameters());
                return output.ToList();
            }
        }

        public static bool IsTrackOwned(String trackName)//placeholder
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                TrackModel tempTrack = new TrackModel();
                tempTrack.Name = trackName;
                var output = cnn.Query<TrackModel>("select * from Tracks where Name = @Name", tempTrack);
                List<TrackModel> temp = output.ToList();
                return temp[0].isOwned;
            }
        }

        public static void UpdateTrackInDB(TrackModel track)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                cnn.Execute("UPDATE Tracks SET isOwned = @isOwned WHERE ID = @ID ", track);
            }
        }

        public static void UpdateCarInDB(CarModel car)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                cnn.Execute("UPDATE Cars SET isOwned = @isOwned WHERE ID = @ID ", car);
            }
        }

        private static string LoadConnectionString(string id = "Default")
        {
            return ConfigurationManager.ConnectionStrings[id].ConnectionString;
        }
    }
}