using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ObjectPool<T> where T : MonoBehaviour, IObjectPoolElement<T>
{
    private T _prefab;
    private List<T> _objects;

    public ObjectPool(T prefab, int prewarmObjects)
    {
        _prefab = prefab;
        _objects = new List<T>();

        for (int i = 0; i < prewarmObjects; i++)
        {
            var obj = Create();
        }
    }

    public T Get()
    {
        var obj = _objects.FirstOrDefault(x => !x.isActiveAndEnabled);

        if (obj == null)
        {
            obj = Create();
        }

        obj.gameObject.SetActive(true);
        return obj;
    }

    public void Release(T obj)
    {
        obj.gameObject.SetActive(false);
    }

    protected T Create()
    {
        var obj = GameObject.Instantiate(_prefab);
        obj.SetObjectPool(this);
        _objects.Add(obj);
        obj.gameObject.SetActive(false);
        return obj;
    }

}
