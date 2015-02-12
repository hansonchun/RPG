using UnityEngine;
using System.Collections;

public class ClickToMove : MonoBehaviour 
{
	NavMeshAgent navAgent;

	// Use this for initialization
	void Start () 
	{
		navAgent = GetComponent<NavMeshAgent> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		Move ();
	}

	// This method handles the movement of the player
	// The player moves to the point where the user clicks
	void Move()
	{
		RaycastHit hit;
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		
		if (Input.GetMouseButtonUp (0)) 
		{
			if (Physics.Raycast (ray, out hit, 500)) 
			{
				navAgent.SetDestination(hit.point);
			}
		}
	}

}
