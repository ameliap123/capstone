using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPosition : MonoBehaviour, IDataPersistence
{

    public Transform Player;
    // Start is called before the first frame update
    void Start()
    {
        float x = PlayerPrefs.GetFloat("PPX");
        float y = PlayerPrefs.GetFloat("PPY");
        //float z = PlayerPrefs.GetFloat("PPZ");
        //removed z for a moment, seeing if this changes anything
        Player.position = new Vector3(x, y);
    }

    public void LoadData(GameData data)
    {
        this.transform.position = data.playerPosition;
    }

    public void SaveData(ref GameData data)
    {
        data.playerPosition = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        PlayerPrefs.SetFloat("PPX", Player.position.x);
        PlayerPrefs.SetFloat("PPY", Player.position.y);
        //PlayerPrefs.SetFloat("PPZ", Player.position.z);
    }
}
