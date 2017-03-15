using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CameraSwap : MonoBehaviour
{

    public Camera MainCamera;
    public Camera CookingCamera;
    GameObject target;
    private ClickToMove moveScript;
    private int flag;

    public void ShowMainCam()
    {
        MainCamera.enabled = true;
        CookingCamera.enabled = false;
    }

    public void ShowCookingCam()
    {
        CookingCamera.enabled = true;
        MainCamera.enabled = false;
    }

    void Awake()
    {
        MainCamera.enabled = true;
        CookingCamera.enabled = false;
        target = GameObject.FindGameObjectWithTag("Player");
        flag = 1;
        moveScript = (ClickToMove)FindObjectOfType(typeof(ClickToMove));
    }

    void Update()
    {
        if (Input.GetKeyDown("e") && flag == 1 && !moveScript.walking)
        {
            target.transform.LookAt(CookingCamera.transform);
            ShowCookingCam();
            flag = 2;
        }

        if (Input.GetKeyDown("r") && flag == 2)
        {
            ShowMainCam();
            flag = 1;
        }
    }
}
