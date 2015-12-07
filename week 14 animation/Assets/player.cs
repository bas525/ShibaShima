using UnityEngine;
using System.Collections;

public class player : MonoBehaviour {

	Animator anim;


	// Use this for initialization
	void Start () {
	
		anim = GetComponent<>
	}
	
	// Update is called once per frame
	void Update () {
		if (Input GetKey(KeyCode.M))
		{
			anim.SetBool("isWalking",true);
		} else {
			anim.SetBool("isWalking", false)
		}
	
	}
}
