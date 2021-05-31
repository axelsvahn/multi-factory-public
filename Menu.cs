using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading;

namespace Multifabriken
{
    class Menu
    {
        //Listor som lagrar beställda objekt av respektive klass
        private List<Car> carList = new List<Car>();
        private List<Candy> candyList = new List<Candy>();
        private List<Rope> ropeList = new List<Rope>();
        private List<Tofu> tofuList = new List<Tofu>();

        public void RunMenu()
        {
            //sköter selektion inom menyn och anropar de andra metoderna
            //är publik eftersom den anropas av main()

            bool run = true;
            while (run) //loop som visar menyn tills användaren stänger av programmet via HandleQuit()
            {
                WriteMenu();
                string input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        //Beställ en bil.
                        OrderCar();
                        break;

                    case "2":
                        //Beställ godis. 
                        OrderCandy();
                        break;

                    case "3":
                        //Beställ snöre.
                        OrderRope();
                        break;

                    case "4":
                        //Beställ tofu.
                        OrderTofu();
                        break;

                    case "5":
                        //Lista alla beställda produkter. 
                        ListOrders();
                        break;

                    case "6":
                        //Avsluta programmet.
                        run = HandleQuit(run);
                        break;

                    default:
                        //om användaren inte matar in en lämplig siffra
                        Console.WriteLine("Felaktig inmatning! Försök igen.");
                        Thread.Sleep(750);
                        Console.Clear();
                        continue;
                }
            }
        }

        public void CreateIntro()
        {
            //Hanterar intro vid programstart
            //är publik eftersom den anropas av main()

            Console.WriteLine("Välkommen till... *trumvirvel* ...");
            Thread.Sleep(3000); //bygger spänning 
            Console.Clear();

            //ASCII-intro

            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("************************************************************");
            Thread.Sleep(100);
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(" __  __       _ _   _  __      _          _ _ ");
            Thread.Sleep(100);
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("|  \\/  |     | | | (_)/ _|    | |        (_) |");
            Thread.Sleep(100);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("| \\  / |_   _| | |_ _| |_ __ _| |__  _ __ _| | _____ _ __");
            Thread.Sleep(100);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("| |\\/| | | | | | __| |  _/ _` | '_ \\| '__| | |/ / _ \\ '_ \\ ");
            Thread.Sleep(100);
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("| |  | | |_| | | |_| | || (_| | |_) | |  | |   <  __/ | | |");
            Thread.Sleep(100);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("|_|  |_|\\__,_|_|\\__|_|_| \\__,_|_.__/|_|  |_|_|\\_\\___|_| |_|");
            Thread.Sleep(100);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\n************************************************************");
            Thread.Sleep(1500);
            Console.ForegroundColor = ConsoleColor.White;
            System.Console.WriteLine("\n\n\t\t\tEn uppgiftslösning \n\n\t\t\t\tav \n\n\t\t\t    Axel Svahn");
            Thread.Sleep(5000);
            Console.Clear();
        }

        private void WriteMenu()
        {
            //skriver ut menyn

            Console.WriteLine("Introduktion:\n");
            Console.WriteLine("Här kan du beställa olika produkter från vår fabrik.");
            Console.WriteLine("Välj alternativ genom att skriva en siffra och tryck sedan på enterknappen.");
            Console.WriteLine("Du kan inte ta bort produkter efter att du beställt dem, så var försiktig!");
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Thread.Sleep(100);
            Console.WriteLine("\n1. Beställ bil.");
            Console.ForegroundColor = ConsoleColor.Blue;
            Thread.Sleep(100);
            Console.WriteLine("2. Beställ godis.");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Thread.Sleep(100);
            Console.WriteLine("3. Beställ snöre.");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Thread.Sleep(100);
            Console.WriteLine("4. Beställ tofu.");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Thread.Sleep(100);
            Console.WriteLine("5. Lista alla beställda produkter.");
            Thread.Sleep(100);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("6. Avsluta programmet.\n");
            Thread.Sleep(100);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Skriv här: ");
        }

