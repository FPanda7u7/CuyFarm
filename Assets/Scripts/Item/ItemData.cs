using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Item Data")]
public class ItemData : ScriptableObject
{
    public string id;
    public string displayName;
    public int cost;
    public Sprite icon;
    public GameObject prefab;
}
