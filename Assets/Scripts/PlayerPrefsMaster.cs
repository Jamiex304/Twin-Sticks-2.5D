using UnityEngine;
using System.Collections;

public class PlayerPrefsMaster : MonoBehaviour {

	//Variable Keys
	const string MASTER_VOLUME_KEY = "master_vol";
	const string DIFFICULTY_KEY = "difficulty";
	const string LEVEL_UNLOCK_KEY = "level_unlock";
	
	//Setup and Connected
	//Volume Master
	//Setting the Master Volume
	public static void SetMasterVol (float volume){
		//Between 0 Volume and 1 Volume else we log an Error
		if (volume > 0f && volume < 1f){
			PlayerPrefs.SetFloat(MASTER_VOLUME_KEY, volume);
		}else{
			Debug.LogError("Master Volume Error in PlayerPrefsMaster");
		}
	}
	//Getting the Master Volume
	public static float GetMasterVol(){
		return PlayerPrefs.GetFloat(MASTER_VOLUME_KEY);
	}
	
	//Sample Code of Unlocking Levels
	//Level Unlock Master
	//Setting the Level Unlock
	public static void UnlockLevel(int level){
		if(level <= Application.levelCount - 1){
			PlayerPrefs.SetInt(LEVEL_UNLOCK_KEY + level.ToString(), 1);// 1 = True
		}else {
			Debug.LogError("Level Is Not In Build Order / Trying to Unlock Level that is not in Build Order");
		}
		
	}
	//Getting the Level Unlock
	public static bool IsLevelUnlocked(int level){
		int levelValue = PlayerPrefs.GetInt(LEVEL_UNLOCK_KEY + level.ToString());
		bool isLevelUnlocked = (levelValue == 1);
		
		if(level <= Application.levelCount - 1){
			return isLevelUnlocked;
		}else {
			Debug.LogError("Level Is Not In Build Order / Trying to Unlock Level that is not in Build Order");
			return false;
		}
	}
	
	//Sample Code for Difficulty
	//Difficulty Master
	//Setting the Master Difficulty
	public static void SetDifficulty (float difficulty){
		//Between 0 Volume and 1 Volume else we log an Error
		if (difficulty >= 1f && difficulty <= 3f){
			PlayerPrefs.SetFloat(DIFFICULTY_KEY, difficulty);
		}else{
			Debug.LogError("Master Difficulty Error in PlayerPrefsMaster - Check If / Else Statement");
		}
	}
	//Getting the Master Volume
	public static float GetDifficulty(){
		return PlayerPrefs.GetFloat(DIFFICULTY_KEY);
	}
}
