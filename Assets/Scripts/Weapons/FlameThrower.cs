using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FlameThrower : Weapon {
	ParticleSystem particles;

	void GetParticleSystem () {
		if (particles == null) {
			particles = GetComponent<ParticleSystem> ();
		}
	}

	override public void UpdateTransform(Transform newTransform) {
		transform.position = newTransform.position;
		transform.rotation = newTransform.rotation;
		transform.forward = newTransform.forward;
		GetParticleSystem ();
		particles.transform.position = newTransform.position;
		particles.transform.rotation = newTransform.rotation;
		particles.transform.forward = newTransform.forward;
	}

	public override void Draw (List<Hit> hits) {
		GetParticleSystem ();
		if (!particles.isPlaying) {
			particles.loop = true;
			particles.Play ();
		}
	}

	public override List<Hit> GetHits (int shootableMask) {
		return new List<Hit> ();
	}

	public override void DisableEffects () {
		GetParticleSystem ();
		particles.Stop ();
	}
}
