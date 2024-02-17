using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPassage
{
    string Type {get;}
    IRoomable Room {get;}
}
