using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] Text Max_Score_Text;
    [SerializeField] Text Score_Text;

    public static int score;
    int max_score;

    private void Start()
    {
       score = 0;
    }

    private void Update()
    {
        score = ((int)(player.position.z / 2));
        max_score = score;
        
        Score_Text.text = "Текущий счёт: " + max_score.ToString();
        if (PlayerPrefs.GetInt("score") <= max_score)
        {
            PlayerPrefs.SetInt("score", max_score);
        }

        Max_Score_Text.text = "Рекорд: " + PlayerPrefs.GetInt("score").ToString();
    }
}
