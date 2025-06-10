using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemScript : MonoBehaviour
{
    public Text itemCountText;
    public Text itemCountText1;
    public Text itemCountText2;
    public Text itemCountText3;
    public Text itemCountText4;
    public Text itemCountText5;
    public Text itemCountText6;
    public List<Item> items = new List<Item>();


    public void AddItem(Item newItem)
    {
        // 동일 ID의 아이템이 이미 존재하는지 확인
        foreach (Item item in items)
        {
            if (item.itemID == newItem.itemID)
            {
                // 존재하면 수량만 증가
                item.quantity += newItem.quantity;

                // UI 갱신(7개 패널 모두)
                UpdateUI();
                UpdateUI1();
                UpdateUI2();
                UpdateUI3();
                UpdateUI4();
                UpdateUI5();
                UpdateUI6();
                return;
            }
        }
        items.Add(newItem); //없으면 새로 추가

        //UI 갱신
        UpdateUI();
        UpdateUI1();
        UpdateUI2();
        UpdateUI3();
        UpdateUI4();
        UpdateUI5();
        UpdateUI6();
    }
    public void UpdateUI()
    {
        if (itemCountText != null)
        {
            string itemsQuantityText = ""; // 각 아이템의 quantity를 담을 문자열 초기화

            foreach (Item item in items)
            {
                itemsQuantityText += item.quantity + "\n";
            }

            itemCountText.text = itemsQuantityText; // 각 아이템의 quantity를 텍스트로 출력
        }
        else
        {
            Debug.LogError("itemCountText is not assigned!");
        }
    }
    public void UpdateUI1()
    {
        if (itemCountText1 != null)
        {
            string itemsQuantityText = ""; // 각 아이템의 quantity를 담을 문자열 초기화

            foreach (Item item in items)
            {
                itemsQuantityText += item.quantity + "\n";
            }

            itemCountText1.text = itemsQuantityText; // 각 아이템의 quantity를 텍스트로 출력
        }
        else
        {
            Debug.LogError("itemCountText is not assigned!");
        }
    }
    public void UpdateUI2()
    {
        if (itemCountText2 != null)
        {
            string itemsQuantityText = ""; // 각 아이템의 quantity를 담을 문자열 초기화

            foreach (Item item in items)
            {
                itemsQuantityText += item.quantity + "\n";
            }

            itemCountText2.text = itemsQuantityText; // 각 아이템의 quantity를 텍스트로 출력
        }
        else
        {
            Debug.LogError("itemCountText is not assigned!");
        }
    }
    public void UpdateUI3()
    {
        if (itemCountText3 != null)
        {
            string itemsQuantityText = ""; // 각 아이템의 quantity를 담을 문자열 초기화

            foreach (Item item in items)
            {
                itemsQuantityText += item.quantity + "\n";
            }

            itemCountText3.text = itemsQuantityText; // 각 아이템의 quantity를 텍스트로 출력
        }
        else
        {
            Debug.LogError("itemCountText is not assigned!");
        }
    }
    public void UpdateUI4()
    {
        if (itemCountText4 != null)
        {
            string itemsQuantityText = ""; // 각 아이템의 quantity를 담을 문자열 초기화

            foreach (Item item in items)
            {
                itemsQuantityText += item.quantity + "\n";
            }

            itemCountText4.text = itemsQuantityText; // 각 아이템의 quantity를 텍스트로 출력
        }
        else
        {
            Debug.LogError("itemCountText is not assigned!");
        }
    }
    public void UpdateUI5()
    {
        if (itemCountText5 != null)
        {
            string itemsQuantityText = ""; // 각 아이템의 quantity를 담을 문자열 초기화

            foreach (Item item in items)
            {
                itemsQuantityText += item.quantity + "\n";
            }

            itemCountText5.text = itemsQuantityText; // 각 아이템의 quantity를 텍스트로 출력
        }
        else
        {
            Debug.LogError("itemCountText is not assigned!");
        }
    }
    public void UpdateUI6()
    {
        if (itemCountText6 != null)
        {
            string itemsQuantityText = ""; // 각 아이템의 quantity를 담을 문자열 초기화

            foreach (Item item in items)
            {
                itemsQuantityText += item.quantity + "\n" ;
            }

            itemCountText6.text = itemsQuantityText; // 각 아이템의 quantity를 텍스트로 출력
        }
        else
        {
            Debug.LogError("itemCountText is not assigned!");
        }
    }
    public void ReceiveItem(Item newItem)
    {
        AddItem(newItem);
    }
    public List<Item> GetItems()
    {
        return items;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
