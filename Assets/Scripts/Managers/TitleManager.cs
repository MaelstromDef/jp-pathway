using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleManager : MonoBehaviour
{
    [SerializeField] Text txtPlayer;

    public void Play()
    {
        if (GatherPlayerName())
        {
            SceneManager.LoadScene("main");
        }
    }

    // Ensures player name is available and grabs it. Returns success status.
    bool GatherPlayerName()
    {
        if (string.IsNullOrEmpty(txtPlayer.text)) return false;

        ScoreManager.currentPlayer = txtPlayer.text;

        return true;
    }
}
