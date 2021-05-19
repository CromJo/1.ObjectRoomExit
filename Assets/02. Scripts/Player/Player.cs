using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //이동 관련
    [SerializeField] float m_Speed = 250f;
    //Plane m_PosY;
    Rigidbody m_Rigidbody;
    float m_Gravity = 300f;

    float m_MaxDistance = 5f;
    [SerializeField] GameObject m_RayPos;

    //열쇠 관련
    Key m_Key;
    bool m_isGetKey = false;
    public bool IsGetKey { get { return m_isGetKey; } set { m_isGetKey = value; } }
    // Start is called before the first frame update

    InteractionDoor m_door;

    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
    }


    void FixedUpdate()
    {
        m_Rigidbody.AddForce(Vector3.down * m_Gravity);
    }

    // Update is called once per frame
    void Update()
    {
        UpdateMoveInput();
        UpdateRayInput();
        //UpdateObjectInput();
    }


    public void UpdateMoveInput()
    {
        float h = Input.GetAxis("Horizontal");              //인풋 매니저 값 받아오기
        float v = Input.GetAxis("Vertical");                //인풋 매니저 값 받아오기
        Vector3 moveDir = new Vector3(h, 0f, v);            //동적할당 하여 wasd키 값을 moveDir에 넣어주기
        moveDir = transform.TransformDirection(moveDir);    //월드좌표계로 바꿔준다.
        m_Rigidbody.velocity = moveDir * m_Speed * Time.deltaTime;
    }

    void UpdateRayInput()                                                                   //레이캐스트 관련함수
    {
        if(Input.GetMouseButtonDown(0))                                                     //왼클 했을 경우
        {
            Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);//광선은 카메라 포지션의 위치해서 앞으로 나아간다.라는 내용을 가진 변수생성
            RaycastHit hit;                                                                 //변수 하나 생성
            if (Physics.Raycast(ray, out hit, m_MaxDistance))                               //광선이 앞으로 나아가며 MaxDistance만큼의 길이를 가지고 있다.
            {
                if (hit.collider.CompareTag("Door"))                                        //태그가 도어라면 (광선이 태그에 맞았다면)
                {
                    InteractionDoor door = hit.collider.GetComponent<InteractionDoor>();    //내가 만든 스크립트 공유된 것들을 불러오고
                    if(door)                                                                //잘 불러와졌고
                    {
                        if(door.canOpen == true)                                            //열수 있는 상태라면
                        {
                            m_door = door;                                                  //광선에 맞은 문의 콜라이더가 미리 만든 변수에 넣어둔다
                            Camera.main.GetComponent<FirstPersonCamera>().enabled = false;  //그리고 내 카메라 기능을 잠시 비활성화 시킨다.
                        }
                        else                                                                //열수 없는 상태라면
                        {
                            //문이 잠긴 소리 출력
                        }

                    }
                }
            }
        }
        else if(Input.GetMouseButtonUp(0))                                                  //만약 윗 문장이 충족되지 않고 이 문장만 충족되었다면
        {
            m_door = null;
            Camera.main.GetComponent<FirstPersonCamera>().enabled = true;                   //카메라 활성화
        }


        if(m_door)                                                                          //
        {
            //float mouseX = Input.GetAxis("Mouse X");
            float mouseY = Input.GetAxis("Mouse Y");

            m_door.AddYaw(mouseY * 180f * Time.deltaTime);
        }
    }

    //public void UpdateObjectInput()
    //{
    //    if (Input.GetMouseButtonDown(0))
    //    {
    //        ray = new Ray(m_RayPos.transform.position, transform.forward);
    //        
    //        if (Physics.Raycast(ray, out hit, m_MaxDistance))
    //        {
    //            if(hit.collider.CompareTag("Door"))
    //            { 
    //                //Debug.Log(hit.transform.name);
    //
    //                hit.collider.gameObject.GetComponent<Door>().DoorActive();
    //
    //                //hit.collider.gameObject.GetComponent<Door>().IsOpen = true;
    //
    //                //GameObject.Find("Map").transform.Find("connectorFloor1-1").transform.Find("connectorDoor1-1-a").GetComponent<Door>().DoorActive();
    //            }
    //            else if(hit.collider.CompareTag("KeyDoor") && m_Key.gameObject)
    //            {
    //
    //            }
    //        }
    //        else if(Physics.Raycast(ray, out hit, m_MaxDistance) && hit.collider.CompareTag("Key"))
    //        {
    //
    //        }
    //    }
    //}
    

}
