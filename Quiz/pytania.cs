using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz
{
    class pytania
    {

        public int q_id { get; set; }
        public string q_title { get; set; }
        public string q_opa { get; set; }
        public string q_opb { get; set; }
        public string q_opc { get; set; }
        public string q_opd { get; set; }
        public string q_opcorrect { get; set; }
        public string q_addeddate { get; set; }
        public int q_fk_ad { get; set; }
        public int q_fk_ex { get; set; }
    }
}