        private bool HandleQuit(bool run)
        {
            //hanterar dialog för nedstängning av programmet

            Console.Write("Vill du verkligen sluta? j(a) / n(ej)");
            string input = Console.ReadLine();
            try
            {
                if (input.Substring(0, 1) == "j" || input.Substring(0, 1) == "J") //hanterar olika varianter på "ja"
                {
                    run = false;
                    Console.Clear();
                    Console.WriteLine("Tack för att du anlitade Multifabriken AB!");
                    return (run);
                }
                else if (input.Substring(0, 1) == "n" || input.Substring(0, 1) == "N") //hanterar olika varianter på "nej"
                {
                    Console.Write("Vad roligt att du vill vara kvar! ");
                    Console.WriteLine("Tryck på valfri tangent för att återgå till menyn.");
                    Console.ReadKey(true);
                    Console.Clear();
                    return (run);
                }
                else //hanterar icke-tomma svar som inte börjar med J eller N
                {
                    Console.WriteLine("Felaktigt svar!");
                    Thread.Sleep(750);
                    Console.Clear();
                    return (run);
                }
            }
            catch (System.Exception) //hanterar tomma svar
            {
                Console.WriteLine("Felaktigt svar!");
                Thread.Sleep(750);
                Console.Clear();
                return (run);
            }
        }
        private void OrderCar()
        {
            //Hanterar beställning av bil
            // 1. Inmatning av registreringsnummer

            Console.Clear();
            System.Console.WriteLine("Svenska bilnummer består av tre bokstäver och tre siffror.");
            System.Console.WriteLine("Sedan 2017 används bokstäverna A-Z.");

            string carLetters = "";
            bool inputLoop = true;
            while (inputLoop) //loopar tills användaren matat in något som fungerar som bilnummer
            {
                Console.Write("Var god skriv in tre bokstäver till bilens registreringsnummer: ");
                try
                {
                    carLetters = Console.ReadLine().Substring(0, 3).ToUpper(); //omvandlar till rätt format
                    if (Regex.IsMatch(carLetters, @"^[A-Z]+$")) //regex för A-Z: ÅÄÖ används inte i bilnummer
                    {
                        inputLoop = false;
                    }
                }
                catch (System.Exception) //hanterar (förhoppningsvis) övriga oförutsedda fel 
                {
                    Console.WriteLine("Försök igen.");
                }
            }
            string carNumbers = "";
            inputLoop = true;
            while (inputLoop)
            {
                Console.Write("Var god skriv in tre siffror till bilens registreringsnummer: ");
                try
                {
                    carNumbers = Console.ReadLine().Substring(0, 3);
                    if (Regex.IsMatch(carNumbers, @"^[0-9]+$")) //regex för siffror
                    {
                        inputLoop = false;
                    }
                }
                catch (System.Exception)
                {
                    Console.WriteLine("Det måste vara tre siffror.");
                }
            }
            string fullCarNumber = carLetters + " " + carNumbers;
            Console.WriteLine($"Bilens registreringsnummer blir: {fullCarNumber}\n");

            //2. Inmatning av färg på bil

            string carColor = "";
            inputLoop = true;
            while (inputLoop)
            {
                Console.Write("Var god ange bilens färg: ");
                try
                {
                    carColor = Console.ReadLine();
                    if (Regex.IsMatch(carColor, @"^[a-zåäöA-ZÅÄÖ]+$") && carColor.Length > 2) //undviker uppenbart felaktig input
                    {
                        inputLoop = false;
                    }
                }
                catch (System.Exception)
                {
                    Console.WriteLine("Försök igen.");
                }
            }

            //3. Inmatning av märke på bil

            string carBrand = "";
            inputLoop = true;
            while (inputLoop)
            {
                Console.Write("Var god ange bilmärke för bilen: ");
                try
                {
                    carBrand = Console.ReadLine();
                    if (carBrand.Length > 1) //undviker uppenbart felaktig input; bilar kan ju dock heta "M1" och liknande
                    {
                        inputLoop = false;
                    }
                }
                catch (System.Exception)
                {
                    Console.WriteLine("Försök igen.");
                }
            }

            // anropa konstruktor       
            Car inputCar = new Car(fullCarNumber, carColor, carBrand);
            System.Console.WriteLine($"\nDu har beställt följande bil: {inputCar.ToString()}");

            // stoppa in instans i lista
            carList.Add(inputCar);

            Console.WriteLine("Tryck på valfri tangent för att återgå till menyn.");
            Console.ReadKey(true);
            Console.Clear();
        }

