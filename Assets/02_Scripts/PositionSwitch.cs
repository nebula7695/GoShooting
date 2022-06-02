using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionSwitch : MonoBehaviour
{
    [SerializeField]
    Transform target;
    [SerializeField]
    float scrollSize=9.9f;
    void Update()
    {
        if (transform.position.y <= -scrollSize)
        {
            transform.position = target.transform.position + Vector3.up * scrollSize;
        }
    }
}
