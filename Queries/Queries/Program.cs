
using Queries.Models;
using System;
using System.Data.Entity;
using System.Linq;

namespace Queries
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = new PlutoContext();

            #region LINQ Syntax Example       
            /*var query = from c in context.Courses
                        where c.Name.Contains("c#")
                        orderby c.Name
                        select c;

            foreach (var course in query)
            {
                Console.WriteLine(course.Name);
            }*/
            #endregion

            #region LINQ Extension Methods Example
            /*var query2 = context.Courses
                .Where(c => c.Name.Contains("c#"))
                .OrderBy(c => c.Name);

            foreach (var course in query2)
            {
                Console.WriteLine(course.Name);
            }*/
            #endregion

            #region LINQ Syntax            
            /*var query = from c in context.Courses
                         where c.Level == 1 && c.Author.Id == 1
                         orderby c.Level descending, c.Name
                         select new { Name = c.Name, Author = c.Author.Name };

            var groupBy = from c in context.Courses
                          group c by c.Level into g
                          select g;

            var innerJoin = from c in context.Courses
                            join a in context.Authors on c.AuthorId equals a.Id
                            select new { CourseName = c.Name, AuthorName = a.Name };

            var groupJoin = from a in context.Authors
                            join c in context.Courses on a.Id equals c.AuthorId into g
                            select new { AuthorName = a.Name, Courses = g.Count() };

            var crossJoin = from a in context.Authors
                            from c in context.Courses
                            select new { AuthorName = a.Name, CourseName = c.Name };

            foreach (var x in crossJoin)
            {
                Console.WriteLine("{0} - {1}", x.AuthorName, x.CourseName);
            }*/
            #endregion

            #region LINQ Extension Methods
            /*var filtering = context.Courses.Where(c => c.Level == 1);

            var ordering = context.Courses.OrderByDescending(c => c.Name).ThenBy(c => c.Level);

            var proyection = context.Courses.Select(c => new { CourseName = c.Name, AuthorName = c.Author.Name });
            var proyection2 = context.Courses.SelectMany(c => c.Tags);

            var distinct = context.Courses.SelectMany(c => c.Tags).Distinct();

            var groupBy = context.Courses.GroupBy(c => c.Level);

            var innerJoin = context.Courses.Join(context.Authors, c => c.AuthorId, a => a.Id, (course, author) => new { CourseName = course.Name, AuthorName = author.Name });

            var groupJoin = context.Authors.GroupJoin(context.Courses, a => a.Id, c => c.AuthorId, (author, courses) => new { Author = author, Courses = courses });

            var crossJoin = context.Authors.SelectMany(a => context.Courses, (author, course) => new { AuthorName = author.Name, CourseName = course.Name });

            var pagination = context.Courses.Skip(10).Take(10);

            var first = context.Courses.OrderBy(x => x.Level).FirstOrDefault();

            var last = context.Courses.OrderBy(x => x.Level).LastOrDefault();

            var single = context.Courses.SingleOrDefault(x => x.Id == 1);

            var all = context.Courses.All(x => x.Name.Contains("C#"));

            var any = context.Courses.Any(x => x.Name == "Beginner C#");

            var count = context.Courses.Count();

            var max = context.Courses.Max(x => x.FullPrice);

            var min = context.Courses.Min(x => x.FullPrice);

            var average = context.Courses.Average(x => x.FullPrice);*/
            #endregion

            #region Deferred Execution
            /*
            var courses = context.Courses;
            var filtered = courses.Where(c => c.Level == 1);
            var sorted = filtered.OrderBy(c => c.Name);
            */
            #endregion

            #region Loading related objects
            var eagerLoading1 = context.Courses.Include("Author").ToList();
            var eagerLoading2 = context.Courses.Include(c => c.Author);
                        
            var explicitLoading1 = context.Authors.Single(a => a.Id == 1);
            context.Courses.Where(c => c.AuthorId == explicitLoading1.Id).Load();
            #endregion

            #region Add objects
            //var authorId = context.Authors.Where(x => x.Name.Contains("Mosh")).Select(x => x.Id).FirstOrDefault();

            //var course = new Course
            //{
            //    Name = "New Course",
            //    Description = "New Description",
            //    FullPrice = 19.95f,
            //    Level = 1,
            //    AuthorId = authorId,
            //};

            //context.Courses.Add(course);
            #endregion

            #region Update objects
            //var course = context.Courses.Find(1);
            //course.Name = "New Name";
            //course.AuthorId = 2;

            //context.SaveChanges();
            #endregion

            #region Delete objects
            //var author = context.Authors.Include(x => x.Courses).Single(x => x.Id == 2);
            //context.Courses.RemoveRange(author.Courses);
            //context.Authors.Remove(author);

            //context.SaveChanges();
            #endregion
        }
    }
}
