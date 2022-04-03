using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarRaycast : MonoBehaviour
{

    RaycastHit hit;

    public bool IsHit = false;
    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log(Physics.Raycast(transform.position, Vector3.forward, out hit, 60));
        //특정위치에 특정 방향으로 최대 길이의 레이를 캐스팅
        //Debug.Log(hit.collider.name);
        //Debug.Log(hit.point);
        //Debug.Log(hit.distance);
        //Debug.Log(hit.normal);
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        ///var hits = Physics.SphereCastAll(transform.position, radius, transform.forward); 써먹을수있을지도모르는코드


        //var hits = Physics.SphereCastAll(transform.position, radius, transform.forward);

        //RayCastHit[] Physics.SphereCastAll(Vector3 origin, float radius, Vector3 direction, float maxDistance, int layerMask);

        // Physics.SphereCast (레이저를 발사할 위치, 구의 반경, 발사 방향, 충돌 결과, 최대 거리)

        //int maxdistance

        /*
        bool rayIsHit = Physics.SphereCast(transform.position, transform.lossyScale.x / 2, transform.forward, out hit, 15);

        Gizmos.color = Color.red;
        if (rayIsHit)
        {
            Gizmos.DrawRay(transform.position, transform.forward * hit.distance);
            Gizmos.DrawWireSphere(transform.position + transform.forward * hit.distance, transform.lossyScale.x / 2);
        }
        else
        {
            Gizmos.DrawRay(transform.position, transform.forward * 15);
        }*/

        /*

        RaycastHit hit;

        Vector3 p1 = transform.position + charCtrl.center;
        float distanceToObstacle = 0;

        // Cast a sphere wrapping character controller 10 meters forward
        // to see if it is about to hit anything.
        if (Physics.SphereCast(p1, charCtrl.height / 2, transform.forward, out hit, 10))
        {
            distanceToObstacle = hit.distance;
        }

        */

        //Physics.Raycast(Vector3 origin, Vector3 direction, out RaycastHit hitInfo, float maxDistance, (int)LayerMask Layermask)


        //Vector3 direction = Quaternion.Eular(0, 0, -30) * 20;
        //Vector3 direction = Quaternion.AngleAxis(-30, Vector3.forward) * 20;

        
        UnityEngine.Debug.DrawRay(transform.position, transform.forward *5, Color.red); //m단위 raycast 그림
        //UnityEngine.Debug.DrawRay(transform.position, Vector3.right* 15, Color.red);
        //UnityEngine.Debug.DrawRay(transform.position, Vector3.left* 15, Color.red);
        //targetDir, transform.forward
        //Vector3 newDi = (1, 0, 1);
        //Vector3 reDi = (1, 0, 1);


        //UnityEngine.Debug.DrawRay(transform.position, Vector3.Angle(newDi,reDi), Color.blue);





        if (Physics.Raycast(transform.position, transform.forward, out hit, 5))
        {

            if (hit.transform.CompareTag("KIA"))
            {
                FindObjectOfType<SimpleCarController>().stop = true;

                IsHit = true; //닿으면 닿았다는 신호 추가
            }

            //닿으면 닿았다는 신호 추가

            
            //Debug.DrawRay(gameObject.transform.position, gameObject.transform.forward * hit.distance, Color.red);
            /*if (hit.transform.CompareTag("KIA"))
            {
                print("ACC 제어");
                FindObjectOfType<MoveRed>().speed = 2;
            }*/

            //print("ACC 제어"); //원래 쓰던건데 잠시 끌게
            //FindObjectOfType<MoveRed>().speed = 2;  //원래 쓰던건데 잠시 끌게

            //////////////FindObjectOfType<SimpleCarController>().stop = true; //얘 안되면 다시 넣어
        }

        else
        {
            FindObjectOfType<SimpleCarController>().stop = false;

            IsHit = false; //안닿음
        }


        ///

        /*UnityEngine.Debug.DrawRay(transform.position, transform.right * distance, Color.red, 1f); //레이저 시각화(위치, 방향 * 길이, 선 색깔, 몇초동안 띄워줄건지)
        if (Physics.Raycast(transform.position, transform.right, out Raycast_Hit, distance)) //레이저에 닿으면
        {
            print("닿음");
            speed *= 1 / 2; //(임시로 가정)간격이 5m이하가 되면 속도를 반으로 줄여줌 (충돌방지)
                            //Raycast_Hit.transform.GetComponent<MeshRenderer>().material.color = Color.red; //닿으면 빨간색

        }
        else
        {
            speed += 0.01f; //아닐 경우 속도를 다시 +1km/h해줌
        } */
    }


}

