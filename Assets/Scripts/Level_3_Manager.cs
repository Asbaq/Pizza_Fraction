using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class Level_3_Manager : MonoBehaviour
{
    [Header("GameObjects Lists")]
    public List<GameObject> Demo_Pieces; // GameObjects for demo display

    [Header("UI Components")]
    public GameObject WinUI;  // Win message UI element
    public TMP_InputField Inputs;  // InputField UI element for feedback

    [Header("Game Logic Settings")]
    public int DemoActiveCount = 0;       // Tracks active count for Demo_Pieces
    public int targetNumber = 4;          // Starting target number

    /// <summary>
    /// Compares the active Real_Pieces with the target number.
    /// </summary>
    public void CompareTargetWithList()
    {
        // Try parsing the input text to an integer
        if (int.TryParse(Inputs.text, out int inputNumber))
        {
            // Check if the input number matches the target
            if (inputNumber == targetNumber)
            {
                Debug.Log($"Target number {targetNumber} achieved!");
                WinUI.SetActive(true);  // Display Win message

                // Deactivate the current Demo_Piece and move to the next
                if (DemoActiveCount < Demo_Pieces.Count)
                {
                    Demo_Pieces[DemoActiveCount].SetActive(false); // Deactivate current piece
                    DemoActiveCount++; // Move to the next piece
                    if (DemoActiveCount < Demo_Pieces.Count)
                    {
                        Demo_Pieces[DemoActiveCount].SetActive(true); // Activate the next piece
                    }
                }

                // If we reached a specific condition, update the target number
                if (DemoActiveCount == 2)
                {
                    targetNumber = 3;
                }

            }
            else
            {
                Debug.Log("Incorrect number entered. Try again.");
            }
        }
        else
        {
            Debug.Log("Invalid input! Please enter a valid number.");
        }
    }
}
