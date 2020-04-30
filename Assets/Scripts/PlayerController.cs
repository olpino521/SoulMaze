using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour 
{
	public PlayerStats playerStats;
    Vector3 forward, right, horizontalMovement, verticalMovement;
	Plane plane;
	Vector3 mouseWorldPosition;
	int currentWeapon = 0;
	Weapon[] loadedWeapons;
	//Variable for weapon

	private void Start()
	{
		loadedWeapons = new Weapon[playerStats.weapons.Length];
		//isometric view
		forward = Camera.main.transform.forward;
		forward.y = 0;
		forward = Vector3.Normalize(forward);
        //90 rotation
		right = Quaternion.Euler(new Vector3(0, 90, 0)) * forward;
		//Plane for rotation 
		plane = new Plane(Vector3.up, 0);

		GameObject tempGun = Instantiate(playerStats.weapons[0], transform.forward + Vector3.up, transform.rotation,transform);
		loadedWeapons[0] = tempGun.GetComponent<Weapon>();
	}

	private void Update()
	{
		float x = Input.GetAxis("Horizontal");
		float z = Input.GetAxis("Vertical");

		if (x != 0 || z != 0) 
			MoveCharacter(x,z);

		RotateCharacter();

		if (Input.GetMouseButton(0))
		{
			Shoot();
		}
	}

	private void Shoot()
	{
		loadedWeapons[currentWeapon].Fire();
	}

	void RotateCharacter()
	{
		float distance;
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		if (plane.Raycast(ray, out distance))
		{
			mouseWorldPosition = ray.GetPoint(distance);
		}
		mouseWorldPosition.y = transform.position.y;
		transform.LookAt(mouseWorldPosition);

	}

	private void MoveCharacter(float horizontal, float vertical)
	{
		horizontalMovement = right * playerStats.speed * Time.deltaTime * horizontal;
		verticalMovement = forward * playerStats.speed * Time.deltaTime * vertical;
		
		transform.position += horizontalMovement;
		transform.position += verticalMovement;
	}

	
}