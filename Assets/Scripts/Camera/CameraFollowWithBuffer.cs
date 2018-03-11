using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowWithBuffer : MonoBehaviour
{

    public GameObject player;
    public Transform playerPosition;
    public Transform playerMoveTreshold;

    private PlayerControllerScript playerController;

    private Vector3 originalPlayerMoveThresholdPosition;

    private bool passedThreshold;

    // Use this for initialization
    void Start()
    {
        playerController = player.GetComponent<PlayerControllerScript>();
        originalPlayerMoveThresholdPosition = playerMoveTreshold.position;


    }

    // Update is called once per frame
    void Update()
    {
        if(player == null)
        {
            return;
        }
        if (playerPosition.position.x > playerMoveTreshold.position.x)
        {
            this.transform.position = new Vector3(playerPosition.position.x, this.transform.position.y, this.transform.position.z);
            passedThreshold = true;
        }

        if (passedThreshold && playerPosition.position.x > originalPlayerMoveThresholdPosition.x)
        {
            this.transform.position = new Vector3(playerPosition.position.x, this.transform.position.y, this.transform.position.z);
        }

        if (playerPosition.position.x < originalPlayerMoveThresholdPosition.x)
        {
            passedThreshold = false;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawLine(playerMoveTreshold.position, new Vector2(playerMoveTreshold.position.x, playerMoveTreshold.position.y + 50));
        Gizmos.DrawLine(playerMoveTreshold.position, new Vector2(playerMoveTreshold.position.x, playerMoveTreshold.position.y - 50));

        Gizmos.DrawLine(playerMoveTreshold.position, new Vector2(playerMoveTreshold.position.x, playerMoveTreshold.position.y + 50));
        Gizmos.DrawLine(playerMoveTreshold.position, new Vector2(playerMoveTreshold.position.x, playerMoveTreshold.position.y - 50));
    }
}
