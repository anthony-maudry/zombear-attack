using UnityEngine;
using System.Collections;

public class Hit {
	GameObject target;
	Vector3 hitPosition;

	public Hit (GameObject hitTarget, Vector3 hitHitPosition) {
		target = hitTarget;
		hitPosition = hitHitPosition;
	}

	public GameObject GetTarget () {
		return target;
	}

	public Vector3 GetHitPosition () {
		return hitPosition;
	}
}
