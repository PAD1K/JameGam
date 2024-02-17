using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IKeyable
{
    void InstantiateComponent(Vector3 position);
    void DestroyComponent();
}
