using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookForward : MonoBehaviour
{

    public Transform sightStart, sightEnd;

    public string layer = "Ground";
    public bool needsCollision = true;

    private bool collision;

    // Use this for initialization
    void Start()
    {

    }

    // Provide capability to check for obstacle in advance

    // Update is called once per frame
    void Update()
    {
        collision = Physics2D.Linecast(sightStart.position, sightEnd.position, 1 << LayerMask.NameToLayer("Ground"));

        Debug.DrawLine(sightStart.position, sightEnd.position, Color.green);

        if (collision == needsCollision)
        {
            transform.localScale = new Vector3(transform.localScale.x == 1 ? -1 : 1, 1, 1);
        }
    }
}
