using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Item : ScriptableObject
{
    public string itemName;
    public int itemID;
    public Sprite itemIcon;// 재료 이미지
    public int quantity;//수량
}
