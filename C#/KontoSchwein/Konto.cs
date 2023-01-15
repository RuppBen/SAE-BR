using System;

namespace KontoSchwein
{
    class Konto
    {
        private int kontonummer;
        private double kontostand;

        public double Kontostand { get => kontostand; set 
            {
                if (value <= 0)
                    kontostand = 0;
                else
                    kontostand = value;
            }
        }
        public int Kontonummer{ get => kontonummer; }

        public Konto()
        {
            Kontostand = 1;
            SetKontonummer();
        }
        public Konto(double betrag)
        {
            Kontostand = 1;
            Kontostand += betrag;
            SetKontonummer();
        }

        private void SetKontonummer()
        {
            Random random = new Random();
            kontonummer = random.Next(100000, 999999);
        }

        public void Einzahlen(double einzahlung)
        {
            Kontostand += einzahlung;
        }

        public void Auszahlung(double auszahlung)
        {
            Kontostand -= auszahlung;
        }

        public override string ToString()
        {
            return ("Kontonummer "+kontonummer+ "\nKontostand "+ Kontostand);
        }
    }
}