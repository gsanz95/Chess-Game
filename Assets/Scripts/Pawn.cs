using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pawn : ChessPiece
{
    public override bool[,] PossibleMove ()
    {
        bool[,] r = new bool[8, 8];
        ChessPiece c, c2;

        //White team move
        if(isLight)
        {
            //Diagonal Left
            if(CurrentX != 0 && CurrentY != 7)
            {
                c = boardmanager.Instance.ChessPieces[CurrentX - 1, CurrentY + 1];
                if(c != null && !c.isLight)
                {
                    r[CurrentX - 1, CurrentY + 1] = true;
                }
            }

            //Diagonal Right
            if (CurrentX != 7 && CurrentY != 7)
            {
                c = boardmanager.Instance.ChessPieces[CurrentX + 1, CurrentY + 1];
                if (c != null && !c.isLight)
                {
                    r[CurrentX + 1, CurrentY + 1] = true;
                }
            }

            //Middle
            if(CurrentY != 7)
            {
                c = boardmanager.Instance.ChessPieces[CurrentX, CurrentY + 1];
                if(c == null)
                {
                    r[CurrentX, CurrentY + 1] = true;
                }
            }

            //First move middle
            if(CurrentY == 1)
            {
                c = boardmanager.Instance.ChessPieces[CurrentX, CurrentY + 1];
                c2 = boardmanager.Instance.ChessPieces[CurrentX, CurrentY + 2];
                if (c == null && c2 == null)
                {
                    r[CurrentX, CurrentY + 2] = true;
                }
            }
        }
        else
        {
            //Diagonal Left
            if (CurrentX != 0 && CurrentY != 0)
            {
                c = boardmanager.Instance.ChessPieces[CurrentX - 1, CurrentY - 1];
                if (c != null && c.isLight)
                {
                    r[CurrentX - 1, CurrentY - 1] = true;
                }
            }

            //Diagonal Right
            if (CurrentX != 7 && CurrentY != 0)
            {
                c = boardmanager.Instance.ChessPieces[CurrentX + 1, CurrentY - 1];
                if (c != null && c.isLight)
                {
                    r[CurrentX + 1, CurrentY - 1] = true;
                }
            }

            //Middle
            if (CurrentY != 0)
            {
                c = boardmanager.Instance.ChessPieces[CurrentX, CurrentY - 1];
                if (c == null)
                {
                    r[CurrentX, CurrentY - 1] = true;
                }
            }

            //First move middle
            if (CurrentY == 6)
            {
                c = boardmanager.Instance.ChessPieces[CurrentX, CurrentY - 1];
                c2 = boardmanager.Instance.ChessPieces[CurrentX, CurrentY - 2];
                if (c == null && c2 == null)
                {
                    r[CurrentX, CurrentY - 2] = true;
                }
            }
        }
        return r;
    }
}
