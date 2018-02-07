using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class textBoxText : MonoBehaviour {

	public static int paraIndex=0;
	public TextMesh showParagraph;

	public static bool nextBtn, backBtn;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		/*nextBtn = vbNext.nextBtn;
		backBtn = vbBack.backBtn;

		if (nextBtn == true) {
			paraIndex++;
			nextBtn = false;
		}
		if (backBtn == true) {
			paraIndex--;
			backBtn = false;
		}
*/
		if (vbBack.paraReadIndex != paraIndex) 
		{ 
			paraIndex = vbBack.paraReadIndex;
			//paraIndex--;
            displayParagraph();
		}
		if (vbNext.paraReadIndex != paraIndex) 
		{ 
			paraIndex = vbNext.paraReadIndex;
			//paraIndex++;
            displayParagraph();
		}


		
	}

	public void displayParagraph()
	{
		if (paraIndex == 0)
		{
			showParagraph.text = "0";
		}
		if (paraIndex == 1)
		{
			showParagraph.text = "The flow of water is similar\nto the flow of electrical\ncurrent in an electrical\ncircuit.";
		}

		if (paraIndex == 2)
		{
			showParagraph.text = "The <b><color=red>pressure different</color></b> that \ncauses the water to flow \ncan be compared to the \n<b><color=red>voltage difference</color></b> which \ncauses the flow of electrical \ncurrent.";
		}
		/*
		if (paraIndex == 9)
		{
			showParagraphResistorVideo.text = "If we create a resistance in \nthe flow of water, the\ncurrent will reduce!";
		}

		if (paraIndex == 10)
		{
			showParagraphResistorVideo.text = "We can do it for example by\nmaking the tube more\nnarrow at a certain place!";
		}
		if (paraIndex == 11)
		{
			showParagraphResistorVideo.text = "We can see this in the water\npipe that a pressure drop\nis created because of the\nnarrow part in the middle. \nThe pressure on the left is\nlarger than on the right.";
		}
		if (paraIndex == 12)
		{
			showParagraphResistorVideo.text = "The resistor has a similar\neffect. Here a voltage drop\nis created. The relation\nbetween the electrical\ncurrent, voltage &\nresistance is described by\n<b><color=red>Ohm’s Law.</color></b>";
		}	
		*/
	}
}
