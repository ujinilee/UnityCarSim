using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CalSpeed : MonoBehaviour
{
    private Vector3 m_LastPosition;
    public Vector3 cur_pos; //선언
    public float m_Speed;
    public Text m_MeterPerSecond, m_KilometersPerHour; //UI text

    void Start()
    {
        //cur_pos = this.gameObject.transform.position; //현재 오브젝트의 위치 구하기
        m_Speed = 0;
    }
    void FixedUpdate()
    {
        cur_pos = this.gameObject.transform.position;
        m_Speed = GetSpeed();
        //print(m_Speed);
        m_MeterPerSecond.text = string.Format("속도: "+"{0:00.00} m/s", m_Speed); //UI출력
        m_KilometersPerHour.text = string.Format("속도: " + "{0:00.00} km/h", m_Speed * 3.6f);//UI출력
    }

    float GetSpeed() //속도 구하는 함수
    {
        float speed = (((transform.position - m_LastPosition).magnitude) / Time.deltaTime); //속도=거리(현재위치-이전위치)/시간
        m_LastPosition = transform.position; //위치업데이트

        return speed;
    }
}