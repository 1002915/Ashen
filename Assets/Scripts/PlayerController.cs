using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

// The line directly below forces the game object to have a Rigidbody2D
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour {
    
    private Rigidbody2D rb;
    private Vector2 userInput;
    private float TimeUntilCanFire = 0f;
    public float movementForce = 10f;
    public float movementSpeed = 1f;
    public float rotationSpeed = 30f;
    public GameObject ProjectilePrefab;
    public GameObject[] Muzzles;
    public float ProjectileForce = 100f;
    public float FireInterval = 0.1f;

    void Start() {
        // Get Rigidbody2D
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    void Update() {
        // are the weapons cooling down?
        if (TimeUntilCanFire > 0)
        {
            TimeUntilCanFire -= Time.deltaTime;
        }
        // is the player trying to fire
        if (Input.GetButton("Fire1")  && TimeUntilCanFire <= 0)
        {
            // put weapons on cooldown
            TimeUntilCanFire = FireInterval;
            // pick a random Muzzles
            int muzzleIndex = Random.Range(0, Muzzles.Length);
            GameObject muzzle = Muzzles[muzzleIndex];

            // get muzzle location
            Vector3 muzzleLocation = muzzle.transform.position;

            // work out the direction to fire
            Vector3 fireDirection = muzzleLocation - transform.position;

            // instantiate the projectile 
            GameObject newProjectile = Instantiate(ProjectilePrefab);

            // position the projectile at the muzzle 
            newProjectile.transform.position = muzzleLocation;

            // get the rigid body for the projectile 
            Rigidbody2D projectileRB = newProjectile.GetComponent<Rigidbody2D>();

            // Launch the projectile
            projectileRB.AddForce(fireDirection.normalized * ProjectileForce);
        }
        // Retrieve the axes
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        // store the axes in the user input variable
        userInput = new Vector2(horizontal, vertical);

    }

    void FixedUpdate()
    {
        // Move by teleporting with collision checks
        Vector2 newPosition = transform.position;
        newPosition += userInput * movementSpeed * Time.fixedDeltaTime;
        rb.MovePosition(newPosition);
    }

	void OnCollisionEnter2D(Collision2D collision) {
        // Boost speed of player when a flask is picked Up
		if(collision.collider.name == "Power Up"){
			Debug.Log ("Range Boost!");
            movementSpeed = movementSpeed + 1;
		}
        // If you run into an enemy, it's game over.
        if(collision.collider.name == "Boss"){
		    Destroy(gameObject);
			  SceneManager.LoadScene("YouDied");
          
		}
        }
  
}
