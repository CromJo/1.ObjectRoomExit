using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightEvent : MonoBehaviour
{
    Light m_Light;
    void Start()
    {
        m_Light = transform.GetChild(0).GetComponent<Light>();
    }

    public void LightTriggerEvent()
    {
        Debug.Log("어서오고");
        StartCoroutine(BlinkEvent());
        
    }

    IEnumerator BlinkEvent()
    {
        m_Light.intensity = 2.5f;
        while (true)
        {
            m_Light.color = Color.red;
            yield return new WaitForSeconds(1f);

            m_Light.color = Color.black;
            yield return new WaitForSeconds(0.2f);
            
        }
    }

}
