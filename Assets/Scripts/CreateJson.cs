using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

[System.Serializable]
public class CarData
{
    //public int m_nLevel;
    //public bool sign = FindObjectOfType<SimpleCarController>().stop;
    public bool sign;
    public bool collision;
    public Vector3 cur_position;
    //public Vector3 m_vecPositon;

    public void printData()
    {
        Debug.Log("정지신호 : " + sign);
        Debug.Log("충돌여부 : " + collision);
        Debug.Log("Position : " + cur_position);
    }
}

public class CreateJson : MonoBehaviour
{
    // Start is called before the first frame update 
    void Start()
    {
        CarData data = new CarData();
        data.sign = FindObjectOfType<SimpleCarController>().stop; //정지신호 

        if (FindObjectOfType<MoveRed>().i >= 1)
        {
            data.collision = true; //충돌여부 
        }
        else
        {
            data.collision = false;
        }
        //data.collision = new Vector3(3.4f, 5.6f, 7.8f);
        //data.cur_position=

        data.cur_position = FindObjectOfType<CalSpeed>().cur_pos; //처음 시작 위치 값

        string str = JsonUtility.ToJson(data);

        Debug.Log("ToJson : " + str);

        CarData data2 = JsonUtility.FromJson<CarData>(str);
        data2.printData();

        // file save 

        CarData data3 = new CarData();
        data3.sign = FindObjectOfType<SimpleCarController>().stop; //정지신호 

        if (FindObjectOfType<MoveRed>().i >= 1)
        {
            data3.collision = true; //충돌여부 
        }
        else
        {
            data3.collision = false;
        }
        data3.cur_position = FindObjectOfType<CalSpeed>().cur_pos;


        File.WriteAllText(Application.dataPath + "/CarJson.json", JsonUtility.ToJson(data3));
    }

    // Update is called once per frame 
    void Update()
    {

    }
}