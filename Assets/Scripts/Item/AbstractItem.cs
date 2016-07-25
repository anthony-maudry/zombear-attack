using UnityEngine;
using System.Collections;

public abstract class AbstractItem : MonoBehaviour {
	public Material material;

	public virtual void Apply (GameObject player) {
	}

	public virtual string GetMessage () {
		return "";
	}

	public virtual Color GetLightColor () {
		return new Color (0, 0, 0);
	}
}
