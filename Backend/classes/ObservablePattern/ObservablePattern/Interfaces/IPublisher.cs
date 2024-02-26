namespace ObservablePattern.Interfaces
{
    public interface IPublisher<T>
    {
        void NotifySubscribers(T Data);
        void AddSubscribe(ISubscriber<T> subscriber);
        void RemoveSubscribe(ISubscriber<T> subscriber);
    }
}