using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class GameManager : MonoBehaviour {

	public bool recording = true;
	private float initialFixedTime;

	void Start(){
		//Unlocking Levels (Proof)
		PlayerPrefsMaster.UnlockLevel(2);
		print(PlayerPrefsMaster.IsLevelUnlocked(1));
		print(PlayerPrefsMaster.IsLevelUnlocked(2));
		initialFixedTime = Time.fixedDeltaTime;
	}

	// Update is called once per frame
	void Update () {
		if (CrossPlatformInputManager.GetButton ("Fire1")){
			recording = false;
		}else{
			recording = true;
		}

		if(Input.GetKeyDown(KeyCode.P)){
			PauseGame();
		}

		if(Input.GetKeyDown(KeyCode.R)){
			ResumeGame();
		}
	}

	void PauseGame(){
		Time.timeScale = 0;
		Time.fixedDeltaTime = 0;
	}

	void ResumeGame(){
		Time.timeScale = 1f;
		Time.fixedDeltaTime = initialFixedTime;
	}
}
