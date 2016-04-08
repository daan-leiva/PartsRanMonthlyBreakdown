using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Odbc;

namespace PartsRanMonthlyBreakdown
{
    public partial class PartDetail : Form
    {
        private static string DSN = "jobboss32";
        private static string userName = "jbread";
        private static string password = "Cloudy2Day";
        string connection_string = "DSN=" + DSN + ";UID=" + userName + ";PWD=" + password;

        int month;
        int year;

        public PartDetail(int month, int year)
        {
            InitializeComponent();

            // set up variables
            this.month = month;
            this.year = year;
        }

        private void PartDetail_Load(object sender, EventArgs e)
        {
            string query = "SELECT jJ.Part_Number AS \"Part Number\", SUM(jT.Act_Run_Qty) AS \"Run Qty\"\n" +
                            "FROM PRODUCTION.dbo.Job_Operation AS jO\n" +
                            "LEFT JOIN PRODUCTION.dbo.Job_Operation_Time AS jT\n" +
                            "ON jO.Job_Operation = jT.Job_Operation\n" +
                            "LEFT JOIN PRODUCTION.dbo.Job AS jJ\n" +
                            "ON jO.Job = jJ.Job\n" +
                            "WHERE jT.Act_Run_Qty <> 0 AND CAST(jT.Work_Date AS DATETIME) >= CAST('" + year + "" + month.ToString("00") + "01 00:00:00.000' AS DATETIME) AND CAST(jT.Work_Date AS DATETIME) < CAST('"+year +(month == 1 ? 1 : 0)+"0501 00:00:00.000' AS DATETIME)\n" +
                            "GROUP BY jJ.Part_Number\n" +
                            "ORDER BY Part_Number;";

            using (OdbcConnection conn = new OdbcConnection(connection_string))
            using (OdbcDataAdapter adapter = new OdbcDataAdapter(query, conn))
            {
                DataTable table = new DataTable();
                adapter.Fill(table);

                dataGridView.DataSource = table;
            }
        }
    }
}
