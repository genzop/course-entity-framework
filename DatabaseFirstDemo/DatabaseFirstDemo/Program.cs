using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseFirstDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = new DatabaseFirstDemoEntities();
            var post = new Post
            {
                Body = "Body",
                DatePublished = DateTime.Now,
                PostID = 1,
                Title = "Title"
            };
            context.Posts.Add(post);
            context.SaveChanges();
        }
    }
}
