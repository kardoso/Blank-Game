﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Launcher : MonoBehaviour {

	public enum LaunchDirection{
		Up,
		Down,
		Left,
		Right
	}

	public LaunchDirection launchDirection;
	public float timeToThrow;

	private Transform spawnPoint;

	void Start(){
		spawnPoint = transform.GetChild(0);
		DisableLight();
		StartCoroutine("LaunchProjectile");
	}

	IEnumerator LaunchProjectile(){
		while(true){
			yield return new WaitForSeconds(timeToThrow);
			GetComponent<Animator>().SetTrigger("LaunchNOW");
		}
	}

	void EnableLight(){
		transform.Find("Light").gameObject.SetActive(true);
	}

	void DisableLight(){
		transform.Find("Light").gameObject.SetActive(false);
	}

	void Launch(){
		var projectilePrototype = Resources.Load("Objects/Projectile", typeof(GameObject)) as GameObject;
		Vector3 spawnPos = new Vector3(spawnPoint.transform.position.x, spawnPoint.transform.position.y, spawnPoint.transform.position.z);
		Vector2 direction = Vector2.up;
		if(launchDirection == LaunchDirection.Up){
			direction = Vector2.up;			
		}
		else if(launchDirection == LaunchDirection.Down){
			direction = Vector2.down;
		}
		else if (launchDirection == LaunchDirection.Left){
			direction = Vector2.left;
		}
		else if(launchDirection == LaunchDirection.Right){
			direction = Vector2.right;
		}
		projectilePrototype.transform.position = spawnPos;
		GameObject.Instantiate(projectilePrototype).GetComponent<Projectile>().SetDirection(direction);
	}
}
