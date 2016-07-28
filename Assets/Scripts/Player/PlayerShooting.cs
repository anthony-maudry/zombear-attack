using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
	public GameObject defaultPrimaryWeapon;

	float weaponDisapear = 0f;
	GameObject defaultWeapon;
	Weapon primaryWeapon;

	void Awake () {
		defaultWeapon = Instantiate (defaultPrimaryWeapon, gameObject.transform.position, gameObject.transform.rotation) as GameObject;
	}

	public void SetPrimaryWeapon (GameObject weapon, float duration) {
		if (primaryWeapon != null && primaryWeapon.gameObject != defaultWeapon) {
			Destroy (primaryWeapon.gameObject);
		}

		primaryWeapon = weapon.GetComponent<Weapon> ();
		weaponDisapear = Time.time + duration;
		primaryWeapon.Prepare ();
	}

	// Update is called once per frame
	void Update () {
		if (MenuPanelController.IsMenuDisplayed) {
			return;
		}

		if (primaryWeapon == null || ( weaponDisapear > 0f && Time.time > weaponDisapear)) {
			SetPrimaryWeapon(defaultWeapon, 0f);
		}

		if (primaryWeapon != null) {
			primaryWeapon.UpdateTimer ();
			primaryWeapon.UpdateTransform (gameObject.transform);
		}

		if(primaryWeapon != null && Input.GetButton ("Fire1") && primaryWeapon.CanShoot ()) {
			primaryWeapon.Shoot ();
		}
	}
}
