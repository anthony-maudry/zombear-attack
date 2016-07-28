using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LaserWeapon : SimpleShotWeapon {

	override public Vector3 GetGunLineEnd (List<Hit> hits) {
		return transform.position + transform.forward * GetRange ();
	}

	override public void GetHitsFromShootRay (Ray shootRay, int shootableMask, List<Hit> hits) {
		RaycastHit[] shootHits = Physics.RaycastAll (shootRay, GetRange (), shootableMask);
		Hit hit;

		foreach ( RaycastHit shootHit in shootHits ) {

			hit = new Hit (shootHit.collider.gameObject, shootHit.point);
			hits.Add (hit);
		}
	}
}

