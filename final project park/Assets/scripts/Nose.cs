using UnityEngine;
using System.Collections;

public class Nose : MonoBehaviour {

	public Rigidbody rb;
	public GameObject dog;
	public float pushBack;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnTriggerEnter(Collider col)
	{
	    Debug.Log("HIT OCCUR");
		if(col.tag == "Nose")
		{
			Debug.Log("NOSES HIT");
			rb.AddForce(-dog.transform.forward * pushBack);
		}
	}
}
