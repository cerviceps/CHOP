using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class RadialButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {

    public Image circle;
    public Image icon;
    public string title;
    public RadialMenu myMenu;
    Color defaultColor;
    Color selectedColor = Color.black;

    public void OnPointerEnter(PointerEventData eventData)
    {
        defaultColor = circle.color;
        circle.color = selectedColor;      
        myMenu.selected = this;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        circle.color = defaultColor;
        myMenu.selected = null;
    }
}
