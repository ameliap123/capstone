using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class SoilData : ScriptableObject
{
    public Sprite sprite;
    public int amount;
}

public class WaterData : ScriptableObject
{
    public Sprite waterSprite;
    public int amount;
}