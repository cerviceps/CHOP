using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneToggle : MonoBehaviour
{
    public GameObject panel;

    public void Update()
    {
        if (Input.GetKeyUp("t"))
        {
			Application.LoadLevel("PancakeScene01");
            
            }
		if (Input.GetKeyUp("g"))
		{
			Application.LoadLevel("SoupScene01");

        }
			
		if (Input.GetKeyUp ("h")) {

			Application.LoadLevel("MovementTests2");
		}
    }
}
