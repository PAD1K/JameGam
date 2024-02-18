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
            var obj = CreateOneObject();
            _objects.Add(obj);
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
        _objects.Remove(obj);
        GameObject.Destroy(obj.gameObject);

        var newObj = CreateOneObject();
        _objects.Add(newObj);
    }

    // КОСТЫЛЬ
    protected T CreateOneObject()
    {
        var obj = GameObject.Instantiate(_prefab);
        obj.SetObjectPool(this);
        obj.gameObject.SetActive(false);
        return obj;
    }

    protected T Create()
    {
        var obj = GameObject.Instantiate(_prefab);
        _objects.Add(obj);
        return obj;
    }

}
