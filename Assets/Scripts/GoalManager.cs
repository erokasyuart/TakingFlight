using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalManager : MonoBehaviour
{
    public static GoalManager Instance;
    private int score = 0;
    [SerializeField] private List<GameObject> goals = new List<GameObject>();

    void Awake()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (score == goals.Count)
        {
            Debug.Log("Score: " + score + " / " + goals.Count);
        }
    }

    public void AddScore()
    {
        score++;
    }
}
