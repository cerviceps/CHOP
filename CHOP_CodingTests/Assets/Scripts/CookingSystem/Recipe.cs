using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recipe : MonoBehaviour {

	string name;
	string result;
	ArrayList ingredients;

	public Recipe(string name, string result) {
		this.name = name;
		this.result = result;
		this.ingredients = new ArrayList ();
	}

	public Recipe(string name, string result, string[] ingredients) {
		this.name = name;
		this.result = result;
		this.ingredients = new ArrayList (ingredients);
	}

	public string getName() {
		return this.name;
	}

	public void setName(string name) {
		this.name = name;
	}

	public string getResult() {
		return this.result;
	}

	public void setResult(string result) {
		this.result = result;
	}

	public void addIngredient(string ingredient) {
		ingredients.Add (ingredient);
	}

	public bool removeIngredient(string ingredient) {
		int index = ingredients.IndexOf (ingredient);
		if (index < 0)
			return false;
		ingredients.RemoveAt(index);
		return true;
	}

	public bool isAvailable(string[] availableIngredients) {
		if (availableIngredients.Length < this.ingredients.Count)
			return false;
		ArrayList availableIngredientsList = new ArrayList (availableIngredients);
		for (int i = 0; i < this.ingredients.Count; i++) {
			if (!availableIngredientsList.Contains(this.ingredients[i]))
				return false;
		}
		return true;
	}


}
