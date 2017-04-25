using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour {

	//public Animation FadeOut;

	public GameObject dBox;
	public SuperTextMesh dText;



	public bool dialogueActive;

	// Use this for initialization
	void Start () {
		//Animation = GetComponent<Animation> ();
	}
	
	// Update is called once per frame
	void Update () {

		if (dialogueActive && Input.GetKeyDown(KeyCode.Space))
		{
			//Animation.
			//Animation.play ("DialogueManager_FadeOut");

			dBox.SetActive (false);
			dialogueActive = false;
		}

	}

	public void ShowBox(string dialogue) 
	{
		dialogueActive = true;
		dBox.SetActive (true);
		dText.text = dialogue;
	}
}
