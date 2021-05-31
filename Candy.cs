namespace Multifabriken
{
    class Candy
    {
        //auto-implemented properties; ingen ytterligare logik eftersom data validation hanteras i Menu.cs
        public string Flavor { get; set; }
        public int Amount { get; set; }

        //konstruktor
        public Candy(string flavor, int amount)
        {
            Flavor = flavor;
            Amount = amount;
        }

        //skriver ut information om instansen, override av default ToString för objektklassen 
        public override string ToString() 
        {
            string toString = $"Smak: {Flavor}, antal: {Amount} bitar";
            return toString;
        }
    }
}
