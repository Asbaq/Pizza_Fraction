using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolManager : MonoBehaviour
{
    public GameObject piecePrefab; // Prefab for circular pieces
    public int poolSize = 8; // Default pool size
    private Queue<GameObject> piecePool = new Queue<GameObject>();

    private void Start()
    {
        InitializePool();
    }

    private void InitializePool()
    {
        for (int i = 0; i < poolSize; i++)
        {
            GameObject piece = Instantiate(piecePrefab, transform);
            piece.SetActive(false);
            piecePool.Enqueue(piece);
        }
    }

    public GameObject GetPiece()
    {
        if (piecePool.Count > 0)
        {
            GameObject piece = piecePool.Dequeue();
            piece.SetActive(true);
            return piece;
        }
        else
        {
            // Expand the pool if needed
            GameObject piece = Instantiate(piecePrefab, transform);
            return piece;
        }
    }

    public void ReturnPiece(GameObject piece)
    {
        piece.SetActive(false);
        piecePool.Enqueue(piece);
    }
}
