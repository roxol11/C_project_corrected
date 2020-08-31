using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quiz
{
    public partial class Form1 : Form
    {       /// <summary>
            /// Załadowanie Form1
            /// </summary>
        public Form1()
        {
            InitializeComponent();
        }
        /// <summary>
        /// utworzenie nowej gry
        /// </summary>
        startgame sg = new startgame();
        /// <summary>
        /// Pasek ładowania
        /// </summary>
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            int sum = 0;
            for (int i = 1; i <= 100; i++)
            {
                Thread.Sleep(100);
                sum = sum + i;
                backgroundWorker1.ReportProgress(i);
                if (i == 100)
                {
                    e.Cancel = true;
                    backgroundWorker1.ReportProgress(100);

                    return;
                }
                if (backgroundWorker1.CancellationPending)
                {
                    e.Cancel = true;
                    backgroundWorker1.ReportProgress(0);
                    return;
                }
            }
        }
        /// <summary>
        /// Pasek ładowania gdy sie ładuje
        /// </summary>
        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
            label1.Text = e.ProgressPercentage.ToString() + "%";
        }
        /// <summary>
        /// Pasek ładowania gdy naładowany
        /// </summary>
        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                label1.Text = "100%";
                sg.Show();
                this.Hide();
            }
            else if (e.Error != null)
            {
                label1.Text = e.Error.Message;
            }
            else
            {
                label1.Text = e.Result.ToString();
            }
        }

        /// <summary>
        /// Ładowanie się Form1
        /// </summary>
        private void Form1_Load(object sender, EventArgs e)
        {
            if (!backgroundWorker1.IsBusy)
            {
                backgroundWorker1.RunWorkerAsync();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
