using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Quiz
{
    static class Program
    {
        /// <summary>
        /// Główny punkt wejścia dla aplikacji.
        /// </summary>
        [STAThread]
        static void Main()
        {
           // Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            /// <summary>
            /// przejście do Form1          
            Application.Run(new Form1());
            /// </summary>
        }
    }
}
