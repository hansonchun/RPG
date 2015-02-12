using UnityEngine;
using System.Collections;

public class Player : Creature {

	// Enemy mechanics
	public static Transform opponent;

	public static Player player;

	public float horizMovement;

	public AnimationClip run;
	public AnimationClip idle;

	void Awake() 
	{
		player = this;
	}

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		Attack ();
		Animate ();
	}

	protected override void Attack() 
	{
		if (Input.GetKeyUp (KeyCode.Space)) 
		{
			if (opponent != null && Vector3.Distance (opponent.position, transform.position) < range)
			{
				Debug.Log ("Attack!");
				opponent.GetComponent<Enemy>().GetHit(damage);
			}
		}
	}


	void Animate() 
	{
		horizMovement = Input.GetAxisRaw ("Horizontal");
		if (horizMovement > 0) 
		{
			animation.Play (run.name);
		}
		else
		{
			animation.Play (idle.name);
		}
	}
}