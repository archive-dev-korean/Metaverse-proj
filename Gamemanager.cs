using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public enum GameInstance //게임 내에서 선택 가능한 돌의 종류 정의
{
    TtenSeokki1,
    TtenSeokki2,
    TtenSeokki3,
    GanSeokki1,
    GanSeokki2,
    GanSeokki3,
    none,
}

public class Gamemanager : MonoBehaviour //UI버튼, 스크롤, 인벤토리 및 아이템 클릭 등을 관리하는 게임 매니저
{
    public Button book1;
    public Button book2;
    public Button book3; 
    // 책 열기 버튼

    // 스크롤이 끝나면 활성화될 UI
    public GameObject Close1;
    public GameObject Close2;
    public GameObject Close3;
    public GameObject MasterClose; //모든 완료 후 표시되는 마스터 클로즈
    public GameObject CloseNotice; //알림 닫기용
    public GameObject RecommendedBook; //추천 도서 UI
    
    public Image Complete1;
    public Image Complete2;
    public Image Complete3;
    //완료 표시 이미지
    
    public Image NoticeScene; //알림 씬 이미지

    public GameObject Scroll1;
    public GameObject Scroll2;
    public GameObject Scroll3;
    // 각 책의 스크롤 내용
    
    public float scrollEndThreshold = 0.9f; //스크롤이 거의 끝났을 때 기준
    public GameObject inventory; // 인벤토리 전체
    public GameObject inven6; // 인벤토리 서브패널
    public ItemScript itemScript; // 아이템 로직 컨트롤러
    public GameInstance selectedStone; // 선택된 돌 상태 저장

    public GameObject talkPanel; //대화 패널
    
    public TalkManager talkManager; // 대화 시스템 매니저
    public QuestManager questManager; // 퀘스트 시스템 매니저
    //public Player playerObj;
    //public GameObject player;
    //public GameObject characterUICanvasObj;
    
