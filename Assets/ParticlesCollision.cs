using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ParticlesCollision : MonoBehaviour {

	void OnParticleCollision (GameObject other) {
		List<Hit> hits = new List<Hit> ();
		Weapon weapon = GetComponent<Weapon> ();
		int shootableMask = LayerMask.NameToLayer ("Shootable");

		if (other.layer == shootableMask) {
			hits.Add (new Hit(other, other.transform.position));
			weapon.HitEnemies (hits);
		}
	}
}
