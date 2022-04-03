using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CrashUI : MonoBehaviour
{
    Text crash_text;

    // Start is called before the first frame update
    void Start()
    {
        crash_text = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (FindObjectOfType<MoveRed>().i >= 1)
        {
            crash_text.text = "O";
        }
    }
}
