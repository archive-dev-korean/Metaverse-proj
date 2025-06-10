using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Jump : MonoBehaviour
{
    public Button jumpbutton;
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Onclick() //점프 버튼 클릭시 isJump 애니메이션(점프모션) 재생
    {
        anim.SetTrigger("isJump");
    }
}
