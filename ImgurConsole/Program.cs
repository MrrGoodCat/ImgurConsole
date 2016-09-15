using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImgurConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            DataProvider data = new DataProvider();
            Console.WriteLine(data.authorizationUri);
            Console.ReadKey();
        }
    }
}
