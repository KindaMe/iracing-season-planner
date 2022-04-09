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

            groupBox_Filter_License.Controls.OfType<CheckBox>().ToList().ForEach(c => c.CheckedChanged += C_CheckedChanged);
            groupBox_Filter_Type.Controls.OfType<CheckBox>().ToList().ForEach(c => c.CheckedChanged += C_CheckedChanged);
            LoadStats();
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

        private void LoadLeagueCarsList()
        {
            leagueCars = null;
            dataGridView_SelectedCars.DataSource = null;
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
                LoadStats();
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
                LoadStats();
            }
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
                if (FilterChecker(dataGridView_Leagues.Rows[u].Cells[2].Value.ToString(), dataGridView_Leagues.Rows[u].Cells[3].Value.ToString()))
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

        private bool FilterChecker(string LicenseToCheck, string LeagueTypeToCheck)
        {
            switch (LicenseToCheck)
            {
                case "A":
                    if (!checkBox_LicenseA.Checked)
                    {
                        return false;
                    }
                    break;

                case "B":
                    if (!checkBox_LicenseB.Checked)
                    {
                        return false;
                    }
                    break;

                case "C":
                    if (!checkBox_LicenseC.Checked)
                    {
                        return false;
                    }
                    break;

                case "D":
                    if (!checkBox_LicenseD.Checked)
                    {
                        return false;
                    }
                    break;

                case "R":
                    if (!checkBox_LicenseR.Checked)
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
                    if (!checkBox_TypeRoad.Checked)
                    {
                        return false;
                    }
                    break;

                case "Oval":
                    if (!checkBox_TypeOval.Checked)
                    {
                        return false;
                    }
                    break;

                case "Dirt Road":
                    if (!checkBox_TypeRoadDirt.Checked)
                    {
                        return false;
                    }
                    break;

                case "Dirt Oval":
                    if (!checkBox_TypeOvalDirt.Checked)
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

        private void C_CheckedChanged(object sender, EventArgs e)
        {
            LeagueFilterUpdate();
            dataGridView_Leagues.ClearSelection();
            LoadLeagueCarsList();
        }

        private void tabControl1_Selected(object sender, TabControlEventArgs e)
        {
            if (e.TabPage.Text == "Schedule")
            {
                UpdateLeagueColors();
            }
        }
    }
}