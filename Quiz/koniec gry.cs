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
    public partial class koniec_gry : Form
    {       /// <summary>
            /// Załadowanie komponentów
            /// </summary>
        public koniec_gry()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Wyświela wynik
        /// </summary>
        private void koniec_gry_Load(object sender, EventArgs e)
        {
            label2.Text = QUIZ.wynik;
        }
        /// <summary>
        /// Przycisk do wyjścia
        /// </summary>
        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
