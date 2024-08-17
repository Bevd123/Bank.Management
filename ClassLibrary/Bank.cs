using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class Bank
    {

        public string Name { get; set; }
        public List<Mitarbeiter> Mitarbeiter { get; set; } = new List<Mitarbeiter>();
        public List<Konto> Konten { get; set; } = new List<Konto>();

        public Bank() 
        {
            Name = "dummy";
        }
        public Bank(string name)
        {
            Name = name;

            MitarbeiterHinzufügen(new Mitarbeiter("Admin", "Admin", "admin", "root"));
        }

        public void MitarbeiterHinzufügen(Mitarbeiter m)
        {
            Mitarbeiter.Add(m);
        }

        public Mitarbeiter GetMitarbeiter(int pos)
        {
            return Mitarbeiter[pos];
        }

        public Mitarbeiter? GetMitarbeiter(string username)
        {
            foreach (Mitarbeiter m in Mitarbeiter)
            {
                if (m.User.Equals(username))
                {
                    return m;
                }
            }
            return null;
        }

        public void KontenHinzufügen(Konto k)
        {
            Konten.Add(k);
        }

        public Konto? GetKonto(int pos)
        {
            return pos < Konten.Count ? Konten[pos] : null;
        }

        public Konto? GetKonto(string inhaber)
        {
            foreach (Konto k in Konten)
            {
                if (k.Inhaber.Equals(inhaber))
                {
                    return k;
                }
            }
            return null;
        }

        public bool Speichern()
        {
            try
            {
                string jsonString = JsonSerializer.Serialize(this);
                File.WriteAllText($"{Name}.bank", jsonString);

                return true;
            }
            catch
            {
                return false;
            }
            

        }

        public static Bank Laden(string file)
        {
            // Deserialisierung
            string jsonString = File.ReadAllText(file);
            Bank deserializedObj = JsonSerializer.Deserialize<Bank>(jsonString) ?? new("was");

            return deserializedObj;
        }


        public override string ToString()
        {
            string s = Name + "\n\n";

            foreach (Konto k in Konten)
            {
                s+= k.ToString();
            }

            foreach (Mitarbeiter m in Mitarbeiter)
            {
                s += m.ToString();
            }

            return s;
        }

    }
}
