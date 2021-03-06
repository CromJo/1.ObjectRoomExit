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

    [SerializeField] float m_MaxDistance;
    [SerializeField] GameObject m_RayPos;

    //열쇠 관련
    bool m_isGetKey = false;
    public bool IsGetKey { get { return m_isGetKey; } set { m_isGetKey = value; } }
    // Start is called before the first frame update

    //문관련
    InteractionDoor m_door;
    Door m_JoDoor;

    //손전등 관련
    FlashLight m_FlashLight;
    [SerializeField] Transform m_FlashLightSoket;
    
    bool m_isEquip;
    public bool isEquip { get { return m_isEquip; } set { m_isEquip = value; } }

    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();

        m_JoDoor = GameObject.Find("connectorFloor1-1").GetComponentInChildren<Door>();

    }


    void FixedUpdate()
    {
        //m_Rigidbody.AddForce(Vector3.down * m_Gravity);
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
        m_Rigidbody.velocity = moveDir * m_Speed;
    }

    void UpdateRayInput()                                                                   //레이캐스트 관련함수
    {
        Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);   //광선은 카메라 포지션의 위치해서 앞으로 나아간다.라는 내용을 가진 변수생성
        RaycastHit hit;                                                                     //변수 하나 생성
        if (Physics.Raycast(ray, out hit, m_MaxDistance))                               //광선이 앞으로 나아가며 MaxDistance만큼의 길이를 가지고 있다.
        {
            Debug.DrawRay(Camera.main.transform.position, Camera.main.transform.forward, Color.red);            //바라보는 시점의으로 레이저를 쏘는것을 표시.(인게임에서는 안보임)
            UIManager text = GameObject.Find("StateText").GetComponent<UIManager>();                            //
            
            text.UpdateState(UIManager.TextState.None);                                                         //기본 상태 
            if (hit.collider.CompareTag("Door"))                                                                //만약 태그가 도어인 곳에 광선이 닿았을 경우 
            {
                text.UpdateState(UIManager.TextState.DoorOpenAndClose);                                         //특정 텍스트 출력
            }
            else if(hit.collider.CompareTag("HiddenDoor") || hit.collider.CompareTag("KeyDoor"))
            {
                if(m_isGetKey)
                {
                    text.UpdateState(UIManager.TextState.GetKeyOpenDoor);
                }
                else
                {
                    text.UpdateState(UIManager.TextState.DoorLock);
                }
            }
            else if(hit.collider.CompareTag("Key") || hit.collider.CompareTag("FlashLight"))
            {
                text.UpdateState(UIManager.TextState.ItemEquip);
            }

            if (Input.GetMouseButtonDown(0))                                                    //왼클 했을 경우
            {
                if (hit.collider.CompareTag("Door"))                                        //태그가 도어라면 (광선이 태그에 맞았다면)
                {
                    InteractionDoor door = hit.collider.GetComponent<InteractionDoor>();    //내가 만든 스크립트 공유된 것들을 불러오고
                    if (door)                                                                //잘 불러와졌고
                    {
                        if (door.canOpen == true)                                            //열수 있는 상태라면
                        {
                            //text.UpdateState(UIManager.TextState.DoorOpenAndClose);
                            m_door = door;                                                  //광선에 맞은 문의 콜라이더가 미리 만든 변수에 넣어둔다
                            Camera.main.GetComponent<FirstPersonCamera>().enabled = false;  //그리고 내 카메라 기능을 잠시 비활성화 시킨다.
                        }
                        else                                                                //열수 없는 상태라면
                        {
                            //문이 잠긴 소리 출력
                        }

                    }
                }
                else if (hit.collider.CompareTag("HiddenDoor"))
                {
                    m_JoDoor = hit.collider.GetComponent<Door>();
                    if (m_JoDoor)
                    {
                        //text.UpdateState(UIManager.TextState.GetKeyOpenDoor);
                        m_JoDoor.HiddenDoorOpen();
                        m_JoDoor.OpenAndClose();
                    }
                    else if (!m_isGetKey)
                    {
                        //text.UpdateState(UIManager.TextState.DoorLock);
                    }
                }
                else if (hit.collider.CompareTag("Key"))                  //키태그를 가지고 있는거라면
                {
                    Key key = hit.collider.GetComponent<Key>();     //광선에 닿은 것의 스크립트를 키에 넣어준다
                    //m_JoDoor = hit.collider.GetComponent<Door>();
                    if (key)                                         //키가 null이 아니라면
                    {
                        Debug.Log("키를 주웠다!");
                        m_isGetKey = true;                          //키 트루 활성화
                        key.PickUpKey();
                        //m_JoDoor.HiddenDoorOpen();
                    }
                }
                else if (hit.collider.CompareTag("FlashLight"))
                {
                    if(IsEquipFlash() == false)
                    {
                        FlashLight flashlight = hit.collider.GetComponent<FlashLight>();
                        if (flashlight)
                        {
                            m_FlashLight = flashlight;
                            flashlight.Equip(m_FlashLightSoket);
                        }

                    }

                    //transform.rotation = Quaternion.Euler(new Vector3(m_FlashLightObj.position.x, m_FlashLightObj.position.y, m_FlashLightObj.position.z));
                    //Vector3 dir = transform.Find("FlashLightEquip").position - transform.position;
                    //
                    //Quaternion targetRotation = Quaternion.LookRotation(dir);               //방향으로 쳐다보기
                    //transform.rotation = targetRotation;                                                    

                }
            }
            else if (Input.GetMouseButtonUp(0))                                                  //만약 윗 문장이 충족되지 않고 이 문장만 충족되었다면
            {
                m_door = null;
                Camera.main.GetComponent<FirstPersonCamera>().enabled = true;                   //카메라 활성화
                
            }
        }
        


        if(m_door)                                                                          //
        {
            //float mouseX = Input.GetAxis("Mouse X");
            float mouseY = Input.GetAxis("Mouse Y");

            m_door.AddYaw(mouseY * 180f * Time.deltaTime);
        }
        
        
        
    }

    public bool IsEquipFlash()
    {
        return m_FlashLight != null;
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
