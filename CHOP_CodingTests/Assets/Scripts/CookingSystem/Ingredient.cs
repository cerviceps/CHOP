using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ingredient : MonoBehaviour {

	[Header("Name needs to exactly match the ingredient name in CookingManager")]
	public string name = null;

	void Start() {
		if (this.name == null) {
			this.name = "DefaultIngredientName";
		}
	}

}
