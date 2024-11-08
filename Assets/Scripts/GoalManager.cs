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
    [SerializeField] private TextMeshProUGUI stateResponse; // win or lose
    [SerializeField] private TextMeshProUGUI stateResponseShadow; // win or lose
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI scoreTextShadow;
    [SerializeField] private TextMeshProUGUI feedbackText;
    [SerializeField] private TextMeshProUGUI feedbackTextShadow;



    void Awake()
    {
        Instance = this;
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (score == goals.Count)
        {
            ShowScore("WELL DONE", "Level Complete!");
        }
    }

    public void AddScore()
    {
        score++;
    }

    public void ShowScore(string state, string feedback)
    {
        Time.timeScale = 0;
        scoreUI.SetActive(true);
        stateResponse.text = state;
        stateResponseShadow.text = state;
        scoreText.text = score.ToString() + " / " + goals.Count;
        scoreTextShadow.text = score.ToString() + " / " + goals.Count;
        feedbackText.text = feedback;
        feedbackTextShadow.text = feedback;
    }

    public void ShowNextGoal()
    {
        if (score < goals.Count)
        {
            goals[score].SetActive(true);
        }
        else
        {
            return;
        }
    }
}
