using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coords : MonoBehaviour
{
    [SerializeField] private float x;
    [SerializeField] private float y;
    [SerializeField] private float z;


    //constructor
    public Coords(float x, float y)
    {
        this.x = x;
        this.y = y;
        z = -1;
    }

    public override string ToString()
    {
        return "(" + x + ", " + y + ", " + z + ")";
    }

    public static void DrawPoint(Coords position, float width, Color color)
    {
        //use coordinates to make new object
        GameObject line = new GameObject("Point_" + position.ToString());
        //set object visuals
        LineRenderer lRenderer = line.AddComponent<LineRenderer>();
        lRenderer.material = new Material(Shader.Find("Unlit/Color"));
        lRenderer.material.color = color;
        lRenderer.positionCount = 2;
        //set starting and ending position/width
        lRenderer.SetPosition(0, new Vector3(position.x - width / 3f, position.y - width / 3f, position.z));
        lRenderer.SetPosition(1, new Vector3(position.x + width / 3f, position.y + width / 3f, position.z));
        lRenderer.startWidth = width;
        lRenderer.endWidth = width;
    }

    public static void DrawLine(Coords start, Coords end, float width, Color color)
    {
        //use coordinates to make new object
        GameObject line = new GameObject("Line_" + start.ToString() + "_" + end.ToString());
        //set object visuals
        LineRenderer lRenderer = line.AddComponent<LineRenderer>();
        lRenderer.material = new Material(Shader.Find("Unlit/Color"));
        lRenderer.material.color = color;
        lRenderer.positionCount = 2;
        //set starting and ending position/width
        lRenderer.SetPosition(0, new Vector3(start.x, start.y, start.z));
        lRenderer.SetPosition(1, new Vector3(end.x, end.y, end.z));
        lRenderer.startWidth = width;
        lRenderer.endWidth = width;
    }

    public static void DrawGraph(int space, float lineWidth)
    {
        //x and y origin lines
        Coords[] yCoords = { new Coords(0, 100), new Coords(0, -100) };
        Coords[] xCoords = { new Coords(160, 0), new Coords(-160, 0) };

        //color coords are stored with (r,g,b) values;
        //(1,1,0) would be a graph with red and green channels turned on
        //y (0,1,0)
        DrawLine(yCoords[0], yCoords[1], lineWidth, Color.green);
        //x (1,0,0)
        DrawLine(xCoords[0],xCoords[1], lineWidth, Color.red);

        //draw horizontal lines
        for(int i = 0; i <= xCoords[0].x + space; i += space)
        {
            if(i <= xCoords[0].x)
            {
                DrawLine(new Coords(i, yCoords[0].y), new Coords(i, yCoords[1].y), lineWidth, Color.white);
                DrawLine(new Coords(-i, yCoords[0].y), new Coords(-i, yCoords[1].y), lineWidth, Color.white);
            }

        }
        //draw vertical lines
        for(int i = 0; i <= yCoords[0].y + space; i += space)
        {
            if(i <= yCoords[0].y)
            {
                DrawLine(new Coords(xCoords[0].x, i), new Coords(xCoords[1].x, i), lineWidth, Color.white);
                DrawLine(new Coords(xCoords[0].x, -i), new Coords(xCoords[1].x, -i), lineWidth, Color.white);
            }

        }
    }
}
