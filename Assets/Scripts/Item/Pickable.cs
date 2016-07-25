using UnityEngine;
using System.Collections;

public class Pickable : MonoBehaviour {
	private AbstractItem item;

	// Use this for initialization
	void Awake () {
	}
	
	// Update is called once per frame
	void Update () {
	}

	void pickItem () {
		GameObject player = GameObject.FindGameObjectWithTag ("Player");

		if (player != null && item != null) {
			item.Apply (player);
		}

		GameObject.Destroy (gameObject);
	}

	void OnTriggerEnter (Collider other) {
		if (other.CompareTag ("Player")) {
			pickItem ();
		}
	}

	public void SetItem (AbstractItem itemInstance) {
		Renderer renderer = GetComponent<Renderer> ();
		Light light = GetComponent<Light> ();

		item = itemInstance;
		if (renderer != null && itemInstance.material != null) {
			renderer.sharedMaterial = itemInstance.material;
		}

		if (light != null && itemInstance.GetLightColor () != null) {
			light.color = itemInstance.GetLightColor ();
		}
	}
}
