using System;
using System.Collections.Generic;

namespace DelegateTest
{
    delegate bool PostCondition(Post post);
    delegate void ActionInPost(Post post);

    static class Program
    {
        private static void AddPostInMailBody(Post post)
        {
            throw new NotImplementedException();
        }

        private static bool PostIsMovieCategory(Post post)
        {
            return post.Equals("Movie");
        }
                
        private static void ExecActionInFilteredListOfPost(IEnumerable<Post> posts, PostCondition AnyCondition, ActionInPost AnyAction)
        {
            foreach (Post post in posts)
            {
                if (AnyCondition(post))
                    AnyAction(post);
            }
        }

        private static void ExecAction(IEnumerable<Post> posts, Func<Post,bool> AnyCondition, Action<Post> AnyAction)
        {
            foreach (Post post in posts)
            {
                if (AnyCondition(post))
                    AnyAction(post);
            }
        }

        static void Main(string[] args)
        {
            var posts = new List<Post>
            {
                new Post
                {
                    Title = "Harry Potter I",
                    Summary = "The Philosopher's Stone ",
                    Category = "Movie"
                },
                new Post
                {
                    Title = "Harry Potter II",
                    Summary = "Secret Chamber",
                    Category = "Movie"
                },
                new Post
                {
                    Title = "Harry Potter III",
                    Summary = "The Prisoner of Azkaban",
                    Category = "Movie"
                },
                new Post
                {
                    Title = "Game of Thrones",
                    Summary = "Winter is Coming",
                    Category = "Series"
                },
                new Post
                {
                    Title = "10 Tips for Starting a Programming Career",
                    Summary = "Career Orientation",
                    Category = "Tips"
                },
                new Post
                {
                    Title = "Refactoring",
                    Summary = "Improving design of existing code",
                    Category = "Books"
                },
            };

            foreach (Post post in posts)
            {
                Console.WriteLine(post.Title);
            }

            foreach (Post post in posts)
            {
                if (post.Category.Equals("Movie"))
                    Console.WriteLine(post.Title);
            }

            foreach (Post post in posts)
            {
                if (post.Category.Equals("Movie"))
                    AddPostInMailBody(post);
            }

            foreach (Post post in posts)
            {
                if (PostIsMovieCategory(post))
                    Console.WriteLine(post.Title);
            }

            foreach (Post post in posts)
            {
                if (PostIsMovieCategory(post))
                    AddPostInMailBody(post);
            }

            //Método passando Métodos como parametros: MindBlow Nv:1!
            ExecActionInFilteredListOfPost(posts, PostIsMovieCategory, AddPostInMailBody);

            //Método passando delegates como parametros para executar uma operação (Obs.: sem precisar criar um Métodos): MindBlow Nv2!
            ExecActionInFilteredListOfPost(
                posts,
                delegate (Post post) { return post.Category.Equals("Movie"); },
                delegate (Post post) { Console.WriteLine(post.Title); }
                );

            //Método passando delegates como parametros para executar uma operação dessa vez com Lambda Expression: MindBlow Nv3!
            ExecActionInFilteredListOfPost(
                posts,
                post => post.Category.Equals("Movie"),
                post => Console.WriteLine(post.Title)
                );

            //USING NATIVE DELEGATE .NET
            //Método passando Métodos como parametros: MindBlow Nv:1!
            ExecAction(posts, PostIsMovieCategory, AddPostInMailBody);

            //Método passando delegates como parametros para executar uma operação (Obs.: sem precisar criar um Métodos): MindBlow Nv2!
            ExecAction(
                posts,
                delegate (Post post) { return post.Category.Equals("Filmes"); },
                delegate (Post post) { Console.WriteLine(post.Title); }
                );

            //Método passando delegates como parametros para executar uma operação dessa vez com Lambda Expression: MindBlow Nv3!
            ExecAction(
                posts,
                post => post.Category.Equals("Filmes"),
                post => Console.WriteLine(post.Title)
                );
        }
    }
}
