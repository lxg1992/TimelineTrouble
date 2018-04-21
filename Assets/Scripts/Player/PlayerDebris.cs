using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDebris : MonoBehaviour {

    private SpriteRenderer renderer2D;
    private Color start;
    private Color end;
    private float t = 0f;


    // Use this for initialization
    void Start()
    {
        renderer2D = GetComponent<SpriteRenderer>();
        start = renderer2D.color;
        end = new Color(start.r, start.g, start.g, 0f);

    }

    // Update is called once per frame
    void Update()
    {
        t += Time.deltaTime;
        renderer2D.material.color = Color.Lerp(start, end, t / 2);

        if (renderer2D.material.color.a <= 0f)
        {
            Destroy(gameObject);
        }
    }


}
