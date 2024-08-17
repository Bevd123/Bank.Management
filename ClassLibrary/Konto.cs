
namespace ClassLibrary
{
    public class Konto
    {
        public string Inhaber { get; set; }

        public double Saldo { get; set; }

        public int Pin { get; set; }
        public bool Eingeloggt { get; set; }
        public List<string> Transaktionen { get; set; } = new List<string>();

        public Konto()
        {
            Inhaber = "";
            Pin = 0;
            Saldo = 0;
            Eingeloggt = false;
            Transaktionen = new List<string>();
        }

        public Konto(string inhaber, int pin)
        {
            Inhaber = inhaber;
            Pin = pin;
            Saldo = 0;
            Eingeloggt = false;
            Transaktionen = new List<string>();
        }

        public bool Einloggen(int pin)
        {
            if (Pin == pin)
            {
                Transaktionen.Add($"{Inhaber} erfolgreich eingeloggt.");
                return Eingeloggt = true;
            }
            else
            {
                Transaktionen.Add($"{Inhaber} nicht eingeloggt (falscher PIN).");
                return Eingeloggt = false;
            }
        }

        public bool Ausloggen()
        {
            Transaktionen.Add($"{Inhaber} erfolgreich ausgeloggt.");
            Eingeloggt = false;
            return true;
        }

        public bool Einzahlen(double betrag)
        {
            if (!Eingeloggt)
            {
                Transaktionen.Add($"{Inhaber} hat versucht {betrag} EUR einzuzahlen, war aber nicht eingeloggt.");
                return false;
            }
            else if (betrag < 0)
            {
                Transaktionen.Add($"{Inhaber} hat versucht {betrag} EUR einzuzahlen, aber Betrag war negativ.");
                return false;
            }
            else
            {
                Transaktionen.Add($"{Inhaber} hat {betrag} EUR erfolgreich eingezahlt.");
                Saldo += betrag;
                return true;
            }

        }

        public bool Abheben(double betrag)
        {
            if (!Eingeloggt)
            {
                Transaktionen.Add($"{Inhaber} hat versucht {betrag} EUR abzuheben, war aber nicht engeloggt.");
                return false;
            }
            else if (betrag < 0)
            {
                Transaktionen.Add($"{Inhaber} hat versucht {betrag} EUR abzuheben, aber Betrag war negativ.");
                return false;
            }
            else if (betrag > Saldo)
            {
                Transaktionen.Add($"{Inhaber} hat versucht {betrag} EUR abzuheben, aber Konto war nicht gedeckt.");
                return false;
            }
            else
            {
                Transaktionen.Add($"{Inhaber} hat {betrag} EUR erfolgreich abgehoben.");
                Saldo -= betrag;
                return true;
            }

        }

        public bool ÜberweisungTätigen(Konto k, double betrag)
        {
            if (!Eingeloggt)
            {
                Transaktionen.Add($"{Inhaber} hat versucht {betrag} EUR zu überweisen, war aber nicht eingeloggt.");
                return false;
            }
            else if (betrag < 0)
            {
                Transaktionen.Add($"{Inhaber} hat versucht {betrag} EUR zu überweisen, aber Betrag war negativ.");
                return false;
            }
            else if (betrag > Saldo)
            {
                Transaktionen.Add($"{Inhaber} hat versucht {betrag} EUR zu überweisen, aber Konto war nicht gedeckt.");
                return false;
            }
            else
            {
                Transaktionen.Add($"{Inhaber} hat {betrag} EUR erfolgreich auf {k.Inhaber} überwiesen.");
                Saldo -= betrag;
                k.ÜberweisungBekommen(Inhaber, betrag);
                return true;
            }
        }

        private void ÜberweisungBekommen(string geldgeber, double betrag)
        {
            Transaktionen.Add($"{Inhaber} hat {betrag} EUR erfolgreich von {geldgeber} erhalten.");
            Saldo += betrag;
        }

        public bool PinÄndern(int pin)
        {
            if (Eingeloggt)
            {
                Transaktionen.Add($"{Inhaber} hat seinen PIN erfolgreich geändert.");
                Pin = pin;
                return true;
            }
            else
            {
                Transaktionen.Add($"{Inhaber} hat versucht seinen PIN zu ändern, war aber nicht eingeloggt.");
                return false;
            }
        }

        public string TransaktionenAusgeben()
        {
            string s = "";

            foreach (string item in Transaktionen)
            {
                s += $"{item}\n";
            }


            return s;
        }

        public override string ToString()
        {
            string s = $"{Inhaber}";
            if (Eingeloggt)
            {
                s += $": {Saldo} Euro (eingeloggt)";
            }
            else
            {
                s += $" (nicht eingeloggt)";
            }
            return s;
        }

    }
}