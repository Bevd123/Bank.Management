using ClassLibrary;

bool neueBank = true;
string[] bankFiles = Directory.GetFiles(".", "*.bank");

Bank b = new Bank();

if (bankFiles.Length > 0)
{
    foreach (string f in bankFiles)
    {
        Console.WriteLine($"\t{f}");
    }
    Console.WriteLine("\tNeue Bank erstellen.");

    Console.WriteLine();
    Console.WriteLine("Welche Bank möchten Sie laden?");

    int curserLine = 0;
    Console.SetCursorPosition(0, curserLine);
    Console.Write(">");

    ConsoleKeyInfo pressedKey;
    do
    {
        pressedKey = Console.ReadKey();

        Console.Write("\b ");
        switch (pressedKey.Key)
        {
            case ConsoleKey.DownArrow:
                if(curserLine < bankFiles.Length) curserLine++;
                break;
            case ConsoleKey.UpArrow:
                if (curserLine > 0) curserLine--;
                break;
        }

        Console.SetCursorPosition(0, curserLine);
        Console.Write(">");
    } while (pressedKey.Key != ConsoleKey.Enter);

    if(curserLine < bankFiles.Length)
    {
        b = Bank.Laden(bankFiles[curserLine]);
        neueBank = false;
    }
    
}

if (neueBank)
{
    Console.Clear();
    Console.Write("Geben Sie den Namen der neuen Bank an: ");
    b = new Bank(Console.ReadLine()!);
}


Console.Clear();
Console.WriteLine(b);

bool runningBank = true;
string[] menüBank = { "Mitarbeiter Login", "Konto Login", "Beenden" };

