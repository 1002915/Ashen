using UnityEngine;
using System.Collections;

public class RemoveBoss : MonoBehaviour {

    public void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.name == "Projectile")
        {
            Destroy(col.gameObject);
        }
        else{
            Destroy(gameObject);
        }
    }

}
