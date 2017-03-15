using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUIToggle : MonoBehaviour
{
    public GameObject panel;
    private bool isVisible = true;

    public void Update()
    {
        if (Input.GetKeyUp("i"))
        {
            if (!isVisible)
            {
                isVisible = true;
                panel.SetActive(true);
            }
            else
            {
                isVisible = false;
                panel.SetActive(false);
            }
        }
    }
}
