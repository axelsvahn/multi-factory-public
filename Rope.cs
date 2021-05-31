namespace Multifabriken
{
    class Rope
    {
        //Klassen heter "Rope" för att undvika krock med namnet "String"
        //auto-implemented properties: ingen ytterligare logik behövs eftersom data validation hanteras i Menu.cs
        public string Color { get; set; }
        public int RopeLength { get; set; }

        //konstruktor
        public Rope(string color, int ropeLength)
        {
            Color = color;
            RopeLength = ropeLength;
        }

        //skriver ut information om instansen, override av default ToString för objektklassen 
        public override string ToString()
        {
            string toString = $"Färg: {Color}, längd: {RopeLength} centimeter";
            return toString;
        }
    }
}
