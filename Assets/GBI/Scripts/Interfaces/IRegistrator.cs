namespace Geekbrains
{
    public interface IRegistrator<T>
    {
        void Register(T   record);
        void Unregister(T record);
    }
}