        private void OrderCandy()
        {
            //Hanterar beställning av godis
            //1. Inmatning av smak

            Console.Clear();
            System.Console.WriteLine("Här på Multifabriken tillverkar vi alla tänkbara sorters smaskigt godis.");
            string flavor = "";
            bool inputLoop = true;
            while (inputLoop)
            {
                Console.Write("Var god ange godisets smak (använd endast bokstäver): ");
                try
                {
                    flavor = Console.ReadLine();
                    if (Regex.IsMatch(flavor, @"^[a-zåäöA-ZÅÄÖ]+$") && flavor.Length > 2) //undviker uppenbart felaktig input
                    {
                        inputLoop = false;
                    }
                }
                catch (System.Exception)
                {
                    Console.WriteLine("Försök igen.");
                }
            }

            // 2. Inmatning av mängd

            int amount = 0;
            inputLoop = true;
            while (inputLoop)
            {
                Console.Write("Var god ange antal godisbitar: ");
                try
                {
                    amount = Convert.ToInt32(Console.ReadLine());
                    if (amount < 1) //hanterar 0 och negativa tal
                    {
                        Console.WriteLine("Det blev inte mycket godis, så vi säger en bit iallafall.");
                        amount = 1;
                    }
                    inputLoop = false;
                }
                catch (System.Exception)
                {
                    Console.WriteLine("Försök igen. Ange endast heltal.");
                }
            }

            //anropa konstruktor
            Candy inputCandy = new Candy(flavor, amount);
            Console.WriteLine($"\nDu har beställt följande godis: {inputCandy.ToString()}");

            // stoppa in instans i lista
            candyList.Add(inputCandy);

            Console.WriteLine("Tryck på valfri tangent för att återgå till menyn.");
            Console.ReadKey(true);
            Console.Clear();
        }

        private void OrderRope()
        {
            //hanterar beställning av snöre
            // 1. Inmatning av färg

            Console.Clear();
            System.Console.WriteLine("Här på Multifabriken tillverkar vi alla tänkbara sorters färgglada snören.");
            string color = "";
            bool inputLoop = true;
            while (inputLoop)
            {
                Console.Write("Var god ange snörets färg (använd endast bokstäver): ");
                try
                {
                    color = Console.ReadLine();
                    if (Regex.IsMatch(color, @"^[a-zåäöA-ZÅÄÖ]+$") && color.Length > 2) //undviker uppenbart felaktig input
                    {
                        inputLoop = false;
                    }
                }
                catch (System.Exception)
                {
                    Console.WriteLine("Försök igen.");
                }
            }

            // 2. Inmatning av längd

            int ropeLength = 0;
            inputLoop = true;
            while (inputLoop)
            {
                Console.Write("Var god ange snörets längd i centimeter (endast heltal): ");
                try
                {
                    ropeLength = Convert.ToInt32(Console.ReadLine());
                    if (ropeLength < 1) //hanterar 0 och negativa tal
                    {
                        Console.WriteLine("Det blev inte mycket till snöre, så vi säger en centimeter iallafall.");
                        ropeLength = 1;
                    }
                    inputLoop = false;
                }
                catch (System.Exception)
                {
                    Console.WriteLine("Försök igen.");
                }
            }

            //anropa konstruktor
            Rope inputRope = new Rope(color, ropeLength);
            Console.WriteLine($"\nDu har beställt följande snöre: {inputRope.ToString()}");

            // stoppa in instans i lista
            ropeList.Add(inputRope);

            Console.WriteLine("Tryck på valfri tangent för att återgå till menyn.");
            Console.ReadKey(true);
            Console.Clear();
        }

