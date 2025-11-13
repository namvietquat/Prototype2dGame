using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    private List<Item> _items = new();
    public Action<Item> OnItemAdded;
    public void AddItem(Item item)
    {
        _items.Add(item);
        OnItemAdded?.Invoke(item);
    }
}