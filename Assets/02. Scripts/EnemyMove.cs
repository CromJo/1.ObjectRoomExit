using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMove : MonoBehaviour
{
    Player m_Player;
    Animator m_Animator;
    NavMeshAgent m_NavMeshAgent;
    float m_Speed = 5f;
    // Start is called before the first frame update
    void Start()
    {
        m_Player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        m_NavMeshAgent = GetComponent<NavMeshAgent>();
        m_Animator = GetComponent<Animator>();
    }
    
    // Update is called once per frame
    void Update()
    {
        //m_NavMeshAgent.velocity = new Vector3();
        m_NavMeshAgent.SetDestination(m_Player.transform.position);             //목적지 설정일 뿐인데 왜 이동도 되는가?
        AnimatonUpdate();
    }

    void AnimatonUpdate()
    {
        if(m_NavMeshAgent.destination != transform.position)
        {
            m_Animator.SetBool("Walk", true);
        }
        else
        {
            m_Animator.SetBool("Walk", false);
        }
    }
}
