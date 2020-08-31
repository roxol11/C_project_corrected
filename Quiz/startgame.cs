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
        public static string imie;
        /// <summary>
        /// Załadowanie Komponentów
        /// </summary>
        public startgame()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Wpisanie imienia do textboxa
        /// </summary>

        private void label1_Click(object sender, EventArgs e)
        {
            imie = textBox1.Text;
            QUIZ Q = new QUIZ();
            Q.Show();
            this.Hide();
        }

        private void startgame_Load(object sender, EventArgs e)
        {

        }
    }
}
