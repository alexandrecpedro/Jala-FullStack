using System;
using System.IO;
using ObservablePattern.Models;
using ObservablePattern.Interfaces;

namespace ObservablePattern.Implements
{
    public class Leitor : ISubscriber<News>
    {
        public void OnCompleted()
        {
            throw new NotImplementedException();
        }

        public void OnError(IOException exception)
        {
            throw new NotImplementedException();
        }

        public void OnUpdate(News data)
        {
            Console.WriteLine(data.Title);
            Console.WriteLine(data.Description);
        }
    }
}
