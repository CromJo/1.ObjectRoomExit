using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAgent : MonoBehaviour
{
    [SerializeField] Transform m_Target;
    [SerializeField] float m_Speed = 5f;
    NavMeshAgent m_Agent;
    // Start is called before the first frame update
    void Start()
    {
        m_Agent = GetComponent<NavMeshAgent>();
        
    }

    // Update is called once per frame
    void Update()
    {
    }
    
    public void EnemyMove()
    {
        //Transform.trans
        m_Agent.SetDestination(m_Target.position);
    }
}
