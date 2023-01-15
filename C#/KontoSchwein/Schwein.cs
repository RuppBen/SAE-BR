using System;

namespace KontoSchwein
{
    class Schwein
    {
        private static double min_gewicht = 40;
        private static double max_gewicht = 500;
        private static double schlachtgewicht =400;

        private string name;
        private double gewicht; 

        public string Name{ get => name; set => name = value;}
        public double Gewicht{ get => gewicht; set
            {
                if (value < min_gewicht)
                    gewicht = min_gewicht;
                else if (value >= max_gewicht)
                    gewicht = max_gewicht;
                else
                    gewicht = value;
            }
        }

        public Schwein() {}
        public Schwein(string name, double gewicht)
        {
            Name = name;
            Gewicht = gewicht;
        }

        public void Fressen(double futter)
        {
            futter = Math.Round(futter / 1000, 2);
            futter = (futter / 100) * 60;
            Gewicht += futter;      
        }

        public string Grunzen()
        {
            return "oingoingoing";
        }

        public bool Schlachtgewicht()
        {
            return Gewicht <= schlachtgewicht;
        }

        public override string ToString()
        {
            return ("Name "+Name+"\nGewicht "+Gewicht);
        }
    }
}