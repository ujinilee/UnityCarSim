using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics; //추가

[System.Serializable]
public class AxleInfo
{
    public WheelCollider leftWheel;
    public WheelCollider rightWheel;
    public bool motor;
    public bool steering;

}

public class SimpleCarController : MonoBehaviour
{
    public List<AxleInfo> axleInfos;
    public float maxMotorTorque;
    public float maxSteeringAngle;

    public float decSpeed = 7f; //감속량

    //public float speed=20;

    Stopwatch watch = new Stopwatch(); //시계설정

    public bool stop = false;

    public bool speedstart = false;
    int speedzero = 0; //로그 1번만 찍히게 해줄 변수
    int stopzero = 0; //로그 1번만 찍히게 해줄 변수2

    private void Start()
    {
        watch.Start();
        speedzero = 0;
        //rigidbody.centerOfMass = new Vector3(0, -0.9f, 0.5f); //무게중심
    }

    // finds the corresponding visual wheel
    // correctly applies the transform
    public void ApplyLocalPositionToVisuals(WheelCollider collider)
    {
        if (collider.transform.childCount == 0)
        {
            return;
        }

        Transform visualWheel = collider.transform.GetChild(0);

        Vector3 position;
        Quaternion rotation;
        collider.GetWorldPose(out position, out rotation);

        visualWheel.transform.position = position;
        visualWheel.transform.rotation = rotation;
    }


    public void FixedUpdate()
    {

        
        if (FindObjectOfType<CalSpeed>().m_Speed > 1)
        {
            speedstart = true; //달리기시작
        }

        if (speedstart == true)
        {
            if (FindObjectOfType<CalSpeed>().m_Speed == 0)
            {
                speedzero++;
                if (speedzero == 1)
                {
                    print(watch.Elapsed.ToString());
                }

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




        float motor = maxMotorTorque * Input.GetAxis("Vertical");
        float steering = maxSteeringAngle * Input.GetAxis("Horizontal");

        foreach (AxleInfo axleInfo in axleInfos)
        {
            if (axleInfo.steering)
            {
                axleInfo.leftWheel.steerAngle = steering;
                axleInfo.rightWheel.steerAngle = steering;
            }
            if (axleInfo.motor)
            {
                axleInfo.leftWheel.motorTorque = motor;
                axleInfo.rightWheel.motorTorque = motor;
            }
            ApplyLocalPositionToVisuals(axleInfo.leftWheel);
            ApplyLocalPositionToVisuals(axleInfo.rightWheel);


            if (!Input.GetButton("Vertical"))
            {

                axleInfo.rightWheel.brakeTorque = decSpeed;

                axleInfo.leftWheel.brakeTorque = decSpeed; //제동

            }
            else
            {

                axleInfo.rightWheel.brakeTorque = 0; //다시 떼면 제동이 0으로 해제

                axleInfo.leftWheel.brakeTorque = 0;

            }
        }



    }
}
