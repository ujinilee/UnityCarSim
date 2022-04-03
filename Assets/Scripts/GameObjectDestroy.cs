using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectDestroy : MonoBehaviour
{
	private float destroyTime;

	void Start()
	{

	}

	void Update()
	{

		if (destroyTime >= 2f)
		{
			Destroy(gameObject);
		}
		else
		{
			destroyTime += Time.deltaTime;
		}
	}

}
