using UnityEngine;
using System.Collections;

public class ItemManager : MonoBehaviour {

	public Transform[] spawnPoints;
	public AbstractItem[] itemsTypes;
	public GameObject itemContainer;
	public float minSpawnRate = 25f;
	public float maxSpawnRate = 35f;
	public float lifeTime = 10f;

	private GameObject spawnedObject;
	private float nextRenderTime;
	private float lastRenderTime = 0f;

	// Use this for initialization
	void Start () {
		ComputeRenderTimes ();
	}
	
	// Update is called once per frame
	void Update () {
		if (spawnedObject != null && Time.time > lastRenderTime + lifeTime) {
			Destroy (spawnedObject);
		}

		if (Time.time > nextRenderTime) {
			SpawnItem ();
		}
	}

	void SpawnItem () {
		if (spawnedObject != null) {
			Destroy (spawnedObject);
		}

		int spawnPointIndex = Random.Range (0, spawnPoints.Length - 1);
		int itemIndex = Random.Range (0, itemsTypes.Length - 1);

		spawnedObject = Instantiate (itemContainer, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation) as GameObject;
		Pickable pickable = spawnedObject.GetComponent<Pickable> ();

		if (pickable != null) {
			pickable.SetItem (itemsTypes [itemIndex]);
		}

		ComputeRenderTimes ();
	}

	void ComputeRenderTimes () {
		lastRenderTime = Time.time;
		nextRenderTime = Time.time + Random.Range (minSpawnRate, maxSpawnRate);
	}
}
