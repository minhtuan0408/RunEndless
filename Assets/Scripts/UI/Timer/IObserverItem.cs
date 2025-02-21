using System;
using UnityEngine;


public interface IObserverItem
{
    // default implementation (C# 8.0+) mới cớ thể viết body cho hàm 
    public void OnNotify(ItemType type);

    void OffNotify(ItemType type);
}
