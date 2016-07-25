﻿using UnityEngine;

public class PlayerMovement : MonoBehaviour {
	public float speed = 6f;

	private Vector3 movement;
	private Animator anim;
	private Rigidbody playerRigidBody;
	private int floorMask;
	private float camRayLength = 100f;

	void Awake () {
		floorMask = LayerMask.GetMask ("Floor");
		anim = GetComponent<Animator> ();
		playerRigidBody = GetComponent<Rigidbody> ();
	}

	void FixedUpdate () {

		if (MenuPanelController.IsMenuDisplayed) {
			return;
		}

		float h = Input.GetAxisRaw ("Horizontal");
		float v = Input.GetAxisRaw ("Vertical");

		Move (h, v);
		Turning ();
		Animating (h, v);
	}

	void Move (float h, float v) {
		movement.Set (h, 0f, v);

		movement = movement.normalized * speed * Time.deltaTime;

		playerRigidBody.MovePosition (transform.position + movement);
	}

	void Turning () {
		Ray camRay = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit floorHit;

		if (Physics.Raycast (camRay, out floorHit, floorMask)) {
			Vector3 playerToMouse = floorHit.point - transform.position;
			playerToMouse.y = 0f;

			Quaternion newRotation = Quaternion.LookRotation (playerToMouse);
			playerRigidBody.rotation = newRotation;
		}
	}

	void Animating (float h, float v) {
		bool isWalking = (h != 0f || v != 0f);
		anim.SetBool ("IsWalking", isWalking);
	}
}
