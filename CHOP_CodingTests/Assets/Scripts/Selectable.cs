using UnityEngine;
using System.Collections;

public class Selectable : MonoBehaviour {

    public Renderer render;
    public Material mat;

    void Awake()
    {
        render = GetComponent<Renderer>();
        render.material.shader = Shader.Find("Toony Colors Pro 2/Desktop");
    }

    void OnMouseOver()
    {
        render.material.shader = Shader.Find("Outline");
        render.material = mat;
    }

    void OnMouseExit()
    {
        render.material.shader = Shader.Find("Toony Colors Pro 2/Desktop");
    }
}
