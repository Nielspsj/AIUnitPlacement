using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private int score = 0;
    public UIManager uiManager;
    //Send info from other scripts to this script.
    //Add score and combos etc.
    //Make score counter readable by UI manager.
    // Start is called before the first frame update
   
    public void EnemyKilled()
    {
        Debug.Log("enemy killed");

        score += 10;
        uiManager.UpdateScore(score);
    }

    public void PlayerKilled()
    {
        Debug.Log("player killed");
        score -= 10;
        uiManager.UpdateScore(score);
    }
}
