using UnityEngine;
using System.Collections;

public class Rotation : MonoBehaviour {
	public float minIntensity = 0.5f;
	public float maxIntensity = 0.8f;
	public float flashSpeed = 3f;

	private Light lightComponent;
	private Renderer materialRenderer;

	void Awake () {
		lightComponent = GetComponent<Light> ();
		materialRenderer = GetComponent<Renderer> ();
	}

	// Update is called once per frame
	void Update () {
		Rotate ();
		Glow ();
	}

	void Rotate () {
		transform.Rotate (new Vector3 (15, 30, 45) * Time.deltaTime);
	}

	void Glow () {

		if (lightComponent != null) {
			lightComponent.intensity = Mathf.Cos (flashSpeed * Time.time);
		}

		if (materialRenderer != null) {
			Color color = materialRenderer.sharedMaterial.GetColor ("_Color");
			color.a = lightComponent.intensity >= minIntensity ? lightComponent.intensity : 0.5f;
			materialRenderer.sharedMaterial.SetColor ("_Color", color);
		}
	}
}
