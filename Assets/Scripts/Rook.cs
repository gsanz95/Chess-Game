using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rook : ChessPiece
{
    public override bool[,] PossibleMove ()
    {
        bool[,] r = new bool[8, 8];

        ChessPiece occupied;
        int i;

        //Right
        i = CurrentX;
        while(true)
        {
            i++;
            if(i >= 8)
            {
                break;
            }

            occupied = boardmanager.Instance.ChessPieces[i, CurrentY];

            if(occupied == null)
            {
                r[i, CurrentY] = true;
            }
            else
            {
                if(occupied.isLight != isLight)
                {
                    r[i, CurrentY] = true;
                }

                break;
            }
        }

        //Left
        i = CurrentX;
        while(true)
        {
            i--;
            if (i < 0)
            {
                break;
            }

            occupied = boardmanager.Instance.ChessPieces[i, CurrentY];

            if (occupied == null)
            {
                r[i, CurrentY] = true;
            }
            else
            {
                if (occupied.isLight != isLight)
                {
                    r[i, CurrentY] = true;
                }

                break;
            }
        }

        //Up
        i = CurrentY;
        while(true)
        {
            i++;
            if (i >= 8)
            {
                break;
            }

            occupied = boardmanager.Instance.ChessPieces[CurrentX, i];

            if (occupied == null)
            {
                r[CurrentX, i] = true;
            }
            else
            {
                if (occupied.isLight != isLight)
                {
                    r[CurrentX, i] = true;
                }
                
                break;
            }
        }

        //Down
        i = CurrentY;
        while (true)
        {
            i--;
            if (i < 0)
            {
                break;
            }

            occupied = boardmanager.Instance.ChessPieces[CurrentX, i];

            if (occupied == null)
            {
                r[CurrentX, i] = true;
            }
            else
            {
                if (occupied.isLight != isLight)
                {
                    r[CurrentX, i] = true;
                }

                break;
            }
        }

        return r;
    }
}
