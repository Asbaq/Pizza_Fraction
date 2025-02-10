# Pizza_Fraction 🍕

![Pizza_Fraction](https://github.com/user-attachments/assets/9d80233f-f050-4732-959f-70cb146d5d37)

## 📌 Introduction
**Pizza_Fraction** is an interactive educational game designed to teach players about fractions in a fun and engaging way. Players are required to activate or deactivate pieces of a pizza to match a target fraction. The game includes smooth interactions, audio feedback, and a progressive difficulty system. Players will work through levels, each with different fraction challenges, to enhance their understanding of fractions.

🔗 Video Trailer

https://youtu.be/mgXqv1YJlnU?si=F9amHefKlmwKumva

## 🔥 Features
- 🍕 Use interactive pizza pieces to visualize fractions.
- 🎮 Simple and intuitive controls for activating and deactivating pizza slices.
- 🧑‍🏫 Educational gameplay for learning fractions.
- 🎶 Audio feedback for correct and incorrect actions.
- 📈 Progressive levels with increasing difficulty.
- 🏆 Win UI to celebrate when the target fraction is achieved.
- 🧑‍💻 Clear visual feedback and fraction updates.
- 🏁 Reset system for each level to keep gameplay engaging.

---

## 🏗️ How It Works
The game is structured with several scripts that manage the different levels, interactive pieces, and fraction logic.

### 📌 **Level_1_Manager Script**
Manages Level 1 of the game, allowing players to activate or deactivate pieces of the pizza to match a target fraction. The game involves two sets of pizza slices: demo slices for visual reference and real slices for player interaction.

```csharp
public class Level_1_Manager : MonoBehaviour
{
    [Header("GameObjects Lists")]
    public List<GameObject> Demo_Pieces; // GameObjects for demo display
    public List<GameObject> Real_Pieces; // GameObjects for real interaction

    [Header("UI Components")]
    public Button addButton;             // Button to activate pieces
    public Button removeButton;          // Button to deactivate pieces
    public TextMeshProUGUI RealFractionText;  // Fraction display for Real_Pieces
    public TextMeshProUGUI DemoFractionText;  // Fraction display for Demo_Pieces
    public GameObject WinUI;                  // Win message UI element

    [Header("Game Logic Settings")]
    public int RealActiveCount = 0;       // Tracks active count for Real_Pieces
    public int DemoActiveCount = 0;       // Tracks active count for Demo_Pieces
    public int targetNumber = 2;          // Starting target number
    public int denominator = 8;           // Fixed denominator for fractions

    public AudioSource audioSource;      // Reference to AudioSource
    public AudioClip successClip;        // Clip to play on success (if condition)
    public AudioClip failureClip;        // Clip to play on failure (else condition)

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
        UpdateFractionText(RealFractionText, 0, true);
        UpdateFractionText(DemoFractionText, targetNumber, false);
        WinUI.SetActive(false);
        RealFractionText.gameObject.SetActive(false);
        ShowDemoPieces(targetNumber);
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

            // Play success audio
            PlayAudio(successClip);

            WinUI.SetActive(true);

            // Increment the target number, but don't exceed the denominator
            targetNumber = Mathf.Min(targetNumber + 2, denominator);
            UpdateFractionText(DemoFractionText, targetNumber, false);

            ShowDemoPieces(targetNumber);
            ResetRealPieces();
        }
        else
        {
            Debug.Log($"Target number {targetNumber} not achieved!");

            // Play failure audio
            PlayAudio(failureClip);
        }
    }

    private void PlayAudio(AudioClip clip)
    {
        if (audioSource != null && clip != null)
        {
            audioSource.PlayOneShot(clip); // Play the specified audio clip
        }
        else
        {
            Debug.LogWarning("AudioSource or AudioClip is not assigned!");
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
```

---

## 🏗️ Additional Levels
The game has additional levels, such as **Level_2_Manager** and **Level_3_Manager**, each adding more complexity and different mechanics to help players learn fractions interactively.

- **Level 2:** Introduces new target fractions and requires more interaction with the real and demo pieces.
- **Level 3:** Allows the user to input their answer and checks if they have reached the target fraction.

---

### 📌 **Level_2_Manager Script**
Handles Level 2, where players continue to interact with fractions through demo and real pizza pieces and gradually increase their target numbers.

```csharp
// Similar script to Level_1_Manager but with extended functionalities
```

---

### 📌 **Level_3_Manager Script**
In this level, players enter the target fraction manually into a text input field and the game validates whether the fraction matches the target.

```csharp
// Similar script to Level_1_Manager with a text input mechanism for user interaction.
```

--- 

This structure allows the game to be dynamic, educational, and enjoyable while reinforcing important mathematical concepts.
