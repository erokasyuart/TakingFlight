/// <summary>
/// Attached to the goal object, this script will show and hide goals as well as add to the player's score by calling the GoalManager
/// </summary>
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    private bool hasTriggered = false;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && !hasTriggered)
        {
            hasTriggered = true;
            GoalManager.Instance.AddScore();
            GoalManager.Instance.ShowNextGoal();
        }
    }
}
