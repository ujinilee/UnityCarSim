using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;
using UnityEngine.SceneManagement; //Scene

public class InputKeyboard : MonoBehaviour
{
    //public float thrust;
    private Rigidbody myRigid;
    public float speed = 2;

    float initSpeed = 0; //처음 스피드값

    public int i = 0;
    int j = 0;

    float impulse = 0.0f;


    public int part = 0;

    public int angle = 2;


    //public bool stop = false;

    ///int speedzero = 0; //로그 1번만 찍히게 해줄 변수
    ///int stopzero = 0; //로그 1번만 찍히게 해줄 변수2

    //public bool stop = false;
    Stopwatch watch = new Stopwatch();


    void Start()
    {
        watch.Start();
        myRigid = GetComponent<Rigidbody>();
        initSpeed = speed;
    }

    void FixedUpdate()
    {
        //transform.Rotate(new Vector3(0, 1, 0) * Time.deltaTime*speed);
        //transform.rotation = Quaternion.Euler(new Vector3(0, 20, 0));
        //transform.Rotate(0, 20, 0);


        //transform.Translate(Vector3.forward * Time.deltaTime * speed, Space.Self);
        //myRigid.AddForce(transform.forward * thrust);
        //myRigid.velocity = new Vector3(2, 0, 0);
        //.forward *Time.deltaTime* speed, Space.Self;
        //myRigid.velocity = Vector3.forward * Time.deltaTime * speed, Space.Self;

        var locVel = transform.InverseTransformDirection(myRigid.velocity);
        locVel.z = speed;
        myRigid.velocity = transform.TransformDirection(locVel);
        //myRigid.velocity += transform.forward * speed;


        //////
        /*if (speed == 0)
        {
            //speedzero++;
            if (speedzero == 1)
            {
                //print(watch.Elapsed.ToString());
            }

        }*/
        /////////
        ///
        if (FindObjectOfType<SimpleCarController>().stop == true) //정지신호받으면 어떻게 감속???
        {
            //speed = 0; //다짜고짜 speed를 0으로 주면 안돼
            if (speed <= 1.5f)
            {
                speed += 0.01f;
            }
            else
            {
                speed -= 0.04f;
            }


            if (speed <= 0)
            {
                speed = 0;
                Invoke("LoadScene", 5); //5초후에 LoadScene 함수 불러와
            }


        }

        else
        {
            //처음 스피드값보다 작으면 +0.01씩

            if (speed <= initSpeed)
            {
                speed += 0.01f;
            }


        }


        //transform.eulerAngles.y <= 178 이거 안먹네
        if (FindObjectOfType<CalDistance>().CarDistance <= 10 && transform.eulerAngles.y <= 178) //if (FindObjectOfType<CarRaycast>().IsHit == true && transform.eulerAngles.y <= 178)
        {
            transform.Rotate(new Vector3(0, angle, 0) * Time.deltaTime * speed);


            /*if(transform.eulerAngles.y > 178)
            {
                while (transform.eulerAngles.y >= 158)
                {
                    transform.Rotate(new Vector3(0, -1, 0) * Time.deltaTime);
                }
            } */
        }
        if (this.gameObject.transform.position.z <= FindObjectOfType<MoveGreen>().carZpos)
        {

            while (transform.eulerAngles.y >= 158)
            {
                //print("ddd");
                transform.Rotate(new Vector3(0, -0.1f, 0) * Time.deltaTime*speed);
            }

        }
        /* if(FindObjectOfType<CalDistance>().CarDistance <= 10 && transform.eulerAngles.y >= 178)
        {
            while (true)
            {
                transform.Rotate(new Vector3(0, -1, 0) * Time.deltaTime * speed);


                if (transform.eulerAngles.y <= 158)
                {
                    break;
                }
            }
            
        } */

        /*if (transform.eulerAngles.y <= 178 && transform.eulerAngles.y >= 158)
        {
            transform.Rotate(new Vector3(0, -3, 0) * Time.deltaTime * speed); ///////
        }*/

        /*if (transform.eulerAngles.y > 178)
        {
            while(transform.eulerAngles.y >= 158)
            {
                transform.Rotate(new Vector3(0, -0.1f, 0) * Time.deltaTime * speed);
            }
            
        }*/



    }



    private void OnCollisionStay(Collision other)
    {
        if (other.collider.CompareTag("KIA") || other.gameObject.name.Contains("Goal"))
        {

            i++;
            if (i == 1)
            {
                impulse = other.relativeVelocity.z * myRigid.mass;
                print("Morning의 충격량:" + impulse);
                print("KIA와 충돌발생");
            }
            //print("SUV와 충돌발생");
            speed = 0; //이부분은 어쩌면... 조금 수정해야할지도.. 감속..어카냐..


            Invoke("LoadScene",5 ); //5초후에 LoadScene 함수 불러와

            /*for(int idx=0; idx <=4; i++)
            {
                if (SceneManager.GetActiveScene().buildIndex == idx)
                {
                    //WaitForSeconds(5);
                    Invoke("LoadScene", 2);
                    //SceneManager.LoadScene(idx + 1);
                }

            }*/


        }


    }

    void LoadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        //씬 매니저를 로드하는데 , 현재 씬 인덱스에서 +1 

    }

    /*if (other.collider.CompareTag("1"))
    {

        print("충돌부위: 1");
    } */

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
}


/*
 * 
 * {
 *     public float accSpeed = 8;
    public float acceleration = 30;//속도

    private float accCurrentHoriSpeed;
    private float accTargetHoriSpeed;
    private float accCurrentVerSpeed;
    private float accTargetVerSpeed;

    void FixedUpdate()
    {
        float hori_raw = Input.GetAxisRaw(horizontal);
        float ver_raw = Input.GetAxisRaw(vertical);

        accTargetHoriSpeed = hori_raw * accSpeed;
        accCurrentHoriSpeed = IncrementTowards(accCurrentHoriSpeed, accTargetHoriSpeed, acceleration);   //가속도 적용

        accTargetVerSpeed = ver_raw * accSpeed;
        accCurrentVerSpeed = IncrementTowards(accCurrentVerSpeed, accTargetVerSpeed, acceleration);   //가속도 적용

        transform.Translate(accCurrentHoriSpeed, accCurrentVerSpeed * -1f, 0);
    }

    private float IncrementTowards(float n, float target, float a)
    {
        if (n == target)
        {
            return n;
        }
        else
        {
            float dir = Mathf.Sign(target - n); // must n be increased or decreased to get closer to target
            n += a * Time.deltaTime * dir;
            return (dir == Mathf.Sign(target - n)) ? n : target; // if n has now passed target then return target, otherwise return n
        }
    }

}
 * 
 * {
    //public float straight = Input.GetAxis("Vertical");

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //print(straight);
        if ()
        {
            Debug.Log("A");
        }

        if (Input.GetKeyDown(KeyCode.B))
        {
            Debug.Log("B");
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            Debug.Log("C");
        }

    }

} */
