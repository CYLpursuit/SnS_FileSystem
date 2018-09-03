using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    class CodeControl
    {
        public static void PrintLine() {
            Console.WriteLine("*************************************************************");
        }

        public static void PrintError() {
            Console.WriteLine("It's wrong.");
        }

        public static void PrintFinish() {
            Console.WriteLine("succeed!");
        }

        public static void PrintTab()
        {
            Console.Write('\t');
        }
    }
}
