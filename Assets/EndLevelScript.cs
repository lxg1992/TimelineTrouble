using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class EndLevelScript : MonoBehaviour {

    GameObject[] gameMusic;

    void Start()
    {
        gameMusic = GameObject.FindGameObjectsWithTag("Music");
    }

        // Use this for initialization
        void OnTriggerEnter2D(Collider2D other)
	{
		if(other.gameObject.CompareTag("Player"))
		{
			if (SceneManager.GetActiveScene().buildIndex == (SceneManager.sceneCountInBuildSettings - 1)) {
                Destroy(gameMusic[0]);
                SceneManager.LoadScene (0);
			} else {
                Destroy(gameMusic[0]);
                SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex + 1);
				Debug.Log ("End activated");
			}
		}
	}
}
