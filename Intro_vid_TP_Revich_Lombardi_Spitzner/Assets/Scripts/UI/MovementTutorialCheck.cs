using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementTutorialCheck : MonoBehaviour
{
    int current_tutorial = 0;
    bool wasDetected = false;

    public List<GameObject> canvasList;

    void Update()
    {
        if (wasDetected)
            return;
        switch (current_tutorial)
        {
            case 0: CheckMovement();
                    break;
            case 1: CheckJump();
                    break;

        }
    }

    void CheckMovement()
    {
        // Check for input from WASD keys
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D))
        {
            wasDetected = true;
            StartCoroutine(DestroyAfterDelay(1f));
        }
    }


    void CheckJump()
    {
        // Check for input from WASD keys
        if (Input.GetButtonDown("Jump"))
        {
            wasDetected = true;
            StartCoroutine(DestroyAfterDelay(1f));
        }
    }

    IEnumerator DestroyAfterDelay(float delay)
    {
        // Wait for the specified delay
        yield return new WaitForSeconds(delay);
        canvasList[current_tutorial].SetActive(false);
        canvasList[current_tutorial+1].SetActive(true);
        current_tutorial++;
        wasDetected = false;

        if (current_tutorial == (canvasList.Count - 1)) Destroy(gameObject);

    }

}
