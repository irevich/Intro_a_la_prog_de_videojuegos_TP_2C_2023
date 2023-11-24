using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevelDoor : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {

            GameManager.incrementCurrentLevel();
            SceneManager.LoadScene((int) Enums.Levels.LoadScreen);
            
        }
    }


}
