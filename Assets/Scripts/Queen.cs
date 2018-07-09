using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Queen : ChessPiece
{
    public override bool[,] PossibleMove()
    {
        bool[,] r = new bool[8, 8];

        ChessPiece occupied;
        int i, j;

        //Right
        i = CurrentX;
        while (true)
        {
            i++;
            if (i >= 8)
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

        //Left
        i = CurrentX;
        while (true)
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
        while (true)
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

        //Up-Left
        i = CurrentX;
        j = CurrentY;

        while (true)
        {
            i--;
            j++;
            if (i < 0 || j >= 8)
            {
                break;
            }

            occupied = boardmanager.Instance.ChessPieces[i, j];

            if (occupied == null)
            {
                r[i, j] = true;
            }
            else
            {
                if (isLight != occupied.isLight)
                {
                    r[i, j] = true;
                }

                break;
            }
        }

        //Up-Right
        i = CurrentX;
        j = CurrentY;

        while (true)
        {
            i++;
            j++;
            if (i >= 8 || j >= 8)
            {
                break;
            }

            occupied = boardmanager.Instance.ChessPieces[i, j];

            if (occupied == null)
            {
                r[i, j] = true;
            }
            else
            {
                if (isLight != occupied.isLight)
                {
                    r[i, j] = true;
                }

                break;
            }
        }

        //Down Left
        i = CurrentX;
        j = CurrentY;

        while (true)
        {
            i--;
            j--;
            if (i < 0 || j < 0)
            {
                break;
            }

            occupied = boardmanager.Instance.ChessPieces[i, j];

            if (occupied == null)
            {
                r[i, j] = true;
            }
            else
            {
                if (isLight != occupied.isLight)
                {
                    r[i, j] = true;
                }

                break;
            }
        }

        //Down Right
        i = CurrentX;
        j = CurrentY;

        while (true)
        {
            i++;
            j--;
            if (i >= 8 || j < 0)
            {
                break;
            }

            occupied = boardmanager.Instance.ChessPieces[i, j];

            if (occupied == null)
            {
                r[i, j] = true;
            }
            else
            {
                if (isLight != occupied.isLight)
                {
                    r[i, j] = true;
                }

                break;
            }
        }

        return r;
    }

}
