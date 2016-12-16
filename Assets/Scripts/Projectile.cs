using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

		void OnCollisionEnter2D(Collision2D collision) {

		Debug.Log ("Collided with " + collision.collider.name);

		if(collision.collider == true){
			Debug.Log ("It'S Solaire!");
			Destroy(gameObject);
	//		GameManager.Instance.OnHit();
		}
	}
}
