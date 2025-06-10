using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Item : ScriptableObject
{
    public string itemName;
    public int itemID;
    public Sprite itemIcon;//������ ������
    public int quantity;//����
}