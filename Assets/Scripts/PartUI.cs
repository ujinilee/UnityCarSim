using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PartUI : MonoBehaviour
{
    Text part_text;

    // Start is called before the first frame update
    void Start()
    {
        part_text = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {

        part_text.text = FindObjectOfType<MoveRed>().part.ToString();
    }
}
