using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDoor : InteractionOpenTrigger
{
    //AutoDoor m_AutoDoor;
    //[SerializeField] GameObject m_AutoDoorObj;
    [SerializeField] bool m_canOpen = false;
    public bool canOpen { get { return m_canOpen; } set { m_canOpen = value; } }



    private void Start()
    {
		//m_AutoDoor = GameObject.Find("door1wing (2)").GetComponent<AutoDoor>();
	}

	public void AutoOpenDoor()
    {
        float doorClose = 0;
        transform.rotation = Quaternion.Euler(0, doorClose, 0);
        transform.localRotation = Quaternion.Slerp(transform.localRotation, transform.rotation, 120 * Time.deltaTime);

    }

    //닫기
    public override void Interaction()
    {
        
    }

    //오픈
    public void OnTriggerEnter(Collider other)
    {
        float doorOpen = -120;
        transform.rotation = Quaternion.Euler(0, doorOpen, 0);
        transform.localRotation = Quaternion.Slerp(transform.localRotation, transform.rotation, 120 * Time.deltaTime);

    }
}
