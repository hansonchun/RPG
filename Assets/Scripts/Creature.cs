using UnityEngine;
using System.Collections;

public abstract class Creature : MonoBehaviour 
{
	public string name;

	public int health;

	public int damage;

	public float range;

	// Attack speed is described one attack per second
	public float attackSpeed = 2.5f;

	public void GetHit(int playerDamage)
	{
		health = health - playerDamage;
	}

	protected abstract void Attack();

}
