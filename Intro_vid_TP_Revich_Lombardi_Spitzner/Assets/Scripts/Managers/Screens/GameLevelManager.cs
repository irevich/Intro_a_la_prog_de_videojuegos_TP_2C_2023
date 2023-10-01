using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static Enums;
public class GameLevelManager : MonoBehaviour
{
    public void LoadMainMenu() => SceneManager.LoadScene((int) Levels.MainMenu);
    public void LoadProgressScreen() => SceneManager.LoadScene((int) Levels.LoadScreen);
    
    public void LoadLevel1() => SceneManager.LoadScene((int) Levels.Level1);
    
    public void LoadVictory() => SceneManager.LoadScene((int) Levels.Victory);
    
    public void LoadDefeat() => SceneManager.LoadScene((int) Levels.Defeat);
    
    
    public void Exit() => Application.Quit();
}
