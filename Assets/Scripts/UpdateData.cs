using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

public class UpdateData
{
    public BallData ballPos;
    public Dictionary<string,PadData> padData=new Dictionary<string, PadData>();
}
public struct PadData
{
    public float xPos;
    public float yPos;
}
public struct BallData
{
    public float xPos;
    public float yPos;
}