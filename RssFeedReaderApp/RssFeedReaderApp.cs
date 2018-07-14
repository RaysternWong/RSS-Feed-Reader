﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Library.RssFeedReader;
using System.Data.SqlClient;
using System.Threading;
using System.Configuration;

namespace RssFeedReaderApp
{
    public partial class RssFeedReaderApp : Form
    {
        string _connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename="
                                   + AppDomain.CurrentDomain.BaseDirectory + "rssFeedReader.mdf"
                                   + ";Integrated Security=True";
        string _cmd = "SELECT title,link,updateTime FROM tNews ORDER BY updateTime DESC";

        SqlConnection _connection;
        SqlDataAdapter _da;
        DataTable _table = new DataTable();

        Thread t;

        int newsExpireDay; 

        public RssFeedReaderApp()
        {
            InitializeComponent();
            _connection = new SqlConnection(_connectionString);

            int days = 0;

            if (int.TryParse(ConfigurationSettings.AppSettings["key"], out newsExpireDay) == false)
                days = 2;

            setNewsExpireHour(days);

        }

        private void setNewsExpireHour(int days)
        {
            tsm_1day.Checked = false;
            tsm_2day.Checked = false;
            tsm_3day.Checked = false;

            switch (days)
            {
                case 1:
                    tsm_1day.Checked = true;
                    newsExpireDay = -1;
                    break;
                case 2:
                    tsm_2day.Checked = true;
                    newsExpireDay = -2;
                    break;
                case 3:
                    tsm_3day.Checked = true;
                    newsExpireDay = -3;
                    break;
                default:
                    tsm_2day.Checked = true;
                    newsExpireDay = -2;
                    break;
            }
        }

        private void tsB_manageRssURL_Click(object sender, EventArgs e)
        {
            ManageRssURL manageRssURLForm = new ManageRssURL();
            manageRssURLForm.Show();
        }

        private void girdView_News_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 1 && e.RowIndex != -1) //If user is clicked the URL cell 
            {
                try
                {
                    string url = gv_News.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                    System.Diagnostics.Process.Start(url);
                }
                catch (Exception exc)
                {
                    string error = "Could not open the link in browser, error : " + exc.Message;
                    MessageBox.Show(error);
                }
            }
        }

        private void RssFeedReaderApp_Load(object sender, EventArgs e)
        {
            //RssFeedReader.testInsert();

            t = new Thread(runFeedReader);
            t.Start();
        }

        private void runFeedReader()
        {
            while (true)
            { 
                try
                {
                    RssFeedReader.downloadNewsToDb();
                    dataGridViewBinding();                
                }
                catch (Exception exc)
                {
                    string mss = "Cannot display news, error : " + exc.Message;
                }
                Thread.Sleep(1000);
            }

        }

        private void dataGridViewBinding()
        {
            string query = string.Empty;
            DateTime deadLines = DateTime.Now;
            deadLines.AddDays(newsExpireDay);

            try
            {
                DataTable dt = new DataTable();

                query += "SELECT title,link,updateTime FROM tNews ORDER BY updateTime DESC; ";
                query += "DELETE FROM tNews WHERE updateTime < '" + deadLines.ToString("yyyy-MM-dd HH:mm:ss") + "';";

                _da = new SqlDataAdapter(query, _connection);
                _da.Fill(dt);
                gv_News.Invoke( (MethodInvoker)delegate { gv_News.DataSource = dt;} );
            }
            catch (Exception exc)
            {
                string mss = "Cannot display news, error : " + exc.Message;
            }
        }

        

        private void tsm_1day_Click(object sender, EventArgs e)
        {

        }
    }
}
