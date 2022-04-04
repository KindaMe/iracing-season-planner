using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ir_planner
{
    public partial class Form1 : Form
    {
        private List<CarModel> cars = new List<CarModel>();
        private List<TrackModel> tracks = new List<TrackModel>();
        private List<LeagueModel> leagues = new List<LeagueModel>();
        private List<CarModel> leagueCars = new List<CarModel>();
        private int currentLeagueRowSelected = 0;

        private List<StatsModel> mostUsedCars = new List<StatsModel>();
        private List<StatsModel> mostUsedTracks = new List<StatsModel>();

        public Form1()
        {
            InitializeComponent();
            LoadCarList();
            LoadTrackList();
            LoadLeaguesList();
            LoadLeagueCarsList(leagues[currentLeagueRowSelected]);

            LoadStats();
        }

        private void UpdateLeagueColors()
        {
            //dataGridView_Leagues.ClearSelection();

            foreach (DataGridViewRow row in dataGridView_Leagues.Rows)
            {
                List<CarModel> temp = SQLiteDataAccess.LoadLeagueCars(leagues[row.Index]);
                int ownedCarsCount = 0;

                for (int i = 0; i < temp.Count; i++)
                {
                    if (temp[i].isOwned == true)
                    {
                        ownedCarsCount++;
                    }
                }

                if (ownedCarsCount > 0)
                {
                    row.Cells[1].Style.BackColor = Color.LightGreen;
                    row.Cells[1].Style.ForeColor = Color.Black;
                    row.Cells[1].Style.SelectionBackColor = Color.White;
                    row.Cells[1].Style.SelectionForeColor = Color.Green;
                }
                else
                {
                    row.Cells[1].Style.BackColor = Color.IndianRed;
                    row.Cells[1].Style.ForeColor = Color.Black;
                    row.Cells[1].Style.SelectionBackColor = Color.White;
                    row.Cells[1].Style.SelectionForeColor = Color.Red;
                }

                //tracks colors ph
                foreach (DataGridViewCell cell in row.Cells)
                {
                    if (cell.ColumnIndex > 2 && cell.Value != null)
                    {
                        bool isTrackOwned = SQLiteDataAccess.IsTrackOwned(cell.Value.ToString());

                        if (isTrackOwned == true && ownedCarsCount > 0)
                        {
                            cell.Style.BackColor = Color.LightGreen;
                            cell.Style.ForeColor = Color.Black;
                            cell.Style.SelectionBackColor = Color.White;
                            cell.Style.SelectionForeColor = Color.Green;
                        }
                        else if (isTrackOwned == true || ownedCarsCount > 0)
                        {
                            cell.Style.BackColor = Color.Orange;
                            cell.Style.ForeColor = Color.Black;
                            cell.Style.SelectionBackColor = Color.White;
                            cell.Style.SelectionForeColor = Color.Orange;
                        }
                        else
                        {
                            cell.Style.BackColor = Color.IndianRed;
                            cell.Style.ForeColor = Color.Black;
                            cell.Style.SelectionBackColor = Color.White;
                            cell.Style.SelectionForeColor = Color.Red;
                        }
                    }
                }

                //tcph end
            }
            dataGridView_Leagues.Refresh();
            //MessageBox.Show("Color Updated!");
        }

        private void LoadCarList()
        {
            cars = SQLiteDataAccess.LoadCars();
            dataGridView_Cars.DataSource = cars;
        }

        private void LoadTrackList()
        {
            tracks = SQLiteDataAccess.LoadTracks();
            dataGridView_Tracks.DataSource = tracks;
        }

        private void LoadLeaguesList()
        {
            leagues = SQLiteDataAccess.LoadLeagues();
            dataGridView_Leagues.DataSource = leagues;
        }

        private void LoadLeagueCarsList(LeagueModel league)
        {
            leagueCars = SQLiteDataAccess.LoadLeagueCars(league);
            dataGridView_SelectedCars.DataSource = leagueCars;
        }

        private void LoadStats()
        {
            mostUsedCars = SQLiteDataAccess.LoadMostUsedCar();
            dataGridView1.DataSource = mostUsedCars;

            mostUsedTracks = SQLiteDataAccess.LoadMostUsedTrack();
            dataGridView2.DataSource = mostUsedTracks;
        }

        private void dataGridView_Leagues_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != currentLeagueRowSelected)
            {
                currentLeagueRowSelected = e.RowIndex;
                LoadLeagueCarsList(leagues[currentLeagueRowSelected]);
            }
        }

        private void dataGridView_Leagues_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            UpdateLeagueColors();

            typeof(DataGridView).InvokeMember(
   "DoubleBuffered",
   BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.SetProperty,
   null,
   dataGridView_Leagues,
   new object[] { true });
        }

        private void dataGridView_Tracks_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dataGridView_Tracks.IsCurrentCellDirty)
            {
                dataGridView_Tracks.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void dataGridView_Tracks_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                SQLiteDataAccess.UpdateTrackInDB(tracks[e.RowIndex]);
                UpdateLeagueColors();
            }
        }

        private void dataGridView_Cars_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dataGridView_Cars.IsCurrentCellDirty)
            {
                dataGridView_Cars.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void dataGridView_Cars_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                SQLiteDataAccess.UpdateCarInDB(cars[e.RowIndex]);
                LoadLeagueCarsList(leagues[currentLeagueRowSelected]);
                UpdateLeagueColors();
            }
        }
    }
}