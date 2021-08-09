using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonCamera : MonoBehaviour
{
    float m_pitchValue;
    float m_yawValue;
    [SerializeField]float m_sensitive = 2f;

    private void Update()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        m_pitchValue -= mouseY * m_sensitive * Time.deltaTime;

        m_yawValue += mouseX * m_sensitive * Time.deltaTime;

        m_pitchValue = Mathf.Clamp(m_pitchValue, -89f, 89f);

        //transform.eulerAngles = new Vector3(m_pitchValue, 0f, 0f);
        transform.parent.eulerAngles = new Vector3(0f, m_yawValue, 0f);
        transform.eulerAngles = new Vector3(m_pitchValue, m_yawValue, 0f);
    }
}
