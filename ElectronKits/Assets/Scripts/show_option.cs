using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class show_option : MonoBehaviour {

	public TextMesh showTextOptA, showTextOptB, showTextOptC, showTextOptD;
	private GameObject optionA, optionB, optionC, optionD;

	public static bool optionCardTracked=false, card22kTracked = false, card1_5kTracked = false,card1kTracked = false;

	private GameObject correct22kResistorImg, correct1_5KResistorImg, correct1KResistorImg;

	public static bool getCorrectAns22k;
	public static bool getCorrectAns1_5k;
	public static bool getCorrectAns1k;

	// Use this for initialization
	void Start () {
		optionA= GameObject.Find("option_A");
		optionB= GameObject.Find("option_B");
		optionC= GameObject.Find("option_C");
		optionD= GameObject.Find("option_D");

		optionA.GetComponent<Renderer>().enabled = false;
		optionB.GetComponent<Renderer>().enabled = false;
		optionC.GetComponent<Renderer>().enabled = false;
		optionD.GetComponent<Renderer>().enabled = false;

		correct22kResistorImg= GameObject.Find("Answer22KImg");
		correct1_5KResistorImg= GameObject.Find("Answer1_5KImg");
		correct1KResistorImg = GameObject.Find("Answer1KImg");

	}
	
	// Update is called once per frame
	void Update () {

		card22kTracked = custom22kResistorTracker.resistor_22k;
		card1_5kTracked = custom1_5kResistanceTracker.resistor_1_5k;
		card1kTracked = Custom1kResistanceTracker.resistor_1k;
		optionCardTracked = customOptionCardTracker.optionCardTracker;


		if (card22kTracked == true || card1_5kTracked == true || card1kTracked==true)
		{
			optionA.GetComponent<Renderer>().enabled = true;
			optionB.GetComponent<Renderer>().enabled = true;
			optionC.GetComponent<Renderer>().enabled = true;
			optionD.GetComponent<Renderer>().enabled = true;

		}


		if (card22kTracked == true)
		{
			showTextOptA.text = "22KΩ";
			showTextOptB.text = "10KΩ";
			showTextOptC.text = "50KΩ";
			showTextOptD.text = "220KΩ";

		}

		if (card1_5kTracked == true)
		{
			showTextOptA.text = "1KΩ";
			showTextOptB.text = "1.5KΩ";
			showTextOptC.text = "15KΩ";
			showTextOptD.text = "150KΩ";
		}

		if (card1kTracked == true)
		{
			showTextOptA.text = "50KΩ";
			showTextOptB.text = "2KΩ";
			showTextOptC.text = "1Ω";
			showTextOptD.text = "1KΩ";
		}

		if (card22kTracked == false  && card1_5kTracked == false  && card1kTracked == false )
		{
	
			optionA.GetComponent<Renderer>().enabled = false;
			optionB.GetComponent<Renderer>().enabled = false;
			optionC.GetComponent<Renderer>().enabled = false;
			optionD.GetComponent<Renderer>().enabled = false;
			
		}

		if (optionCardTracked == false)
		{
			optionA.GetComponent<Renderer>().enabled = false;
			optionB.GetComponent<Renderer>().enabled = false;
			optionC.GetComponent<Renderer>().enabled = false;
			optionD.GetComponent<Renderer>().enabled = false;
		}

		//-------------------------22k RESISTOR-----------------------------

		if (card22kTracked == true)
		{
			if (getCorrectAns22k == false)
			{
				correct22kResistorImg.GetComponent<Renderer>().enabled = false;
			}

			if (getCorrectAns22k == true)
			{
				correct22kResistorImg.GetComponent<Renderer>().enabled = true;
			}

		}

		if(card22kTracked==false)
		{
			correct1_5KResistorImg.GetComponent<Renderer>().enabled = false;
		}

		//-------------------------1.5k RESISTOR-----------------------------

		if (card1_5kTracked == true)
		{
			if (getCorrectAns1_5k == false)
			{
				correct1_5KResistorImg.GetComponent<Renderer>().enabled = false;
			}

			if (getCorrectAns1_5k == true)
			{
				correct1_5KResistorImg.GetComponent<Renderer>().enabled = true;
			}

		}

		if(card1_5kTracked==false)
		{
				correct1_5KResistorImg.GetComponent<Renderer>().enabled = false;
		}

		//-------------------------1k RESISTOR-----------------------------

		if (card1kTracked == true)
		{
			if (getCorrectAns1k == false)
			{
				correct1KResistorImg.GetComponent<Renderer>().enabled = false;
			}

			if (getCorrectAns1k == true)
			{
				correct1KResistorImg.GetComponent<Renderer>().enabled = true;
			}

		}

		if(card1kTracked==false)
		{
			correct1KResistorImg.GetComponent<Renderer>().enabled = false;
		}

		
	}
}
