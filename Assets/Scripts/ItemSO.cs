using UnityEngine;

[CreateAssetMenu()]
public class ItemSO : ScriptableObject
{
    public string id;
    public Sprite icon;
    public int price;
    public GameObject prefab;
    public ItemType itemType;
    public ItemState itemState;
}
