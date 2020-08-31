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
    public partial class QUIZ : Form
    {
        public QUIZ()
        {
            InitializeComponent();
        }

        private void QUIZ_Load(object sender, EventArgs e)
        {
            label2.Text = startgame.name;
        }
    }
}
