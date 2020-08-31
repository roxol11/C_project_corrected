using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient; //polaczenie z Sql w app.config
using System.Configuration;

namespace Quiz
{
	public partial class QUIZ : Form
	{
		/// <summary>
		/// //deklaracja czasu Timera
		/// </summary>
		int czas = 0;
		/// <summary>
		/// Tablica z wygranymi
		/// </summary>
		int[] x = new int[7];
		/// <summary>
		/// deklaracja zmiennej
		/// </summary>
		int p = 0; //deklaracja zmiennej wygranej
		/// <summary>
		/// deklaracja poprawnej odpowiedzi i wyvranej odpowiedzi
		/// </summary>
		string pop_odp, wyb_odp;
		/// <summary>
		/// Wyniku
		/// </summary>
		public static string wynik;
		/// <summary>
		/// Utworzenie kasy zwrotnej
		/// </summary>
		klasa_zwrotna rc = new klasa_zwrotna();
		/// <summary>
		/// id_pytania
		/// </summary>
		int id_pytania = 0;
		/// <summary>
		/// połączenie z baza danych
		/// </summary>
		private string connstring = ConfigurationManager.ConnectionStrings["kbc"].ConnectionString; //polaczenie z pliku z baz

		/// <summary>
		/// Komponenty
		/// </summary>
		public QUIZ()
		{
			InitializeComponent();
		}

		private void QUIZ_Load(object sender, EventArgs e)
		{
			timer1.Interval = 1000; // 1000milisekund = 1 sekunda
			timer1.Start();  //start timera
			label2.Text = startgame.imie; // pobranie imienia z poprzedniego ekranu
			id_pytania = Funkcje.losuj(1, 7); //wybiera pytanie
			x[p] = id_pytania;
			wys_pytanie(id_pytania);
			tab_zmian(p);
		}


		/// <summary>
		/// Tablica z wygranymi jeżeli odpowiemy na pytanie przechodzi do kolejnego
		/// </summary>
		public void tab_zmian(int P)
		{
			if (p == 0)
			{
				label7.BackColor = Color.Orange;
				wynik = "0";
			}
			if (p == 1)
			{
				label8.BackColor = Color.Orange;
				label7.BackColor = Color.CornflowerBlue;
				wynik = label7.Text;
			}
			if (p == 2)
			{
				label9.BackColor = Color.Orange;
				label8.BackColor = Color.CornflowerBlue;
				wynik = label8.Text;
			}
			if (p == 3)
			{
				label10.BackColor = Color.Orange;
				label9.BackColor = Color.CornflowerBlue;
				wynik = label9.Text;
			}
			if (p == 4)
			{
				label11.BackColor = Color.Orange;
				label10.BackColor = Color.CornflowerBlue;
				wynik = label10.Text;
			}
			if (p == 5)
			{
				label12.BackColor = Color.Orange;
				label11.BackColor = Color.CornflowerBlue;
				wynik = label11.Text;
			}
			if (p == 6)
			{
				label12.BackColor = Color.Orange;
				wynik = label12.Text;
				this.Hide();
				koniec_gry kon = new koniec_gry();
				kon.Show();
			}

		}
		/// <summary>
		/// funkcja przycisków
		/// </summary>
		public void funkcja_przyciskow()
		{
			/// <summary>
			/// sprawdzanie odpowiedzi
			/// </summary>
			if (wyb_odp.Equals(pop_odp))
			{
				id_pytania++;
				wys_pytanie(id_pytania);
			l1:
				/// <summary>
				/// losowanie pytania z bazy danych
				/// </summary>
				int s = Funkcje.losuj(1, 8);
				bool c = Funkcje.search(x, s);
				if (c == true)
				{
					goto l1;
				}
				else
				{
					p++;
					id_pytania = s;
					x[p] = id_pytania;
					wys_pytanie(id_pytania);
					tab_zmian(p);
				}
			}
			else
			{
				/// <summary>
				/// jeżeli sie pomylimy to koniec gry
				/// </summary>
				this.Hide();
				koniec_gry kon = new koniec_gry();
				kon.Show();
			}
		}
		/// <summary>
		/// przycisk 1
		/// </summary>
		private void label3_Click(object sender, EventArgs e) //deklaracja przycisków odpowiedzi A
		{
			wyb_odp = label3.Text;
			funkcja_przyciskow();
			czas = 0;
		}
		/// <summary>
		/// przycisk 2
		/// </summary>
		private void label4_Click(object sender, EventArgs e) //deklaracja przycisków odpowiedzi B
		{
			wyb_odp = label4.Text;
			funkcja_przyciskow();
			czas = 0;

		}
		/// <summary>
		/// przycisk 3
		/// </summary>
		private void label5_Click(object sender, EventArgs e) //deklaracja przycisków odpowiedzi C
		{
			wyb_odp = label5.Text;
			funkcja_przyciskow();
			czas = 0;

		}
		/// <summary>
		/// przycisk 4
		/// </summary>
		private void label6_Click(object sender, EventArgs e) //deklaracja przycisków odpowiedzi D 
		{
			wyb_odp = label6.Text;
			funkcja_przyciskow();
			czas = 0;
		}

		public void wys_pytanie(int id_pytania) //wyswietlenie pytania
		{
			string sql = "select q_question,q_optionA,q_optionB,q_optionC,q_optionD,q_CORRECTOPTION from questions where q_id=" + id_pytania;
			SqlConnection connection = new SqlConnection(connstring);
			try
			{
				/// <summary>
				/// łączenie z baza danych, pobieranie pytań i odpowiedzi
				/// </summary>
				connection.Open();
				SqlCommand cmd = new SqlCommand(sql, connection);
				SqlDataReader reader = cmd.ExecuteReader();
				while (reader.Read())
				{
					label1.Text = reader.GetValue(0).ToString(); //Pytanie
					label3.Text = reader.GetValue(1).ToString(); //Odpowiedz A
					label4.Text = reader.GetValue(2).ToString(); //Odpowiedz B
					label5.Text = reader.GetValue(3).ToString(); //Odpowiedz C
					label6.Text = reader.GetValue(4).ToString(); //Odpowiedz D
					pop_odp = reader.GetValue(5).ToString();   //Poprawna odpowiedz
				}
				connection.Close();
			}

			catch (Exception ex)
			{
				MessageBox.Show("Wystapił jakiś błąd z Baza Danych");
			}

		}
		/// <summary>
		/// Zrobiony timer
		/// </summary>
		private void timer1_Tick(object sender, EventArgs e) //Timer 
		{
			czas = czas + 1;
			label14.Text = czas.ToString();
			if (czas >= 15)
			{
				timer1.Stop();
				this.Hide();
				koniec_gry kon = new koniec_gry();
				kon.Show();
			}
		}

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
		{

		}
	}
}
