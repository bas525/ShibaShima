using UnityEngine;
using System.Collections;

public class Player_2 : MonoBehaviour {

	private Rigidbody rb;
	
	[Header("Movement")]
	public float moveSpeed;
	public float airSpeed;
	public float reverseSpeed;
	public float jumpStrength;
	public float rotateSpeed;
	public float setDrag;
	private bool grounded = false;
	
	[Header("PowerUps")]
	public bool SpeedBoost;
	public int speedTime;
	public bool haveBark;
	public bool haveDash;
	public bool stunned;
	
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.LeftArrow))
			{
				transform.RotateAround(transform.position, transform.up, -5*rotateSpeed);
			}
		if (Input.GetKey (KeyCode.RightArrow))
			{
				transform.RotateAround(transform.position, transform.up, 5*rotateSpeed);
			}
	}
	
	void OnCollisionStay(Collision col)
	{
		if (col.collider.tag == "Ground")
		{
			rb.drag = setDrag;
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

		if (Input.GetKeyDown(KeyCode.M))
		{
			if (grounded)
			{
				rb.AddForce(transform.up * jumpStrength, ForceMode.VelocityChange);
			}
		}

		if (Input.GetKey(KeyCode.UpArrow))
		{
			if (grounded) {
				rb.AddForce(transform.forward * moveSpeed);
			}
			else {
				rb.AddForce(transform.forward * moveSpeed * airSpeed);
			}
		}
		
		if (Input.GetKey(KeyCode.DownArrow))
		{
			//moves the dog backwards
			if (grounded) {
				rb.AddForce(-transform.forward * reverseSpeed);
			}
			else {
				rb.AddForce(-transform.forward * reverseSpeed * airSpeed);
			}
		}
	}
}
