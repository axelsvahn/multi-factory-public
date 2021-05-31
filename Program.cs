using System;
using System.Collections.Generic;

namespace Multifabriken
{
    class Program
    {
        static void Main(string[] args)
        {
            //anropar menyklassen och inget mer
            Menu myMenu = new Menu();
            myMenu.CreateIntro();
            myMenu.RunMenu(); 
        }
    }
}
