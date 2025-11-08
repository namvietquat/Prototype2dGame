using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class InventoryPanel : MonoBehaviour
{
    private List<InventorySlot> _itemSlot = new();
    void Awake()
    {
        _itemSlot.AddRange(GetComponentsInChildren<InventorySlot>());
    }
    public void Initialize(PlayerInventory playerInventory)
    {
        playerInventory.OnItemAdded += AddItem;
    }
    public void AddItem(Item item)
    {
        var slot = _itemSlot.FirstOrDefault(s => s.Name == item.ItemData.Name &&
                                                s.CanBeStack);
        if (slot != null)
        {
            // Stack
            slot.StackUp();
        }
        else
        {
            var freeSlot = _itemSlot.FirstOrDefault(s => s.IsAvailable);
            if (freeSlot != null)
            {
                freeSlot.Initialize(item);
                freeSlot.IsAvailable = false;
            }
        }
    }
    public void RemoveItem(InventorySlot slot)
    {
        slot.FreeSlot();
    }
}
