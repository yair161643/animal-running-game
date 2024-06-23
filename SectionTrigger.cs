using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SectionTrigger : MonoBehaviour
{
    public GameObject roadSection;
    public GameObject oneRoadSection;
    public GameObject twoRoadSection;
    public GameObject threeRoadSection;
    public float minYThreshold = -24f; // Define the minimum Y position threshold
    private bool hasInstantiated = false; // Flag to track if instantiation has occurred
    public Text textOfPoints; // Reference to the Text component

    private static int points = 300; // Variable to hold the points
    private float nextPointIncreaseTime = 0f; // Time for the next point increase

    // Update is called once per frame
    void Update()
    {
        // Check if it's time to increase the points
        if (Time.time >= nextPointIncreaseTime)
        {
            // Increase points
            points++;
            // Update the next time to increase points
            nextPointIncreaseTime = Time.time + 0.2f;
            // Update the points text
            UpdatePointsText();
        }

        if (transform.position.y < minYThreshold)
        {
            // Close the game
            Debug.Log("Game Over");
            QuitGame();
        }
    }

    void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false; // Stop playing the editor
#else
        Application.Quit(); // Quit application (works for standalone builds)
#endif
    }

    private void OnTriggerEnter(Collider other)
    {
        triggerWallScript triggerWall = other.GetComponent<triggerWallScript>(); // Get the triggerWallScript component attached to the collided object

        if (triggerWall != null && !triggerWall.isTouchedAlready) // Check if the collided object has the triggerWallScript component and isTouchedAlready is false
        {
            int rndNumber = Random.Range(0, 4);
            if (rndNumber == 0)
            {
                Instantiate(roadSection, new Vector3(0, 0, 381f), Quaternion.identity);
            }
            else if (rndNumber == 1)
            {
                Instantiate(oneRoadSection, new Vector3(0, 0, 381f), Quaternion.identity);
            }
            else if (rndNumber == 2)
            {
                Instantiate(twoRoadSection, new Vector3(0, 0, 381f), Quaternion.identity);
            }
            else if (rndNumber == 3)
            {
                Instantiate(threeRoadSection, new Vector3(0, 0, 381f), Quaternion.identity);
            }

            triggerWall.isTouchedAlready = true; // Set isTouchedAlready to true
            hasInstantiated = true; // Set the flag to true to indicate instantiation
            StartCoroutine(ResetInstantiationFlag());
        }
    }


    IEnumerator ResetInstantiationFlag()
    {
        yield return new WaitForSeconds(2f); // Wait for 0.8 seconds
        hasInstantiated = false; // Reset the flag
    }

    void UpdatePointsText()
    {
        // Update the points text
        textOfPoints.text = "Points: " + points.ToString();
    }

    void Start()
    {
        // Set the initial next point increase time
        nextPointIncreaseTime = Time.time + 0.2f;
        // Update the points text initially
        UpdatePointsText();
    }
}
