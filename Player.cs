using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

// 플레이어의 상호작용 및 상태를 관리하는 클래스
public class Player : MonoBehaviour
{
    //public TalkManager talkManager;
    public GameObject scanObject; // 현재 상호작용 대상 오브젝트 (ex: NPC, 오브젝트 등)
    public Button makebutton; // 아이템 제작 버튼

    public ObjData currentQuest; //현재 퀘스트 대상 오브젝트
    public GameObject inventoryCanvas; // 인벤토리 UI 캔버스

    bool isMaking = false; // 플레이어가 아이템 제작 중인지 여부

    void Awake()
    {
        // talkButton.onClick.AddListener(() => TalkStart());
        //talkManager = GameObject.FindWithTag("TalkManager").GetComponent<TalkManager>();
        inventoryCanvas = GameObject.FindWithTag("InvenSingleTon"); // 인벤토리 캔버스를 Tag로 찾아서 연결
    }

    void FixedUpdate() // Ray를 통해 NPC감지 및 상호작용 처리 코드(비활성)
    {
        //RaycastHit rayHit;

        //if (Physics.Raycast(transform.position, transform.forward, out rayHit, 0.7f))
        //{
        //    if (rayHit.collider.tag == "NPC")
        //    {
        //        scanObject = rayHit.collider.gameObject;
        //        objData = scanObject.GetComponent<ObjData>();
        //        talkButtonObj.gameObject.SetActive(true);
        //    }
        //}
        //else
        //{
        //    scanObject = null;

        //    if(talkButtonObj != null)
        //        talkButtonObj.gameObject.SetActive(false);
        //}
    }

    public void SetCurrentQuest(ObjData obj) //현재 퀘스트 오브젝트 설정
    {
        currentQuest = obj;
    }

    public ObjData GetCurrentQuest() // 현재 퀘스트 오브젝트 반환
    {
        return currentQuest;
    }

    //public void TalkStart()
    //{
    //    if (scanObject != null)
    //    {
    //        talkManager.Action(scanObject);
    //    }
    //}

    public void SetScanObject(GameObject npc) //현재 상호작용 중인 오브젝트 설정
    {
        scanObject = npc;
    }

    public GameObject GetScanObject() //현재 상호작용 중인 오브젝트 반환
    {
        return scanObject;
    }

    void OnTriggerEnter(Collider other) //플레이어가 트리거 존에 진입했을 때 처리
    {
        if (other.CompareTag("inven"))
        {
        //인벤토리 UI 활성화
            InvenCanvas inventoryCanvasObj = inventoryCanvas.GetComponent<InvenCanvas>(); 
            inventoryCanvasObj.SetActiveInven(true);
            isMaking = true;
        }
        else if(other.CompareTag("Portal"))
        {
        //포탈 태그 충돌 시 씬 전환
            SceneManager.LoadScene("4_Forest");
        }
    }

    void OnTriggerExit(Collider other) // 플레이어가 트리거 존을 벗어났을 때 처리
    {
        if (other.CompareTag("inven"))
        {
        // 인벤토리 UI 비활성화
            InvenCanvas inventoryCanvasObj = inventoryCanvas.GetComponent<InvenCanvas>();
            inventoryCanvasObj.SetActiveInven(false);
            isMaking = false;
        }
    }

    public void SetIsPlayerMaking(bool state) // 제작 상태 설정
    {
        isMaking = state;
    }

    public bool GetIsPlayerMaking() //제작 상태 여부 반환
    {
        return isMaking;
    }
}