while(runningBank)
{
    Console.Clear();
    foreach (string s in menüBank)
    {
        Console.WriteLine($"\t{s}");
    }

    Console.WriteLine();
    Console.WriteLine("Was möchten Sie tun?");

    int curserBank = 0;
    Console.SetCursorPosition(0, curserBank);
    Console.Write(">");

    ConsoleKeyInfo auswahlBank;
    do
    {
        auswahlBank = Console.ReadKey();

        Console.Write("\b ");
        switch (auswahlBank.Key)
        {
            case ConsoleKey.DownArrow:
                if (curserBank < menüBank.Length - 1) curserBank++;
                break;
            case ConsoleKey.UpArrow:
                if (curserBank > 0) curserBank--;
                break;
        }

        Console.SetCursorPosition(0, curserBank);
        Console.Write(">");
    } while (auswahlBank.Key != ConsoleKey.Enter);

    Console.Clear();
    Console.WriteLine(menüBank[curserBank]);
    Console.WriteLine();

    switch (curserBank)
    {
        case 0:
            Console.Write("Username: ");
            string? user = Console.ReadLine();
            Mitarbeiter? m = b.GetMitarbeiter(user??"");
            if(m != null)
            {
                Console.Write("Passwort: ");
                string? pw = Console.ReadLine();

                if (m.Einloggen(pw??""))
                {

                    bool runningMitarbeiter = true;
                    string[] menüMitarbeiter = { "Neuen Kunden anlegen", "Kunden auflisten", "Transaktionslog von Kunde x anzeigen", "zurück" };

                    while (runningMitarbeiter)
                    {
                        Console.Clear();
                        foreach (string s in menüMitarbeiter)
                        {
                            Console.WriteLine($"\t{s}");
                        }

                        Console.WriteLine();
                        Console.WriteLine("Was möchten Sie tun?");

                        int curserMitarbeiter = 0;
                        Console.SetCursorPosition(0, curserMitarbeiter);
                        Console.Write(">");

                        ConsoleKeyInfo auswahlMitarbeiter;
                        do
                        {
                            auswahlMitarbeiter = Console.ReadKey();

                            Console.Write("\b ");
                            switch (auswahlMitarbeiter.Key)
                            {
                                case ConsoleKey.DownArrow:
                                    if (curserMitarbeiter < menüMitarbeiter.Length - 1) curserMitarbeiter++;
                                    break;
                                case ConsoleKey.UpArrow:
                                    if (curserMitarbeiter > 0) curserMitarbeiter--;
                                    break;
                            }

                            Console.SetCursorPosition(0, curserMitarbeiter);
                            Console.Write(">");
                        } while (auswahlMitarbeiter.Key != ConsoleKey.Enter);

                        switch (curserMitarbeiter)
                        {
                            case 0:
                                Console.Clear();
                                Console.WriteLine(menüMitarbeiter[curserMitarbeiter]);
                                Console.WriteLine();

                                Console.Write("Inhaber: ");
                                string? inhaber = Console.ReadLine();
                                Console.Write("Pin: ");
                                int pin;
                                if (!int.TryParse(Console.ReadLine(), out pin)) pin = 0;

                                b.KontenHinzufügen(new Konto(inhaber??"", pin));

                                break;
                            case 1:
                                Console.Clear();
                                Console.WriteLine(menüMitarbeiter[curserMitarbeiter]);
                                Console.WriteLine();

                                foreach (Konto k in b.Konten)
                                {
                                    Console.WriteLine(k);
                                }
                                break;
                            case 2:
                                Console.Clear();
                                Console.WriteLine(menüMitarbeiter[curserMitarbeiter]);
                                Console.WriteLine();

                                Console.Write("Kundenname für das Transaktionslog: ");
                                string? name = Console.ReadLine();

                                foreach (Konto k in b.Konten)
                                {
                                    if (name?.Equals(k.Inhaber) ?? false)
                                    {
                                        Console.WriteLine(k.TransaktionenAusgeben());
                                        break;
                                    }

                                }

                                break;
                            case 3:
                                runningMitarbeiter = false;
                                break;
                            default:
                                break;
                        }
                        Console.WriteLine("Drücken Sie [ENTER]...");
                        Console.ReadLine();

                    }


                }

            }
            

            break;
        case 1:
            Console.Write("Kontoinhaber: ");
            string? kontoinhaber = Console.ReadLine();
            Konto? konto = b.GetKonto(kontoinhaber ?? "");
            if (konto != null)
            {
                Console.Write("Passwort: ");
                string? pw = Console.ReadLine();
                int pin = 0;
                Int32.TryParse(pw, out pin);

                if (konto.Einloggen(pin))
                {

                    bool runningKonto = true;
                    string[] menüKonto = { "Einzahlen", "Abheben", "Überweisung tätigen", "Transaktionen anzeigen", "zurück" };

                    while (runningKonto)
                    {
                        Console.Clear();
                        foreach (string s in menüKonto)
                        {
                            Console.WriteLine($"\t{s}");
                        }

                        Console.WriteLine();
                        Console.WriteLine("Was möchten Sie tun?");

                        int curserKonto = 0;
                        Console.SetCursorPosition(0, curserKonto);
                        Console.Write(">");

                        ConsoleKeyInfo auswahlKonto;
                        do
                        {
                            auswahlKonto = Console.ReadKey();

                            Console.Write("\b ");
                            switch (auswahlKonto.Key)
                            {
                                case ConsoleKey.DownArrow:
                                    if (curserKonto < menüKonto.Length - 1) curserKonto++;
                                    break;
                                case ConsoleKey.UpArrow:
                                    if (curserKonto > 0) curserKonto--;
                                    break;
                            }

                            Console.SetCursorPosition(0, curserKonto);
                            Console.Write(">");
                        } while (auswahlKonto.Key != ConsoleKey.Enter);

                        Console.Clear();
                        Console.WriteLine(menüKonto[curserKonto]);
                        Console.WriteLine();

                        switch (curserKonto)
                        {
                            case 0:
                                Console.Write("Wie viel wollen Sie einzahlen? ");
                                double betragE = 0;
                                double.TryParse(Console.ReadLine(), out betragE);
                                if (konto.Einzahlen(betragE))
                                {
                                    Console.WriteLine($"Sie haben erfolgreich {betragE} Euro eingezahlt.");
                                }
                                else
                                {
                                    Console.WriteLine("Einzahlen fehlgeschlagen.");
                                }
                                break;
                            case 1:
                                Console.Write("Wie viel wollen Sie abheben? ");
                                double betragA = 0;
                                double.TryParse(Console.ReadLine(), out betragA);
                                if (konto.Abheben(betragA))
                                {
                                    Console.WriteLine($"Sie haben erfolgreich {betragA} Euro abgehoben.");
                                }
                                else
                                {
                                    Console.WriteLine("Abheben fehlgeschlagen.");
                                }
                                break;
                            case 2:
                                Console.Write("Wie viel wollen Sie überweisen? ");
                                double betragÜ = 0;
                                double.TryParse(Console.ReadLine(), out betragÜ);

                                Console.Write("Kundenname für das Überweisungsziel: ");
                                string? name = Console.ReadLine();

                                foreach (Konto k in b.Konten)
                                {
                                    if (name?.Equals(k.Inhaber) ?? false)
                                    {
                                        konto.ÜberweisungTätigen(k, betragÜ);
                                        break;
                                    }
                                }
                                break;
                            case 3:
                                Console.WriteLine(konto.TransaktionenAusgeben());
                                break;
                            case 4:
                                runningKonto = false;
                                break;
                            default:
                                break;
                        }
                        Console.WriteLine("Drücken Sie [ENTER]...");
                        Console.ReadLine();

                    }


                }

            }


            break;
        case 2:
            runningBank = false;
            break;
        default:
            break;
    }


}

b.Speichern();
