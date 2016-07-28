using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class SimpleShotWeapon : Weapon {

	Ray shootRay;
	LineRenderer gunLine;

	protected void GetGunline () {
		if (gunLine == null) {
			gunLine = GetComponent<LineRenderer> ();
		}
	}

	virtual protected float GetRange () {
		return 100f;
	}

	virtual public Vector3 GetGunLineEnd (List<Hit> hits) {
		if (hits.Count > 0) {
			return hits [0].GetHitPosition ();
		} else {
			return transform.position + transform.forward * GetRange ();
		}
	}

	public override void Draw (List<Hit> hits) {
		GetGunline ();
		if (gunLine != null) {
			gunLine.enabled = true;
			gunLine.SetPosition (0, transform.position);
			gunLine.SetPosition (1, GetGunLineEnd (hits));
		}
	}

	public override List<Hit> GetHits (int shootableMask) {
		List<Hit> hits = new List<Hit> ();
		shootRay.origin = transform.position;
		shootRay.direction = transform.forward;

		GetHitsFromShootRay (shootRay, shootableMask, hits);

		return hits;
	}

	virtual public void GetHitsFromShootRay (Ray shootRay, int shootableMask, List<Hit> hits) {
		RaycastHit shootHit;
		Hit hit;

		if(Physics.Raycast (shootRay, out shootHit, GetRange (), shootableMask)) {

			hit = new Hit (shootHit.collider.gameObject, shootHit.point);
			hits.Add (hit);
		}
	}

	public override void DisableEffects () {
		GetGunline ();
		gunLine.enabled = false;
	}
}
