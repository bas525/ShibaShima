using UnityEngine;
using System.Collections;

public class Player_1 : MonoBehaviour {

	private Rigidbody rb;
	
	[Header("Movement")]
	public float Speed;
	private float moveSpeed;
	public float airSpeed;
	public float reverseSpeed;
	public float jumpStrength;
	public float rotateSpeed;
	public float setDrag;
	private float frozen = 1;
	private bool grounded = false;
	
	[Header("PowerUps")]
	private bool SpeedBoost = false;
	private bool SpeedDown = false;
	public float speedTime;
	public float speedEnd;
	private bool haveBark = false;
	private float barkEnd;
	private bool usedBark;
	private bool haveFart = false;
	private float fartEnd;
	private bool usedFart;
	public GameObject bark;
	public GameObject fart;
	private bool stunned;
	private float freezeEnd;
	public GameObject SparkUp;
	public GameObject SparkDown;
	
	[Header("Sniffed")]
	public Butt butt;
	public bool sniffed;
	
	
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		if(Time.time > barkEnd && usedBark) {
			usedBark = false;
			bark.SetActive(false);
		}
		if(Time.time > fartEnd && usedFart) {
			usedFart = false;
			bark.SetActive(false);
		
		}
		if(Time.time > freezeEnd && stunned) {
			stunned = false;
			frozen = 1;
		}

		if (Time.time > speedEnd && SpeedBoost) {
			SpeedBoost = false;
			SparkUp.SetActive(false);
		}

		if (Time.time > speedEnd && SpeedDown) {
			SpeedDown = false;
			SparkDown.SetActive(false);
		}
		 
		if (Input.GetKey (KeyCode.A))
		{
			transform.RotateAround(transform.position, transform.up, -5*rotateSpeed*frozen);
		}
		if (Input.GetKey (KeyCode.D))
		{
			transform.RotateAround(transform.position, transform.up, 5*rotateSpeed*frozen);
		}
		if (Input.GetKey (KeyCode.C))
		{
			if(haveBark) {
				bark.SetActive(true);
				barkEnd = Time.time + 1;
				usedBark = true;
				haveBark = false;
			}
			if(haveFart) {
				fart.SetActive(true);
				fartEnd = Time.time + 1;
				usedFart = true;
				haveFart = false;
			}
		
		}
		sniffed = butt.sniffed;
		if(sniffed) moveSpeed = Speed * 1.05f;
		else moveSpeed = Speed;
		
		if(SpeedBoost) moveSpeed = moveSpeed*1.1f;

		if (SpeedDown) moveSpeed = moveSpeed * 0.5f;
	}
	
	void OnTriggerEnter(Collider col)
	{
		if(col.tag == "Bark")
		{
			frozen = 0;
			stunned = true;
			freezeEnd = Time.time + 2;
		}
		if(col.tag == "BarkPower")
		{
			haveBark = true;
			col.gameObject.SetActive(false);
		}
		if(col.tag == "FartPower")
		{
			haveFart = true;
			col.gameObject.SetActive(false);
		}
		if(col.tag == "SpeedPower" && !SpeedBoost)
		{
			SpeedBoost = true;
			speedEnd = speedTime + Time.time;
			col.gameObject.SetActive(false);
			SparkUp.SetActive(true);

		}
		if (col.tag == "SpeedDown" && !SpeedDown) 
		{
			SpeedDown = true;
         	speedEnd =  Time.time +5;
			col.gameObject.SetActive(false);
			SparkDown.SetActive(true);
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
				rb.AddForce(transform.up * jumpStrength * frozen, ForceMode.VelocityChange);
			}
		}

		if (Input.GetKey(KeyCode.W))
		{
			if (grounded) {
				rb.AddForce(transform.forward * moveSpeed * frozen);
			}
			else {
				rb.AddForce(transform.forward * moveSpeed * airSpeed*frozen);
			}
		}
		
		if (Input.GetKey(KeyCode.S))
		{
			//moves the dog backwards
			if (grounded) {
				rb.AddForce(-transform.forward * reverseSpeed*frozen);
			}
			else {
				rb.AddForce(-transform.forward * reverseSpeed * airSpeed*frozen);
			}
		}
	}
}
