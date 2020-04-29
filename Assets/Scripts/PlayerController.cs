using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
	[SerializeField] float speed = 4f;
    Vector3 forward, right, move, horizontalMovement, verticalMovement, direction;
	
	private void Start()
	{
        //isometric view
		forward = Camera.main.transform.forward;
		forward.y = 0;
		forward = Vector3.Normalize(forward);
        //90 rotation
		right = Quaternion.Euler(new Vector3(0, 90, 0)) * forward;
	}

	private void Update()
	{
		if(Input.anyKey) MoveCharacter();
	}
	
	private void MoveCharacter()
	{
        //inputs:
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

		move = new Vector3(x, 0, z);
		horizontalMovement = right * speed * Time.deltaTime * x;
		verticalMovement = forward * speed * Time.deltaTime * z;
		
		direction = Vector3.Normalize(horizontalMovement + verticalMovement);
		
		transform.forward = direction;
		transform.position += horizontalMovement;
		transform.position += verticalMovement;
	}
}