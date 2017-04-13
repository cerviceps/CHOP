using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredientSpawner : MonoBehaviour {

	// Takes an array of ingredients and spawns them at predetermined coords

	[Header("Coords should correspond with prefabs")]
	public Vector3[] coords;
	public GameObject[] prefabs;
	Dictionary<string, int> ingNameToIndexMap;

	void Start() {
		if (this.coords.Length != this.prefabs.Length)
			throw new UnityException (":: IngredientSpawner :: Coords and Prefabs are different lengths!");
		
		this.ingNameToIndexMap = new Dictionary<string, int> ();
		// Index the Ingredient names so we don't have to search through all the prefabs when we spawn them
		for (int i = 0; i < prefabs.Length; i++) {
			Ingredient prefabIngredient = (Ingredient)prefabs [i].GetComponent (typeof(Ingredient)) as Ingredient;
			this.ingNameToIndexMap.Add (prefabIngredient.name, i);
		}

		Debug.Log ("Testing prefab1...");
		spawnByName ("chicken");
	}

	public bool spawnByName(string name) {
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
}
