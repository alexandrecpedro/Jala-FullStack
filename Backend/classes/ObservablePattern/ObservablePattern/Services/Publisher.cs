using System;
using System.Collections.Generic;
using ObservablePattern.Interfaces;

namespace ObservablePattern.Services
{
    public class Publisher<T> : IPublisher<T>
    {
        private readonly List<ISubscriber<T>> _subscribers;

        public Publisher()
        {
            _subscribers = new List<ISubscriber<T>>();
        }
        
        public void AddSubscribe(ISubscriber<T> subscriber)
        {
            if (!_subscribers.Contains(subscriber))
            {
                _subscribers.Add(subscriber);
            }
        }

        public void NotifySubscribers(T Data)
        {
            foreach(var subscriber in _subscribers)
            {
                subscriber.OnUpdate(Data);
            }
        }

        public void RemoveSubscribe(ISubscriber<T> subscriber)
        {
            if (_subscribers.Contains(subscriber))
            {
                _subscribers.Remove(subscriber);
            }
        }
    }
}
