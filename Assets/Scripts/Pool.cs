using System;
using System.Collections.Generic;

public class Pool<T> 
{
    readonly Stack<T> _objects = new Stack<T>();

    readonly Func<T> _objectGenerator;
    readonly Action<T> _objectResetter;

    public Pool(Func<T> objectGenerator, Action<T> objectResetter, int initialCapacity )
    {
        _objectGenerator = objectGenerator;
        _objectResetter = objectResetter;

        for (int i = 0; i < initialCapacity; i++)
        {
            _objects.Push(_objectGenerator());
        }
    }

    public T GetObject() => _objects.Count == 0 ? _objectGenerator() : _objects.Pop();

    public void ReturnObject(T item)
    {
        _objectResetter(item);
        _objects.Push(item);
    }

    public void Clear() => _objects.Clear();

    public int Count => _objects.Count;
}