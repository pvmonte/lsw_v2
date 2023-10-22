using UnityEngine;

public enum ItemType
{
    Shirt,
    Pants,
    Shoes,
    Hair,
    Hat
}

[CreateAssetMenu(menuName = "Item", fileName = "Item")]
public class Item : ScriptableObject
{
    [field: SerializeField] public ItemType Type { get; private set; }
    [field: SerializeField] public string Name { get; private set; }
    [field: SerializeField] public Sprite Icon { get; private set; }
    [field: SerializeField] public int Price { get; private set; }
    [field: SerializeField] public GameObject Prefab { get; private set; }
}