namespace DAL.Migrations
{
    using DAL.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DAL.DBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
            ContextKey = "DAL.DBContext";
        }


        public class MyContextInitializer : DropCreateDatabaseAlways<DBContext>
        {
            protected override void Seed(DBContext context)
            {

                context.Authors.Add(new Author { NickName = "Kolya", Status = "user", CountComments = 0 });
                context.Authors.Add(new Author { NickName = "Vasya", Status = "experienced user", CountComments = 20 });
                context.Authors.Add(new Author { NickName = "Yura", Status = "advanced user", CountComments = 50 });
                context.Authors.Add(new Author { NickName = "Kostya", Status = "guru user", CountComments = 100 });

                context.Categories.Add(new Category { Title = "Humor", Discription = "A smile is a sign of good mood." });
                context.Categories.Add(new Category { Title = "Fishing", Discription = "As for fishing - fishing spots, tackle, bait, etc." });
                context.Categories.Add(new Category { Title = "Auto", Discription = "News, reviews, desires." });
                context.Categories.Add(new Category { Title = "Games", Discription = "Games - news, strategies, walkthroughs, etc." });

                context.Tags.Add(new Tag { Text = "Humor" });
                context.Tags.Add(new Tag { Text = "good" });
                context.Tags.Add(new Tag { Text = "fish" });
                context.Tags.Add(new Tag { Text = "bait" });
                context.Tags.Add(new Tag { Text = "review" });
                context.Tags.Add(new Tag { Text = "Auto" });
                context.Tags.Add(new Tag { Text = "new" });
                context.Tags.Add(new Tag { Text = "game" });

                context.SaveChanges();                

                context.Posts.Add(new Post
                {
                    Author = context.Authors.FirstOrDefault(x => x.NickName == "Kostya"),
                    //AuthorId = context.Authors.Single(x => x.NickName == "Kostya").Id,
                    Category = context.Categories.FirstOrDefault(x => x.Title == "Fishing"),
                    DateTime = DateTime.Today,
                    Text = "ffgghghgguuhhuhhhhuuuhhj13",
                    Title = "Fishing rod"
                });

                context.Posts.Add(new Post
                {
                    Author = context.Authors.FirstOrDefault(x => x.NickName == "Kostya"),
                    //AuthorId = context.Authors.Single(x => x.NickName == "Kostya").Id,
                    Category = context.Categories.FirstOrDefault(x => x.Title == "Auto"),
                    DateTime = DateTime.Today,
                    Text = "ffgghghgguuhhuhhhhuuuhhj13 rtuityug",
                    Title = "Classic auto"
                });

                context.Posts.Add(new Post
                {
                    Author = context.Authors.FirstOrDefault(x => x.NickName == "Kostya"),
                   // AuthorId = context.Authors.Single(x => x.NickName == "Kostya").Id,
                    Category = context.Categories.FirstOrDefault(x => x.Title == "Humor"),
                    DateTime = DateTime.Today,
                    Text = "ffgghghgguuhhuhhhhuuuhhj13 123",
                    Title = "Black humor"
                });

                context.SaveChanges();

                context.Comments.Add(new Comment
                {
                    AuthorId = context.Authors.Single(x => x.NickName == "Kostya").Id,
                    Post = context.Posts.FirstOrDefault(x => x.Title == "Fishing rod"),
                    DateTime = DateTime.Today,
                    Text = "ffgghghgguuhhuhhhhuuuhhj13 hjlhjkhcjghjb",
                });
                context.Comments.Add(new Comment
                {
                    AuthorId = context.Authors.Single(x => x.NickName == "Vasya").Id,
                    Post = context.Posts.FirstOrDefault(x => x.Title == "Classic auto"),
                    DateTime = DateTime.Today,
                    Text = "eesxeseesesscrdrcdsstfcfxdxcxdsddfxdsddxdsddd fdfgcfddr rdyuh l ",
                });
                context.Comments.Add(new Comment
                {
                    AuthorId = context.Authors.Single(x => x.NickName == "Yura").Id,
                    Post = context.Posts.FirstOrDefault(x => x.Title == "Classic auto"),
                    DateTime = DateTime.Today,
                    Text = "okknhjnbhvcdxddg cxfgbh  ghhufxxbbkjddhfcvmb mhfghlj  hjgyg",
                });

                context.SaveChanges();
            }
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

        }
    }
}
