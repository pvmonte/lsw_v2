using UnityEngine;

[System.Serializable]
public class ItemSlot
{
    [SerializeField] private GameObject equipped;
    [SerializeField] private Transform slotTransform;

    public void Equip(Item item)
    {
        if (equipped != null)
        {
            GameObject.Destroy(equipped.gameObject);
        }
        
        equipped = GameObject.Instantiate(item.Prefab, slotTransform);
    }
}