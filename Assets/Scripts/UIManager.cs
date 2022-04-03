using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Diagnostics;

public class UIManager : MonoBehaviour
{
    Text time_text;
    Stopwatch watch = new Stopwatch();

    // Start is called before the first frame update
    void Start()
    {
        time_text = GetComponent<Text>();
        watch.Start();
    }

    // Update is called once per frame
    void Update()
    {
        time_text.text = watch.Elapsed.ToString();

        if (FindObjectOfType<MoveRed>().i >= 1)
        {
            watch.Stop();
        }
    }
}
