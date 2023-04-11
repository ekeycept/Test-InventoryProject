using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Gun", menuName = "Items/Gun")]
public class Gun : Item
{
    public float damage;
    public Item ammoType;
}
