namespace Geekbrains
{
    public interface IEventDispatcher
    {
        void DispatchEvent<T>(T eventArgs)
            where T : BaseEvent;

        void AddEventListener<T>(IEventListener<T> listener)
            where T : BaseEvent;
    }
}