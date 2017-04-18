using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ingredient : MonoBehaviour {

	[Header("Name needs to exactly match")]
	[Header("the ingredient name in CookingManager")]
	public string name = "DefaultIngredientName";

	void Start() {
		// Attach a Draggable monobehavior to this gameobject
		gameObject.AddComponent<Draggable>();
	}

}
