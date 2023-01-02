using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vidzy
{
    class Program
    {
        static void Main(string[] args)
        {
            VidzyDbContext context = new VidzyDbContext();
            context.AddVideo("Schindler's List", new DateTime(1994, 02, 24), "Thriller", (byte)Classification.Platinum);
        }
    }
}
