using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UserControlUI : MonoBehaviour
{
    
    Text text_state;
    public Button Btn;
    //ColorBlock BtnColors = 
    int clickNum = 0; //사용자가 버튼 클릭하는 수

    public void ButtonClickOn()
    {
        clickNum+=1;

        if (clickNum % 2 == 1)
        {
            print("ON");
            //text_state.text = "ON";//ON텍스트 출력
            FindObjectOfType<SimpleCarController>().enabled = true; //사용자가 조작 가능한 스크립트를 찾은뒤 ON
            Btn.interactable = true;

            ColorBlock colors = Btn.colors;
            colors.selectedColor = Color.red;
            Btn.colors = colors;

            //BtnColors.selectedColor= new Color(1f, 0f, 0f, 1f);
            //Btn.colors = BtnColors;

            //BtnColors.normalColor = new Color(1f, 0f, 0f, 1f); ;


        }
        else
        {
            print("OFF");
            //BtnColors.selectedColor = Color.blue;
            // text_state.text = "OFF";//OFF텍스트 출력
            //Btn.interactable = false;
            //button.colors = Color.white;//버튼 색 바뀜

            FindObjectOfType<SimpleCarController>().enabled = false;

            ColorBlock colors = Btn.colors;
            colors.selectedColor = Color.white;
            Btn.colors = colors; //버튼색 변경

            //gameObject.GetComponent<SimpleCarController>().enabled = false; //사용자가 조작 가능한 스크립트 OFF




        }
        

    }


}
