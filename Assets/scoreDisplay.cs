using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class scoreDisplay : MonoBehaviour
{
    public static int score = 0;
    
    // Update is called once per frame
    void Update()
    {
        GetComponent<TMP_Text>().text = "Score: " + score +
            "\nHealth: " + playerController.health;
    }
}
