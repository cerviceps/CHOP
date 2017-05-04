using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadialMenu : MonoBehaviour {

    public RadialButton buttonPrefab;
    public RadialButton selected;

	// Use this for initialization
	public void SpawnButtons (Interactable obj) {
        for (int i=0;i<obj.options.Length; i++)
        {
            RadialButton newButton = Instantiate(buttonPrefab) as RadialButton;
            newButton.transform.SetParent(transform, false);
            float theta = (Mathf.PI / obj.options.Length) * i;
            float xPos = Mathf.Sin(theta);
            float yPos = Mathf.Cos(theta);
            newButton.transform.localPosition = new Vector3(xPos, yPos, 0f) * 100f;
            newButton.circle.color = obj.options[i].color;
            newButton.icon.sprite = obj.options[i].sprite;
            newButton.title = obj.options[i].title;
            newButton.myMenu = this;
        }
    }


    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            //Add stuff here, like this
            if (selected.title == "Interact")
            {
                Destroy(GameObject.Find("Stump_Split_01 (1)"));
                Debug.Log("Great!");
            }
            Destroy(gameObject);
        }
    }
	
}
