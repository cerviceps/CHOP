using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ingredient : MonoBehaviour {

	[Header("Name needs to exactly match")]
	[Header("the ingredient name in CookingManager")]
	public string name = "DefaultIngredientName";
	public GameObject cookedPrefab;
	public bool isCookable = false;
	public float cookTime = 3.0f;

	void Start() {
		// Attach a Draggable monobehavior to this gameobject
		gameObject.AddComponent<Draggable>();
	}

	IEnumerator cook() {
		// Disable dragging on this ingredient while cooking
		try {
			Debug.Log("Disabling dragging");
			gameObject.GetComponent<Draggable>().setInputMask(true);
		} catch (MissingComponentException e) {
			Debug.Log ("Draggable script is missing on " + name + ": " + e.Message);
		}

		yield return new WaitForSeconds (cookTime);	

		// Instantiate cooked version at this transform and delete this raw version
		Instantiate(cookedPrefab, gameObject.transform.position, Quaternion.identity);
		// To make sure the cursor isn't locked into an invisible state, return it to default state here
		Cursor.visible = true;
		Cursor.lockState = CursorLockMode.None;
		Destroy (gameObject);
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.name.Equals ("pan")) {
			if (isCookable) {
				StartCoroutine (cook ());
			}
		}
	}
		
}
