using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectibles : MonoBehaviour {

    public GameObject globals;
    private ScoreSheet scoreSheet;
    public int scoreValue ;
    private bool touch = false;
    private Animator animController;
    private AudioSource collectSFX;

	// Use this for initialization
	void Start () {
        collectSFX = GetComponent<AudioSource>();
        animController = GetComponent<Animator>();
        scoreSheet = globals.GetComponent<ScoreSheet>();
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
            scoreSheet.AddScore(this.scoreValue);
            Debug.Log("current score is :" + scoreSheet.GetScore());
            touch = true;
            animController.SetBool("collected", touch);
            collectSFX.Play();
            
        }
    }

}
