/// <summary>
/// This script manages the goals in the game then displays the score on an end-level UI
/// </summary>
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
    [SerializeField] private Button nextLevelButton;


    void Awake()
    {
        Instance = this; // singleton pattern
        Time.timeScale = 1; // makes sure the game is running at normal speed
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

    /// <summary>
    /// Shows the score UI with the state and feedback
    /// </summary>
    /// <param name="state">State is whether the end score should be win or lose</param>
    /// <param name="feedback">Let's the player know how they lost or if they won</param>
    public void ShowScore(string state, string feedback)
    {
        Time.timeScale = 0; // stops the game from playing in the background
        scoreUI.SetActive(true); 

        if (score < goals.Count) // if the player hasn't completed all of the goals
        {
            nextLevelButton.gameObject.SetActive(false); // hides the next level so player can't progress
        }

        stateResponse.text = state;
        stateResponseShadow.text = state;
        scoreText.text = score.ToString() + " / " + goals.Count;
        scoreTextShadow.text = score.ToString() + " / " + goals.Count;
        feedbackText.text = feedback;
        feedbackTextShadow.text = feedback;
    }

    /// <summary>
    /// Shows the next goal in the list
    /// </summary>
    public void ShowNextGoal()
    {
        if (score < goals.Count)
        {
            goals[score].SetActive(true);

            if (score > 0)
            {
                goals[score - 1].SetActive(false);
            }
        }
    }
}
