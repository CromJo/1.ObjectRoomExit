using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorCloseTrigger : MonoBehaviour
{
    Player m_Player;
    Key m_Key;
    Door m_Door;
    //[SerializeField] GameObject m_KeyObj;
    [SerializeField] GameObject m_HiddenDoor1;
    [SerializeField] GameObject m_HiddenDoor2;
    [SerializeField] GameObject m_AutoDoor;
    //List<int> m_List;

    
    // Start is called before the first frame update
    void Start()
    {
        //door
        //m_Door = m_Door.gameObject.GetComponent<Door>();
        m_Key = GameObject.Find("rust_key").GetComponent<Key>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if(m_Key != null)
            {
                //m_KeyObj.SetActive(true);
                m_Key.GetKey();                     //이 부분 왜 안될까요?
                m_HiddenDoor1.GetComponent<Door>().IsOpen = false;
                m_HiddenDoor2.GetComponent<Door>().IsOpen = false;

                m_HiddenDoor1.GetComponent<Door>().Hidden3Door();
                m_HiddenDoor2.GetComponent<Door>().Hidden3Door();
            }

            //열리는 스크립트
            AutoDoor autoDoor = GameObject.FindWithTag("KeyDoor").GetComponent<AutoDoor>();
            autoDoor.AutoOpenDoor();
        }

        
    }

    private void OnTriggerExit(Collider other)
    {
        gameObject.GetComponent<MeshCollider>().enabled = false;
    }

    //public abstract void AutoMaticCloseDoor(Vector3 point);
    
}
