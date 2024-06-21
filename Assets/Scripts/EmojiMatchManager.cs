using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmojiMatchManager : MonoBehaviour
{
    public Sprite[] emojiSprites; // Array of emoji sprites
    public GameObject emojiPrefab; // Prefab for emoji objects
    private GameObject[,] emojiGrid; // 2D array to hold the emoji game objects
    private int gridWidth = 2; // Example grid size
    private int gridHeight = 2;

    void Start()
    {
        InitializeGame();
    }

    void InitializeGame()
    {
        emojiGrid = new GameObject[gridWidth, gridHeight];
        // Initialize and place emojis in the grid
        for (int x = 0; x < gridWidth; x++)
        {
            for (int y = 0; y < gridHeight; y++)
            {
                GameObject newEmoji = Instantiate(emojiPrefab, new Vector2(x, y), Quaternion.identity);
                Sprite emojiSprite = emojiSprites[Random.Range(0, emojiSprites.Length)];
                newEmoji.GetComponent<SpriteRenderer>().sprite = emojiSprite;
                newEmoji.name = emojiSprite.name; // Set the name of the game object to the name of the sprite
                emojiGrid[x, y] = newEmoji;
            }
        }
    }

    public GameObject GetEmojiAtPosition(Vector3 position)
    {
        int x = Mathf.RoundToInt(position.x);
        int y = Mathf.RoundToInt(position.y);

        if (x >= 0 && x < gridWidth && y >= 0 && y < gridHeight)
        {
            return emojiGrid[x, y];
        }
        return null;
    }

    public void RemoveEmojiAtPosition(Vector3 position)
    {
        int x = Mathf.RoundToInt(position.x);
        int y = Mathf.RoundToInt(position.y);

        if (x >= 0 && x < gridWidth && y >= 0 && y < gridHeight)
        {
            Destroy(emojiGrid[x, y]);
            emojiGrid[x, y] = null;
        }
    }
}
