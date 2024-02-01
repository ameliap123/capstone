using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu]
public class plantData : ScriptableObject
{
    public TileBase[] tiles;
    public int nitrogen, water;
}
