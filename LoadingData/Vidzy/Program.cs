
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
            //Exercise 1
            AddVideo("Terminator 1", new DateTime(1984, 10, 26), Classification.Silver, "Action");

            //Exercise 2
            AddTag("Classics");            
            AddTag("Drama");

            //Exercise 3
            AssingTag("Classics", 1);
            AssingTag("Drama", 1);
            AssingTag("Comedy", 1);

            //Exercise 4
            RemoveTag("Comedy", 1);

            //Exercise 5
            DeleteVideo(1);

            //Exercise 6
            DeleteGenre(2);

        }

        public static void AddVideo(string name, DateTime release, Classification classification, string genreName)
        {
            using(var context = new VidzyContext())
            {
                byte genreId = context.Genres.Where(x => x.Name == genreName).Select(x => x.Id).FirstOrDefault();

                Video newVideo = new Video
                {
                    Name = name,
                    ReleaseDate = release,
                    Classification = classification,
                    GenreId = genreId
                };

                context.Videos.Add(newVideo);
                context.SaveChanges();
            }
        }

        public static void AddTag(string name)
        {
            using (var context = new VidzyContext())
            {
                Tag newTag = new Tag
                {
                    Name = name
                };

                context.Tags.Add(newTag);
                context.SaveChanges();
            }
        }

        public static void AssingTag(string tagName, int videoId)
        {
            using (var context = new VidzyContext())
            {
                var tag = context.Tags.Where(x => x.Name == tagName).FirstOrDefault();
                if(tag == null)
                {
                    tag = new Tag { Name = tagName };
                    context.Tags.Add(tag);
                    context.SaveChanges();
                }

                var video = context.Videos.Find(videoId);
                if(!video.Tags.Where(x => x.Name == tag.Name).Any())
                {
                    video.Tags.Add(tag);
                    context.SaveChanges();
                }
            }
        }

        public static void RemoveTag(string tagName, int videoId)
        {            
            using (var context = new VidzyContext())
            {
                var video = context.Videos.Find(videoId);
                var tag = video.Tags.Where(x => x.Name == tagName).FirstOrDefault();
                video.Tags.Remove(tag);
                context.SaveChanges();
            }
        }

        public static void DeleteVideo(int videoId)
        {
            using (var context = new VidzyContext())
            {
                var video = context.Videos.Where(x => x.Id == videoId).FirstOrDefault();
                if(video != null)
                {
                    context.Videos.Remove(video);
                    context.SaveChanges();
                }                
            }
        }

        public static void DeleteGenre(int genreId)
        {
            using (var context = new VidzyContext())
            {
                var genre = context.Genres.Where(x => x.Id == genreId).Include(x => x.Videos).FirstOrDefault();
                if(genre != null)
                {
                    context.Videos.RemoveRange(genre.Videos);
                    context.Genres.Remove(genre);
                    context.SaveChanges();
                }               
            }
        }
    }
}
