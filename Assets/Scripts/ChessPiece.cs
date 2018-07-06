using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ChessPiece : MonoBehaviour
{
    public int currentX { get; set; }
    public int currentY { get; set; }
    public bool isLight;

    public void SetPosition(int x, int y)
    {
        currentX = x;
        currentY = y;
    }

    public virtual bool PossibleMove(int x, int y)
    {
        return true;
    }
}
