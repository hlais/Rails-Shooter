using UnityEngine.UI;
using UnityEngine;

public class ScoreBoard : MonoBehaviour
{
    int score;
    Text scoreText;

    

    private void Start()
    {
        scoreText = GetComponent<Text>();
        scoreText.text = score.ToString();
    }
    public void HitPoints(int hitPoints)
    {
        score += hitPoints;
        scoreText.text = score.ToString();
    }
}