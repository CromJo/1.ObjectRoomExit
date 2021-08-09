using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomEvent : MonoBehaviour
{
    [SerializeField] LightEvent[] m_LightEvent;
    GameObject[] m_LightObj;
    AutoDoor m_AutoDoor;
    [SerializeField] GameObject m_AutoDoorObj;
    bool isEventStart = false;
    private void Start()
    {
        m_AutoDoor = GameObject.Find("door1wing (2)").GetComponent<AutoDoor>();
        //m_LightEvent = GetComponents<LightEvent>(); 
    }

	private void OnTriggerEnter(Collider other)
    {
        if (isEventStart == true)
            return;
        if (isEventStart == false)
        {
            isEventStart = true;
            m_AutoDoor.AutoOpenDoor();
            for (int i = 0; i < m_LightEvent.Length; ++i)
            {
                m_LightEvent[i].LightTriggerEvent();
            }

        }
    }

	private void OnTriggerStay(Collider other)
	{
        EnemyAgent enemyAgent = GameObject.Find("Enemy").GetComponent<EnemyAgent>();
        enemyAgent.EnemyMove();
	}
    
}
