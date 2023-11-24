//using NUnit.Framework.Constraints;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class DrawLine : MonoBehaviour
{
    private Coords point;
    [SerializeField] private float lineWidth = 2;
    [SerializeField] private float pointWidth = 3;
    

    private void Awake()
    {
        point = GetComponent<Coords>();
    }

    private void Start()
    {
        Debug.Log(point.ToString());
        //draw graph
        Coords.DrawGraph(50, 1);

        //CHALLENGE: draw coordinates for your star sign
        Coords[] aries =
        {
            new Coords(0, 0),
            new Coords(-2.5f, 5),
            new Coords(-10, 10),
            new Coords(-30, 15)
        };
        //draw points
        foreach(Coords coord in aries)
        {
            Coords.DrawPoint(coord, pointWidth, Color.yellow);
        }
        //draw lines
        for(int i = 0; i < aries.Length - 1; i++)
        {
            Coords.DrawLine(aries[i], aries[i + 1], lineWidth, Color.yellow);
        }
        //END CHALLENGE
    }
}
