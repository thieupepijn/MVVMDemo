using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMDemo
{
    public class Util
    {

        public static string RandomName()
        {
            Random random = new Random();

            int number = random.Next(0, 5);

            switch (number)
            {
                case 0: return "Felicity";
                case 1: return "Serenity";
                case 2: return "Rafaella";
                case 3: return "Maria";
                case 4: return "Pepijn";
                default: return string.Empty;
            }



        }


    }
}
