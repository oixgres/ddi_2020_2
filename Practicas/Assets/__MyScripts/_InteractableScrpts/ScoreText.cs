using UnityEngine;
using UnityEngine.UI;
using System;
public class ScoreText : MonoBehaviour
{
    public Text scoreText;
    public double score;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            score = Convert.ToDouble(scoreText.text);
            score++;
            scoreText.text = score.ToString("0");
            Destroy(gameObject);
        }
    }
}
