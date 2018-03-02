﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mirror : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.gameObject.tag.Equals("Player")){
			other.gameObject.GetComponent<Player>().InvetControls();
			Camera.main.GetComponent<CameraShake>().ShakeCamera(0.2f);
			//break sprite
			GetComponent<BoxCollider2D>().enabled = false;
		}
	}
}
