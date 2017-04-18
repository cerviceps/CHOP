using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredientSpawner : MonoBehaviour {

	// Takes an array of ingredients and spawns them at predetermined coords

	[Header("Coords should correspond with prefabs")]
	public Vector3[] coords;
	public GameObject[] prefabs;
	Dictionary<string, int> ingNameToIndexMap = null;

	void Start() {
		spawnAtAllCoords ();
	}

	public void spawnAtAllCoords() {
		int length = Mathf.Min (this.prefabs.Length, this.coords.Length);
		for (int i = 0; i < length; i++) {
			Instantiate (prefabs [i], coords [i], Quaternion.identity);
		}
	}

	public bool spawnByName(string name) {
		if (this.ingNameToIndexMap == null) {
			indexNames ();
		}

		int index;
		try {
			index = ingNameToIndexMap [name];
		} catch (KeyNotFoundException e) {
			Debug.LogError ("spawnByName() error: " + e);
			return false;
		}
		// Instantiate the pref at the corresponding position (vector)
		GameObject prefab = this.prefabs [index];
		Vector3 coord = this.coords [index];
		Instantiate (prefab, coord, Quaternion.identity);
		return true;
	}

	// Index the Ingredient names the first time we look them up so we don't have to search through all the prefabs when we spawn them
	private void indexNames() {
		this.ingNameToIndexMap = new Dictionary<string, int> ();
		for (int i = 0; i < this.prefabs.Length; i++) {
			Ingredient prefabIngredient = (Ingredient)this.prefabs [i].GetComponent (typeof(Ingredient)) as Ingredient;
			this.ingNameToIndexMap.Add (prefabIngredient.name, i);
		}
	}
}
