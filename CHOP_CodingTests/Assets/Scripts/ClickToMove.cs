using UnityEngine;
using System.Collections;

public class ClickToMove : MonoBehaviour {

    private Animator animator;
    private UnityEngine.AI.NavMeshAgent navMeshAgent;
    public bool walking;
    public Camera Cam;
    //public GameObject waypoint;
    //private GameObject wpInstance;
	private Vector3 distToWalk = new Vector3(.8f,0,1.5f);
	private float currentPos;
	private Vector3 destVector;
    private bool keepWalking;

	void Awake ()
    {
        animator = GetComponent<Animator>();
        navMeshAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        destVector = navMeshAgent.transform.position;
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
			if (Input.GetKey(KeyCode.W)) {
                walking = true;
				destVector.z = navMeshAgent.transform.position.z + distToWalk.z;
				navMeshAgent.destination = destVector; 
				navMeshAgent.Resume();
			}

            if (Input.GetKey(KeyCode.S))
            {
                walking = true;
                destVector.z = navMeshAgent.transform.position.z - distToWalk.z;
                navMeshAgent.destination = destVector;
                navMeshAgent.Resume();
            }

            if (Input.GetKey(KeyCode.A))
            {
                walking = true;
                destVector.x = (navMeshAgent.transform.position.x - distToWalk.x);
                navMeshAgent.destination = destVector;
                navMeshAgent.Resume();
            }

            if (Input.GetKey(KeyCode.D))
            {
                walking = true;
                destVector.x = navMeshAgent.transform.position.x + distToWalk.x;
                navMeshAgent.destination = destVector;
                navMeshAgent.Resume();
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
