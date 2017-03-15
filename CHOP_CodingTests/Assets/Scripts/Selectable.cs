using UnityEngine;
using System.Collections;

public class Selectable : MonoBehaviour {

    public Renderer render;
    public Material mat;

    void Awake()
    {
        render = GetComponent<Renderer>();
        render.material.shader = Shader.Find("Standard");
    }

    void OnMouseOver()
    {
        render.material.shader = Shader.Find("Outline");
        render.material = mat;
    }

    void OnMouseExit()
    {
        render.material.shader = Shader.Find("Standard");
    }
}
