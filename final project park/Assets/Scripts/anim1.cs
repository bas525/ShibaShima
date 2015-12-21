using UnityEngine;
using System.Collections;

public class anim1 : MonoBehaviour {

	public Animator anim;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S))
		{
			anim.SetBool("RunAnimation", true);
		} else {
			anim.SetBool("RunAnimation", false);
		}
	}
}
