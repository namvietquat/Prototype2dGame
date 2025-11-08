using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class InventorySlot : MonoBehaviour
{
    [SerializeField] private TMP_Text _name;
    [SerializeField] private TMP_Text _stackText;
    [SerializeField] private Image _thumbnail;
    public string Name => _name.text;
    public bool IsAvailable = true;
    private int _currentStackSize;
    private Item _item;
    public Item Item => _item;
    public bool CanBeStack => _currentStackSize < _item.ItemData.MaxStackSize;
    public void Initialize(Item item)
    {
        _item = item;
        _name.text = item.ItemData.Name;
        _thumbnail.sprite = item.ItemData.Image;
        _thumbnail.color = Color.white;

        StackUp();
    }
    public void StackUp()
    {
        _currentStackSize++;
        UpdateStackText();
    }
    public void StackDown()
    {
        _currentStackSize--;
        UpdateStackText();
    }
    private void UpdateStackText()
    {
        _stackText.text = _currentStackSize > 1 ? _currentStackSize.ToString() : "";
    }
    public void FreeSlot()
    {
        _item = null;
        _name.text = "";
        _thumbnail.sprite = null;
        _thumbnail.color = default;
        _currentStackSize = 0;
        IsAvailable = true;
        UpdateStackText();
    }
}
