using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScanDataDrawing : MonoBehaviour
{
    public GameObject spherePrefab; //spherePrefab을 받을 변수 
    private float distance; //distance정보를 저장할 변수
    private float[] angle; //angle정보를 저장할 배열 변수
    private const int DATA_LENGTH = 360; //360개의 데이터의 개수를 상수로 설정
    private int drawingIndex; //DATA_LENGTH만큼 Update문을 수행하기 위한 변수 설정

    void Start()
    {
        distance = 3.0f; //거리는 3.0f로 설정한다.
        angle = new float[DATA_LENGTH]; //데이타 개수만큼 배열 형성
        drawingIndex = 0; //0으로 초기화

        SaveAngleData(); // 게임 시작 시, SaveAngleData를 실행하여 angle배열 변수에 1~360까지의 데이타를 저장.
    }
    void Update()
    {
        //DATA_LENGTH크기만큼 drawingIndex변수를 통해 해당 로직을 수행한다. DATA_LENGTH는 360이라는 값이므로 360번만 로직을 수행하게 됩니다.
        if (drawingIndex < DATA_LENGTH)
        {
            transform.rotation = Quaternion.Euler(0.0f, angle[drawingIndex], 0.0f); //angle[drawingIndex]에 담겨있는 데이타를 통해 회전을 수행한다.
            //게임 오브젝트를 생성하는 Instantiate함수. 
            //spherePrefab을 생성하고 윗 줄에서 회전을 한 상태의 forward방향 즉, 바라보는 방향으로 * distance만큼 떨어진 위치에 생성을 시킵니다.
            //Quaternion.identity는 기존spherePrefab의 회전 디폴트 값을 받는다는 코드입니다. 즉, 최초에 spherePrefab을 생성할 때 해당 오브젝트를 회전 시킨 상태가 아니라면
            //Quaternion.identity는 0,0,0이 됩니다.
            Instantiate(spherePrefab, transform.forward * distance, Quaternion.identity);
            drawingIndex++; //drawingIndex값을 1씩 증가시켜 DATA_LENGTH와 비교를 하게 됩니다.
        }
    }
    //angle배열 변수에 1~360까지 데이타를 저장.
    public void SaveAngleData()
    {
        for (int i = 0; i < DATA_LENGTH; i++)
        {
            angle[i] = i + 1; //i+1로 설정하여 1부터 360까지의 데이타를 저장한다.
        }
    }

}
