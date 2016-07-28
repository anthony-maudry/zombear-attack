using UnityEngine;
using System.Collections;

public class FlameThrowerItem : AbstractItem {
	public GameObject FlameThrowerWeapon;
	public float weaponDuration;

	const string MESSAGE = "Lance Flamme !";

	public override void Apply (GameObject player) {
		player.GetComponentInChildren<PlayerShooting> ().SetPrimaryWeapon (Instantiate (FlameThrowerWeapon) as GameObject, weaponDuration);
	}

	public override string GetMessage () {
		return MESSAGE;
	}

	public override Color GetLightColor () {
		return new Color (0.9f, 0.3f, 0.2f);
	}
}
