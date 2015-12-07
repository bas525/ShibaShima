﻿using UnityEngine;
using System.Collections;

public class Timer : MonoBehaviour {

    [Header("Timer")]
	public int timer;
	
	[Header("Players")]
	public Player_1 player1;
	public Player_2 player2;
	public bool sniff1;
	public bool sniff2;
	
	[Header("Camera Control")]
	public GameObject CamTime;
	public GameObject Cam1;
	public GameObject Cam2;
	private bool camSet = false;
	
	[Header("Power Control")]
	public GameObject speed;
	public GameObject bark;
	public float respawnS;
	public float respawnB;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {		
		sniff1 = player1.sniffed;
		sniff2 = player2.sniffed;
		if(!camSet) {
			CamTime.SetActive(false); Cam1.SetActive(false); Cam2.SetActive(false);
			Cam1.SetActive(true); Cam2.SetActive(true); CamTime.SetActive(true);
		}
	    timer = 150 - (int) Time.time;
		if(timer < 0) {
			timer = 0;
		}
		string textBuffer = timer.ToString();
		if(timer < 100) {
			textBuffer = "0" + textBuffer;
		}
		if(timer < 10) {
			textBuffer = "00" + textBuffer;
		}
		GetComponent<TextMesh>().text = textBuffer;
		
		if(!speed.activeSelf && respawnS == 0) {
			respawnS = Time.time + 20;
		}
		if(!bark.activeSelf && respawnB == 0) {
			respawnB = Time.time + 20;
		}
		if(Time.time > respawnS && !speed.activeSelf) {
			speed.SetActive(true);
			respawnS = 0;
		}
		if(Time.time > respawnB && !bark.activeSelf) {
			bark.SetActive(true);
			respawnB = 0;
		}
	}
}
