using UnityEngine;
using System.Collections;

public class Player_1 : MonoBehaviour {

	private Rigidbody rb;
	
	[Header("Movement")]
	public float moveSpeed;
	public float reverseSpeed;
	public float jumpStrength;
	public float rotateSpeed;
	public bool grounded = false;
	
	[Header("Health")]
	public int health;
	
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.A))
			{
				transform.RotateAround(transform.position, transform.up, -5*rotateSpeed);
			}
		if (Input.GetKey (KeyCode.D))
			{
				transform.RotateAround(transform.position, transform.up, 5*rotateSpeed);
			}
	}
	
	void OnCollisionStay(Collision col)
	{
		if (col.collider.tag == "Ground")
		{
			rb.drag = 1;
			grounded = true;
		}
	}

	void OnCollisionExit(Collision col)
	{
		if (col.collider.tag == "Ground")
		{
			rb.drag = 0;
			grounded = false;
		}
	}
	
	//FixedUpdate is called once per physics step
	void FixedUpdate()
	{

		if (Input.GetKeyDown(KeyCode.Space))
		{
			if (grounded)
			{
				rb.AddForce(transform.up * jumpStrength, ForceMode.VelocityChange);
			}
		}

		if (Input.GetKey(KeyCode.W) && grounded)
		{
			rb.AddForce(transform.forward * moveSpeed);
		}
		
		if (Input.GetKey(KeyCode.S) && grounded)
		{
			//moves the dog backwards
			rb.AddForce(-transform.forward * reverseSpeed);
		}
	}
}
