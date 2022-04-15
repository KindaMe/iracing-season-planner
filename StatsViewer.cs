using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ir_planner
{
    public partial class StatsViewer : UserControl
    {
        public StatsViewer()
        {
            InitializeComponent();
        }

        private List<StatsModel> stats = new List<StatsModel>();
        private String title = "TITLE";
        private String description = "DESCRIPTION";

        public List<StatsModel> Stats
        {
            get
            {
                return stats;
            }
            set
            {
                stats = value;
                if (stats != null)
                {
                    if (stats.Count >= 3)
                    {
                        LABEL_1_NAME.Text = stats[0].Name;
                        LABEL_2_NAME.Text = stats[1].Name;
                        LABEL_3_NAME.Text = stats[2].Name;
                        LABEL_1_NUM.Text = stats[0].Counter.ToString();
                        LABEL_2_NUM.Text = stats[1].Counter.ToString();
                        LABEL_3_NUM.Text = stats[2].Counter.ToString();
                        stats.RemoveRange(0, 3);
                        dataGridView1.DataSource = stats;
                    }
                    else if (stats.Count == 2)
                    {
                        LABEL_1_NAME.Text = stats[0].Name;
                        LABEL_2_NAME.Text = stats[1].Name;
                        LABEL_3_NAME.Text = "";
                        LABEL_1_NUM.Text = stats[0].Counter.ToString();
                        LABEL_2_NUM.Text = stats[1].Counter.ToString();
                        LABEL_3_NUM.Text = "";
                        dataGridView1.DataSource = null;
                    }
                    else if (stats.Count == 1)
                    {
                        LABEL_1_NAME.Text = stats[0].Name;
                        LABEL_2_NAME.Text = "";
                        LABEL_3_NAME.Text = "";
                        LABEL_1_NUM.Text = stats[0].Counter.ToString();
                        LABEL_2_NUM.Text = "";
                        LABEL_3_NUM.Text = "";
                        dataGridView1.DataSource = null;
                    }
                    else if (stats.Count == 0)
                    {
                        LABEL_1_NAME.Text = "";
                        LABEL_2_NAME.Text = "";
                        LABEL_3_NAME.Text = "";
                        LABEL_1_NUM.Text = "";
                        LABEL_2_NUM.Text = "";
                        LABEL_3_NUM.Text = "";
                        dataGridView1.DataSource = null;
                    }
                }

                Invalidate();
            }
        }

        public String Title
        {
            get
            {
                return title;
            }
            set
            {
                title = value;
                LABEL_MAIN_NAME.Text = title.ToUpper();

                Invalidate();
            }
        }

        public String Description
        {
            get
            {
                return description;
            }
            set
            {
                description = value;
                LABEL_DESCRIPTION.Text = description.ToUpper();

                Invalidate();
            }
        }
    }
}