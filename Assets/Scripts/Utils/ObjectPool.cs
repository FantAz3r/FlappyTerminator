using System;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool<T> where T : MonoBehaviour
{
    private T _prefab;
    private List<T> _objects;
    private Stack<T> _availableObjects;
    private Quaternion _startRotation = Quaternion.Euler(0, 0, 90);
    public ObjectPool(T prefab)
    {
        _prefab = prefab;
        _objects = new List<T>();
        _availableObjects = new Stack<T>();
    }

    public event Action<T> Released;

    public T Get()
    {
        if (_availableObjects.Count > 0)
        {
            T obj = _availableObjects.Pop();
            obj.gameObject.SetActive(true);
            return obj;
        }
        else
        {
            return Create();
        }
    }

    public void Release(T obj)
    {
        obj.transform.position = Vector3.zero;
        obj.transform.rotation = _startRotation;

        if (obj.TryGetComponent(out Rigidbody rigidbody))
        {
            rigidbody.velocity = Vector3.zero;
            rigidbody.angularVelocity = Vector3.zero;
        }

        obj.gameObject.SetActive(false);
        Released?.Invoke(obj);
        _availableObjects.Push(obj);
    }

    private T Create()
    {
        T obj = GameObject.Instantiate(_prefab);
        _objects.Add(obj);
        return obj;
    }

    public void Clear()
    {
        foreach (T obj in _objects)
        {
            Release(obj);
        }

        _availableObjects = new Stack<T>(_objects);
    }
}