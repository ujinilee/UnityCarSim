using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalDistance : MonoBehaviour
{

    public GameObject Car1;
    public GameObject Car2;
    public float CarDistance;

    void Update()
    {
        CarDistance = Vector3.Distance(Car1.transform.position, Car2.transform.position);
        //Debug.Log("두 차 간의 거리"+CarDistance);
        
        /*if (CarDistance <= 60)
        {
            FindObjectOfType<CalSpeed>().m_Speed -= 1; //감속 -1씩 -1은 임의로 설정
        }*/


        }

}

