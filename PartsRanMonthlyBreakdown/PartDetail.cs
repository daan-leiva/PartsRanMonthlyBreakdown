using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PartsRanMonthlyBreakdown
{
    public partial class PartDetail : Form
    {
        public PartDetail()
        {
            InitializeComponent();
        }

        private void PartDetail_Load(object sender, EventArgs e)
        {
            string query = "SELECT SUM(CASE WHEN (CAST(jT.Work_Date AS DATETIME) >= CAST('20150401 00:00:00.000' AS DATETIME) AND CAST(jT.Work_Date AS DATETIME) < CAST('20150501 00:00:00.000' AS DATETIME)) THEN jT.Act_Run_Qty ELSE 0 END) AS April_15,\n" +
                                    "\tSUM(CASE WHEN (CAST(jT.Work_Date AS DATETIME) >= CAST('20150501 00:00:00.000' AS DATETIME) AND CAST(jT.Work_Date AS DATETIME) < CAST('20150601 00:00:00.000' AS DATETIME)) THEN jT.Act_Run_Qty ELSE 0 END) AS May_15,\n" +
                                    "\tSUM(CASE WHEN (CAST(jT.Work_Date AS DATETIME) >= CAST('20150601 00:00:00.000' AS DATETIME) AND CAST(jT.Work_Date AS DATETIME) < CAST('20150701 00:00:00.000' AS DATETIME)) THEN jT.Act_Run_Qty ELSE 0 END) AS June_15,\n" +
                                    "\tSUM(CASE WHEN (CAST(jT.Work_Date AS DATETIME) >= CAST('20150701 00:00:00.000' AS DATETIME) AND CAST(jT.Work_Date AS DATETIME) < CAST('20150801 00:00:00.000' AS DATETIME)) THEN jT.Act_Run_Qty ELSE 0 END) AS July_15,\n" +
                                    "\tSUM(CASE WHEN (CAST(jT.Work_Date AS DATETIME) >= CAST('20150801 00:00:00.000' AS DATETIME) AND CAST(jT.Work_Date AS DATETIME) < CAST('20150901 00:00:00.000' AS DATETIME)) THEN jT.Act_Run_Qty ELSE 0 END) AS August_15,\n" +
                                    "\tSUM(CASE WHEN (CAST(jT.Work_Date AS DATETIME) >= CAST('20150901 00:00:00.000' AS DATETIME) AND CAST(jT.Work_Date AS DATETIME) < CAST('20151001 00:00:00.000' AS DATETIME)) THEN jT.Act_Run_Qty ELSE 0 END) AS September_15,\n" +
                                    "\tSUM(CASE WHEN (CAST(jT.Work_Date AS DATETIME) >= CAST('20151001 00:00:00.000' AS DATETIME) AND CAST(jT.Work_Date AS DATETIME) < CAST('20151101 00:00:00.000' AS DATETIME)) THEN jT.Act_Run_Qty ELSE 0 END) AS October_15,\n" +
                                    "\tSUM(CASE WHEN (CAST(jT.Work_Date AS DATETIME) >= CAST('20151101 00:00:00.000' AS DATETIME) AND CAST(jT.Work_Date AS DATETIME) < CAST('20151201 00:00:00.000' AS DATETIME)) THEN jT.Act_Run_Qty ELSE 0 END) AS November_15,\n" +
                                    "\tSUM(CASE WHEN (CAST(jT.Work_Date AS DATETIME) >= CAST('20151201 00:00:00.000' AS DATETIME) AND CAST(jT.Work_Date AS DATETIME) < CAST('20160101 00:00:00.000' AS DATETIME)) THEN jT.Act_Run_Qty ELSE 0 END) AS December_15,\n" +
                                    "\tSUM(CASE WHEN (CAST(jT.Work_Date AS DATETIME) >= CAST('20160101 00:00:00.000' AS DATETIME) AND CAST(jT.Work_Date AS DATETIME) < CAST('20160201 00:00:00.000' AS DATETIME)) THEN jT.Act_Run_Qty ELSE 0 END) AS January_16,\n" +
                                    "\tSUM(CASE WHEN (CAST(jT.Work_Date AS DATETIME) >= CAST('20160201 00:00:00.000' AS DATETIME) AND CAST(jT.Work_Date AS DATETIME) < CAST('20160301 00:00:00.000' AS DATETIME)) THEN jT.Act_Run_Qty ELSE 0 END) AS February_16,\n" +
                                    "\tSUM(CASE WHEN (CAST(jT.Work_Date AS DATETIME) >= CAST('20160301 00:00:00.000' AS DATETIME) AND CAST(jT.Work_Date AS DATETIME) < CAST('20160401 00:00:00.000' AS DATETIME)) THEN jT.Act_Run_Qty ELSE 0 END) AS March_16,\n" +
                                    "\tSUM(CASE WHEN (CAST(jT.Work_Date AS DATETIME) >= CAST('20160401 00:00:00.000' AS DATETIME) AND CAST(jT.Work_Date AS DATETIME) < CAST('20160501 00:00:00.000' AS DATETIME)) THEN jT.Act_Run_Qty ELSE 0 END) AS April_16\n" +
                            "FROM PRODUCTION.dbo.Job_Operation AS jO\n" +
                            "LEFT JOIN PRODUCTION.dbo.Job_Operation_Time AS jT\n" +
                            "ON jO.Job_Operation = jT.Job_Operation\n" +
                            "LEFT JOIN PRODUCTION.dbo.Job AS jJ\n" +
                            "ON jO.Job = jJ.Job\n" +
                            "WHERE jT.Act_Run_Qty <> 0;";

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
