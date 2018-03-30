using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class VideoInstructionScript : MonoBehaviour {

	public GameObject videoPlayer, instructionPanel;
	public static bool videoCard = false;
	// Use this for initialization
	void Start () {

		videoPlayer.SetActive(false);
instructionPanel.SetActive(false);

	}
	
	// Update is called once per frame
	void Update () {
		videoCard = CustomResistorTracker.oneKresistorTracker;
		if (videoCard == true)
		{
			videoPlayer.SetActive(true);
			instructionPanel.SetActive(false);
		}

		else
		{

			videoPlayer.SetActive(false);
			instructionPanel.SetActive(true);
		}

	}
}
