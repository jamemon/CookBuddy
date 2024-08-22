using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class JigsawManager : MonoBehaviour
{
    [Header("Game Elements")]
    [Range(2, 6)]
    [SerializeField] private int diificulty = 4;
    [SerializeField] private Texture2D texture;
    [SerializeField] Transform gameHolder;
    [SerializeField] Transform piecesPrefab;
    [SerializeField] private GameObject winUI;
    [SerializeField] private GameObject LoseUI;
    [SerializeField] private TextMeshProUGUI grade;
    [SerializeField] private TextMeshProUGUI timeLeft;
    [SerializeField] private Clock clock;

    private List<Transform> pieces;
    private Vector2Int dimensions;
    private float width;
    private float height;

    private Transform draggingPiece = null;
    private Vector3 offset;

    private int piecesCorrect = 0;

    private void Start()
    {
        StartGame(texture);
    }
    public void StartGame(Texture2D jigsawTexture)
    {
        pieces = new List<Transform>();

        dimensions = GetDimensions(jigsawTexture,diificulty);

        CreateJigsawPieces(jigsawTexture);

        Scatter();

        UpdateBorder();

        piecesCorrect = 0;
    }

    Vector2Int GetDimensions(Texture2D jigsawTexture, int difficulty)
    {
        Vector2Int dimensions = Vector2Int.zero;

        if (jigsawTexture.width < jigsawTexture.height) {
            dimensions.x = difficulty;
            dimensions.y = (difficulty * jigsawTexture.height) / jigsawTexture.width;
        }
        else
        {
            dimensions.x = (difficulty * jigsawTexture.width) / jigsawTexture.height;
            dimensions.y = difficulty;
        }

        return dimensions;
    }

    void CreateJigsawPieces(Texture2D jigsawTexture)
    {
        height = 1f / dimensions.y;
        float aspect = (float) jigsawTexture.width / jigsawTexture.height;
        width = aspect / dimensions.x;

        for (int row = 0; row < dimensions.y; row++) {
            for (int col = 0; col < dimensions.x; col++) {
                Transform piece = Instantiate(piecesPrefab, gameHolder);
                piece.localPosition = new Vector3(
                    (-width * dimensions.x / 2) + (width * col) + (width / 2),
                    (height * dimensions.y / 2) + (height * row) + (height / 2),
                    -1);
                piece.localScale = new Vector3(width, height, 1f);

                piece.name = $"Piece {(row * dimensions.x) + col}";
                pieces.Add(piece);

                float width1 = 1f / dimensions.x;
                float height1 = 1f / dimensions.y;

                Vector2[] uv = new Vector2[4];
                uv[0] = new Vector2(width1 * col, height1 * row);
                uv[1] = new Vector2(width1 * (col + 1), height1 * row);
                uv[2] = new Vector2(width1 * col, height1 * (row +1));
                uv[3] = new Vector2(width1 * (col + 1), height1 * (row + 1));

                Mesh mesh = piece.GetComponent<MeshFilter>().mesh;
                mesh.uv = uv;

                piece.GetComponent<MeshRenderer>().material.SetTexture("_MainTex", jigsawTexture);
               






            }
        }
    }

    public void Scatter()
    {
        float orthoHeight = Camera.main.orthographicSize;
        float screenAspect = (float)Screen.width / Screen.height;
        float orthoWidth = (screenAspect * orthoHeight);

        float pieceWidth = width * gameHolder.localScale.x;
        float pieceHeight = height * gameHolder.localScale.y;

        orthoHeight -= pieceHeight;
        orthoWidth -= pieceWidth;



        foreach (Transform piece in pieces) 
        {
            float x = Random.Range(-orthoWidth,orthoWidth);
            float y = Random.Range(-orthoHeight,orthoHeight);
            piece.position = new Vector3(x,y,-1);
        }




    }


    public void UpdateBorder()
    {
        LineRenderer lineRenderer = gameHolder.GetComponent<LineRenderer>();

        float halfWidth = (width * dimensions.x) / 2f;
        float halfHeight = (height * dimensions.y) / 2f;

        float borderZ = 0f;

        lineRenderer.SetPosition(0,new Vector3(-halfWidth,halfHeight,borderZ));
        lineRenderer.SetPosition(1,new Vector3(halfWidth,halfHeight,borderZ));
        lineRenderer.SetPosition(2,new Vector3(halfWidth,-halfHeight,borderZ));
        lineRenderer.SetPosition(3,new Vector3(-halfWidth,-halfHeight,borderZ));


        lineRenderer.startWidth = 0.1f;
        lineRenderer.endWidth = 0.1f;

        lineRenderer.enabled = true;

    }

    private void SnapAndDisableIfCorrect()
    {
        int pieceIndex = pieces.IndexOf(draggingPiece);

        int col = pieceIndex % dimensions.x;
        int row = pieceIndex / dimensions.x;

        Vector2 targetPosition = new((-width * dimensions.x / 2) + (width * col) + (width /2),
                                    (-height * dimensions.y / 2) + (height * row) + (height / 2));


        if (Vector2.Distance(draggingPiece.localPosition, targetPosition) < (width / 2)) 
        { 
            draggingPiece.localPosition = targetPosition;

            draggingPiece.GetComponent<BoxCollider2D>().enabled = false;

            piecesCorrect++;
            if (piecesCorrect == pieces.Count) 
            {
                winUI.SetActive(true);
                clock.stopClock(true);
                grade.text = calGrade();
                timeLeft.text = clock.getTimer().ToString();
            }

        }



    }

    string calGrade()
    {
        if (clock.getTimer() >= 20f)
        {
            return "A";
        }
        else if (clock.getTimer() < 20 && clock.getTimer() > 10)
        {
            return "B";
        }
        else if (clock.getTimer() < 10 && clock.getTimer() > 0)
        {
            return "C";
        }
        return "F";
    }






    private void Update()
    {
        if(clock.getTimer() <= 0)
        {
            LoseUI.SetActive(true);
            clock.stopClock(true);
        }
        if (Input.GetMouseButtonDown(0) && !clock.getGameEnd())  
        {
           RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hit)
            {
                draggingPiece = hit.transform;
                offset = draggingPiece.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
                offset += Vector3.back;
            }

        }

        if(draggingPiece && Input.GetMouseButtonUp(0))
        {
            SnapAndDisableIfCorrect();
            draggingPiece.position += Vector3.back;
            draggingPiece = null;
        }


        if (draggingPiece)
        {
            Vector3 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            newPosition += offset;
            draggingPiece.position = newPosition;
        }
    }

}
