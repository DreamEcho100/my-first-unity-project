using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Transform player;
    private Vector3 tempPos;

    [SerializeField]
    private float minX = -80;

    [SerializeField]
    private float maxX = 80;

    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
    }

    void LateUpdate()
    {
        if (!player || player.position.x < minX || player.position.x > maxX)
            return;

        tempPos = transform.position;
        tempPos.x = player.position.x;
        transform.position = tempPos;
    }
}
