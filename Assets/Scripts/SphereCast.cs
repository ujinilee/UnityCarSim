using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereCast : MonoBehaviour
{
	void OnCreate() { }
	void OnUpdate() { }

	void OnDrawGizmos()
	{

		float maxDistance = 10;
		RaycastHit[] hit;
		// Physics.SphereCast (레이저를 발사할 위치, 구의 반경, 발사 방향, 충돌 결과, 최대 거리)
		//

		//RaycastHit[] Physics.SphereCastAll(transform.position, transform.lossyScale.x * 2, transform.forward); //XXXXXX
		var isHit = Physics.SphereCastAll(transform.position, transform.lossyScale.x * 2, transform.forward, maxDistance);
		//bool isHit = Physics.SphereCast(transform.position, transform.lossyScale.x*2 , transform.forward, out hit, maxDistance);

		Gizmos.color = Color.green;

		//Debug.DrawRay(transform.position, transform.lossyScale.x * 2, transform.forward, maxDistance);
		for (int i = 0; i < isHit.Length; i++)
            if (isHit[i].collider.tag != "Untagged")
            {
				Debug.Log(isHit[i].collider.tag + "감지");
			}
			

		/*
		if (isHit)
		{
			Gizmos.DrawRay(transform.position, transform.forward * hit.distance);
			Gizmos.DrawWireSphere(transform.position + transform.forward * hit.distance, transform.lossyScale.x * 2);
			Debug.Log(hit.collider.name);

			//print(hit.collider.tag);
		}
		else
		{
			Gizmos.DrawRay(transform.position, transform.forward * maxDistance);
		}
		*/
	}
}
