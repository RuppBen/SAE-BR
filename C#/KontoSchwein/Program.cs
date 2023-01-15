using System;

namespace KontoSchwein
{
    class Program
    {
        static void Main(string[] args)
        {
            string nameSchwein = "ichkannmichnichtentscheiden"; //still here coause I didnt find a solution
            string eingabe; //variable mit stätiger Veränderung
            char chooseEXE; //Variable mit stätiger Veränderung
            double menge;   //Variable mit stätiger Veränderung

            do
            {
            System.Console.Write("Woud you like to do Banking(1) or Farming(2)# ");
            eingabe = Console.ReadLine();
            chooseEXE = Convert.ToChar(eingabe);

            switch (chooseEXE)
            {
                case '1':   //BANKING
                    System.Console.Write("Startkapital(default=1)# "); 
                    eingabe = Console.ReadLine();
                    if (eingabe == "")
                    {
                        menge = 0;
                    }
                    else
                    {
                        menge = Convert.ToDouble(eingabe);
                    }
                    Konto konto = new Konto(menge);

                    do
                    {
                    System.Console.Write("Was möchten Sie machen(einzahlen=1, auszahlen=2)# ");
                    eingabe = Console.ReadLine();
                    chooseEXE = Convert.ToChar(eingabe);
                    switch (chooseEXE)
                    {
                        case '1':   //einzahlen
                            System.Console.Write("Menge zum Einzahlen# ");
                            eingabe = Console.ReadLine();
                            menge = Convert.ToDouble(eingabe);
                            konto.Einzahlen(menge);
                            break;

                        case '2':   //auszahlen
                            System.Console.Write("Menge zum Auszahlen# ");
                            eingabe = Console.ReadLine();
                            menge = Convert.ToDouble(eingabe);
                            konto.Auszahlung(menge);
                            break;
                    }
                    System.Console.WriteLine(konto);
                    System.Console.Write("WEITER(y or n)# ");
                    eingabe = Console.ReadLine();
                    chooseEXE = Convert.ToChar(eingabe);
                    }while(chooseEXE == 'y' || chooseEXE == 'Y');
                    break;

                case '2':   //FARMING
                    System.Console.Write("Name des Schweins# "); 
                    eingabe = Console.ReadLine();
                    if (eingabe == "")
                    {
                        nameSchwein = "ichkannmichnichtentscheiden";
                    }
                    else
                        nameSchwein = eingabe;
                    
                    System.Console.Write("Gewicht des Schweins(default=40)# ");
                    eingabe = Console.ReadLine();
                    if (eingabe == "")
                    {
                        menge = 40;
                    }
                    else
                    {
                        menge = Convert.ToDouble(eingabe);
                    }
                    Schwein schwein = new Schwein(nameSchwein, menge);
                    
                    do
                    {
                    System.Console.Write("Was möchten Sie machen(Füttern=1, Reden=2, quit=q)# ");
                    eingabe = Console.ReadLine();
                    chooseEXE = Convert.ToChar(eingabe);
                        switch (chooseEXE)
                            {
                                case '1':   //füttern
                                    System.Console.Write("Wie viel Futter(default=1000)# ");
                                    eingabe = Console.ReadLine();
                                    if (eingabe == "")
                                    {
                                        menge = 1000;
                                    }
                                    else
                                    {
                                        menge = Convert.ToDouble(eingabe);
                                    }
                                    schwein.Fressen(menge);
                                    break;

                                case '2':   //reden
                                    System.Console.Write("Schreiben Sie was Sie sagen Möchten# ");
                                    eingabe = Console.ReadLine();
                                    System.Console.WriteLine(eingabe);
                                    System.Console.WriteLine(schwein.Grunzen());
                                    System.Console.WriteLine();
                                    break;
                                
                                case 'q':
                                    goto Exitpoint;  
                            }
                    System.Console.WriteLine(schwein);
                    }while(schwein.Schlachtgewicht());
                    System.Console.WriteLine("schlachtgewicht erreicht");
                    Exitpoint:
                    break;

            }
            System.Console.Write("Programm Wiederholen(y or n)# ");
            eingabe = Console.ReadLine();
            chooseEXE = Convert.ToChar(eingabe);
            }while(chooseEXE == 'y' || chooseEXE == 'Y');
        }
    }
}