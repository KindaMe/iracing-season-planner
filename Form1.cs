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
        private UserSettingsModel userSettings = new UserSettingsModel();

        private List<CarModel> cars = new List<CarModel>();
        private List<TrackModel> tracks = new List<TrackModel>();
        private List<LeagueModel> leagues = new List<LeagueModel>();
        private List<CarModel> leagueCars = new List<CarModel>();
        private int currentLeagueRowSelected = 0;

        private List<StatsModel> mostUsedCars = new List<StatsModel>();
        private List<StatsModel> mostUsedTracks = new List<StatsModel>();
        private List<StatsModel> bestValueCars = new List<StatsModel>();
        private List<StatsModel> bestValueTracks = new List<StatsModel>();

        public Form1()
        {
            InitializeComponent();
            LoadUserSettings();
            LoadCarList();
            LoadTrackList();
            LoadLeaguesList();

            foreach (ToolStripMenuItem item in filtersToolStripMenuItem.DropDownItems.OfType<ToolStripMenuItem>().ToList())
            {
                item.DropDownItems.OfType<ToolStripMenuItem>().ToList().ForEach(c => c.CheckedChanged += C_CheckedChanged);
            }
        }

        //FORM
        private void Form1_Load(object sender, EventArgs e)
        {
            RefreshLeagueFilters();
        }

        private void LoadUserSettings()
        {
            userSettings = SQLiteDataAccess.LoadUserSettings();
            aToolStripMenuItem.Checked = userSettings.FILTER_CLASS_A;
            bToolStripMenuItem.Checked = userSettings.FILTER_CLASS_B;
            cToolStripMenuItem.Checked = userSettings.FILTER_CLASS_C;
            dToolStripMenuItem.Checked = userSettings.FILTER_CLASS_D;
            rToolStripMenuItem.Checked = userSettings.FILTER_CLASS_R;
            roadToolStripMenuItem.Checked = userSettings.FILTER_TYPE_ROAD;
            ovalToolStripMenuItem.Checked = userSettings.FILTER_TYPE_OVAL;
            dirtRoadToolStripMenuItem.Checked = userSettings.FILTER_TYPE_ROAD_DIRT;
            dirtOvalToolStripMenuItem.Checked = userSettings.FILTER_TYPE_OVAL_DIRT;
            onlyAvailableToolStripMenuItem.Checked = userSettings.FILTER_AVAILABLE_ONLY;
        }

        private void UpdateUserSettings()
        {
            userSettings.FILTER_CLASS_A = aToolStripMenuItem.Checked;
            userSettings.FILTER_CLASS_B = bToolStripMenuItem.Checked;
            userSettings.FILTER_CLASS_C = cToolStripMenuItem.Checked;
            userSettings.FILTER_CLASS_D = dToolStripMenuItem.Checked;
            userSettings.FILTER_CLASS_R = rToolStripMenuItem.Checked;
            userSettings.FILTER_TYPE_ROAD = roadToolStripMenuItem.Checked;
            userSettings.FILTER_TYPE_OVAL = ovalToolStripMenuItem.Checked;
            userSettings.FILTER_TYPE_ROAD_DIRT = dirtRoadToolStripMenuItem.Checked;
            userSettings.FILTER_TYPE_OVAL_DIRT = dirtOvalToolStripMenuItem.Checked;
            userSettings.FILTER_AVAILABLE_ONLY = onlyAvailableToolStripMenuItem.Checked;
        }

        private void tabControl1_Selected(object sender, TabControlEventArgs e)
        {
            if (e.TabPage.Text == "Schedule")
            {
                filtersToolStripMenuItem.Enabled = true;
                availableToolStripMenuItem.Enabled = true;
                UpdateLeagueColors();
                RefreshLeagueFilters();
            }
            else if (e.TabPage.Text == "Statistics")
            {
                filtersToolStripMenuItem.Enabled = true;
                availableToolStripMenuItem.Enabled = false;

                LoadStats();
            }
            else if (e.TabPage.Text == "Manage")
            {
                filtersToolStripMenuItem.Enabled = false;
            }
        }

        private void C_CheckedChanged(object sender, EventArgs e)
        {
            UpdateUserSettings();
            SQLiteDataAccess.UpdateUserSettings(userSettings);

            if (tabControl1.SelectedTab.Text == "Schedule")
                RefreshLeagueFilters();
            else if (tabControl1.SelectedTab.Text == "Statistics")
                LoadStats();
        }

        //LEAGUE TAB
        private void LoadLeaguesList()
        {
            leagues = SQLiteDataAccess.LoadLeagues();
            dataGridView_Leagues.DataSource = leagues;
        }

        private void UpdateLeagueColors()
        {
            foreach (DataGridViewRow row in dataGridView_Leagues.Rows)
            {
                //league colors ph
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

                //track colors ph
                foreach (DataGridViewCell cell in row.Cells)
                {
                    if (cell.ColumnIndex > 3 && cell.Value != null)
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
            }
            dataGridView_Leagues.Refresh();
        }

        private void LoadLeagueCarsList(LeagueModel league)
        {
            leagueCars = SQLiteDataAccess.LoadLeagueCars(league);
            dataGridView_SelectedCars.DataSource = leagueCars;

            foreach (DataGridViewRow row in dataGridView_SelectedCars.Rows)
            {
                if ((bool)row.Cells[1].Value == true)
                {
                    row.Cells[2].Style.BackColor = Color.LightGreen;
                    row.Cells[2].Style.ForeColor = Color.Black;
                    row.Cells[2].Style.SelectionBackColor = Color.LightGreen;
                    row.Cells[2].Style.SelectionForeColor = Color.Black;
                }
                else
                {
                    row.Cells[2].Style.BackColor = Color.IndianRed;
                    row.Cells[2].Style.ForeColor = Color.Black;
                    row.Cells[2].Style.SelectionBackColor = Color.IndianRed;
                    row.Cells[2].Style.SelectionForeColor = Color.Black;
                }
            }
        }

        private void LoadLeagueCarsList()
        {
            leagueCars = null;
            dataGridView_SelectedCars.DataSource = null;
        }

        private void LeagueFilterUpdate()
        {
            CurrencyManager currencyManager = (CurrencyManager)BindingContext[dataGridView_Leagues.DataSource];
            currencyManager.SuspendBinding();

            for (int u = 0; u < dataGridView_Leagues.RowCount; u++)
            {
                dataGridView_Leagues.Rows[u].Visible = true;
            }

            for (int u = 0; u < dataGridView_Leagues.RowCount; u++)
            {
                if (FilterChecker(dataGridView_Leagues.Rows[u].Cells[2].Value.ToString(), dataGridView_Leagues.Rows[u].Cells[3].Value.ToString(), dataGridView_Leagues.Rows[u].Cells[1].Style.BackColor == Color.LightGreen, false))
                {
                    dataGridView_Leagues.Rows[u].Visible = true;
                }
                else
                {
                    dataGridView_Leagues.Rows[u].Visible = false;
                }
            }

            currencyManager.ResumeBinding();
        }

        private void RefreshLeagueFilters()
        {
            LeagueFilterUpdate();
            dataGridView_Leagues.ClearSelection();
            LoadLeagueCarsList();
        }

        private bool FilterChecker(string LicenseToCheck, string LeagueTypeToCheck, bool Available, bool StatsMode)
        {
            if (StatsMode == false)
            {
                if (onlyAvailableToolStripMenuItem.Checked == true && Available == false)
                {
                    return false;
                }
            }

            switch (LicenseToCheck)
            {
                case "A":
                    if (!aToolStripMenuItem.Checked)
                    {
                        return false;
                    }
                    break;

                case "B":
                    if (!bToolStripMenuItem.Checked)
                    {
                        return false;
                    }
                    break;

                case "C":
                    if (!cToolStripMenuItem.Checked)
                    {
                        return false;
                    }
                    break;

                case "D":
                    if (!dToolStripMenuItem.Checked)
                    {
                        return false;
                    }
                    break;

                case "R":
                    if (!rToolStripMenuItem.Checked)
                    {
                        return false;
                    }
                    break;

                default:
                    MessageBox.Show("License Filter Error");
                    break;
            }

            switch (LeagueTypeToCheck)
            {
                case "Road":
                    if (!roadToolStripMenuItem.Checked)
                    {
                        return false;
                    }
                    break;

                case "Oval":
                    if (!ovalToolStripMenuItem.Checked)
                    {
                        return false;
                    }
                    break;

                case "Dirt Road":
                    if (!dirtRoadToolStripMenuItem.Checked)
                    {
                        return false;
                    }
                    break;

                case "Dirt Oval":
                    if (!dirtOvalToolStripMenuItem.Checked)
                    {
                        return false;
                    }
                    break;

                default:
                    MessageBox.Show("Type Filter Error");
                    break;
            }

            return true;
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

            typeof(DataGridView).InvokeMember("DoubleBuffered", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.SetProperty, null, dataGridView_Leagues, new object[] { true });
        }

        //MANAGE TAB
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
                RefreshManageColors();
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
                RefreshManageColors();
            }
        }

        private void dataGridView_Cars_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView_Tracks.ClearSelection();
            Label_Manage_Name.Text = (string)dataGridView_Cars.Rows[e.RowIndex].Cells[2].Value;
            Label_Manage_Type.Text = "CAR";
            RefreshManageColors();
        }

        private void dataGridView_Tracks_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView_Cars.ClearSelection();
            Label_Manage_Name.Text = (string)dataGridView_Tracks.Rows[e.RowIndex].Cells[2].Value;
            Label_Manage_Type.Text = "TRACK";
            RefreshManageColors();
        }

        private void RefreshManageColors()
        {
            DataGridViewSelectedRowCollection selectedTracks = dataGridView_Tracks.SelectedRows;
            DataGridViewSelectedRowCollection selectedCars = dataGridView_Cars.SelectedRows;

            if (selectedTracks.Count > 0)
            {
                if ((bool)selectedTracks[0].Cells[1].Value == true)
                {
                    Label_Manage_Name.BackColor = Color.LightGreen;
                }
                else
                {
                    Label_Manage_Name.BackColor = Color.IndianRed;
                }
            }
            else if (selectedCars.Count > 0)
            {
                if ((bool)selectedCars[0].Cells[1].Value == true)
                {
                    Label_Manage_Name.BackColor = Color.LightGreen;
                }
                else
                {
                    Label_Manage_Name.BackColor = Color.IndianRed;
                }
            }
        }

        private void dataGridView_Tracks_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            RefreshManageColors();
        }

        private void dataGridView_Cars_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            RefreshManageColors();
        }

        //STATS TAB
        private void LoadStats()
        {
            mostUsedCars = SQLiteDataAccess.LoadMostUsedCar();
            statsViewer1.FirstPlaceNumber = mostUsedCars[0].Counter;
            statsViewer1.FirstPlaceText = mostUsedCars[0].Name;
            statsViewer1.SecondPlaceNumber = mostUsedCars[1].Counter;
            statsViewer1.SecondPlaceText = mostUsedCars[1].Name;
            statsViewer1.ThirdPlaceNumber = mostUsedCars[2].Counter;
            statsViewer1.ThirdPlaceText = mostUsedCars[2].Name;

            mostUsedTracks = SQLiteDataAccess.LoadMostUsedTrack();
            statsViewer2.FirstPlaceText = mostUsedTracks[0].Name;
            statsViewer2.FirstPlaceNumber = mostUsedTracks[0].Counter;
            statsViewer2.SecondPlaceText = mostUsedTracks[1].Name;
            statsViewer2.SecondPlaceNumber = mostUsedTracks[1].Counter;
            statsViewer2.ThirdPlaceText = mostUsedTracks[2].Name;
            statsViewer2.ThirdPlaceNumber = mostUsedTracks[2].Counter;

            bestValueCars = GetBestValueCar();
            if (bestValueCars.Count > 2)
            {
                statsViewer3.ThirdPlaceText = bestValueCars[2].Name;
                statsViewer3.ThirdPlaceNumber = bestValueCars[2].Counter;
                statsViewer3.SecondPlaceText = bestValueCars[1].Name;
                statsViewer3.SecondPlaceNumber = bestValueCars[1].Counter;
                statsViewer3.FirstPlaceText = bestValueCars[0].Name;
                statsViewer3.FirstPlaceNumber = bestValueCars[0].Counter;
            }
            else
            {
                if (bestValueCars.Count > 1)
                {
                    statsViewer3.ThirdPlaceText = "";
                    statsViewer3.ThirdPlaceNumber = 0;
                    statsViewer3.SecondPlaceText = bestValueCars[1].Name;
                    statsViewer3.SecondPlaceNumber = bestValueCars[1].Counter;
                    statsViewer3.FirstPlaceText = bestValueCars[0].Name;
                    statsViewer3.FirstPlaceNumber = bestValueCars[0].Counter;
                }
                else
                {
                    if (bestValueCars.Count > 0)
                    {
                        statsViewer3.ThirdPlaceText = "";
                        statsViewer3.ThirdPlaceNumber = 0;
                        statsViewer3.SecondPlaceText = "";
                        statsViewer3.SecondPlaceNumber = 0;
                        statsViewer3.FirstPlaceText = bestValueCars[0].Name;
                        statsViewer3.FirstPlaceNumber = bestValueCars[0].Counter;
                    }
                    else
                    {
                        statsViewer3.ThirdPlaceText = "";
                        statsViewer3.ThirdPlaceNumber = 0;
                        statsViewer3.SecondPlaceText = "";
                        statsViewer3.SecondPlaceNumber = 0;
                        statsViewer3.FirstPlaceText = "";
                        statsViewer3.FirstPlaceNumber = 0;
                    }
                }
            }

            bestValueTracks = GetBestValueTrack();
            if (bestValueTracks.Count > 2)
            {
                statsViewer4.ThirdPlaceText = bestValueTracks[2].Name;
                statsViewer4.ThirdPlaceNumber = bestValueTracks[2].Counter;
                statsViewer4.SecondPlaceText = bestValueTracks[1].Name;
                statsViewer4.SecondPlaceNumber = bestValueTracks[1].Counter;
                statsViewer4.FirstPlaceText = bestValueTracks[0].Name;
                statsViewer4.FirstPlaceNumber = bestValueTracks[0].Counter;
            }
            else
            {
                if (bestValueTracks.Count > 1)
                {
                    statsViewer4.ThirdPlaceText = "";
                    statsViewer4.ThirdPlaceNumber = 0;
                    statsViewer4.SecondPlaceText = bestValueTracks[1].Name;
                    statsViewer4.SecondPlaceNumber = bestValueTracks[1].Counter;
                    statsViewer4.FirstPlaceText = bestValueTracks[0].Name;
                    statsViewer4.FirstPlaceNumber = bestValueTracks[0].Counter;
                }
                else
                {
                    if (bestValueTracks.Count > 0)
                    {
                        statsViewer4.ThirdPlaceText = "";
                        statsViewer4.ThirdPlaceNumber = 0;
                        statsViewer4.SecondPlaceText = "";
                        statsViewer4.SecondPlaceNumber = 0;
                        statsViewer4.FirstPlaceText = bestValueTracks[0].Name;
                        statsViewer4.FirstPlaceNumber = bestValueTracks[0].Counter;
                    }
                    else
                    {
                        statsViewer4.ThirdPlaceText = "";
                        statsViewer4.ThirdPlaceNumber = 0;
                        statsViewer4.SecondPlaceText = "";
                        statsViewer4.SecondPlaceNumber = 0;
                        statsViewer4.FirstPlaceText = "";
                        statsViewer4.FirstPlaceNumber = 0;
                    }
                }
            }
        }

        private List<StatsModel> GetBestValueCar()
        {
            List<StatsModel> statsModels = new List<StatsModel>();

            foreach (DataGridViewRow row in dataGridView_Leagues.Rows)
            {
                //filter test
                LeagueModel LeagueInCurrentRow = (LeagueModel)row.DataBoundItem;
                if (!FilterChecker(LeagueInCurrentRow.License.ToString(), LeagueInCurrentRow.Type, false, true))
                {
                    continue;
                }
                //

                List<CarModel> CarsInLeague = SQLiteDataAccess.LoadLeagueCars(leagues[row.Index]);
                int ownedCarsCount = 0;

                for (int i = 0; i < CarsInLeague.Count; i++)
                {
                    if (CarsInLeague[i].isOwned == true)
                    {
                        ownedCarsCount++;
                    }
                }

                if (ownedCarsCount == 0)
                {
                    foreach (CarModel car in CarsInLeague)
                    {
                        if (statsModels.Exists(x => x.Name == car.Name))
                        {
                            statsModels.Find(x => x.Name == car.Name).Counter++;
                        }
                        else
                        {
                            StatsModel tempModel = new StatsModel
                            {
                                Counter = 1,
                                Name = car.Name
                            };
                            statsModels.Add(tempModel);
                        }
                    }
                }
            }
            statsModels.Sort((x, y) => y.Counter.CompareTo(x.Counter));

            //foreach (StatsModel obj in statsModels)
            //{
            //    MessageBox.Show(obj.Name + ": " + obj.Counter);
            //}

            return statsModels;
        }

        private List<StatsModel> GetBestValueTrack()
        {
            //unlocks most races you were missing only track for

            List<StatsModel> statsModels = new List<StatsModel>();

            foreach (DataGridViewRow row in dataGridView_Leagues.Rows)
            {
                //filter test
                LeagueModel LeagueInCurrentRow = (LeagueModel)row.DataBoundItem;
                if (!FilterChecker(LeagueInCurrentRow.License.ToString(), LeagueInCurrentRow.Type, false, true))
                {
                    continue;
                }
                //

                List<CarModel> CarsInLeague = SQLiteDataAccess.LoadLeagueCars(leagues[row.Index]);
                int ownedCarsCount = 0;

                for (int i = 0; i < CarsInLeague.Count; i++)
                {
                    if (CarsInLeague[i].isOwned == true)
                    {
                        ownedCarsCount++;
                    }
                }

                if (ownedCarsCount > 0)
                {
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        if (cell.ColumnIndex > 3 && cell.Value != null)
                        {
                            bool isTrackOwned = SQLiteDataAccess.IsTrackOwned(cell.Value.ToString());

                            if (isTrackOwned == false)
                            {
                                if (statsModels.Exists(x => x.Name == cell.Value.ToString()))
                                {
                                    statsModels.Find(x => x.Name == cell.Value.ToString()).Counter++;
                                }
                                else
                                {
                                    StatsModel tempModel = new StatsModel
                                    {
                                        Counter = 1,
                                        Name = cell.Value.ToString()
                                    };
                                    statsModels.Add(tempModel);
                                }
                            }
                        }
                    }
                }
            }

            statsModels.Sort((x, y) => y.Counter.CompareTo(x.Counter));

            return statsModels;
        }
    }
}