﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waveMovement : MonoBehaviour 
{
	private Rigidbody2D rb;
	public float speed;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () 
	{
        transform.Translate(Vector2.right * speed * Time.deltaTime);

	}
}
