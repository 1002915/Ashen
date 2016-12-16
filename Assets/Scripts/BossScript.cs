using UnityEngine;
using System.Collections;

public class BossScript : MonoBehaviour {

	// Check for collisions, and destroy the enemy if hit.
	void OnCollisionEnter2D(Collision2D collision) 
	{
		Debug.Log ("Collided with " + collision.collider.name);
		
		if(collision.collider.name == "Projectile(Clone)")
		{
			Debug.Log ("It'S Solaire!");
			Destroy(gameObject);
			GameManager.Instance.OnHit();
		}
	}
}
