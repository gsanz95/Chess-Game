using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class King : ChessPiece
{
    public override bool[,] PossibleMove()
    {
        bool[,] r = new bool[8, 8];

        ChessPiece occupied;
        int i, j;

        //Upper Side
        i = CurrentX - 1;
        j = CurrentY + 1;
        if(CurrentY != 7)
        {
            for(int k = 0; k < 3; k++)
            {
                if(i >= 0 && i < 8)
                {
                    occupied = boardmanager.Instance.ChessPieces[i, j];
                    if (occupied == null)
                    {
                        r[i, j] = true;
                    }
                    else if(isLight != occupied.isLight)
                    {
                        r[i, j] = true;
                    }
                }
                i++;
            }
        }

        //Lower Side
        i = CurrentX - 1;
        j = CurrentY - 1;
        if (CurrentY != 0)
        {
            for (int k = 0; k < 3; k++)
            {
                if (i >= 0 && i < 8)
                {
                    occupied = boardmanager.Instance.ChessPieces[i, j];
                    if (occupied == null)
                    {
                        r[i, j] = true;
                    }
                    else if (isLight != occupied.isLight)
                    {
                        r[i, j] = true;
                    }
                }
                i++;
            }
        }

        //Middle Left
        if(CurrentX != 0)
        {
            occupied = boardmanager.Instance.ChessPieces[CurrentX - 1, CurrentY];
            if(occupied == null)
            {
                r[CurrentX - 1, CurrentY] = true;
            }
            else if(isLight != occupied.isLight)
            {
                r[CurrentX - 1, CurrentY] = true;
            }
        }

        //Middle Right
        if (CurrentX != 7)
        {
            occupied = boardmanager.Instance.ChessPieces[CurrentX + 1, CurrentY];
            if (occupied == null)
            {
                r[CurrentX + 1, CurrentY] = true;
            }
            else if (isLight != occupied.isLight)
            {
                r[CurrentX + 1, CurrentY] = true;
            }
        }

        return r;
    }
}
