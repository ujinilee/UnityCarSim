using UnityEngine;

using System.Collections;



public class CarCtr : MonoBehaviour
{

	private Rigidbody myRigid;


	// 자동차 바퀴 방향조종을 위한 Transform 4개

	public Transform tireTransformFL;

	public Transform tireTransformFR;

	public Transform tireTransformRL;

	public Transform tireTransformRR;



	public WheelCollider colliderFR;

	public WheelCollider colliderFL;

	public WheelCollider colliderRR;

	public WheelCollider colliderRL;



	// 바퀴 회전을 위한 Transform

	public Transform wheelTransformFL;

	public Transform wheelTransformFR;

	public Transform wheelTransformRL;

	public Transform wheelTransformRR;



	// 속도에 따라서 방향전환율을 다르게 적용하기 위한 준비

	public float highestSpeed = 500f;

	public float lowSpeedSteerAngle = 0.1f;

	public float highSpeedStreerAngle = 25f;



	// 감속량

	public float decSpeed = 7f;



	// 속도제한을 위한 변수들

	public float currentSpeed;

	public float maxSpeed = 350f;    // 전진 최고속도

	public float maxRevSpeed = 100f; // 후진 최고속도



	// 백라이트 조정

	public GameObject brakeLight;

	public GameObject reverseLight;

	public Material backBrakeIdle;

	public Material backBrakeLight;

	public Material backReverseIdle;

	public Material backReverseLight;



	public int maxTorque = 30;



	private float prevSteerAngle;

	private bool bHandBraked = false;



	private float lowStiffness = 0.2f;

	private float highStiffness = 1f;



	public Texture2D speedometerDial;

	public Texture2D speedometerPointer;



	// Use this for initialization

	void Start()
	{
		myRigid = GetComponent<Rigidbody>();

		myRigid.centerOfMass = new Vector3(0, -0.9f, 0.5f); // 무게중심이 높으면 차가 쉽게 전복된다

	}



	// Update is called once per frame

	void FixedUpdate()
	{

		HandBrake();

		SideSlip();

		Control();

	}



	void Update()
	{

		// 앞바퀴 2개를 이동방향으로 향하기

		tireTransformFL.Rotate(Vector3.up, colliderFL.steerAngle - prevSteerAngle, Space.World);

		tireTransformFR.Rotate(Vector3.up, colliderFR.steerAngle - prevSteerAngle, Space.World);

		prevSteerAngle = colliderFR.steerAngle;



		WheelSuspension();

	}



	void Control()
	{

		// 최고속도 제한

		// WheelCollider.rpm 전진:+, 후진:-

		currentSpeed = 2 * 3.14f * colliderRL.radius * colliderRL.rpm * 60 / 1000;



		float direction = Input.GetAxis("Vertical"); //전진:0.1~1, 후진:-0.1~-1

		//print ("direction:" + direction);

		float torque = maxTorque * direction;



		if (!bHandBraked && direction > 0 && currentSpeed < maxSpeed)
		{

			//print ("전진");

			colliderFR.motorTorque = torque;

			colliderFL.motorTorque = torque;

		}
		else if (!bHandBraked && direction < 0 && Mathf.Abs(currentSpeed) < maxRevSpeed)
		{

			//print ("후진");

			colliderFR.motorTorque = torque;

			colliderFL.motorTorque = torque;

		}
		else
		{

			colliderFR.motorTorque = 0;

			colliderFL.motorTorque = 0;

		}



		// 전후진 키를 누르지 않으면 제동이 걸리도록 한다

		if (!Input.GetButton("Vertical"))
		{

			colliderRR.brakeTorque = decSpeed;

			colliderRL.brakeTorque = decSpeed;

		}
		else
		{

			colliderRR.brakeTorque = 0;

			colliderRL.brakeTorque = 0;

		}



		// 속도에 따라 방향전환율을 달리 적용하기 위한 계산

		float speedFactor = myRigid.velocity.magnitude / highestSpeed;

		/** Mathf.Lerp(from, to, t) : Linear Interpolation(선형보간)

		 * from:시작값, to:끝값, t:중간값(0.0 ~ 1.0)

		 * t가 0이면 from을 리턴, t가 1이면 to 를 리턴함, 0.5라면 from, to 의 중간값이 리턴됨

		*/

		float steerAngle = Mathf.Lerp(lowSpeedSteerAngle, highSpeedStreerAngle, 1 / speedFactor);

		//print ("steerAngle:" + steerAngle);

		steerAngle *= Input.GetAxis("Horizontal");



		//좌우 방향전환

		colliderFR.steerAngle = steerAngle;

		colliderFL.steerAngle = steerAngle;



		// 바퀴회전효과

		wheelTransformFL.Rotate(-colliderFL.rpm / 60 * 360 * Time.fixedDeltaTime, 0, 0);

		wheelTransformFR.Rotate(-colliderFR.rpm / 60 * 360 * Time.fixedDeltaTime, 0, 0);

		wheelTransformRL.Rotate(-colliderRL.rpm / 60 * 360 * Time.fixedDeltaTime, 0, 0);

		wheelTransformRR.Rotate(-colliderRR.rpm / 60 * 360 * Time.fixedDeltaTime, 0, 0);

	}


