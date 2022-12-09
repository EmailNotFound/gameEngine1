using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathManager : MonoBehaviour
{
    public void OnTryAgainClick()
    {
        SceneManager.LoadScene("Game");
    }

    public void OnBackTitleClick()
    {
        SceneManager.LoadScene("Title");
    }

}
