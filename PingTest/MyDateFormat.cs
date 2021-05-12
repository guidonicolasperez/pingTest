using System;
using System.Collections.Generic;
using System.Text;

namespace PingTest
{

    public class MyDateFormat
    {
        public int dia { get; set; }
        public int mes { get; set; }
        public int ano { get; set; }
        public int hora { get; set; }

        public MyDateFormat(DateTime date)
        {
            dia = date.Day;
            mes = date.Month;
            ano = date.Year;
            hora = date.Hour;

        }

        public string getDateString()
        {
            return ano + "-" + mes + "-" + dia + "-" + hora;
        }


    }
}
