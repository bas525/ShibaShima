using UnityEngine;
using System.Collections;


public class Player_2 : MonoBehaviour {
	
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
		
		if (Input.GetKey (KeyCode.LeftArrow))
		{
			transform.RotateAround(transform.position, transform.up, -5*rotateSpeed*frozen);
		}
		if (Input.GetKey (KeyCode.RightArrow))
		{
			transform.RotateAround(transform.position, transform.up, 5*rotateSpeed*frozen);
		}
		if (Input.GetKey (KeyCode.L))
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
			if(SpeedDown) {
				SpeedDown = false;
				SparkDown.SetActive(false);
			}
			else{
				SpeedBoost = true;
				speedEnd = speedTime + Time.time;
				SparkUp.SetActive(true);
			}
			col.gameObject.SetActive(false);
			
		}
		if (col.tag == "SpeedDown" && !SpeedDown) 
		{
			if(SpeedBoost) {
				SpeedBoost = false;
				SparkUp.SetActive(false);
			}
			else {
				SpeedDown = true;
				speedEnd =  Time.time +5;
				SparkDown.SetActive(true);
			}
			col.gameObject.SetActive(false);
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
				rb.AddForce(transform.up * jumpStrength * frozen, ForceMode.VelocityChange);
			}
		}
		
		if (Input.GetKey(KeyCode.UpArrow))
		{
			if (grounded) {
				rb.AddForce(transform.forward * moveSpeed * frozen);
			}
			else {
				rb.AddForce(transform.forward * moveSpeed * airSpeed*frozen);
			}
		}
		
		if (Input.GetKey(KeyCode.DownArrow))
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

