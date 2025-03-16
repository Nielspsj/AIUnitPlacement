using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{

    public TMP_Text scoreText;
    // Start is called before the first frame update
   

    public void UpdateScore(int score)
    {
        scoreText.text = score.ToString();
    }
}
