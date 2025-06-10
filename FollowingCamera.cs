using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using UnityEngine;

//플레이어를 따라가며, 조이스틱 입력에 따라 카메라를 회전시키는 스크립트
public class FollowingCamera : MonoBehaviour 
{
    public Transform following_object; //따라갈 대상
    public FixedJoystick joystick; // 조이스틱 입력
    public float cameraSpeed; //카메라 회전 속도
    private float totalRotation = 0f; //누적 회전값
    public GameObject inventory; //인벤토리 오브젝트
   

    public void OnTriggerEnter(Collider other) //트리거 존에 진입했을 때 호출됨
    {
        if (other.tag == "inven")
        {
            //inventory.gameObject.SetActive(true);
            
            joystick.gameObject.SetActive(false); //인벤토리 진입 시 조이스틱 비활성화
        }
    }

    //고정된 주기로 호출되는 물리 업데이트 함수
    // 카메라 위치 및 회전 조정
    private void FixedUpdate()
    {
        // 현재 위치에서 따라갈 오브젝트 위치로 보간 이동 (부드럽게 따라감)
        Vector3 pos = this.transform.position; 
        this.transform.position = Vector3.Lerp(pos, following_object.position, 0.4f);

        //조이스틱 입력 받아오기
        float horizontalInput = joystick.Horizontal;
        float verticalInput = joystick.Vertical;

        // 입력이 존재할 경우 회전 수행
        if(horizontalInput != 0 || verticalInput != 0)
        {
               // Y축 회전: 카메라가 죄우 회전하는 각도 계산
                float yrotationAngle = Mathf.Atan2(horizontalInput, verticalInput) * Mathf.Rad2Deg;

                // X, Z축 회전: 정면 기준 위아래 회전용(안 쓰거나 시각적 효과용)
                float zrotationAngle = Mathf.Max(0, Mathf.Atan2(verticalInput, horizontalInput) * Mathf.Rad2Deg);
                float xrotationAngle = Mathf.Max(0, Mathf.Atan2(verticalInput, horizontalInput) * Mathf.Rad2Deg);

                // 최종 회전값 계산
                Quaternion targetRotation = Quaternion.Euler(xrotationAngle, yrotationAngle, zrotationAngle);

                // 현재 회전에서 목표 회전으로 부드럽게 회전
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, cameraSpeed * Time.fixedDeltaTime);

            // 누적 회전값 저장(비활성됨)
            totalRotation += xrotationAngle;
            totalRotation += zrotationAngle;
            
        }
        
    }
}
