using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionDoor : MonoBehaviour
{
    [SerializeField] float m_maxYaw;
    [SerializeField] float m_minYaw;
    [SerializeField] bool m_isReverse = false;
    [SerializeField] bool m_canOpen = false;
    float m_yawAngle;                                   

    public bool canOpen { get { return m_canOpen; } }       //열수 있는지 없는지에 관한

    private void Start()    
    {
        m_yawAngle = transform.eulerAngles.y;               //현재 앵글 초기화 시켜줌
    }

    public void AddYaw(float value)
    {
        if (m_canOpen == false)                             //열수 없으면 
            return;                                         //종료

        if (m_isReverse)                                    //여는 것에 관해서
            value *= -1f;                                   //반대로 열면 반대로 열릴 수 있도록

        m_yawAngle += value;                                        //받은 값을 현재 각도로 만들어줌 ( 위에서 isReverse를 했기 때문에 밀거나 당길 수 있음
        m_yawAngle = Mathf.Clamp(m_yawAngle, m_minYaw, m_maxYaw);   //값이 넘어가려한다면 잡아줌
        Vector3 angle = transform.localEulerAngles;                 //내 앵글 값을 새로운 변수에 넣고
        angle.y = m_yawAngle;                                       //받아온 각도를 방금만든 변수에 넣어줌
        transform.localEulerAngles = angle;                         //방금 넣은 각도를 내 각도로 변환 시켜줌
    }
}
