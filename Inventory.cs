using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.Composites;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Button = UnityEngine.UI.Button;
using Image = UnityEngine.UI.Image;

// 인벤토리 UI에서 돌 선택 및 제작 화면을 제어하는 클래스
public class Inventory : MonoBehaviour
{
    public GameObject[] backgroundArr = {}; // 각 돌의 제작 배경 오브젝트 배열
    public Gamemanager gameManager; // GameManager 참조
    public GameObject inventory; //인벤토리 창 자체 오브젝트
    private GameInstance[] stoneEnumArr = { //선택 가능한 돌 Enum 배열
        GameInstance.TtenSeokki1,
        GameInstance.TtenSeokki2,
        GameInstance.TtenSeokki3,
        GameInstance.GanSeokki1,
        GameInstance.GanSeokki2,
        GameInstance.GanSeokki3,
    };
    public Image currentImage; //선택한 돌에 해당하는 이미지
    public Image[] activeImageArr; // 돌 버튼 클릭 시 활성화할 이미지 배열
    Player playerScript; //플레이어 스크립트 참조

    void Start()
    {
        gameManager = FindObjectOfType<Gamemanager>();
        playerScript = GameObject.FindWithTag("Player").GetComponent<Player>() ;
    }
    // 돌 버튼 클릭 시 호출: 해당 돌을 선택하고 이미지 활성화
    public void stoneClick(int buttonIndex)
    {
        // 기존 선택 이미지 비활성화
        if(currentImage != null)
        {
            currentImage.transform.gameObject.SetActive(false);
        }
        // 선택된 돌 Enum 저장
        gameManager.SetSelectedStone(stoneEnumArr[buttonIndex]);
        currentImage = activeImageArr[buttonIndex];
        currentImage.transform.gameObject.SetActive(true);
    }
   /* public void stoneClick2()
    {
        if(gameManager.GetSelectedStone() == Gamemanager.GameInstance.TtenSeokki1)
        {
            Debug.Log(123);
            inventory.gameObject.SetActive(true);
        }
        else if(gameManager.GetSelectedStone() == Gamemanager.GameInstance.TtenSeokki2)
        {
            inventory.gameObject.SetActive(true);
        }
        else if(gameManager.GetSelectedStone() == Gamemanager.GameInstance.TtenSeokki3)
        {
            inventory.gameObject.SetActive(true);
        }
        else if(gameManager.GetSelectedStone() == Gamemanager.GameInstance.GanSeokki1)
        {
            inventory.gameObject.SetActive(true);
        }
        else if(gameManager.GetSelectedStone() == Gamemanager.GameInstance .GanSeokki2)
        {
            inventory.gameObject.SetActive (true);
        }
        else if(gameManager.GetSelectedStone() == Gamemanager.GameInstance.GanSeokki3)
        {
            inventory.gameObject.SetActive(true);
        }
    }
   */
    public void makeclick() //제작 버튼 클릭 시: 선택된 돌에 맞는 배경 UI 활성화
    {
        // 선택된 돌에 따라 해당 배경 활성화
        if (gameManager.GetSelectedStone() == GameInstance.TtenSeokki1)
        {
            backgroundArr[0].gameObject.SetActive(true);
        }
        else if (gameManager.GetSelectedStone() == GameInstance.TtenSeokki2)
        {
            backgroundArr[1].gameObject.SetActive(true);
        }
        else if (gameManager.GetSelectedStone() == GameInstance.TtenSeokki3)
        {
            backgroundArr[2].gameObject.SetActive(true);
        }
        else if (gameManager.GetSelectedStone() == GameInstance.GanSeokki1)
        {
            backgroundArr[3].gameObject.SetActive(true);
        }
        else if (gameManager.GetSelectedStone() == GameInstance.GanSeokki2)
        {
            backgroundArr[4].gameObject.SetActive(true);
        }
        else if (gameManager.GetSelectedStone() == GameInstance.GanSeokki3)
        {
            backgroundArr[5].gameObject.SetActive(true);
        }
        gameObject.SetActive(false); // 인벤토리 창 닫기
    }

    public void CloseInven() //인벤토리 창 닫기 + 제작 상태 false로 변경
    {
        gameObject.SetActive(false);
        playerScript.SetIsPlayerMaking(false);
    }
}