        private void OrderTofu()
        {
            //Hanterar beställning av tofu
            // 1. Inmatning av volym

            Console.Clear();
            System.Console.WriteLine("Här på Multifabriken tillverkar vi alla tänkbara sorters mumsig tofu.");
            int volume = 0;
            bool inputLoop = true;
            while (inputLoop)
            {
                Console.Write("Var god ange volymen med tofu i liter (endast heltal): ");
                try
                {
                    volume = Convert.ToInt32(Console.ReadLine());
                    if (volume < 1) //hanterar 0 och negativa tal
                    {
                        Console.WriteLine("Det blev inte mycket tofu, så vi säger en liter iallafall.");
                        volume = 1;
                    }
                    inputLoop = false;
                }
                catch (System.Exception)
                {
                    Console.WriteLine("Försök igen.");
                }
            }

            // 2. Inmatning av kryddning

            string seasoning = "";
            inputLoop = true;
            while (inputLoop)
            {
                Console.Write("Var god ange tofuns kryddning (endast bokstäver): ");
                try
                {
                    seasoning = Console.ReadLine();
                    if (Regex.IsMatch(seasoning, @"^[a-zåäöA-ZÅÄÖ]+$") && seasoning.Length > 2) //undviker uppenbart felaktig input
                    {
                        inputLoop = false;
                    }
                }
                catch (System.Exception)
                {
                    Console.WriteLine("Försök igen.");
                }
            }

            //Anropa konstruktor
            Tofu inputTofu = new Tofu(volume, seasoning);
            Console.WriteLine($"\nDu har beställt följande tofu: {inputTofu.ToString()}");

            // Stoppa in instans i lista
            tofuList.Add(inputTofu);

            Console.WriteLine("Tryck på valfri tangent för att återgå till menyn.");
            Console.ReadKey(true);
            Console.Clear();
        }

        private void ListOrders()
        {
            // Loopar igenom respektive lista och visar nummer samt egenskaper för varje lagrat objekt.  
            // Hanterar vad som händer om en lista är tom.

            Console.Clear();
            System.Console.WriteLine("Nu ska vi se vad du har beställt!");
            Thread.Sleep(1500); //ger bättre användarupplevelse än att ge all information omedelbart

            //1. Lista på bilar

            Console.WriteLine("\nDu har beställt följande bilar:");
            if (carList.Count == 0)
            {
                Console.WriteLine("Inga!");
            }
            else
            {
                for (int i = 0; i < carList.Count; i++)
                {
                    Car car = carList[i];
                    Console.WriteLine(i + 1 + ": " + car.ToString());
                }
            }

            //2. Lista på godis

            Thread.Sleep(1000);
            Console.WriteLine("\nDu har beställt följande typer av godis:");
            if (candyList.Count == 0)
            {
                Console.WriteLine("Inga!");
            }
            else
            {
                for (int i = 0; i < candyList.Count; i++)
                {
                    Candy candy = candyList[i];
                    Console.WriteLine(i + 1 + ": " + candy.ToString());
                }
            }

            //3. Lista på snören

            Thread.Sleep(1000);
            Console.WriteLine("\nDu har beställt följande typer av snören:");
            if (ropeList.Count == 0)
            {
                Console.WriteLine("Inga!");
            }
            else
            {
                for (int i = 0; i < ropeList.Count; i++)
                {
                    Rope rope = ropeList[i];
                    Console.WriteLine(i + 1 + ": " + rope.ToString());
                }
            }

            //4. Lista på tofu

            Thread.Sleep(1000);
            Console.WriteLine("\nDu har beställt följande typer av tofu:");
            if (tofuList.Count == 0)
            {
                Console.WriteLine("Inga!");
            }
            else
            {
                for (int i = 0; i < tofuList.Count; i++)
                {
                    Tofu tofu = tofuList[i];
                    Console.WriteLine(i + 1 + ": " + tofu.ToString());
                }
            }

            Thread.Sleep(1000);
            Console.WriteLine("\nTryck på valfri tangent för att återgå till menyn.");
            Console.ReadKey(true);
            Console.Clear();
        }
    }
}
