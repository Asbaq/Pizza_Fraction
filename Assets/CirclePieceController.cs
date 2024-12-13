using UnityEngine;

public class CirclePieceController : MonoBehaviour
{
    public Material shadedMaterial;  // Material for shaded pieces
    public Material defaultMaterial; // Material for unshaded pieces

    private Renderer[] pieces; // Array to hold all circle segment renderers

    private void Start()
    {
        // Get all child renderers (circle pieces)
        pieces = GetComponentsInChildren<Renderer>();
        ResetCircle();
    }

    public bool AddPiece()
    {
        foreach (var piece in pieces)
        {
            if (piece.material != shadedMaterial)
            {
                piece.material = shadedMaterial;
                return true;
            }
        }
        return false; // No unshaded pieces left
    }

    public bool RemovePiece()
    {
        for (int i = pieces.Length - 1; i >= 0; i--)
        {
            if (pieces[i].material == shadedMaterial)
            {
                pieces[i].material = defaultMaterial;
                return true;
            }
        }
        return false; // No shaded pieces left
    }

    public int GetShadedCount()
    {
        int count = 0;
        foreach (var piece in pieces)
        {
            if (piece.material == shadedMaterial)
            {
                count++;
            }
        }
        return count;
    }

    public void ResetCircle()
    {
        foreach (var piece in pieces)
        {
            piece.material = defaultMaterial;
        }
    }
}
