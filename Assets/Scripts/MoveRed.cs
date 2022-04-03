using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;
using System.IO; //텍스트를 가져다 쓰기 위한 선언
using System;
using System.Diagnostics;

public class MoveRed : MonoBehaviour
{
    private Rigidbody myRigid;
    public float speed = 2;
    public int i = 0;
    int j = 0;
    float impulse = 0.0f;
    public int part = 0;
    public bool stop = false;

    int speedzero = 0; //로그 1번만 찍히게 해줄 변수
    int stopzero = 0; //로그 1번만 찍히게 해줄 변수2

    Stopwatch watch = new Stopwatch();

    // Start is called before the first frame update
    void Start()
    {
        watch.Start();
        myRigid = GetComponent<Rigidbody>();
        Load();
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        Run();
        //myRigid.AddForce(dir * speed);
        if (speed == 0)
        {
            //speedzero++;
            if(speedzero == 1){
                //print(watch.Elapsed.ToString());
            }
            
        }
        if (stop == true)
        {
            stopzero++;
            if (stopzero == 1)
            {
                print(watch.Elapsed.ToString());
            }
            
        }
        else
        {
            stopzero = 0;
        }

    }

    void Run()
    {
        //Vector3 dir = Vector3.forward;

        //transform.position += dir * speed * Time.deltaTime;

        transform.Translate(Vector3.forward * Time.deltaTime * speed, Space.Self);
    }
    private void OnCollisionStay(Collision other)
    {
        if (other.collider.CompareTag("KIA")|| other.gameObject.name.Contains("Goal"))
        {

            i++;
            if (i == 1)
            {
                impulse = other.relativeVelocity.z*myRigid.mass;
                print("Morning의 충격량:" + impulse);
                print("KIA와 충돌발생");
            }
            //print("SUV와 충돌발생");
            speed = 0;

        }

        /*if (other.collider.CompareTag("1"))
        {
            
            print("충돌부위: 1");
        } */

    }

    private void OnTriggerStay(Collider coll)
    {
        i++;

        if (coll.CompareTag("1"))
        {
            j++;
            if (j == 1)
            {
                print("충돌부위: 1");
                part = 1;
            }
            
        }

        if (coll.CompareTag("2"))
        {
            j++;
            if (j == 1)
            {
                print("충돌부위: 2");
                part = 2;
            }

        }

        if (coll.CompareTag("3"))
        {
            j++;
            if (j == 1)
            {
                print("충돌부위: 3");
                part = 3;
            }

        }

        if (coll.CompareTag("4"))
        {
            j++;
            if (j == 1)
            {
                print("충돌부위: 4");
                part = 4;
            }

        }

        if (coll.CompareTag("5"))
        {
            j++;
            if (j == 1)
            {
                print("충돌부위: 5");
                part = 5;
            }

        }

        if (coll.CompareTag("6"))
        {
            j++;
            if (j == 1)
            {
                print("충돌부위: 6");
                part = 6;
            }

        }

        if (coll.CompareTag("7"))
        {
            j++;
            if (j == 1)
            {
                print("충돌부위: 7");
                part = 7;
            }

        }

        if (coll.CompareTag("8"))
        {
            j++;
            if (j == 1)
            {
                print("충돌부위: 8");
                part = 8;
            }

        }

        if (coll.CompareTag("9"))
        {
            j++;
            if (j == 1)
            {
                print("충돌부위: 9");
                part = 9;
            }

        }

        if (coll.CompareTag("10"))
        {
            j++;
            if (j == 1)
            {
                print("충돌부위: 10");
                part = 10;
            }

        }

        if (coll.CompareTag("11"))
        {
            j++;
            if (j == 1)
            {
                print("충돌부위: 11");
                part = 11;
            }

        }

        if (coll.CompareTag("12"))
        {
            j++;
            if (j == 1)
            {
                print("충돌부위: 12");
                part = 12;
            }

        }
    }
    /* private void OnTriggerStay(Collision coll)
    {
        if (coll.collider.CompareTag("1"))
        {
            j++;
            if (j == 1)
            {
                print("충돌부위: 1");
            } 
        }
        print("충돌부위: 1");
    } */


    public void Load()
    {
        string JsonString = File.ReadAllText(Application.dataPath + "/Resources/JsonFile/testGIA Morning.json");
        JsonData jsonData = JsonMapper.ToObject(JsonString);

        print("차량번호:" + jsonData[0][0].ToString()); //Debug.Log -> print
        print(jsonData[0][2].ToString() + "0km/h");
        print(jsonData[0][1].ToString() + "kg");
        //Debug.Log("충돌시간:" + jsonData[1]["time"].ToString() + "초");

        string jsonSpeed = jsonData[0][2].ToString(); //데이터를 문자열로 저장
        speed = (float.Parse(jsonSpeed)); //문자열을 정수로 저장

        string jsonMass = jsonData[0][1].ToString(); //질량 설정
        myRigid.mass = (float.Parse(jsonMass));
    }

    
}
