using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Draggable : MonoBehaviour {
	
	Vector3 dist;
	Vector3 startPos;
	float posX;
	float posZ;
	float posY;

	bool inputMask = false;

	Shader originalShader;

	void Start() {
		try {
			originalShader = gameObject.transform.GetChild (0).gameObject.GetComponent<MeshRenderer> ().material.shader;
		} catch (MissingComponentException e) {
			Debug.Log (e.Message);
		}
	}

	public void setInputMask(bool enabled) {
		Debug.Log ("SETTING INPUT MASK TO " + enabled);
		this.inputMask = enabled;
	}

	void OnMouseDown()
	{
		if (!inputMask) {
			Cursor.visible = false;
			Cursor.lockState = CursorLockMode.Confined;

			// Put outline shader on the prefab's active child's meshrenderer
			try {
				Transform childTransform = gameObject.transform.GetChild (0);
				Material mat = childTransform.gameObject.GetComponent<MeshRenderer> ().material;
				Shader outlineShader = Shader.Find ("Toon/Basic Outline");
				mat.shader = outlineShader;
				mat.SetColor("_OutlineColor", Color.yellow);
			} catch (MissingComponentException e) {
				Debug.Log (e.Message);
			}
				
			startPos = transform.position;
			dist = Camera.main.WorldToScreenPoint (transform.position);
			posX = Input.mousePosition.x - dist.x;
			posY = Input.mousePosition.y - dist.y;
			posZ = Input.mousePosition.z - dist.z;
		}
	}

	void OnMouseUp() {
		Cursor.visible = true;
		Cursor.lockState = CursorLockMode.None;

		// Set shader to the original shader
		try {
			Transform childTransform = gameObject.transform.GetChild (0);
			Material mat = childTransform.gameObject.GetComponent<MeshRenderer> ().material;
			mat.shader = this.originalShader;
		} catch (MissingComponentException e) {
			Debug.Log (e.Message);
		}
	}

	void OnMouseDrag()
	{
		// TODO inputMask doesn't update until this method is called again
		if (!inputMask) {
			Debug.Log ("Inputmask = " + inputMask);
			float disX = Input.mousePosition.x - posX;
			float disY = Input.mousePosition.y - posY;
			float disZ = Input.mousePosition.z - posZ;
			Vector3 lastPos = Camera.main.ScreenToWorldPoint (new Vector3 (disX, disY, disZ));
			transform.position = new Vector3 (lastPos.x, startPos.y, lastPos.z);
		}
	}
}
