using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class Mitarbeiter
    {
        public string Nachname { get; set; }
        public string Vorname { get; set; }
        public string User { get; set; }
        public string PW { get; set; }

        public Mitarbeiter(string nachname, string vorname, string user, string pw)
        {
            Nachname = nachname;
            Vorname = vorname;
            User = user;
            PW = pw;
        }

        public bool Einloggen(string pw)
        {
            if (PW == pw)
            {
                return true;
            }
            return false;
        }

    }
}
