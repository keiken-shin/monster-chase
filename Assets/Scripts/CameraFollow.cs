using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Transform player;
    private Vector3 tempPosOfCamera;
    private string PLAYER_TAG = "Player";

    [SerializeField]
    private float minX, maxX;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag(PLAYER_TAG).transform;
    }

    // Late Update is called once per frame after all calculation is done in update
    void LateUpdate()
    {
        if (!player) {
            return;
        }

        tempPosOfCamera = transform.position;   // Get camera position
        tempPosOfCamera.x = player.position.x;  // Set temp position (x) of camera to player position (x)

        // Stop the camera to follow player out of bound
        if (tempPosOfCamera.x < minX) {
            tempPosOfCamera.x = minX;
        }

        if (tempPosOfCamera.x > maxX) {
            tempPosOfCamera.x = maxX;
        }

        transform.position  = tempPosOfCamera;  // Set position of camera to temp position
    }
}
