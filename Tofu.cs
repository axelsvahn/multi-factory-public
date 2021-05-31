namespace Multifabriken
{
    class Tofu
    {
        //auto-implemented properties; ingen ytterligare logik eftersom data validation hanteras i Menu.cs
        public int Volume { get; set; }
        public string Seasoning { get; set; }
        
        //konstruktor
        public Tofu(int volume, string seasoning)
        {
            Volume = volume;
            Seasoning = seasoning;
        }

        //skriver ut information om instansen, override av default ToString för objektklassen 
        public override string ToString()
        {
            string toString = $"Volym: {Volume} liter, kryddning: {Seasoning}";
            return toString;
        }
    }
}
