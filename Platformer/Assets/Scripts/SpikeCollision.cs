using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeCollision : MonoBehaviour
{

	// Use this for initialization
	void Start ()
    {
        Debug.Log("dududu");	
	}

    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("DED");
        Destroy(collision.gameObject);
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}
