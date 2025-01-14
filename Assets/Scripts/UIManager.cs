using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEditor;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public TMP_InputField playerName;
    public TextMeshProUGUI bestScoreLabel;

    private void Start()
    {
        StartMenuManager.Instance.LoadPlayerData();
        bestScoreLabel.text = "Best Score : " + StartMenuManager.Instance.name + " : " + StartMenuManager.Instance.highestScore;
    }

    public void StartNew()
    {
        StartMenuManager.Instance.currentPlayer = playerName.text;
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
        //Conditional Compiling
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
