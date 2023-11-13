using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadScreenManager : MonoBehaviour
{
    [SerializeField] private Image _progressBar;
    [SerializeField] private Text _progressText;


    private void Start()
    {
        StartCoroutine(LoadSceneAsync());
    }

    IEnumerator LoadSceneAsync()
    {
        //Get the level to load and load it async
        AsyncOperation operation = SceneManager.LoadSceneAsync(getLevelToLoad());
        float progress = 0f;

        operation.allowSceneActivation = false;
        while (!operation.isDone)
        {
            progress = operation.progress;
            _progressBar.fillAmount = progress;
            _progressText.text = $"{(int) progress * 100f}%";
            if (operation.progress >= 0.9f)
            {
                _progressText.text = $"Press space bar to continue...";
                if (Input.GetKeyDown(KeyCode.Space))
                    operation.allowSceneActivation = true;
            } 
            yield return null;
        }
    }

    private int getLevelToLoad(){
        int levelToLoad;
        switch (GameManager.getCurrentLevel()) {
            case 1:
                levelToLoad = (int)Enums.Levels.Level1;
                break;
            case 2:
                levelToLoad = (int)Enums.Levels.Level2;
                break;
            default:
                levelToLoad = (int)Enums.Levels.MainMenu;
                GameManager.resetCurrentLevel();
                break;
        }
        return levelToLoad;
    }
}
