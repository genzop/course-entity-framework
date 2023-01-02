using Queries.Models;
using System;
using System.Data.Entity;
using System.Linq;
using Vidzy.Models;

namespace Vidzy
{
    class Program
    {
        static void Main(string[] args)
        {
            VidzyContext context = new VidzyContext();

            #region Section 6
            //var query1 = context.Videos.Where(x => x.Genre.Name == "Action").OrderBy(x => x.Name);
            //var query2 = context.Videos.Where(x => x.Genre.Name == "Drama" && x.Classification == Classification.Gold).OrderByDescending(x => x.ReleaseDate);
            //var query3 = context.Videos.Select(x => new { MovieName = x.Name, Genre = x.Genre });
            //var query4 = context.Videos.GroupBy(x => x.Classification).Select(x => new { Classification = x.Key, Movies = x });
            //var query5 = context.Videos.GroupBy(x => x.Classification).Select(x => new { Name = x.Key.ToString(), Count = x.Count() }).OrderBy(x => x.Name);
            //var query6 = context.Genres.Select(x => new { Name = x.Name, Count = x.Videos.Count }).OrderByDescending(x => x.Count);
            #endregion

            #region Section 7
            //var query7 = context.Videos.Include(x => x.Genre).ToList();
            #endregion

            foreach (var x in query7)
            {
                Console.WriteLine("{0}", x.Genre.Name);
            }
        }
    }
}
