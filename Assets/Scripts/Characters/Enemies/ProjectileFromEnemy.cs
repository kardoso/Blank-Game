﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileFromEnemy : MonoBehaviour {

	public float velocidade;
	public AudioClip projectileFX;
	
	void Start()
	{
		SoundManager.PlaySFX(projectileFX);	
	}
	
	void Update () {
		transform.Translate(Vector2.right * Time.deltaTime * velocidade);
		//transform.position = Vector2.MoveTowards (transform.position, alvo, velocidade * Time.deltaTime);
		if(Time.timeScale < 1 && Time.timeScale > 0){
			Destroy(this.gameObject);
		}
	}

	void OnTriggerEnter2D (Collider2D Other){
		if (Other.tag.Equals("Player")) {
			Other.gameObject.GetComponent<Player>().MakeDamage();
			Destroy(this.gameObject);
		}
	}

	void OnBecameInvisible()
	{
		Destroy(this.gameObject);
	}
}
