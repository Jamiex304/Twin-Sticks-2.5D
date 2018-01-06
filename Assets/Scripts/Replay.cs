using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Replay : MonoBehaviour {

	private const int bufferFrames = 1000;
	private MyKeyFrame[] keyframes = new MyKeyFrame[bufferFrames];
	private Rigidbody rigidBody;
	private GameManager manager;

	// Use this for initialization
	void Start () {
		//MyKeyFrame testKey = new MyKeyFrame(1.0f, Vector3.up, Quaternion.identity);
		rigidBody = GetComponent<Rigidbody>();
		//Linking Scripts
		manager = GameObject.FindObjectOfType<GameManager>();
	}
	
	// Update is called once per frame
	void Update () {
		// Recording the Frames
		if(manager.recording){
			Record ();
		}else{
			PlayBack();
		}


	}

	void PlayBack(){
		rigidBody.isKinematic = true;
		int frame = Time.frameCount % bufferFrames;
		//print("Reading Frame: " + frame);
		transform.position = keyframes[frame].position;
		transform.rotation = keyframes[frame].rotation;
	}

	void Record ()
	{
		rigidBody.isKinematic = false;
		int frame = Time.frameCount % bufferFrames;
		float time = Time.time;
		//print ("Writing Frame: " + frame);
		//Creating a new Frame
		keyframes[frame] = new MyKeyFrame (time, transform.position, transform.rotation);
	}
}

/// <summary>
/// Structure for storing time, rotation and position
/// </summary>
public struct MyKeyFrame{
	// My Structure for Replay System in-game
	// Variables
	public float frameTime;
	public Vector3 position;
	public Quaternion rotation; 

	//Constructor
	public MyKeyFrame(float aTime, Vector3 aPosition, Quaternion aRotation){
		frameTime = aTime;
		position = aPosition;
		rotation = aRotation;
	}
}