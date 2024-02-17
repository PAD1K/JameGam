using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IObjectPoolElement<T> where T : MonoBehaviour, IObjectPoolElement<T>
{
    public void SetObjectPool(ObjectPool<T> objectPool);
}
