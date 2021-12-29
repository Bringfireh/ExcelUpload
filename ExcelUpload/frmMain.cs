using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExcelUpload
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void btnUploadExcel_Click(object sender, EventArgs e)
        {
            string exeldoc = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Book1.xlsx");
            //string exeldoc = Path.Combine(System.Environment.CurrentDirectory + "ExcelFiles", "Book1.xlsx");
            //string exeldoc = Path.Combine(System.IO.Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName) + "ExcelFiles", "Book1.xlsx");
            
            OleDbConnection conn = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source="+exeldoc + ";Extended Properties='Excel 12.0 Xml; HDR = YES; IMEX = 1'");
            OleDbCommand cmd = new OleDbCommand("select * from [sheet1$]", conn);
            DataTable tbl = new DataTable();
            lbl.Text = DateTime.Now.ToString("hh:mm:ss." + DateTime.Now.Ticks);
            conn.Open();
            tbl.Load(cmd.ExecuteReader());
            conn.Close();
            dgv.DataSource = tbl;
            lbl.Text += "\n" + DateTime.Now.ToString("hh:mm:ss." + DateTime.Now.Ticks);

        }

        private void frmMain_Load(object sender, EventArgs e)
        {

        }
    }
}
