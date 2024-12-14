using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Level_2_Manager : MonoBehaviour
{
    [Header("GameObjects Lists")]
    public List<GameObject> Demo_Pieces; // GameObjects for demo display
    public List<GameObject> Real_Pieces; // GameObjects for real interaction

    [Header("UI Components")]
    public Button addButton;             // Button to activate pieces
    public Button removeButton;          // Button to deactivate pieces
    public TextMeshProUGUI DemoFractionText;  // Fraction display for Demo_Pieces
    public TextMeshProUGUI RealFractionText;  // Fraction display for Real_Pieces
    public GameObject WinUI;                  // Win message UI element

    [Header("Game Logic Settings")]
    public int DemoActiveCount = 0;       // Tracks active count for Demo_Pieces
    public int RealActiveCount = 0;       // Tracks active count for Real_Pieces
    public int targetNumber = 2;          // Starting target number
    public int denominator = 0;           // Fixed denominator for fractions

    private void Start()
    {
        InitializeGame();

        // Add button listeners
        addButton.onClick.AddListener(ActivateNextRealPiece);
        removeButton.onClick.AddListener(DeactivateLastRealPiece);
    }

    /// <summary>
    /// Initialize the game state.
    /// </summary>
    private void InitializeGame()
    {
        ResetAllPieces();
        UpdateFractionText(RealFractionText, 8, true);
        UpdateFractionText(DemoFractionText, targetNumber, false);
        WinUI.SetActive(false);
        ShowDemoPieces(targetNumber);
        ShowRealPieces();
    }

    /// <summary>
    /// Resets all GameObjects and counters.
    /// </summary>
    private void ResetAllPieces()
    {
        // Deactivate all GameObjects
        foreach (GameObject obj in Real_Pieces) obj.SetActive(false);
        foreach (GameObject obj in Demo_Pieces) obj.SetActive(false);

        RealActiveCount = 0;
        DemoActiveCount = 0;
    }

    /// <summary>
    /// Activates the next GameObject in Real_Pieces.
    /// </summary>
    private void ActivateNextRealPiece()
    {
        if (RealActiveCount < Real_Pieces.Count)
        {
            Real_Pieces[RealActiveCount].SetActive(true);
            RealActiveCount++;
            UpdateFractionText(RealFractionText, RealActiveCount, true);
        }
    }

    /// <summary>
    /// Deactivates the last activated GameObject in Real_Pieces.
    /// </summary>
    private void DeactivateLastRealPiece()
    {
        if (RealActiveCount > 0)
        {
            RealActiveCount--;
            Real_Pieces[RealActiveCount].SetActive(false);
            UpdateFractionText(RealFractionText, RealActiveCount, true);
        }
    }

    /// <summary>
    /// Compares the active Real_Pieces with the target number.
    /// </summary>
    public void CompareTargetWithList()
    {
        if (RealActiveCount == targetNumber)
        {
            Debug.Log($"Target number {targetNumber} achieved!");

            WinUI.SetActive(true);

            int Limit = targetNumber - 2;
            if(Limit >= 0)
            {
                targetNumber -= 2;
                UpdateFractionText(DemoFractionText, targetNumber, false);
            }

            ResetAllPieces();
            ShowDemoPieces(targetNumber);
            ShowRealPieces();
        }
    }

    /// <summary>
    /// Activates the Demo_Pieces up to the target count.
    /// </summary>
    private void ShowDemoPieces(int count)
    {
        for (int i = 0; i < count && i < Demo_Pieces.Count; i++)
        {
            Demo_Pieces[i].SetActive(true);
        }
        DemoActiveCount = count;
    }
    
    /// <summary>
    /// Activates the Demo_Pieces up to the target count.
    /// </summary>
    private void ShowRealPieces()
    {
        for (int i = 0;i < Real_Pieces.Count; i++)
        {
            Real_Pieces[i].SetActive(true);
        }
        RealActiveCount = Real_Pieces.Count;
    }

    /// <summary>
    /// Resets Real_Pieces and hides the Real fraction text.
    /// </summary>
    private void ResetRealPieces()
    {
        foreach (GameObject obj in Real_Pieces)
        {
            obj.SetActive(false);
        }
        RealActiveCount = 0;
        RealFractionText.gameObject.SetActive(false);
    }

    /// <summary>
    /// Updates the fraction text with either vertical or inline format.
    /// </summary>
    /// <param name="textComponent">Text component to update.</param>
    /// <param name="numerator">Numerator value.</param>
    /// <param name="isVertical">True for vertical format, false for inline format.</param>
    private void UpdateFractionText(TextMeshProUGUI textComponent, int numerator, bool isVertical)
    {
        if (isVertical)
        {
            textComponent.text = $"<align=center>{numerator}\n—\n{denominator}</align>";
        }
        else
        {
            textComponent.text = $"{numerator}/{denominator}";
        }
        textComponent.gameObject.SetActive(true);
    }

}
