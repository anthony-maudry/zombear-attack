using UnityEngine;
using System.Collections;

public class LaserGunItem : AbstractItem {
	public GameObject laserGunWeapon;
	public float weaponDuration;

	const string MESSAGE = "Fusil Laser !";

	public override void Apply (GameObject player) {
		player.GetComponentInChildren<PlayerShooting> ().SetPrimaryWeapon (Instantiate (laserGunWeapon) as GameObject, weaponDuration);
	}

	public override string GetMessage () {
		return MESSAGE;
	}

	public override Color GetLightColor () {
		return new Color (0f, 0.7f, 1f);
	}
}
