using UnityEngine;
using System.Collections;

public class CharacterFollow : MonoBehaviour {

    public GameObject target;

    void Awake ()
    {
        target = GameObject.FindGameObjectWithTag("Player");
    }
	
	void Update ()
    {
        Vector3 NewPos = transform.position;

        NewPos.x = target.transform.position.x + 6.5f;
        NewPos.y = target.transform.position.y + 4.0f;
        NewPos.z = target.transform.position.z;

        transform.position = NewPos;
    }
}
