using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public CirclePieceController circleController;
    public TextMeshProUGUI currentFractionText;
    public TextMeshProUGUI targetFractionText;

    public Button addButton;
    public Button removeButton;

    private int targetNumerator;
    private int denominator = 8;

    private void Start()
    {
        InitializeGame();
        addButton.onClick.AddListener(OnAddPiece);
        removeButton.onClick.AddListener(OnRemovePiece);
    }

    private void InitializeGame()
    {
        targetNumerator = Random.Range(1, denominator + 1);
        targetFractionText.text = $"Target: {targetNumerator}/{denominator}";
        circleController.ResetCircle();
        UpdateFractionText();
    }

    private void OnAddPiece()
    {
        if (circleController.AddPiece())
        {
            UpdateFractionText();
            CheckWinCondition();
        }
    }

    private void OnRemovePiece()
    {
        if (circleController.RemovePiece())
        {
            UpdateFractionText();
        }
    }

    private void UpdateFractionText()
    {
        int currentNumerator = circleController.GetShadedCount();
        currentFractionText.text = $"Current: {currentNumerator}/{denominator}";
    }

    private void CheckWinCondition()
    {
        if (circleController.GetShadedCount() == targetNumerator)
        {
            Debug.Log("Success!");
            // Trigger next level or show success UI
            InitializeGame();
        }
    }
}
