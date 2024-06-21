using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineDrawer : MonoBehaviour
{
    private LineRenderer lineRenderer;
    private Vector3 startMousePos, endMousePos;
    private EmojiMatchManager matchManager;

    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        matchManager = FindObjectOfType<EmojiMatchManager>();
        lineRenderer.positionCount = 0;
    }


    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            startMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            startMousePos.z = 0;
            lineRenderer.positionCount = 1;
            lineRenderer.SetPosition(0, startMousePos);
        }
        else if (Input.GetMouseButton(0))
        {
            endMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            endMousePos.z = 0;
            lineRenderer.positionCount = 2;
            lineRenderer.SetPosition(1, endMousePos);
        }
        else if (Input.GetMouseButtonUp(0))
        {
            CheckMatch();
            lineRenderer.positionCount = 0;
        }
    }

    void CheckMatch()
    {
        GameObject startEmoji = matchManager.GetEmojiAtPosition(startMousePos);
        GameObject endEmoji = matchManager.GetEmojiAtPosition(endMousePos);

        if (startEmoji != null && endEmoji != null && startEmoji.name == endEmoji.name)
        {
            matchManager.RemoveEmojiAtPosition(startMousePos);
            matchManager.RemoveEmojiAtPosition(endMousePos);
        }
    }
}
