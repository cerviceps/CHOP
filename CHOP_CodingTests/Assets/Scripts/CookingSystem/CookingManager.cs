using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookingManager : MonoBehaviour {

	ArrayList recipes;
	ArrayList availableRecipes;
	public string[] ingredients;

	void Start () {
		this.recipes = new ArrayList ();
		this.availableRecipes = new ArrayList ();

		// Sample recipe - in real life we could load recipes via database or web call
		string[] sampleIngredients = new string[] { "chicken", "water", "lettuce" };
		Recipe sampleRecipe = new Recipe ("Chicken Stew", "Hearty Chicken Stew", sampleIngredients);
		this.recipes.Add (sampleRecipe);

		// This is assuming we can't get new cooking inventory items after this scene has started
		for (int i = 0; i < this.recipes.Count; i++) {
			Recipe r = (Recipe)this.recipes [i];
			if (r.isAvailable (this.ingredients)) {
				this.availableRecipes.Add (r);
				Debug.Log ("Adding recipe to availableRecipes: " + r.getName ());
			}
		}
	}
	
	void Update () {
		
	}
}
