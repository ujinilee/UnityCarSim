using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavAgent : MonoBehaviour
{
    public Transform destTr; //목표지점
    NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (agent.isPathStale == false)
        {
            agent.destination = destTr.position;
            if (FindObjectOfType<MoveRed>().i >= 1)
            {
                agent.destination = this.gameObject.transform.position; //충돌하면 목적지는 없다.
            }
        }
        

    }
}
