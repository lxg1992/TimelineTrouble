using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finishline : MonoBehaviour {

    private Animator timeMachineAnimator;
    public GameObject smoke;

	// Use this for initialization
	void Start () {
        timeMachineAnimator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D target)
    {
        
        if (target.gameObject.tag == "Player")
        {
            Invoke("Smoke", 0.66f);

        }
    }

    public void PrepareSmoke()
    {
        Debug.Log("Butts");
        timeMachineAnimator.SetBool("PlayerTouch0", true);
        Invoke("Smoke", 0.66f);
    }

    void Smoke()
    {
        Instantiate(smoke, this.transform.position, this.transform.rotation);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
