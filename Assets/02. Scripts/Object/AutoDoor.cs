using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDoor : DoorCloseTrigger
{
    // Start is called before the first frame update
    void Start()
    {
            
    }

    // Update is called once per fr
    void Update()
    {
        
    }

    public void AutoOpenDoor()
    { 
        
        float doorClose = 0;
        doorClose = 120;
        transform.rotation = Quaternion.Euler(0, doorClose, 0);
        transform.localRotation = Quaternion.Slerp(transform.localRotation, transform.rotation, (120 * Time.deltaTime) * 2.5f);
    }

}