    void Awake() //중복된 Gamemanager 방지
    {
        int gameManagerCount = FindObjectsOfType<Gamemanager>().Length;

        if (gameManagerCount > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    void Start()
    {
        selectedStone = GameInstance.none;
    }

    public void OnSceneLoaded(Scene scene, LoadSceneMode mode) //씬 로드 시 호출되는 이벤트
    {
        Debug.Log("씬재로드");
    }

    public void SetSelectedStone(GameInstance stone) //현재 선택된 돌 저장
    {
        selectedStone = stone;
    }

    public GameInstance GetSelectedStone() //선택된 돌 반환
    {
        return selectedStone;
    }

    //public void Action(GameObject scanObj)
    //{
    //    // scanObject = scanObj;
    //    ObjData objData = scanObj.GetComponent<ObjData>();
    //    talkManager.Talk(objData.GetNPCId(), objData.GetIsNPC(), objData.GetNPCQuestState(), objData.GetCurrentQuest());

    //    talkPanel.SetActive(isAction);
    //}

    //public void Talk(int id, bool isNPC, NPCQuestState state, int currentQuest)
    //{
    //    string talkData = "";

    //    if (state == NPCQuestState.NONE)
    //    {
    //        talkData = talkManager.GetTalk(id, 0);
    //    }
    //    else if (state == NPCQuestState.HAVE_QUEST)
    //    {
    //        talkData = talkManager.GetTalk(id + (int)state + (10 * (currentQuest + 1)), talkIndex); // 1000 + 0 + 10 = 1010
    //    }
    //    else if (state == NPCQuestState.SUCCESS_QUEST)
    //    {
    //        talkData = talkManager.GetTalk(id + (int)state + (10 * (currentQuest + 1)), talkIndex); // 1000 + 0 + 10 = 1010
    //    }
    //    else if (state == NPCQuestState.PROCESS_QUEST)
    //    {
    //        talkData = talkManager.GetTalk(id, talkIndex);
    //    }
    //    ////Set Talk Data
    //    //int questTalkIndex = questManager.GetQuestTalkIndex(id);
    //    ////string talkData = talkManager.GetTalk(id, talkIndex);
    //    //string talkData = talkManager.GetTalk(id + questTalkIndex, talkIndex);

    //    // End Talk
    //    if (talkData == null)
    //    {
    //        isAction = false;
    //        Debug.Log("isAction = false");

    //        talkIndex = 0;
    //        Debug.Log(questManager.CheckQuest(id));

    //        return;
    //    }

    //    if (isNPC)
    //    {
    //        talkText.text = talkData;
    //    }
    //    else
    //    {
    //        talkText.text = talkData;
    //    }
    //    isAction = true;
    //    talkIndex++;
    //}

    //public void SetSuccessArr()
    //{
    //    ObjData currentQuestObj = playerObj.GetCurrentQuest();
    //    currentQuestObj.SetSuccessList(currentQuestObj.GetCurrentQuest(), true);

    //    if (currentQuestObj.GetNPCQuestState() == NPCQuestState.PROCESS_QUEST)
    //    {
    //        currentQuestObj.SetNPCQuestState(NPCQuestState.SUCCESS_QUEST);
    //    }
    //}

    public void OnScrollValueChanged(Vector2 value) //특정 스크롤이 끝까지 내려갔는지 체그하는 이벤트
    {
       
        if (value.y <= 1 - scrollEndThreshold)
        {
            Debug.Log("911"); // 확인용 디버그 메세지
          
        }
    }

    public void ItemClick() // 특정 아이템 클릭 시 수량, UI 갱신
    {
        //inventory.gameObject.SetActive(true);
        inven6.gameObject.SetActive(false);
        if (itemScript != null)
        {
            Debug.Log(123);
            var itemList = itemScript.GetItems();

            
            int itemIndexToUpdate = 0; 
            if (itemIndexToUpdate >= 0 && itemIndexToUpdate < itemList.Count)
            {
                itemList[itemIndexToUpdate].quantity++;
                itemList[itemIndexToUpdate].quantity++; 
                itemList[itemIndexToUpdate].quantity++; 
            }
            else
            {
                Debug.LogError("Invalid item index or itemList is empty!");
            }

            // UI ����
            itemScript.UpdateUI();
        }
        else
        {
            Debug.LogError("ItemScript�� �Ҵ���� �ʾҽ��ϴ�.");
        }
    }
    public void ItemClick2()
    {
        
        inven6.gameObject.SetActive(false);
        if (itemScript != null)
        {
            Debug.Log(123);
            
            var itemList = itemScript.GetItems();

           
            int itemIndexToUpdate = 1; 
            if (itemIndexToUpdate >= 1 && itemIndexToUpdate < itemList.Count)
            {
                itemList[itemIndexToUpdate].quantity++; 
                itemList[itemIndexToUpdate].quantity++; 
                itemList[itemIndexToUpdate].quantity++; 
            }
            else
            {
                Debug.LogError("Invalid item index or itemList is empty!");
            }

            
            itemScript.UpdateUI1();
        }
        else
        {
            Debug.LogError("ItemScript�� �Ҵ���� �ʾҽ��ϴ�."); 
        }
    }
    public void ItemClick3()
    {
       // inventory.gameObject.SetActive(true);
        inven6.gameObject.SetActive(false);
        if (itemScript != null)
        {
            Debug.Log(123);
           
            var itemList = itemScript.GetItems();

           
            int itemIndexToUpdate = 2; 
            if (itemIndexToUpdate >= 2 && itemIndexToUpdate < itemList.Count)
            {
                itemList[itemIndexToUpdate].quantity++; 
                itemList[itemIndexToUpdate].quantity++; 
                itemList[itemIndexToUpdate].quantity++; 
            }
            else
            {
                Debug.LogError("Invalid item index or itemList is empty!");
            }

            // UI ����
            itemScript.UpdateUI2();
        }
        else
        {
            Debug.LogError("ItemScript�� �Ҵ���� �ʾҽ��ϴ�.");
        }
    }
    public void ItemClick4()
    {
        //inventory.gameObject.SetActive(true);
        inven6.gameObject.SetActive(false);
        if (itemScript != null)
        {
            Debug.Log(123);
            
            var itemList = itemScript.GetItems();

           
            int itemIndexToUpdate = 3; 

            if (itemIndexToUpdate >= 3 && itemIndexToUpdate < itemList.Count)
            {
                itemList[itemIndexToUpdate].quantity++; 
                itemList[itemIndexToUpdate].quantity++; 
                itemList[itemIndexToUpdate].quantity++; 
            }
            else
            {
                Debug.LogError("Invalid item index or itemList is empty!");
            }

            // UI ����
            itemScript.UpdateUI3();
        }
        else
        {
            Debug.LogError("ItemScript�� �Ҵ���� �ʾҽ��ϴ�.");
        }
    }
    public void ItemClick5()
    {
       // inventory.gameObject.SetActive(true);
        inven6.gameObject.SetActive(false);
        if (itemScript != null)
        {
            Debug.Log(123);
           
            var itemList = itemScript.GetItems();

           
            int itemIndexToUpdate = 4; 

            if (itemIndexToUpdate >= 4 && itemIndexToUpdate < itemList.Count)
            {
                itemList[itemIndexToUpdate].quantity++; 
                itemList[itemIndexToUpdate].quantity++; 
                itemList[itemIndexToUpdate].quantity++; 
            }
            else
            {
                Debug.LogError("Invalid item index or itemList is empty!");
            }

            // UI ����
            itemScript.UpdateUI4();
        }
        else
        {
            Debug.LogError("ItemScript�� �Ҵ���� �ʾҽ��ϴ�.");
        }
    }
    public void ItemClick6()
    {
        //inventory.gameObject.SetActive(true);
        inven6.gameObject.SetActive(false);
        if (itemScript != null)
        {
            Debug.Log(123);
            // ItemScript���� ������ ����Ʈ ��������
            var itemList = itemScript.GetItems();

            
            int itemIndexToUpdate = 5; 
            if (itemIndexToUpdate >= 5 && itemIndexToUpdate < itemList.Count)
            {
                itemList[itemIndexToUpdate].quantity++; 
                itemList[itemIndexToUpdate].quantity++; 
                itemList[itemIndexToUpdate].quantity++; 
            }
            else
            {
                Debug.LogError("Invalid item index or itemList is empty!");
            }

            // UI ����
            itemScript.UpdateUI5();
        }
        else
        {
            Debug.LogError("ItemScript�� �Ҵ���� �ʾҽ��ϴ�.");
        }
    }
    public void ItemClick7()
    {
        //inventory.gameObject.SetActive(true);
        inven6.gameObject.SetActive(false);
        if (itemScript != null)
        {
            Debug.Log(123);
            
            var itemList = itemScript.GetItems();

           
            int itemIndexToUpdate = 6; 

            if (itemIndexToUpdate >= 6 && itemIndexToUpdate < itemList.Count)
            {
                itemList[itemIndexToUpdate].quantity++; 
                itemList[itemIndexToUpdate].quantity++; 
                itemList[itemIndexToUpdate].quantity++; 
            }
            else
            {
                Debug.LogError("Invalid item index or itemList is empty!");
            }

            // UI ����
            itemScript.UpdateUI6();
        }
        else
        {
            Debug.LogError("ItemScript�� �Ҵ���� �ʾҽ��ϴ�.");
        }
    }

    // 책 클릭 시 스크롤 UI 열기
    public void BookClick3()
    {
        Scroll3.gameObject.SetActive(true);
    }
   public void BookClick2()
    {
        Scroll2.gameObject.SetActive(true);
    }
   public void BookClick1()
    {
        Scroll1.gameObject.SetActive(true);
    }
    public void CloseClick2()
    {
            NoticeScene.gameObject.SetActive(false);
    }

    // 스크롤 닫기 후 완료 이미지 및 인벤토리 활성화(비활성됨)
    public void CloseClick()
    {
        //if (scrollRect1.gameObject.activeSelf == true && scrollRect2.gameObject.activeSelf == false && scrollRect3.gameObject.activeSelf == false)
        //{
        //    scrollRect1.gameObject.SetActive(false);
        //    Complete1.gameObject.SetActive(true);
        //    inven6.gameObject.SetActive(true);
        //}
        //else if (scrollRect1.gameObject.activeSelf == false && scrollRect2.gameObject.activeSelf == true && scrollRect3.gameObject.activeSelf == false)
        //{
        //    scrollRect2.gameObject.SetActive(false);
        //    Complete2.gameObject.SetActive(true);
        //    inven6.gameObject.SetActive(true);
        //}
        //else if(scrollRect1.gameObject.activeSelf == false && scrollRect2.gameObject.activeSelf == false && scrollRect3.gameObject.activeSelf == true)
        //{
        //    scrollRect3.gameObject.SetActive(false);
        //    Complete3.gameObject.SetActive(true);
        //    inven6.gameObject.SetActive(true);
        //}
        //else if(Complete1.gameObject.activeSelf == true &&  Complete2.gameObject.activeSelf == true && Complete3.gameObject.activeSelf == true)
        //{
        //    MasterClose.gameObject.SetActive(true);
        //    RecommendedBook.gameObject.SetActive(false);
        //    inven6.gameObject .SetActive(true);
        //}
       
    }
}
