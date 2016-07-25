using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {
	public Transform target;
	public float smooting = 5f;

	private Vector3 offset;

	void Start () {
		offset = transform.position - target.position;
	}

	void FixedUpdate () {
		Vector3 targetCamPosition = target.position + offset;
		transform.position = Vector3.Lerp (transform.position, targetCamPosition, smooting * Time.deltaTime);
	}
}
