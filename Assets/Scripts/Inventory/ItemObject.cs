using UnityEngine;

public class ItemObject : MonoBehaviour
{
    [SerializeField] private ItemDataSO _itemData;
    private Item _item;
    void Awake()
    {
        _item = new Item(_itemData);
    }
    void OnValidate()
    {
        gameObject.name = "Item_" + _itemData.Name;
    }
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.layer != LayerMask.NameToLayer("Player"))
        {
            return;
        }
        if (collider.TryGetComponent<PlayerInventory>(out var playerInventory))
        {
            playerInventory.AddItem(_item);
            Destroy(gameObject);
        }
    }
}