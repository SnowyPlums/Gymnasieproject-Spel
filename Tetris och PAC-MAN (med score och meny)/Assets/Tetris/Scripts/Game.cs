using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Game : MonoBehaviour {


    public static int gridWidth = 10;
    public static int gridHeight = 20;

    public static Transform[,] grid = new Transform[gridWidth, gridHeight];

    public int scoreOneLine = 40;
    public int scoreTwoLine = 100;
    public int scoreThreeLine = 300;
    public int scoreFourLine = 1000;

    public Text hud_score;

    private int numberOfRowsThisTurn = 0;

    private int currentScore = 0;

    private GameObject previewTetromino;
    private GameObject nextTetromino;

    private bool gameStarted = false;

    private Vector2 previewTetrominoPosition = new Vector2(-6.5F, 15);

	// Use this for initialization
	void Start () {

        SpawnNextTetromino();
	}

    private void Update ()
    {
        UpdateScore();

        updateUI();
    }

    public void updateUI ()
    {
        hud_score.text = currentScore.ToString();
    }

    public void UpdateScore ()
    {
        if (numberOfRowsThisTurn > 0)
        {
            if (numberOfRowsThisTurn == 1)
            {
                ClearOneLine();
            }
            else if (numberOfRowsThisTurn == 2)
            {
                ClearTwoLine();
            }
            else if (numberOfRowsThisTurn == 3)
            {
                ClearThreeLine();
            }
            else if (numberOfRowsThisTurn == 4)
            {
                ClearFourLine();
            }

            numberOfRowsThisTurn = 0;
        }
    }

    public void ClearOneLine ()
    {
        currentScore += scoreOneLine;
    }

    public void ClearTwoLine ()
    {
        currentScore += scoreTwoLine;
    }

    public void ClearThreeLine ()
    {
        currentScore += scoreThreeLine;
    }

    public void ClearFourLine ()
    {
        currentScore += scoreFourLine;
    }

    public bool CheckIsAboveGrid (Tetromino tetromino)
    {
        for (int i = 0; i < gridWidth; i++)
        {
            foreach (Transform mino in tetromino.transform)
            {
                Vector2 pos = Round(mino.position);

                if (pos.y > gridHeight - 1)
                {
                    return true;
                }
            }
        }
        return false;
    }

    public bool IsFullRowAt (int y)
    {
        for (int x = 0; x < gridWidth; x++)
        {
            if (grid[x, y] == null)
            {
                return false;
            }
        }

        numberOfRowsThisTurn++;

        return true;
    }

    public void DeleteMinoAt (int y)
    {
        for (int x = 0; x < gridWidth; x++)
        {
            Destroy(grid[x, y].gameObject);

            grid[x, y] = null;
        }
        numberOfRowsThisTurn++;
    }

    public void MoveRowDown (int y)
    {
        for (int x = 0; x < gridWidth; x++)
        {
            if (grid[x, y] != null)
            {
                grid[x, y - 1] = grid[x, y];

                grid[x, y] = null;

                grid[x, y - 1].position += new Vector3(0, -1, 0);
            }
        }
    }

    public void MoveAllRowDown (int y)
    {
        for (int i = y; i < gridHeight; i++)
        {
            MoveRowDown(i);
        }
    }

    public void DeleteRow ()
    {
        for (int y = 0; y < gridHeight; y++)
        {
            if (IsFullRowAt(y))
            {
                DeleteMinoAt(y);

                MoveAllRowDown(y + 1);

                --y;
            }
        }
    }
	
    public void UpdateGrid (Tetromino tetromino)
    {
        for (int y = 0; y < gridHeight; y++)
        {
            for (int x = 0; x < gridWidth; x++)
            {
                if (grid[x,y] != null)
                {
                    if (grid[x,y].parent == tetromino.transform)
                    {
                        grid[x,y] = null;
                    }
                }
            }
        }

        foreach (Transform mino in tetromino.transform)
        {
            Vector2 pos = Round(mino.position);

            if (pos.y < gridHeight)
            {
                grid[(int)pos.x, (int)pos.y] = mino;
            }
        }
    }

    public void SpawnNextTetromino ()
    {
        if (!gameStarted)
        {
            gameStarted = true;

            nextTetromino = (GameObject)Instantiate(Resources.Load(GetRandomTetromino(), typeof(GameObject)), new Vector2(5.0f, 20.0f), Quaternion.identity);
            previewTetromino = (GameObject)Instantiate(Resources.Load(GetRandomTetromino(), typeof(GameObject)), previewTetrominoPosition, Quaternion.identity);
            previewTetromino.GetComponent<Tetromino>().enabled = false;
        }
        else
        {
            previewTetromino.transform.localPosition = new Vector2(5.0F, 20.0F);
            nextTetromino = previewTetromino;
            nextTetromino.GetComponent<Tetromino>().enabled = true;

            previewTetromino = (GameObject)Instantiate(Resources.Load(GetRandomTetromino(), typeof(GameObject)), previewTetrominoPosition, Quaternion.identity);
            previewTetromino.GetComponent<Tetromino>().enabled = false;
        }
    }

    public bool CheckIsInsideGrid (Vector2 pos)
    {
        return ((int)pos.x >= 0 && (int)pos.x < gridWidth && (int)pos.y >= 0);
    }

    public Vector2 Round (Vector2 pos)
    {
        return new Vector2(Mathf.Round(pos.x), Mathf.Round(pos.y));
    }

    public Transform GetTransformAtGridPosition(Vector2 pos)
    {
        if (pos.y > gridHeight - 1)
        {
            return null;
        }
        else
        {
            return grid[(int)pos.x, (int)pos.y];
        }
    }

    string GetRandomTetromino ()
    {
        int randomTetromino = Random.Range(1, 8);

        string randomTetrominoName = "Prefabs/Tetromino_T";

        switch (randomTetromino)
        {
            case 1:
                randomTetrominoName = "Prefabs/Tetromino_T";
                break;
            case 2:
                randomTetrominoName = "Prefabs/Tetromino_Long";
                break;
            case 3:
                randomTetrominoName = "Prefabs/Tetromino_Square";
                break;
            case 4:
                randomTetrominoName = "Prefabs/Tetromino_J";
                break;
            case 5:
                randomTetrominoName = "Prefabs/Tetromino_L";
                break;
            case 6:
                randomTetrominoName = "Prefabs/Tetromino_S";
                break;
            case 7:
                randomTetrominoName = "Prefabs/Tetromino_Z";
                break;
        }

        return randomTetrominoName;
    }

    public void GameOver ()
    {
        SceneManager.LoadScene("GameOver");
    }
}
