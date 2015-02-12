using UnityEngine;
using System.Collections;

public class Enemy : Creature 
{
	Player player;
	NavMeshAgent navAgent;
	bool block;
	public float chasingRange;

	// Use this for initialization
	void Start()
	{
		player = Player.player;
		navAgent = GetComponent<NavMeshAgent> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		Attack ();
		FollowPlayer ();
	}

	void OnMouseOver()
	{
		Player.opponent = transform;
		Debug.Log ("Select Me" + gameObject.name);
	}

	protected override void Attack() 
	{
		if (IsInRange (range)) 
		{
			if (!block) 
			{
				player.GetHit (damage);
				block = true;
				Invoke ("UnBlock", attackSpeed);
			}
		}
	}

	void FollowPlayer() 
	{
		if (IsInRange (chasingRange)) 
		{
			navAgent.SetDestination (player.transform.position);
		}
		else
		{
			navAgent.SetDestination(transform.position);
		}
	}

	void UnBlock()
	{
		block = false;
	}

	// Returns true if the player is in the given range with the enemy
	bool IsInRange(float range) 
	{
		if (Vector3.Distance (player.transform.position, transform.position) < range) 
		{
			return true;
		} 
		else 
		{
			return false;
		}
	}
}
