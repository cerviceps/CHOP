using UnityEngine;
using System.Collections;

public class ClickToMove : MonoBehaviour {

    private Animator animator;
    private UnityEngine.AI.NavMeshAgent navMeshAgent;
    public bool walking;
    public Camera Cam;
    //public GameObject waypoint;
    //private GameObject wpInstance;


	void Awake ()
    {
        animator = GetComponent<Animator>();
        navMeshAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();
	}
	

	void Update ()
    {
        if (Cam.enabled)
        {

            Ray ray = Cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Input.GetButtonDown("Fire1"))
            {

                if (Physics.Raycast(ray, out hit, 500))
                {
                    walking = true;
                    navMeshAgent.destination = hit.point;
                    navMeshAgent.Resume();
                    //wpInstance = (GameObject)Instantiate(waypoint, hit.point, Quaternion.identity);
                    //Destroy(wpInstance, 0.5f);
                }

            }

            if (navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance)
            {
                if (!navMeshAgent.hasPath || Mathf.Abs(navMeshAgent.velocity.sqrMagnitude) < float.Epsilon)
                {
                    walking = false;
                }
            }
            else
            {
                walking = true;
            }

            animator.SetBool("IsWalking", walking);
        }
    }
}
