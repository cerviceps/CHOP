using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ingredient : MonoBehaviour {

	[Header("Name needs to exactly match")]
	[Header("the ingredient name in CookingManager")]
	public string name = "DefaultIngredientName";
	public bool isCookable = false;
	bool hasCooked = false;

	void Start() {
		// Attach a Draggable monobehavior to this gameobject
		gameObject.AddComponent<Draggable>();
	}

	IEnumerator cook() {
		// Disable dragging on this ingredient
		try {
			Debug.Log("Disabling dragging");
			gameObject.GetComponent<Draggable>().inputMask = true;
		} catch (MissingComponentException e) {
			Debug.Log ("Draggable script is missing on " + name + ": " + e.Message);
		}

		// Get reference to raw gameobject
		Transform rawTransform = gameObject.transform.Find("raw");
		if (rawTransform == null)
			yield return null;
		GameObject rawObject = rawTransform.gameObject;
		// Get reference to cooked gameobject
		Transform cookedTransform = gameObject.transform.Find("cooked");
		if (cookedTransform == null)
			yield return null;
		GameObject cookedObject = cookedTransform.gameObject;

		yield return new WaitForSeconds (3.0f);
		// Disable the raw object and enable the cooked object
		rawObject.SetActive(false);
		cookedObject.SetActive (true);

		// Enable the dragging script
		try {
			gameObject.GetComponent<Draggable>().inputMask = false;
		} catch (MissingComponentException e) {
			Debug.Log (e.Message);
		}
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.name.Equals ("pan")) {
			if (isCookable) {
				StartCoroutine (cook ());
			}
		}
	}
		
}
