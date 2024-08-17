

using ClassLibrary;

try
{
    

    Console.Write("Bitte geben Sie Ihren Namen ein: ");
    string name = Console.ReadLine()!;

    Console.Write("Bitte geben Sie Ihren PIN ein (nur Ziffern): ");
    int pin = Convert.ToInt32(Console.ReadLine());

    Konto k = new Konto(name, pin);

    bool running = true;
    while (running)
    {
        Console.Clear();
        Console.WriteLine(k);
        Console.WriteLine("Was wollen Sie tun?");
        Console.Write("1: Ein-/Ausloggen, 2: Einzahlen, 3: Abheben, 4: Transaktionen anzeigen, 0: Beenden - ");
        int auswahl = Convert.ToInt32(Console.ReadLine());

        switch (auswahl)
        {
            case 1:
                if (k.Eingeloggt)
                {
                    k.Ausloggen();
                    Console.WriteLine("Sie sind erfolgreich ausgeloggt. Bitte [ENTER] drücken...");
                }
                else
                {
                    Console.Write("Bitte geben Sie Ihren PIN ein: ");
                    pin = Convert.ToInt32(Console.ReadLine());
                    if (k.Einloggen(pin) == true)
                    {
                        Console.WriteLine("Sie sind erfolgreich eingeloggt. Bitte [ENTER] drücken...");
                    }
                    else
                    {
                        Console.WriteLine("Einloggen fehlgeschlagen. Bitte [ENTER] drücken...");
                    }
                }
                Console.ReadLine();
                break;
            case 2:
                if (k.Eingeloggt)
                {
                    Console.Write("Wie viel wollen Sie einzahlen? ");
                    double betrag = Convert.ToDouble(Console.ReadLine());
                    if (k.Einzahlen(betrag))
                    {
                        Console.WriteLine($"Sie haben erfolgreich {betrag} Euro eingezahlt. Bitte [ENTER] drücken...");
                    }
                    else
                    {
                        Console.WriteLine("Einzahlen fehlgeschlagen. Bitte [ENTER] drücken...");
                    }
                }
                else
                {
                    Console.WriteLine("Sie sind nicht eingeloggt. Bitte [ENTER] drücken...");
                }
                Console.ReadLine();
                break;
            case 3:
                if (k.Eingeloggt)
                {
                    Console.Write("Wie viel wollen Sie abheben? ");
                    double betrag = Convert.ToDouble(Console.ReadLine());
                    if (k.Abheben(betrag))
                    {
                        Console.WriteLine($"Sie haben erfolgreich {betrag} Euro abgehoben. Bitte [ENTER] drücken...");
                    }
                    else
                    {
                        Console.WriteLine("Abheben fehlgeschlagen. Bitte [ENTER] drücken...");
                    }
                }
                else
                {
                    Console.WriteLine("Sie sind nicht eingeloggt. Bitte [ENTER] drücken...");
                }
                Console.ReadLine();
                break;
            case 4:
                Console.WriteLine(k.TransaktionenAusgeben());
                Console.WriteLine("Bitte [ENTER] drücken...");
                Console.ReadLine();
                break;
            case 0:
                running = false;
                break;
            default:
                break;
        }
    }

}
catch (Exception ex)
{
    Console.WriteLine("Es ist etwas schief gelaufen");
    Console.WriteLine(ex.Message);
}