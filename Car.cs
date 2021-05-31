namespace Multifabriken
{
    class Car
    {
        //auto-implemented properties; ingen ytterligare logik eftersom data validation hanteras i Menu.cs
        public string RegNum { get; set; }
        public string Color { get; set; }
        public string CarBrand { get; set; }

        //konstruktor
        public Car(string regNum, string color, string carBrand)
        {
            RegNum = regNum;
            Color = color;
            CarBrand = carBrand;
        }

        //skriver ut information om instansen, override av default ToString för objektklassen 
        public override string ToString() 
        {
            string toString = $"Registreringsnummer: {RegNum}, färg: {Color}, bilmärke: {CarBrand}";
            return toString;
        }
    }
}
