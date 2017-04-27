using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickMarker3 : MonoBehaviour {

	//Ray ray;
	//RaycastHit hit;

	Vector3 newPosition;

	//Public GameObject prefab;

	// use this for initialization 

	void Start () {

		newPosition = transform.position;
	}

	//Update is called once per frame
	void Update ()
	{

		if (Input.GetMouseButtonDown(0))
		{
			RaycastHit hit;
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			if (Physics.Raycast(ray, out hit))
			{
				newPosition = hit.point; 
				transform.position = newPosition;
			}
		}
	}
}

		//ray = Camera.main.ScreenPointToRay (Input.mousePosition);

		//if (Physics.Raycast (ray, out hit)) {

			//if (Input.GetKey (KeyCode.Mouse0)) {

				//prefab.transform.position = hit.point;
				//GameObject obj = Instantiate (prefab, new Vector3 (hit.point.x, hit.point.y, hit.point.z), Quaternion.identity) as GameObject;

				//GameObject.Destroy (prefab, 0.5f);
			//}
		//}
	//}
//}
