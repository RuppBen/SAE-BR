using System;
using System.Collections.Generic; 

namespace _27._01Assoziation
{
    class Kunde
    {
        private string vorname;
        private string nachname;

        public string Vorname { get => vorname; set => vorname = value; }
        public string Nachname { get => nachname; set => nachname = value; }
        //public Konto DasKonto { get => DasKonto; set => DasKonto = value; }   //Kan be used if still needet
        public List<Konto>DieKonten;
        public Kunde() 
        {
            //DasKonto = new Konto();
            DieKonten = new List<Konto>();
            DieKonten.Add(new Konto());
        }
        public Kunde(string vorname, string nachname)
        {
            Vorname = vorname;
            Nachname = nachname;
            //DasKonto = new Konto();
            DieKonten = new List<Konto>();
            DieKonten.Add(new Konto());
        }
        public Konto GetKonto(int kontonummer)
        {
            foreach (Konto item in DieKonten)
            {
                if (item.Kontonummer ==kontonummer )
                {
                    return item;
                }
            }
            return null;
        }
        public void Geldtransfer(Kunde empfänger, double betrag, int SendeNummer, int EmpfängerNummer)
        {
            GetKonto(SendeNummer).Auszahlung(betrag);
            empfänger.GetKonto(EmpfängerNummer).Einzahlen(betrag); 
        }
        public void AddKonto()
        {
            DieKonten.Add(new Konto());
        }

        public override string ToString()
        {
            string ausgabe = "Nachname: "+Nachname+"\nVorname: "+Vorname+"\n";
            foreach (Konto item in DieKonten)
            {
                ausgabe += item.ToString();
                ausgabe += "\n";
            }
            return ausgabe;    
        }
    }
}