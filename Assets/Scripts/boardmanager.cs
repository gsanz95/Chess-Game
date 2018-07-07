using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boardmanager : MonoBehaviour
{
    public static boardmanager Instance { set; get; }
    private bool[,] allowedMoves { set; get; }

    public ChessPiece[,] ChessPieces { set; get; }
    private ChessPiece selectedChessPiece;

    private const float TILE_SIZE = 1.0f;
    private const float TILE_OFFSET = 0.5f;

    private int selectionX = -1;
    private int selectionY = -1;

    public List<GameObject> chessPiecePrefabs;
    private List<GameObject> activeChessPiece;

    private Quaternion orientationLight = Quaternion.Euler(0, 0, 0);
    private Quaternion orientationDark = Quaternion.Euler(0, 180, 0);

    public bool isLightTurn = true;

    private void Start()
    {
        SpawnAllPieces();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateSelection();
        DrawChessBoard();

        if(Input.GetMouseButtonDown(0))
        {
            if (selectionX >= 0 && selectionY >= 0)
            {
                if(selectedChessPiece == null)
                {
                    // Select Chess Piece
                    SelectChessPiece(selectionX, selectionY);
                }else
                {
                    // Move Chess Piece
                    MoveChessPiece(selectionX, selectionY);
                }
            }
        }
    }

    private void SelectChessPiece(int x, int y)
    {
        if(ChessPieces[x, y] == null)
        {
            return;
        }
        if(ChessPieces[x, y].isLight != isLightTurn)
        {
            return;
        }

        selectedChessPiece = ChessPieces[x, y];
    }

    private void MoveChessPiece(int x, int y)
    {
        if(selectedChessPiece.PossibleMove (x,y))
        {
            ChessPieces[selectedChessPiece.currentX, selectedChessPiece.currentY] = null;
            selectedChessPiece.transform.position = GetTileCenter(x, y);
            ChessPieces[x, y] = selectedChessPiece;

            isLightTurn = !isLightTurn;
        }

        selectedChessPiece = null;
    }
    private void SpawnChessPiece(int index, int x, int y, bool isLight)
    {
        GameObject go;
        if (isLight == true)
        {
            go = Instantiate(chessPiecePrefabs[index], GetTileCenter(x, y), orientationLight) as GameObject;
        }
        else
        {
            go = Instantiate(chessPiecePrefabs[index], GetTileCenter(x, y), orientationDark) as GameObject;
        }

        go.transform.SetParent(transform);
        ChessPieces[x, y] = go.GetComponent<ChessPiece>();
        ChessPieces[x, y].SetPosition (x, y);
        activeChessPiece.Add(go);
    }

    private Vector3 GetTileCenter(int x, int y)
    {
        Vector3 origin = Vector3.zero;
        origin.x = (TILE_SIZE * x) + TILE_OFFSET;
        origin.z = (TILE_SIZE * y) + TILE_OFFSET;
        return origin;

    }

    private void SpawnAllPieces()
    {
        activeChessPiece = new List<GameObject>();
        ChessPieces = new ChessPiece[8, 8];

        // White Team
        // King
        SpawnChessPiece(0, 3, 0, true);

        // Queen
        SpawnChessPiece(1, 4, 0, true);

        // Bishop
        SpawnChessPiece(2, 2, 0, true);
        SpawnChessPiece(2, 5, 0, true);

        // Knight
        SpawnChessPiece(3, 1, 0, true);
        SpawnChessPiece(3, 6, 0, true);

        // Rook
        SpawnChessPiece(4, 0, 0, true);
        SpawnChessPiece(4, 7, 0, true);

        //Pawn
        for (int i = 0; i < 8; i++ )
        {
            SpawnChessPiece(5, i, 1, true);
        }

        // Dark Team
        // King
        SpawnChessPiece(6, 4, 7, false);

        // Queen
        SpawnChessPiece(7, 3, 7, false);

        // Bishop
        SpawnChessPiece(8, 2, 7, false);
        SpawnChessPiece(8, 5, 7, false);

        // Knight
        SpawnChessPiece(9, 1, 7, false);
        SpawnChessPiece(9, 6, 7, false);

        // Rook
        SpawnChessPiece(10, 0, 7, false);
        SpawnChessPiece(10, 7, 7, false);

        //Pawn
        for (int i = 0; i < 8; i++)
        {
            SpawnChessPiece(11, i, 6, false);
        }
    }

    private void UpdateSelection()
    {
        if(!Camera.main)
        {
            return;
        }
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 25.0f, LayerMask.GetMask("ChessPlane")))
        {
            selectionX = (int)hit.point.x;
            selectionY = (int)hit.point.z;
        }else
        {
            selectionX = -1;
            selectionY = -1;
        }
    }

    private void DrawChessBoard()
    {
        Vector3 widthLine = Vector3.right * 8;
        Vector3 heightLine = Vector3.forward * 8;

        // Draw horizontal and vertical lines
        for(int i = 0; i <= 8; i++)
        {
            Vector3 start = Vector3.forward * i;
            Debug.DrawLine(start,start + widthLine);
            for(int j = 0; j <= 8; j++)
            {
                start = Vector3.right * j;
                Debug.DrawLine(start, start + heightLine);
            }
        }

        // Draw Selection
        if (selectionX >= 0 && selectionY >= 0)
        {
            Debug.DrawLine(
                Vector3.forward * selectionY + Vector3.right * selectionX,
                Vector3.forward * (selectionY + 1) + Vector3.right * (selectionX + 1));

            Debug.DrawLine(
                Vector3.forward * (selectionY + 1) + Vector3.right * selectionX,
                Vector3.forward * selectionY + Vector3.right * (selectionX + 1));
        }
    }
}
