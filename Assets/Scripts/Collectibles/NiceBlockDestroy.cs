using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NiceBlockDestroy : MonoBehaviour {
     
    public Debris debris;
    public int totalDebris = 2;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D target)
    {
        if (target.gameObject.tag == "Player")
        {
            OnExplode();
        }
    }

    void OnExplode()
    {
        var t = transform;
        for (int i = 0; i < totalDebris; i++)
        {
            t.TransformPoint(0, -100, 0);
            var clone = Instantiate(debris, t.position, Quaternion.identity) as Debris;
            var body2D = clone.GetComponent<Rigidbody2D>();
            body2D.AddForce(Vector3.right * Random.Range(-1000, 1000));
            body2D.AddForce(Vector3.up * Random.Range(-500, 2000));

        }

        Destroy(gameObject);
    }
}
