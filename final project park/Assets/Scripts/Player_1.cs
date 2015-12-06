using UnityEngine;
using System.Collections;

public class Player_1 : MonoBehaviour {

	private Rigidbody rb;
	
	[Header("Movement")]
	public float moveSpeed;
	public float airSpeed;
	public float reverseSpeed;
	public float slideX;
	public float slideY;
	public float slideZ;
	public float jumpStrength;
	public float rotateSpeed;
	public float setDrag;
	public bool grounded = false;
	
	[Header("Health")]
	public int health;
	
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
		slideX = rb.velocity.x;
		slideY = rb.velocity.y;
		slideZ = rb.velocity.z;
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

		if (Input.GetKeyDown(KeyCode.Space))
		{
			if (grounded)
			{
				rb.AddForce(transform.up * jumpStrength, ForceMode.VelocityChange);
			}
		}

		if (Input.GetKey(KeyCode.W))
		{
			if (grounded) {
				rb.AddForce(transform.forward * moveSpeed);
			}
			else {
				rb.AddForce(transform.forward * moveSpeed * airSpeed);
			
		}
		
		if (Input.GetKey(KeyCode.S))
		{
			//moves the dog backwards
			if (grounded) {
				rb.AddForce(-transform.forward * reverseSpeed);
			}
		}
	}
}
