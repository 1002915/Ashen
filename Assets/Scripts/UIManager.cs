using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {
    public static UIManager Instance;

    void Awake()
    {
        Instance = this;
    }
    // Set the hit counter to display the hit count.
    public Text hitCountDisplay;
    public void UpdateHitCount(int hitCount)
    {
        hitCountDisplay.text = "Hit Count: " + hitCount;
    }
}
