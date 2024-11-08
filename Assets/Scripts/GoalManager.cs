using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GoalManager : MonoBehaviour
{
    public static GoalManager Instance;
    private int score = 0;
    [SerializeField] private List<GameObject> goals = new List<GameObject>();

    [Header("Score UI")]
    [SerializeField] private GameObject scoreUI;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI scoreTextShadow;



    void Awake()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (score == goals.Count)
        {
            Time.timeScale = 0;
            ShowScore();
        }
    }

    public void AddScore()
    {
        score++;
    }

    private void ShowScore()
    {
        scoreUI.SetActive(true);
        scoreText.text = score.ToString() + " / " + goals.Count;
        scoreTextShadow.text = score.ToString() + " / " + goals.Count;
    }

    public void ShowNextGoal()
    {
        goals[score].SetActive(true);
    }
}
