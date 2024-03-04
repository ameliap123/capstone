using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class GameData
{
    public Vector3 playerPosition;
    public Dictionary<string, bool> itemsCollected;
    public Dictionary<string, bool> dirtCollected;
    public Dictionary<string, bool> waterCollected;

    //values defined here will be default values
    //the game starts with then there is no data to load

    public GameData()
    {
        playerPosition = Vector3.zero;
        itemsCollected = new Dictionary<string, bool>();
        dirtCollected = new Dictionary<string, bool>();
        waterCollected = new Dictionary<string, bool>();
    }
}