	private RaycastHit hit;

	private Vector3 wheelPos;

	void WheelSuspension()
	{



		if (Physics.Raycast(colliderFR.transform.position, -colliderFR.transform.up,

						   out hit, colliderFR.radius + colliderFR.suspensionDistance))
		{

			wheelPos = hit.point + (colliderFR.radius * colliderFR.transform.up);

			//print ("지면 충돌");

		}
		else
		{

			wheelPos = colliderFR.transform.position - (colliderFR.transform.up * colliderFR.suspensionDistance);

			//print ("충돌 아님");

		}

		wheelPos.y += 3f; // 정상적인 모델이라면 이부분이 없어도 됨

		tireTransformFR.position = wheelPos;



		if (Physics.Raycast(colliderFL.transform.position, -colliderFL.transform.up,

						   out hit, colliderFL.radius + colliderFL.suspensionDistance))
		{

			wheelPos = hit.point + (colliderFL.radius * colliderFL.transform.up);

		}
		else
		{

			wheelPos = colliderFL.transform.position - (colliderFL.transform.up * colliderFL.suspensionDistance);

		}

		wheelPos.y += 3f;

		tireTransformFL.position = wheelPos;



		if (Physics.Raycast(colliderRL.transform.position, -colliderRL.transform.up,

						   out hit, colliderRL.radius + colliderRL.suspensionDistance))
		{

			wheelPos = hit.point + (colliderRL.radius * colliderRL.transform.up);

		}
		else
		{

			wheelPos = colliderRL.transform.position - (colliderRL.transform.up * colliderRL.suspensionDistance);

		}

		wheelPos.y += 3f;

		tireTransformRL.position = wheelPos;



		if (Physics.Raycast(colliderRR.transform.position, -colliderRR.transform.up,

						   out hit, colliderRR.radius + colliderRR.suspensionDistance))
		{

			wheelPos = hit.point + (colliderRR.radius * colliderRR.transform.up);

		}
		else
		{

			wheelPos = colliderRR.transform.position - (colliderRR.transform.up * colliderRR.suspensionDistance);

		}

		wheelPos.y += 3f;

		tireTransformRR.position = wheelPos;

	}



	void HandBrake()
	{

		if (Input.GetButton("Jump"))
		{

			bHandBraked = true;

			//print ("핸드브레이크 작동");

			//colliderFL.motorTorque = 0;

			//colliderFR.motorTorque = 0;

			//colliderFL.brakeTorque = 100;

			//colliderFR.brakeTorque = 100;

			colliderRL.brakeTorque = 100;

			colliderRR.brakeTorque = 100;

		}
		else
		{

			colliderFL.brakeTorque = 0;

			colliderFR.brakeTorque = 0;

			colliderRL.brakeTorque = 0;

			colliderRR.brakeTorque = 0;

			bHandBraked = false;

			//print ("핸드브레이크 해제");

		}

	}



	void SideSlip()
	{



		if (!Input.GetButton("Vertical"))
		{

			WheelFrictionCurve wfc = new WheelFrictionCurve();

			wfc.asymptoteSlip = colliderRL.sidewaysFriction.asymptoteSlip;

			wfc.asymptoteValue = colliderRL.sidewaysFriction.asymptoteValue;

			wfc.extremumSlip = colliderRL.sidewaysFriction.extremumSlip;

			wfc.extremumValue = colliderRL.sidewaysFriction.extremumValue;

			wfc.stiffness = 0.01f;

			colliderRL.sidewaysFriction = wfc;

			colliderRR.sidewaysFriction = wfc;



			//colliderRL.forwardFriction = wfc;

			//colliderRR.forwardFriction = wfc;

		}
		else
		{

			WheelFrictionCurve wfc = new WheelFrictionCurve();

			wfc.asymptoteSlip = colliderRL.sidewaysFriction.asymptoteSlip;

			wfc.asymptoteValue = colliderRL.sidewaysFriction.asymptoteValue;

			wfc.extremumSlip = colliderRL.sidewaysFriction.extremumSlip;

			wfc.extremumValue = colliderRL.sidewaysFriction.extremumValue;

			wfc.stiffness = 1f;

			colliderRL.sidewaysFriction = wfc;

			colliderRR.sidewaysFriction = wfc;



			colliderRL.forwardFriction = wfc;

			colliderRR.forwardFriction = wfc;

		}

	}



	//speedometerDial(320X170), speedometerPointer(320X40)

	void OnGUI()
	{

		GUI.DrawTexture(new Rect(Screen.width / 2 - 160, Screen.height - 170, 320, 170), speedometerDial);

		float speedFactor = Mathf.Abs(currentSpeed / maxSpeed); // 최고속도에 대한 현재속도의 비

		float rotationAngle = Mathf.Lerp(0, 180, speedFactor);      // 속도비를 0 ~ 180 사이의 수(각도)로 표현

		GUIUtility.RotateAroundPivot(rotationAngle, new Vector2(Screen.width / 2, Screen.height - 20));

		GUI.DrawTexture(new Rect(Screen.width / 2 - 160, Screen.height - 40, 320, 40), speedometerPointer);

	}

}