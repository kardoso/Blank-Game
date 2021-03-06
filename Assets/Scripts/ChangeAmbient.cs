﻿using UnityEngine;
using UnityEngine.Tilemaps;
using System.Collections;
using System.Collections.Generic;

public class ChangeAmbient : MonoBehaviour {
	Transform player;			//This will be the player(duh)
	bool inside;				//if player is inside this quad

	public Color quadColor;		//The color of this quad when player is not inside
	public Color inAmbientColor;	//Ambient light color when player is inside this quad
	public Color outAmbientColor;	//Ambient light color when player is outside this quad

	public Transform objectWithInsideLights;

	void Start()
	{
		inside = false;
		GetComponent<Tilemap>().color = quadColor;
		EnableLights(false);
		player = FindObjectOfType<Player>().transform;
	}

	void OnTriggerStay2D(Collider2D other)
	{
		if(other.gameObject.tag.Equals("Player")){
			if (GetComponent<CompositeCollider2D>().bounds.Contains(new Vector3(player.position.x, player.position.y, transform.position.z))){
				if(!inside){
					RenderSettings.ambientLight = inAmbientColor;
					EnableLights(true);
					FadeThisObject(0.2f, false);
					inside = true;
				}
			}
			else{
				if(inside){
					RenderSettings.ambientLight = outAmbientColor;
					EnableLights(false);
					FadeThisObject(0.2f, true);
					inside = false;
				}
			}
		}
	}

	void OnTriggerExit2D(Collider2D other)
	{	
		if(other.gameObject.tag.Equals("Player")){
			if(inside){
				RenderSettings.ambientLight = outAmbientColor;
				EnableLights(false);
				FadeThisObject(0.2f, true);
				inside = false;
			}
		}
	}

	public void ResetObject(){
		RenderSettings.ambientLight = outAmbientColor;
		EnableLights(false);
		FadeThisObject(0.05f, true);
		inside = false;
	}

	void FadeThisObject(float duration, bool fadeIn){
		if(fadeIn){
			FindObjectOfType<Fade>().FadeGameObject(this.gameObject, duration, 0f, quadColor.a);
		}
		else{
			FindObjectOfType<Fade>().FadeGameObject(this.gameObject, duration, quadColor.a, 0f);
		}
	}

	public void EnableLights(bool check){
		foreach(Transform t in objectWithInsideLights){
			t.GetComponent<Light>().enabled = check;
		}
	}
}