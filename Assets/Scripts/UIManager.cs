using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{

    public TextMeshProUGUI scoreText;
    // Start is called before the first frame update
   

    public void UpdateScore(int score)
    {
        //string textforscore = scoreText.GetComponent<TextMeshProUGUI>().text;
        Debug.Log("score: " + score);
        //textforscore = score.ToString();
        //scoreText.SetText(score.ToString());
        scoreText.text = score.ToString();
    }
}
