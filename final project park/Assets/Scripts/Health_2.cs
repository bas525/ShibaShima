using UnityEngine;
using System.Collections;

public class Health_2 : MonoBehaviour {

	int value;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnCollisionEnter(Collision col)
	{
		
		if(col.collider.tag == "Nose")
		{
			//test hit
			Debug.Log("VIOLATED!!!!!");
		}
	}
}
