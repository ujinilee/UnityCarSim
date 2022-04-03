using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;
using System.IO;

public class Card
{
    public int CardID;
    public string CardName;
    public string CardDis;
    public int CardMana;

    public Card(int id, int mana, string dis, string name)
    {
        CardID = id;
        CardMana = mana;
        CardDis = dis;
        CardName = name;

    }
}
public class JsonTest01 : MonoBehaviour
{
    public List<Card> CardList = new List<Card>();

    // Start is called before the first frame update
    void Start()
    {
        CardList.Add(new Card(0, 1, "Test", "TestCard"));
    }

    public void SaveCard()
    {
        JsonData CardJson = JsonMapper.ToJson(CardList);
        File.WriteAllText(Application.dataPath + "/Resources/CarData.json", CardJson.ToString());
    }

    public void LoadCard()
    {
        string json = File.ReadAllText(Application.dataPath + "/Resources/CarData.json");
        JsonData CardData = JsonMapper.ToObject(json);

        for(int j = 0; j < CardData.Count; j++)
        {
            Debug.Log(CardData[j]["CardID"].ToString() + "," + CardData[j]["CardMana"].ToString() + "," + CardData[j]["CardDis"].ToString());
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
