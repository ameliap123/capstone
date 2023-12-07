using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPosition : MonoBehaviour, IDataPersistence
{

    /*public Transform Player;
    // Start is called before the first frame update
    void Start()
    {
        float x = PlayerPrefs.GetFloat("PPX");
        float y = PlayerPrefs.GetFloat("PPY");
        //float z = PlayerPrefs.GetFloat("PPZ");
        //removed z for a moment, seeing if this changes anything
        Player.position = new Vector3(x, y);
    }*/

    //portion pertaining to IDataPersistence
    public void LoadData(GameData data)
    {
        this.transform.position = data.playerPosition;
    }

    public void SaveData(ref GameData data)
    {
        data.playerPosition = this.transform.position;
    }

    // Update is called once per frame
    /*void Update()
    {
        PlayerPrefs.SetFloat("PPX", Player.position.x);
        PlayerPrefs.SetFloat("PPY", Player.position.y);
        //PlayerPrefs.SetFloat("PPZ", Player.position.z);
    }*/

    public float x, y, z;

    void Start()
    {
        
    }

    void Update()
    {

    }

    public void Save()
    {
        x = transform.position.x;
        y = transform.position.y;
        z = transform.position.z;

        PlayerPrefs.SetFloat("x", x);
        PlayerPrefs.SetFloat("y",y);
        PlayerPrefs.SetFloat("z",z);
    }

    public void Load()
    {
        x = PlayerPrefs.GetFloat("x");
        y = PlayerPrefs.GetFloat("y");
        z = PlayerPrefs.GetFloat("z");

        Vector3 LoadPosition = new Vector3(x,y,z);
        transform.position = LoadPosition;
    }
}
