using System.Collections.Generic;

public interface IDataLoader<T>
{
    Stack<T> LoadDataToStack(string path);

    List<T> LoadDataToList(string path);

    Queue<T> LoadDataToQueue(string path);
}
