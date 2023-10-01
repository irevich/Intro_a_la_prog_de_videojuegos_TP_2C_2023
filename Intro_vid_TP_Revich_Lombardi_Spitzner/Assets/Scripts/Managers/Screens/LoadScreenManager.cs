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
        AsyncOperation operation = SceneManager.LoadSceneAsync((int)Enums.Levels.Level1);
        float progress = 0f;

        operation.allowSceneActivation = false;
        while (!operation.isDone)
        {
            progress = operation.progress;
            //_progressBar.fillAmount = progress;
            //_progressText.text = $"{progress * 100f}%";
            if (operation.progress >= 0.9f)
            {
                //_progressText.text = $"Press space bar to continue...";
                if (Input.GetKeyDown(KeyCode.Space))
                    operation.allowSceneActivation = true;
            } 
            yield return null;
        }
    }
}
