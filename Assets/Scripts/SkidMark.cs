using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkidMark : MonoBehaviour
{

	public float currentFrictionValue; //현재마찰값
	public GameObject skidPrefab; //스키드마크

	void Update()
	{

		WheelHit hit;

		transform.GetComponent<WheelCollider>().GetGroundHit(out hit);

		currentFrictionValue = hit.sidewaysSlip; //마찰값

		currentFrictionValue = Mathf.Abs(currentFrictionValue);

		//print(currentFrictionValue);
		if (currentFrictionValue >= 0.3f)
		{ 
			setSkidMark(); //1.5이상일때 스키드마크 함수 불러옴

		}
	}

	private Vector3 prevPos = Vector3.zero;

	private float skidTime;

	void setSkidMark()
	{

		WheelHit hit;

		transform.GetComponent<WheelCollider>().GetGroundHit(out hit); //바퀴위치

		if (prevPos == Vector3.zero)
		{

			prevPos = hit.point;

			return;

		}

		if (skidTime > 0.05f)
		{

			Vector3 relativePos = prevPos - hit.point; ;

			Quaternion rot = Quaternion.LookRotation(relativePos);

			GameObject skidInstance = (GameObject)Instantiate(skidPrefab, hit.point, rot);

			prevPos = hit.point;

			skidInstance.AddComponent<GameObjectDestroy>();

			skidTime = 0;

		}
		else
		{

			skidTime += Time.deltaTime;

		}

	}
}