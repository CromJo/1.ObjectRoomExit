using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorCloseTrigger : MonoBehaviour
{
    Player m_Player;
    [SerializeField] GameObject m_Key;
    Key m_Key2;
    [SerializeField] GameObject m_HiddenDoor1;
    [SerializeField] GameObject m_HiddenDoor2;
    //List<int> m_List;
    // Start is called before the first frame update
    void Start()
    {
        //door
		//m_List.ForEach();
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            //m_Key.gameObject.SetActive(true);
            m_Key2.gameObject.SetActive(true);
            m_HiddenDoor1.GetComponent<Door>().IsOpen = false;
            m_HiddenDoor2.GetComponent<Door>().IsOpen = false;

            m_HiddenDoor1.GetComponent<Door>().Hidden3Door();
            m_HiddenDoor2.GetComponent<Door>().Hidden3Door();
        }
    }

}
