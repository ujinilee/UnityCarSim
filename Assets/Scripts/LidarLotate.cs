﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LidarLotate : MonoBehaviour
{
    public float lidarSpinSpeed; //라이다가 도는 속도를 설정할 변수.
    private void Start()
    {
        lidarSpinSpeed = 130.0f;
    }
    void Update()
    {
        //Lidar를 계속 회전시키기 위한 코드.
        //실제로 라이다 센서는 무한하게 계속해서 회전을 하며 데이타를 측정하므로
        //데이타를 측정하는 듯한 느낌을 주기 위해 코드를 작성한 것입니다.
        transform.Rotate(-Vector3.up * Time.deltaTime * lidarSpinSpeed);
    }
}
