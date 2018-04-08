using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Explode : MonoBehaviour {

    public AudioClip swordSwing1;

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }

    private void OnTriggerEnter2D(Collider2D target)
    {
        if (target.gameObject.tag == "Deadly")
        {
            OnExplode();
			SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);

        }
    }

    void OnExplode()
    {
        Destroy(gameObject);
    }

}
