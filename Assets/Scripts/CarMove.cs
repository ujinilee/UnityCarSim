using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMove : MonoBehaviour
{
    private Rigidbody myRigid;
    float speed;

    // Start is called before the first frame update
    void Start()
    {
        myRigid = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 dir = Vector3.forward;

        transform.position += dir * speed * Time.deltaTime;

        //myRigid.AddForce(dir * speed);


    }
}
