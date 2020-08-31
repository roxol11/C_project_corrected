using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quiz
{
    public partial class startgame : Form
    {
        public static string name;
        public startgame()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            name = textBox1.Text;
            QUIZ Q = new QUIZ();
            Q.Show();
        }
    }
}
