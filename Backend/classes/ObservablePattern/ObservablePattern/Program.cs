using System;
using ObservablePattern.Implements;
using ObservablePattern.Models;
using ObservablePattern.Services;

namespace ObservablePattern
{
    class Program
    {
        static void Main(string[] args)
        {
            var jornal = new Publisher<News>();

            var leitor_1 = new Leitor();
            var leitor_2 = new Leitor();
            var leitor_3 = new Leitor();

            jornal.AddSubscribe(leitor_1);
            jornal.AddSubscribe(leitor_2);
            jornal.AddSubscribe(leitor_3);

            var news = new News
            {
                Title = "Novas Notícias",
                Description = "asdjkasldakldaksd"
            };

            jornal.NotifySubscribers(news);
            

            Console.ReadKey();
        }
    }
}
