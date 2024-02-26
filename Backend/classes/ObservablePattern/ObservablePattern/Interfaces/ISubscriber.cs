using System.IO;

namespace ObservablePattern.Interfaces
{
    public interface ISubscriber<T>
    {
        void OnUpdate(T data);
        void OnError(IOException exception);
        void OnCompleted();
    }
}
