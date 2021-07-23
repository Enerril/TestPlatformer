using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowOneDimension : MonoBehaviour {

	public Transform player;
	public float distance = 10;
	public float height = 5;
	public Vector3 lookOffset = new Vector3(0,0,1);
	float cameraSpeed = 100;
	float rotSpeed = 100;


	Transform myTransform;
	float xOffset;
	float yOffset;

	Vector3 tempPos;

	private void Start()
    {
		myTransform = transform;


	}


	void FixedUpdate () 
	{
		
	}

	void LateUpdate()
	{
        if (player != null)
        {
			tempPos = player.position;
			tempPos.y = player.position.y;
			transform.position = new Vector3(tempPos.x, transform.position.y, transform.position.z);
		}
	




	}

}
