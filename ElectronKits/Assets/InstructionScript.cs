using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class InstructionScript : MonoBehaviour
{

	public Text txtInstruction, txtPageNum;

	private int intStepCounter = 1;

	private string strInstruction;

	public Button btnNext, btnBack, btnStart;

	public GameObject panelInstruction,countdown;


	// Use this for initialization
	void Start()
	{

		btnStart.interactable = false;
		countdown.SetActive(false);
		//Click listener
		btnNext.onClick.AddListener(TaskOnNextClick);
		btnBack.onClick.AddListener(TaskOnBackClick);
		btnStart.onClick.AddListener(TaskOnStartClick);


	}

	// Update is called once per frame
	void Update()
	{

		txtSteps();

		txtInstruction.text = strInstruction;
		txtPageNum.text = intStepCounter.ToString() + "/4";

		if (intStepCounter == 1)
		{
			btnBack.interactable = false;
		}

		else
		{
			btnBack.interactable = true;
		}

		if (intStepCounter == 4)
		{

			btnNext.interactable = false;
			btnStart.interactable = true;

		}
		else
		{
			btnNext.interactable = true;

		}

	}

	void txtSteps()
	{
		switch (intStepCounter)
		{
			case 1:
				strInstruction = "There are 4 rounds\nin this challenge.";
				break;

			case 2:
				strInstruction = "Arrange the logic gate cards\naccording to the on screen\ninstructions before each round.";
				break;
			case 3:
				strInstruction = "New round will begin\nonce the round is completed correctly.";
				break;
			case 4:
				strInstruction = "Aim to complete \nall 4 rounds as fast as possible!\nHave Fun!";
				break;



		}



	}

	void TaskOnNextClick()
	{
		intStepCounter++;


	}

	void TaskOnBackClick()

	{

		intStepCounter--;

	}

void TaskOnStartClick()

{
		
		panelInstruction.SetActive(false);
		countdown.SetActive(true);
	}



}
