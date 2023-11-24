using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevelDoor : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // Check if the collided object has the tag "NextLevel"
        if (other.CompareTag("Player"))
        {
            // int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            // int nextSceneIndex = currentSceneIndex + 1;
            // SceneManager.LoadScene(nextSceneIndex);

            GameManager.incrementCurrentLevel();
            SceneManager.LoadScene((int) Enums.Levels.LoadScreen);
            
        }
    }


}
