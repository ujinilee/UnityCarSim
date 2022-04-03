using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI; //AI와 관련된 함수

public class NavMesh : MonoBehaviour
{
    public Transform Target; //목적지(타켓)설정

    NavMeshAgent agent; //컴포넌트

    int i = 0;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>(); //컴포넌트추가
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(Target.position);

        //agent.SetDestination(Vector3) : Vector3의 위치를 목적지로 설정한 후 가는 경로 재계산

    }
    /* private void OnCollisionStay(Collision other)
    {
        if (other.gameObject.name.Contains("Morning")|| other.gameObject.name.Contains("KIA"))
        {
            print("충돌");
            //agent.enabled = false; //충돌하면 네비게이션 기능 종료

        }
    } */
    

}
