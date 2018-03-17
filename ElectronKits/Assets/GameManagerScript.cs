using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{

	public bool counterDownDone = false;
	public bool checkBtnClick = false;

	public bool round1 = false;
	public bool round2 = false;
	public bool round3 = false;
	public bool round4 = false;
	public bool roundComplete = false;

	public bool correct_sound = false;
	public bool wrong_sound = false;

	public int questionNumber = 2;
	public Stopwatch stopWatch = new Stopwatch();

	// Use this for initialization
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{

	}
}
