using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    float m_DoorOpen = 120f;         //열리면 Transform Rotation Y값을 90으로 만들 변수
    float m_DoorClose = 0f;         //닫히면 Transform Rotation Y값을 0으로 만들 변수
    float m_MaxDistance = 5f;       //사거리
    float m_OpenCloseTime = 1f;     //열리는 시간

    bool m_isOpen = false;          //연 상태인지 확인하는 변수
    public bool IsOpen { get{ return m_isOpen; } set { m_isOpen = value; } }
    [SerializeField] bool m_canOpen;
    public bool canOpen { get { return m_canOpen; } set { m_canOpen = value; } }
    DoorCloseTrigger m_CloseDoor;

    Player m_Player;
    // Start is called before the first frame update
    void Start()
    {
        if (gameObject.name.EndsWith("B")) m_DoorOpen = -120f;
        m_Player = GameObject.Find("FPSController").GetComponent<Player>();
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

            m_canOpen = false;
        }
    }

    public void HiddenDoorOpen()
    {
        if(CompareTag("HiddenDoor") && m_Player.IsGetKey == true)
        {
            m_canOpen = true;
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
        if (m_canOpen && (CompareTag("Door") || CompareTag("HiddenDoor") || CompareTag("KeyDoor")))
        {
            if (m_canOpen)
            {
                //Debug.Log("열렸다");
                Quaternion targetRotation = Quaternion.Euler(0f, m_DoorOpen, 0f);                                                       //문열기
                transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRotation, m_OpenCloseTime * Time.deltaTime);  //문열기
            }
            
            
        }
        else if (!m_canOpen && CompareTag("Door"))
        {
            //Debug.Log("닫혔다");
            Quaternion targetRotation = Quaternion.Euler(0f, m_DoorClose, 0f);                                                      //문닫기
            transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRotation, m_OpenCloseTime * Time.deltaTime);  //문닫기
        }
    }
}
