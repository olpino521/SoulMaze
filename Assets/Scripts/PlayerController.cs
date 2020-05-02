using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour 
{
	public PlayerStats playerStats;
    Vector3 forward, right, horizontalMovement, verticalMovement, direction;
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
		plane = new Plane(Vector3.up, Vector3.up);

		GameObject tempGun = Instantiate(playerStats.weapons[0], transform.position + transform.forward, Quaternion.identity,transform);
		loadedWeapons[0] = tempGun.GetComponent<Weapon>();
	}

	private void Update()
	{
		//Gets the overall direction of input. Used for movement and dash
		LoadDirection();

		MoveCharacter();
		RotateCharacter();

		if (Input.GetMouseButton(0))
			Shoot();

		if (IsDashReady() && Input.GetKeyDown(KeyCode.Space))
			Dash();
	}

	void LoadDirection()
	{
		float x = Input.GetAxis("Horizontal");
		float z = Input.GetAxis("Vertical");
		horizontalMovement = right * x;
		verticalMovement = forward * z;
		direction = horizontalMovement + verticalMovement;
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

	private void MoveCharacter()
	{		
		transform.position += direction * playerStats.speed * Time.deltaTime;
	}

	bool IsDashReady()
	{
		if (playerStats.DashCurrentCooldown == playerStats.dashCooldown)
			return true;

		playerStats.DashCurrentCooldown += Time.deltaTime;
		return false;
	}

	void Dash()
	{
		playerStats.DashCurrentCooldown = 0;
		StartCoroutine(DashRoutine());
	}

	IEnumerator DashRoutine()
	{
		//Get direction of dash
		Vector3 dashDirectionSnapshot = new Vector3();
		dashDirectionSnapshot = direction == Vector3.zero ? transform.forward : direction;
		dashDirectionSnapshot.Normalize();
		float remainingDashDistance = playerStats.dashDistance;
		while (remainingDashDistance > 0)
		{
			yield return new WaitForFixedUpdate();
			transform.position += dashDirectionSnapshot * Time.fixedDeltaTime * playerStats.dashSpeed;
			remainingDashDistance -= Time.fixedDeltaTime * playerStats.dashSpeed;
		}
		
	}
	
}