using UnityEngine;
using System.Collections;

public class HealthItem : AbstractItem {
	const int HEALTH_RETRIEVED = 10;
	const string MESSAGE = "Soigné !";

	public override void Apply (GameObject player) {
		PlayerHealth playerHealth = player.GetComponent<PlayerHealth> ();

		playerHealth.TakeDamage (-HEALTH_RETRIEVED);
	}

	public override string GetMessage () {
		return MESSAGE;
	}

	public override Color GetLightColor () {
		return new Color (0f, 0.85f, 0.2f);
	}
}
