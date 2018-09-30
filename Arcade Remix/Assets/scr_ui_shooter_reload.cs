﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scr_ui_shooter_reload : MonoBehaviour {
    public GameObject text;
    public GameObject player;
	// Update is called once per frame
	void Update () {
		if (player.GetComponent<scr_player_shooter_controls>().ammo <= 0)
        {
            text.SetActive(true);
        }
        else
        {
            text.SetActive(false);
        }
	}
}
