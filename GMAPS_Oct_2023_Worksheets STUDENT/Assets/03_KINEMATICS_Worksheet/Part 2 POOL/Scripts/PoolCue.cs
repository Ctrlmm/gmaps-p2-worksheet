using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolCue : MonoBehaviour
{
    public LineFactory lineFactory;
    public GameObject ballObject;

    private Line drawnLine;
    private Ball2D ball;

    private void Start()
    {
        ball = ballObject.GetComponent<Ball2D>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var startLinePos = Camera.main.ScreenToWorldPoint(Input.mousePosition); // Start line drawing
            if (ball != null && ball.IsCollidingWith(startLinePos.x, startLinePos.y))
            {
                drawnLine = lineFactory.GetLine(startLinePos, startLinePos, 0.1f, Color.blue); // Example width and color
                drawnLine.EnableDrawing(true); // Enable line drawing
            }
        }
        else if (Input.GetMouseButton(0) && drawnLine != null)
        {
            Vector2 endLinePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            drawnLine.end = endLinePos; // Set the end position of the line
        }
        else if (Input.GetMouseButtonUp(0) && drawnLine != null)
        {
            drawnLine.EnableDrawing(false);

            // Update the velocity of the white ball.
            if (ball != null)
            {
                HVector2D v = new HVector2D(drawnLine.end.x - drawnLine.start.x, drawnLine.end.y - drawnLine.start.y);
                ball.Velocity = v;
            }

            drawnLine = null; // End line drawing            
        }
    }

    /// <summary>
    /// Get a list of active lines and deactivate them.
    /// </summary>
    public void Clear()
    {
        var activeLines = lineFactory.GetActive();

        foreach (var line in activeLines)
        {
            line.gameObject.SetActive(false);
        }
    }
}