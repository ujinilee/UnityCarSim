using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereCast2 : MonoBehaviour
{
    // ray의 길이
    [SerializeField]
    private float _maxDistance = 20.0f;

    // ray의 색상
    [SerializeField]
    private Color _rayColor = Color.red;

    void OnDrawGizmos()
    {
        Gizmos.color = _rayColor;
        float sphereScale = Mathf.Max(transform.lossyScale.x, transform.lossyScale.y, transform.lossyScale.z);

        // 함수 파라미터 : 현재 위치, Sphere의 크기(x,y,z 중 가장 큰 값이 크기가 됨), Ray의 방향, RaycastHit 결과, Sphere의 회전값, SphereCast를 진행할 거리
        if (true == Physics.SphereCast(transform.position, sphereScale*2, transform.forward, out RaycastHit hit, _maxDistance))
        {
            // Hit된 지점까지 ray를 그려준다.
            Gizmos.DrawRay(transform.position, transform.forward * hit.distance);

            // Hit된 지점에 Sphere를 그려준다.
            Gizmos.DrawWireSphere(transform.position + transform.forward * hit.distance, sphereScale*2);
        }
        else
        {
            // Hit가 되지 않았으면 최대 검출 거리로 ray를 그려준다.
            Gizmos.DrawRay(transform.position, transform.forward * _maxDistance);
        }
    }
}
