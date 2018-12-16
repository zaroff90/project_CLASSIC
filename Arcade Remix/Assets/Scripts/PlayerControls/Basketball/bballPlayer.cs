﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bballPlayer : MonoBehaviour 
{
	public GameObject player;
	public GameObject hoop;
	public float yPos;
	public float ySpeed;
	private float yStart;

	private Animator anim;

	public float throwCounter;
	public float throwCounterLim;

	public bool caught;
	// Use this for initialization
	void Start () 
	{
		yStart = player.GetComponent<Transform>().position.y;
		ySpeed = 2;
		anim = player.GetComponent<Animator>();        
    }
	
	// Update is called once per frame
	void Update () 
	{
		caught = GetComponent<testShot>().touching;
        anim.SetFloat("speed",Mathf.Abs(this.GetComponent<Rigidbody2D>().velocity.x)/50);
        yPos = player.GetComponent<Transform>().position.y;
		if (Input.GetMouseButton(0) && (gameObject.transform.position.y < 0))
		{
			
			if ((yPos + 6) <= gameObject.transform.position.y)
				yPos += ySpeed;
		}
		else
		{
			if (yPos > yStart)
				yPos -= ySpeed;
		}
		//anim.Play("bball anim_bball_moving", -1, 0f);
		if (Input.GetMouseButton(0))
		{
			anim.Play("anim_bball_locked");
			throwCounter = throwCounterLim;
		}
		else
		{
			if (caught || (this.GetComponent<Rigidbody2D>().velocity.x < 0.01f  && this.GetComponent<Rigidbody2D>().velocity.x > -.01f))
			{
				anim.Play("anim_bball_idle");
			}
			else
			{
				if (throwCounter <= 0f)
				{
					print("YUP");
					anim.Play("anim_bball_moving");
				}
				else
				{
					throwCounter -= .05f;
					anim.Play("anim_bball_throw");
					print(throwCounter);
				}
			}
		}

		if (player.GetComponent<Transform>().position.x >= hoop.GetComponent<Transform>().position.x)
			player.GetComponent<Transform>().localScale = new Vector2(-1, 1);
		else
			player.GetComponent<Transform>().localScale = new Vector2(1, 1);

		player.GetComponent<Transform>().position = new Vector2(gameObject.GetComponent<Transform>().position.x, 
																yPos);
	}
}
