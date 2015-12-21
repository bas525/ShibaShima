using UnityEngine;
using System.Collections;

public class anim2 : MonoBehaviour {

	public Animator anim;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow))
		{
			anim.SetBool("isWalking",true);
		} else {
			anim.SetBool("isWalking", false);
		}
	}
}
