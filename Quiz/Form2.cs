using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quiz
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            // TODO: Ten wiersz kodu wczytuje dane do tabeli 'quizappDataSet.exams' . Możesz go przenieść lub usunąć.
            this.examsTableAdapter.Fill(this.quizappDataSet.exams);

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            label8.Text = comboBox1.SelectedValue.ToString();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            pytania q = new pytania();
            q.q_title = textBox1.Text;
            q.q_opa = textBox2.Text;
            q.q_opb = textBox3.Text;
            q.q_opc = textBox4.Text;
            q.q_opd = textBox5.Text;
            q.q_opcorrect = textBox6.Text;
            q.q_addeddate = System.DateTime.Now.ToShortDateString();
            q.q_fk_ex = comboBox1.SelectedValue.ToString();



            klasa_wchodzaca ic = new klasa_wchodzaca();

            string msg = ic.insert_srecord(q);
            MessageBox.Show(msg);

        }
    }
}
