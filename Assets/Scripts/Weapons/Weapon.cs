using UnityEngine;
using System.Collections;
using System.Collections.Generic;

abstract public class Weapon : MonoBehaviour {

	public int damagePerShot;
	public float shootRate;

	float timer;
	int shootableMask;
	ParticleSystem gunParticles;
	AudioSource gunAudio;
	Light gunLight;
	float effectsDisplayTime = 0.2f;

	public void Prepare ()
	{
		shootableMask = LayerMask.GetMask ("Shootable");
		gunParticles = GetComponent<ParticleSystem> ();
		gunAudio = GetComponent<AudioSource> ();
		gunLight = GetComponent<Light> ();
	}

	virtual public void UpdateTransform(Transform newTransform) {
		transform.position = newTransform.position;
		transform.rotation = newTransform.rotation;
		transform.forward = newTransform.forward;
	}

	public void UpdateTimer () {

		timer += Time.deltaTime;

		if(timer >= shootRate * effectsDisplayTime)
		{
			gunLight.enabled = false;
			DisableEffects ();
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (MenuPanelController.IsMenuDisplayed) {
			return;
		}
	}

	public bool CanShoot () {
		return (timer >= shootRate && Time.timeScale != 0);
	}

	abstract public void Draw (List<Hit> hits);

	abstract public List<Hit> GetHits (int shootableMask);

	abstract public void DisableEffects ();

	public void Shoot () {

		timer = 0f;

		gunAudio.enabled = true;
		gunAudio.Stop ();
		gunAudio.Play ();

		gunLight.enabled = true;

		gunParticles.Stop ();
		gunParticles.Play ();

		List<Hit> hits = GetHits (shootableMask);

		Draw (hits);

		HitEnemies (hits);
	}

	public void HitEnemies (List<Hit> hits) {
		foreach (Hit hit in hits) {

			EnemyHealth enemyHealth = hit.GetTarget ().GetComponent <EnemyHealth> ();
			if(enemyHealth != null)
			{
				enemyHealth.TakeDamage (damagePerShot, hit.GetHitPosition ());
			}
		}
	}
}
