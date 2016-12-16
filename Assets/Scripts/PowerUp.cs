using UnityEngine;
using System.Collections;

public class PowerUp : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

		void OnCollisionEnter2D(Collision2D collision) {

		Debug.Log ("Collided with " + collision.collider.name);

		if(collision.collider.name == "solaire_0"){
			Debug.Log ("Range Boost!");
			Destroy(gameObject);
		}
	}
}
