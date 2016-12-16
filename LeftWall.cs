using UnityEngine;
using System.Collections;

public class LeftWall : Wall
{
    private SoundManager sm;

        // Use this for initialization
    void Start () 
    {
        sm = FindObjectOfType<SoundManager>();
	}

    public float deathCountdown = 1;
    private bool deathCountdownActive = false;

    public override void OnHit()
    {
        sm.OnHitEvent();
        GameManager.Instance.OnHit();
        Debug.Log("LeftWall::OnHit");

       // Destroy(gameObject);

        deathCountdownActive = true;
    }
    
	// Update is called once per frame
	void Update () {
        if ( deathCountdownActive)
        {
            deathCountdown -= Time.deltaTime;

            if (deathCountdown <= 0)
            {
                deathCountdownActive = false;
                Destroy(gameObject);
            }
        }
	}

}
