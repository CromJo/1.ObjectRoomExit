using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    float m_DoorOpen = 90f;         //열리면 Transform Rotation Y값을 90으로 만들 변수
    float m_DoorClose = 0f;         //닫히면 Transform Rotation Y값을 0으로 만들 변수
    float m_MaxDistance = 5f;       //사거리
    float m_OpenCloseTime = 1f;     //열리는 시간

    bool m_isOpen = false;          //연 상태인지 확인하는 변수
    public bool IsOpen { get{ return m_isOpen; } set { m_isOpen = value; } }

    DoorCloseTrigger m_CloseDoor;


    // Start is called before the first frame update
    void Start()
    {
        if (gameObject.name.EndsWith("b")) m_DoorOpen = -90f; 
        
    }

    // Update is called once per frame
    void Update()
    {
        OpenAndClose();                                                               //지금 여기가 업데이트기 떄문에 계속들어옴 그런데 2번째부터 갑자기 m_isOpen이 비활성화가 됨 어찌 된 일?

    }
    
    
    public void Hidden3Door()
    {
        if (CompareTag("HiddenDoor"))
        {
            Debug.Log("닫쳤다");
            Quaternion targetRotation = Quaternion.Euler(0f, m_DoorClose, 0f);                                                          //문열기
            transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRotation, (m_OpenCloseTime * Time.deltaTime) * 4);  //문열기
 
        }
    }

    public void DoorActive()
    {
        m_isOpen = !m_isOpen;           //지금 상태의 반대상황으로 만들어준다.
	}

    public void KeyDoorActive()
    {
        //키를 가지고 있을시 활성화
    }

    public void OpenAndClose()
    {
        if (m_isOpen && CompareTag("Door"))
        {
            //Debug.Log("열렸다");
            Quaternion targetRotation = Quaternion.Euler(0f, m_DoorOpen, 0f);                                                       //문열기
            transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRotation, m_OpenCloseTime * Time.deltaTime);  //문열기
        }
        else if (!m_isOpen && CompareTag("Door"))
        {
            //Debug.Log("닫혔다");
            Quaternion targetRotation = Quaternion.Euler(0f, m_DoorClose, 0f);                                                      //문닫기
            transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRotation, m_OpenCloseTime * Time.deltaTime);  //문닫기
        }
    }
}
