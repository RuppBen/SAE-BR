using System;

namespace _2020_Sommer_SAE
{
    class pc
    {
        private int pcID;
        private string raumNR;
        private int ramGB;

        public int PcID { get => pcID; set => pcID = value; }
        public string RaumNR { get => raumNR; set => raumNR = value; }
        public int RamGB { get => ramGB; set => ramGB = value; }

        public pc(int pcID,string raumNR, int ramGB)
        {
            PcID = pcID;
            RaumNR = raumNR;
            RamGB = ramGB;
        }
        public pc(){}
    }
}