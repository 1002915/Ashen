using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    public static GameManager Instance;

    void Awake()
    {
        Instance = this;
    }
    
    // Set the hit count and add each time the player hits something
    public int HitCount = 0;
    public void OnHit()
    {
        ++HitCount;
        UIManager.Instance.UpdateHitCount(HitCount);
    }

    // If all enemies are killed, go to credits.
    void Update()
    {
        if (HitCount >= 12) {
             SceneManager.LoadScene("Credits");
        }
    }
}
