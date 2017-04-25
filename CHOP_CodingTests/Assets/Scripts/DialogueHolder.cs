using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueHolder : MonoBehaviour {

	public string dialogue;

	private DialogueManager RiverDialogue01;

	// Use this for initialization
	void Start () {

		RiverDialogue01 = FindObjectOfType<DialogueManager> ();

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider Other)
	{
		if (Other.gameObject.name == "Player") {
			if (Input.GetKeyDown (KeyCode.Space)) {
				RiverDialogue01.ShowBox (dialogue);
			}
		}
	}

}
