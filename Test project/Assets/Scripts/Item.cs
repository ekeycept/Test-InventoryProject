using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public abstract class Item : ScriptableObject
{
    public ItemClass itemClass;
    public Sprite sprite;
    public string itemName;
    public float itemWeight;
    public bool isStackable;
    public int stackCaptivity;
    public int amount;
}
