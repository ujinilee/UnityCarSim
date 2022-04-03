using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AgainButton : MonoBehaviour
{
    public Button Btn;

    public void ButtonClickOn()
    {
        Again();
    }

    void Again()
    {
        SceneManager.LoadScene(1); 
    }
}
