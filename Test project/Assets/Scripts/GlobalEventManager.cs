using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GlobalEventManager
{
    public static Action OnInventoryChanged;

    public static void SendInventoryChanged()
    {
        if (OnInventoryChanged != null)
            OnInventoryChanged.Invoke();
    }

}
