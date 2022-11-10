using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemObject", menuName = "ScriptableObject/ItemMap")]
public class WeapownData : ScriptableObject
{
    public WeapownDataset setData;
}

[System.Serializable]
public struct WeapownDataset
{
    public int Id;
    public string itemName;
    public GameObject itemObject;
    public string itemSet;
    public ItemType itemtype;
}

public enum ItemType
{
    sword, gun
}