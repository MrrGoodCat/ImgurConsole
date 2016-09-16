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
            ImgurToken token = new ImgurToken();
            DataProvider data = new DataProvider();
            //Console.WriteLine(data.authorizationUri);
            Console.WriteLine(DataProvider.GetPin("59b901759d20a52", "9fa708a1d20975d47e425c255ebd60acc49c2b58"));
            Console.ReadKey();
        }
    }
}
