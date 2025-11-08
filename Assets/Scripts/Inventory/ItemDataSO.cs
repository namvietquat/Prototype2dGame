using UnityEngine;

[CreateAssetMenu(fileName = "ItemData", menuName = "Data/Item Data SO")]
public class ItemDataSO : ScriptableObject
{
    public string Name;
    public Sprite Image;
    public int MaxStackSize;
    public string Description;
}