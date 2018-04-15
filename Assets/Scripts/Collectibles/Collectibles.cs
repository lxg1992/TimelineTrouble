using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectibles : MonoBehaviour {

    private bool touch = false;
    private Animator animController;
    private AudioSource collectSFX;

	// Use this for initialization
	void Start () {
        collectSFX = GetComponent<AudioSource>();
        animController = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        if (touch && collectSFX.isPlaying == false)
        {
            Destroy(gameObject);
        }
	}

    private void OnTriggerEnter2D(Collider2D target)
    {
        if (target.gameObject.tag == "Player" && !touch)
        {
            touch = true;
            animController.SetBool("collected", touch);
            collectSFX.Play();
            
        }
    }

}
