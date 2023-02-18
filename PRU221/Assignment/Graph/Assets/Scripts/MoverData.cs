using System;
using UnityEngine;

[Serializable]
public class MoverData
{
    public string Type;
    public int Power;
    public Vector3 Position;
    public Vector3 Destination;

    public override string ToString()
    {
        return Position + " " + Destination;
    }
}