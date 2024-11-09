/// <summary>
/// Buttons used in the title screen
/// </summary>
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleButtons : MonoBehaviour
{
    public void PlayMain()
    {
        SceneManager.LoadScene("Level 1");
    }
}
