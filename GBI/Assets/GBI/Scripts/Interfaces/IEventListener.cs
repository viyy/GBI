namespace Geekbrains
{
    public interface IEventListener<in T> where T : BaseEvent
    {
        void HandleEvent<T>(T eventArgs);
    }
}