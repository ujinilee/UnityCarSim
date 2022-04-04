using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;
using System.IO; //텍스트를 가져다 쓰기 위한 선언
using System;


public class MoveGreen2 : MonoBehaviour
{
    private Rigidbody myRigid;
    public float speed = 2;
    public int i = 0;
    int j = 0;
    float impulse = 0.0f;


    public float carZpos=0.0f;

    // Start is called before the first frame update
    void Start()
    {
        myRigid = GetComponent<Rigidbody>();
        //Load();

        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Run();
        if (FindObjectOfType<MoveRed>().i >= 1)
        {
            i++;
            //speed = 0; //추가추가추가 나중에 없애도됨 네비할때만 추가 충돌하면 speed 0으로 먹게 하려고
        }

        //myRigid.AddForce(dir * speed);

        carZpos = this.gameObject.transform.position.z;


    }

    void Run()
    {
        //Vector3 dir = Vector3.right;

        //transform.position += dir * speed * Time.deltaTime;

        transform.Translate(Vector3.forward * Time.deltaTime * speed, Space.Self);

    }
    private void OnCollisionStay(Collision other)
    {
        if (other.gameObject.name.Contains("Morning"))
        {
            i++;
            if (i == 1)
            {
                impulse = other.relativeVelocity.x*900;
                print("K5의 충격량:"+impulse);
                print("Morning과 충돌발생");
            }
            //print("SUV와 충돌발생");
            //speed = 0;
        } 



        //if (other.gameObject.name.Contains("Morning") || other.gameObject.name.Contains("Goal"))

    }
    public void Load()
    {
        string JsonString = File.ReadAllText(Application.dataPath + "/Resources/JsonFile/testGIA K5.json");
        JsonData jsonData = JsonMapper.ToObject(JsonString);

        Debug.Log("차량번호:" + jsonData[0][0].ToString());
        Debug.Log(jsonData[0][2].ToString() + "0km/h");
        Debug.Log(jsonData[0][1].ToString() + "kg");
        //Debug.Log("충돌시간:" + jsonData[1]["time"].ToString() + "초");

        string jsonSpeed = jsonData[0][2].ToString(); //데이터를 문자열로 저장
        speed = (float.Parse(jsonSpeed)); //문자열을 정수로 저장

        string jsonMass = jsonData[0][1].ToString(); //질량 설정
        myRigid.mass = (float.Parse(jsonMass)); 
    }
}
