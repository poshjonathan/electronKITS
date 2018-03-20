using UnityEngine;
using System.Collections;
using Vuforia;
using UnityEngine.UI;



//This script can detect the presence of the target & input text or other instruction depending on the target's presence.
public class ResistorTutorial : MonoBehaviour
{


	private bool mTrackStatus = false;
	//private Rect mButtonRect = new Rect(Screen.width-150, Screen.height-1200 , 100, 900);

	private Rect mButtonRectNext = new Rect((Screen.width - 360), Screen.height / 2, 400, 400);
	private Rect mButtonRectBack = new Rect((Screen.width - Screen.width), Screen.height / 2, 400, 400);

	public TextMesh showParagraph, showParagraphResistorVideo;
	public int paraIndex = 0;

	private GameObject redarrowAmercian, redarrowInt, resistorRedBox, text3DAmercian, text3DInt;
	private GameObject vidPlaneResistNorm, resistorNormPic, vidPlaneResistNarrow, resistorNarrowPic;
	private GameObject text3DExplain1, text3DExplain2, resistorRedBox1, addtionalTextbox;



	public Button nextBtn, backBtn;
	public GameObject goNext, goBack;
	public GameObject resistanceCartoonImage, ohmFormula, ohmTriangle;

	private GameObject hand;
	public GameObject startMarker, voltageMarker, currentMarker, resistorMarker;

	private static bool onKresistorTracker;

	public GameObject exampleCircuit1, exampleCircuit1EQU;

	public GameObject currentEQU, voltageEQU, resistanceEQU;

	public GameObject goIntructions;
	public Button helpBtn, closHelpBtn, closeHelpCurrentBtn,closeHelpVoltageBtn;

public GameObject exampleCircuit2, exampleCircuit2EQU;

	public GameObject helpCurrentBtn, goHelpCurrentPanel;
public GameObject helpVoltageBtn, goHelpVoltagePanel;

	void Start()
	{
		//Find red arrow game object:
		redarrowAmercian = GameObject.Find("redPointer_Amercian");
		redarrowInt = GameObject.Find("redPointer_Int");

		resistorRedBox = GameObject.Find("resistorRedBox");

		text3DAmercian = GameObject.Find("3D_Text_Amercian_std");
		text3DInt = GameObject.Find("3D_Text_int_std");

		vidPlaneResistNorm = GameObject.Find("videoPlaneResistorNorm");
		resistorNormPic = GameObject.Find("currentFlowNorm");

		vidPlaneResistNarrow = GameObject.Find("videoPlaneResistorNarrow");
		resistorNarrowPic = GameObject.Find("currentFlowNarrow");

		text3DExplain1 = GameObject.Find("3D_Text_explain_1");

		resistorRedBox1 = GameObject.Find("resistorRedBox_1");
		addtionalTextbox = GameObject.Find("AdditionalTextBox");

		hand = GameObject.Find("Hand_Poly_by_Google");


		nextBtn.onClick.AddListener(TaskOnNextClick);
		backBtn.onClick.AddListener(TaskOnBackClick);

		backBtn.interactable = false;

		goNext.SetActive(false);
		goBack.SetActive(false);

		exampleCircuit1.SetActive(false);
		exampleCircuit1EQU.SetActive(false);

		currentEQU.SetActive(false);
		voltageEQU.SetActive(false);
		resistanceEQU.SetActive(false);

		goIntructions.SetActive(false);

			exampleCircuit2.SetActive(false);
		exampleCircuit2EQU.SetActive(false);

		helpCurrentBtn.SetActive(false);
		helpVoltageBtn.SetActive(false);

		goHelpCurrentPanel.SetActive(false);
		goHelpVoltagePanel.SetActive(false);

		helpBtn.onClick.AddListener( TaskOnHelpClick);
closHelpBtn.onClick.AddListener( TaskOnCloseHelpClick);
		closeHelpCurrentBtn.onClick.AddListener( TaskOnCloseHelpCurrentClick);
closeHelpVoltageBtn.onClick.AddListener( TaskOnCloseHelpVoltageClick);


	}



	void Update()// This is like the update function. Have to insert function here to update in real time
	{
		onKresistorTracker = CustomResistorTracker.oneKresistorTracker;

		if (onKresistorTracker == false)
		{
			goNext.SetActive(false);
			goBack.SetActive(false);


		}

		if (onKresistorTracker == true)
		{

			goNext.SetActive(true);
			goBack.SetActive(true);






			if (paraIndex != 3)
			{
				resistorRedBox.GetComponent<Renderer>().enabled = false;
			}

			if (paraIndex != 4)
			{
				text3DAmercian.GetComponent<Renderer>().enabled = false;
				redarrowAmercian.GetComponent<Renderer>().enabled = false;
			}

			if (paraIndex != 5)
			{
				text3DInt.GetComponent<Renderer>().enabled = false;
				redarrowInt.GetComponent<Renderer>().enabled = false;
			}

			if (paraIndex < 6 || paraIndex > 9)
			{
				vidPlaneResistNorm.GetComponent<Renderer>().enabled = false;
				resistorNormPic.GetComponent<Renderer>().enabled = false;

			}

			if (paraIndex < 7 || paraIndex > 14)
			{
				text3DExplain1.GetComponent<Renderer>().enabled = false;
				addtionalTextbox.GetComponent<Renderer>().enabled = false;
			}
			if (paraIndex < 10 || paraIndex > 14)
			{
				vidPlaneResistNarrow.GetComponent<Renderer>().enabled = false;
				resistorNarrowPic.GetComponent<Renderer>().enabled = false;
				resistorRedBox1.GetComponent<Renderer>().enabled = false;

			}
			if (paraIndex < 13 || paraIndex > 14)
			{
				resistanceCartoonImage.SetActive(false);
			}

			if (paraIndex < 15 || paraIndex > 15)
			{
				ohmFormula.SetActive(false);


			}

			if (paraIndex < 16 || paraIndex > 34)
			{
				ohmTriangle.SetActive(false);

			}
			if (paraIndex < 24 ||paraIndex >28)
			{

				exampleCircuit1.SetActive(false);



			}
			if (paraIndex < 28 ||paraIndex >28 )
			{

				exampleCircuit1EQU.SetActive(false);

			}

			if (paraIndex < 30 ||paraIndex >34)
			{

				exampleCircuit2.SetActive(false);



			}
			if (paraIndex < 34 ||paraIndex >34 )
			{

				exampleCircuit1EQU.SetActive(false);

			}

			if (paraIndex < 19)
			{

				voltageEQU.SetActive(false);

			}

			if (paraIndex  >19 && paraIndex<32)
			{

				voltageEQU.SetActive(false);

			}

			if (paraIndex  >34 )
			{

				voltageEQU.SetActive(false);

			}
			if (paraIndex < 21)
			{

				currentEQU.SetActive(false);

			}
			if (paraIndex > 21 && paraIndex < 26)
			{

				currentEQU.SetActive(false);

			}
			if (paraIndex > 27)
			{

				currentEQU.SetActive(false);

			}

			if (paraIndex != 23)
			{

				resistanceEQU.SetActive(false);

			}

				if (paraIndex < 24 ||paraIndex==29 || paraIndex>34)
			{

				helpCurrentBtn.SetActive(false);
				helpVoltageBtn.SetActive(false);

			}








			//guiStyle.fontSize = 50; //change the font size
			//guiStyle.normal.textColor = Color.white; //set text color

			//GUIContent to use own texture
			/*
			if (GUI.Button(mButtonRectNext, new GUIContent(iconNext)))
			{   // do something on button click 
				paraIndex++;
				paragraphStorage();

				// Show the red arrow. Make it rotate in the future.
				// redarrow.transform.Rotate(Vector.forward * -90);
				StartCoroutine(blinkingBox()); //method use for blinking red box

				showRedArrow();
				showResistorVideoNorm();
				paragraphStorageResistorVideo();
				//showResistorVideoNarrow();

			}

			if (GUI.Button(mButtonRectBack, new GUIContent(iconBack)))
			{
				// do something on button click 
				paraIndex--;
				paragraphStorage();

				StartCoroutine(blinkingBox()); //method use for blinking red box

				showRedArrow();
				showResistorVideoNorm();
				paragraphStorageResistorVideo();

				//showResistorVideoNarrow();
			}
			*/






			if (paraIndex == 1)
			{


				backBtn.interactable = false;

			}
			/*
			if (paraIndex == 14)
			{
				nextBtn.interactable = false;


			}
			*/
			showHand();

		}
	}

	public void paragraphStorage()
	{
		if (paraIndex == 1)
		{
			showParagraph.text = "1. The resistor is the part\nof an electrical circuit\nthat resists, or limits, the\npower of an electrical\ncurrent in a circuit.";

		}

		if (paraIndex == 2)
		{

			showParagraph.text = "2. The resistor also helps\nto reduce, or lessen, the\namount of electricity\nmoving through the\ncircuit.";

		}

		if (paraIndex >= 3 && paraIndex <= 5)
		{

			showParagraph.text = "3. These are the standard\nsymbols for resistor.\n";

		}

		if (paraIndex == 6)
		{

			showParagraph.text = "4. To explain the\ndefinition more clearly\nwe use the example\nof water flowing\nto a tube.";

		}

		if (paraIndex == 15)
		{
			showParagraph.text = "5. Ohm’s law is a way of\ndescribing the\nrelationship between\nthe voltage, resistance\nand current using math.";
		}
		if (paraIndex == 16)
		{
			showParagraph.text = "6. You can use this\ntriangle to remember\nOhm's law.";
		}
		if (paraIndex == 17)
		{
			showParagraph.text = "7. Use hand to cover the\nletter you want to find. \nFor example, we need to \nfind voltage.";

		}

		if (paraIndex == 18)
		{
			showParagraph.text = "8. Find voltage:\nPlace your hand over the\nV in the triangle, then\nlook at " +
				"the R & I. I & R\nare next to each other,\n         so you need\n            to mulitply.";

		}
		if (paraIndex == 19)
		{

			showParagraph.text = "9. That means you get:";

		}

		if (paraIndex == 20)
		{

			showParagraph.text = "10. Find current:\nPlace your hand over the\nI. Then you’ll see the V\nover the R, which\nmeans divide V by R.";

		}

		if (paraIndex == 21)
		{

			showParagraph.text = "11. That means you get:";

		}

		if (paraIndex == 22)
		{

			showParagraph.text = "12. Find resistance:\nPlace your hand over the\nR. Then you’ll see the V\nover the I, which means\ndivide V by I.";

		}

		if (paraIndex == 23)
		{

			showParagraph.text = "13. That means you get:";

		}

		if (paraIndex == 24)
		{

			showParagraph.text = "14. This is a simple circuit\nwith a battery &\na resistor.";

		}
		if (paraIndex == 25)
		{

			showParagraph.text = "15. Battery is 12V &\nresistor is 600Ω.\nHow much current flows\nthrough the circuit?";

		}
		if (paraIndex == 26)
		{

			showParagraph.text = "16. To find the amount of\ncurrent, place your hand\nover I. Then you’ll see\nthe V over the R:";

		}
		if (paraIndex == 27)
		{

			showParagraph.text = "17. Try to find the current\nyourself!\nPress next for the anwser!";

		}
		if (paraIndex == 28)
		{

			showParagraph.text = "18. So the current in\nthe circuit is 0.02A!";

		}
			if (paraIndex == 29)
		{

			showParagraph.text = "19. Let's try another\nquestion!";

		}
		if (paraIndex == 30)
		{

			showParagraph.text = "20. This time let's find\nthe voltage!";

		}

			if (paraIndex == 31)
		{

			showParagraph.text = "21. The resistance of the resistor\nis 600 Ohm.\nWhat is the voltage\nof the battery?";

		}
		if (paraIndex == 32)
		{

			showParagraph.text = "22. To find the amount of\nvoltage, place your hand\nover V. Then you’ll see\nthe I multiple by R:";

		}
		if (paraIndex == 33)
		{

			showParagraph.text = "23. Try to find the voltage\nyourself!\nPress next for the anwser!";

		}

		if (paraIndex == 34)
		{

			showParagraph.text = "24. So the voltage of the\nbattery is 1.8V!";

		}
			if (paraIndex == 35)
		{

			showParagraph.text = "<color=red>With that we have come\nto an end of this resistor\ntutorial! I hope " +
				"that you\nnow have a better \nunderstanding the\nfunctionality of a \nresistor and Ohm's Law \ncalculation!</color>";

		}







	}

	public void paragraphStorageResistorVideo()
	{
		if (paraIndex == 7)
		{
			showParagraphResistorVideo.text = "The flow of water is similar\nto the flow of electrical\ncurrent in an electrical\ncircuit.";
		}

		if (paraIndex == 8)
		{
			showParagraphResistorVideo.text = "The <b><color=red>pressure different</color></b> that \ncauses the water to flow \ncan be compared to the \n<b><color=red>voltage difference</color></b> which \ncauses the flow of electrical \ncurrent.";
		}
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
		if (paraIndex == 13)
		{
			showParagraphResistorVideo.text = "In short, if you <b><color=red>\nincrease the voltage</color></b>\nin a " +
				"circuit while\nthe resistance is the same,\nyou get <b><color=red>more current.</color></b>";
		}
		if (paraIndex == 14)
		{
			showParagraphResistorVideo.text = "If you <b><color=red>increase the\nresistance </color></b>in a " +
				"circuit while\nthe voltage stays the same,\n<b><color=red>you get less current</color></b>.";

		}

	}

	public IEnumerator blinkingBox()//method use for blinking
	{
		if (paraIndex == 3)
		{
			resistorRedBox.GetComponent<Renderer>().enabled = true;
			yield return new WaitForSeconds(0.4f);
			resistorRedBox.GetComponent<Renderer>().enabled = false;
			yield return new WaitForSeconds(0.4f);
			resistorRedBox.GetComponent<Renderer>().enabled = true;
			yield return new WaitForSeconds(0.4f);
			resistorRedBox.GetComponent<Renderer>().enabled = false;
			yield return new WaitForSeconds(0.4f);
			resistorRedBox.GetComponent<Renderer>().enabled = true;
			yield return new WaitForSeconds(0.4f);
			resistorRedBox.GetComponent<Renderer>().enabled = false;
			yield return new WaitForSeconds(0.4f);
			resistorRedBox.GetComponent<Renderer>().enabled = true;
			yield break;
		}

	}

	public IEnumerator blinkingBox1()//method use for blinking
	{
		if (paraIndex == 10)
		{
			resistorRedBox1.GetComponent<Renderer>().enabled = true;
			yield return new WaitForSeconds(0.4f);
			resistorRedBox1.GetComponent<Renderer>().enabled = false;
			yield return new WaitForSeconds(0.4f);
			resistorRedBox1.GetComponent<Renderer>().enabled = true;
			yield return new WaitForSeconds(0.4f);
			resistorRedBox1.GetComponent<Renderer>().enabled = false;
			yield return new WaitForSeconds(0.4f);
			resistorRedBox1.GetComponent<Renderer>().enabled = true;
			yield return new WaitForSeconds(0.4f);
			resistorRedBox1.GetComponent<Renderer>().enabled = false;
			yield return new WaitForSeconds(0.4f);
			resistorRedBox1.GetComponent<Renderer>().enabled = true;
			yield break;
		}
	}

	public void showRedArrow()
	{

		if (paraIndex == 4)
		{
			text3DAmercian.GetComponent<Renderer>().enabled = true;
			redarrowAmercian.GetComponent<Renderer>().enabled = true;
		}

		if (paraIndex == 5)
		{
			text3DInt.GetComponent<Renderer>().enabled = true;
			redarrowInt.GetComponent<Renderer>().enabled = true;
		}
	}

	public void showResistorVideoNorm()
	{
		if (paraIndex >= 6 && paraIndex <= 9)
		{
			vidPlaneResistNorm.GetComponent<Renderer>().enabled = true;
			resistorNormPic.GetComponent<Renderer>().enabled = true;
		}

		if (paraIndex >= 7 && paraIndex <= 14)//Remember to change this
		{
			text3DExplain1.GetComponent<Renderer>().enabled = true;
			addtionalTextbox.GetComponent<Renderer>().enabled = true;
		}
		if (paraIndex >= 10 && paraIndex <= 14)
		{
			vidPlaneResistNarrow.GetComponent<Renderer>().enabled = true;
			resistorNarrowPic.GetComponent<Renderer>().enabled = true;
			StartCoroutine(blinkingBox1());
		}

	}

	public void showCartoon()
	{

		if (paraIndex > 12 && paraIndex <= 14)
		{
			resistanceCartoonImage.SetActive(true);


		}

	}

	public void showOhmFormula()
	{


		if (paraIndex == 15)
		{

			ohmFormula.SetActive(true);


		}


	}

	public void showOhmTriangle()
	{


		if (paraIndex >= 16 && paraIndex <= 34)
		{

			ohmTriangle.SetActive(true);


		}

	}
	public void showHand()
	{
		if (paraIndex < 18 || paraIndex == 24 ||paraIndex==29||paraIndex>34)
		{

			hand.transform.position = Vector3.MoveTowards(hand.transform.position, startMarker.transform.position, 2f);
			if (hand.transform.position == startMarker.transform.position)
			{

				hand.SetActive(false);

			}
		}

		if (paraIndex == 18 || paraIndex == 19)
		{

			hand.SetActive(true);
			hand.transform.position = Vector3.MoveTowards(hand.transform.position, voltageMarker.transform.position, 1f);

		}
		if (paraIndex == 20 || paraIndex == 21)
		{
			hand.SetActive(true);
			hand.transform.position = Vector3.MoveTowards(hand.transform.position, currentMarker.transform.position, 1f);

		}
		if (paraIndex == 22 || paraIndex == 23)
		{
			hand.SetActive(true);
			hand.transform.position = Vector3.MoveTowards(hand.transform.position, resistorMarker.transform.position, 1f);

		}
		if (paraIndex == 26)
		{
			hand.SetActive(true);
			hand.transform.position = Vector3.MoveTowards(hand.transform.position, currentMarker.transform.position, 1f);

		}
			if (paraIndex == 32)
		{
			hand.SetActive(true);
			hand.transform.position = Vector3.MoveTowards(hand.transform.position, voltageMarker.transform.position, 1f);

		}




	}

	public void showExample()
	{


		if (paraIndex >= 24 && paraIndex<=28)
		{

			helpCurrentBtn.SetActive(true);
			helpVoltageBtn.SetActive(true);
			exampleCircuit1.SetActive(true);

			if (paraIndex == 28)
			{



				exampleCircuit1EQU.SetActive(true);

			}
		}

		if (paraIndex >= 30 && paraIndex<=34)
		{

			helpCurrentBtn.SetActive(true);
			helpVoltageBtn.SetActive(true);
			exampleCircuit2.SetActive(true);

			if (paraIndex == 34)
			{



				exampleCircuit2EQU.SetActive(true);

			}
		}



	}

	public void showEQU()
	{

		if (paraIndex == 19 ||(paraIndex>=32 && paraIndex<=34))
		{

			voltageEQU.SetActive(true);

		}
		if (paraIndex == 21 || paraIndex == 26 || paraIndex == 27)
		{

			currentEQU.SetActive(true);

		}
		if (paraIndex == 23)
		{

			resistanceEQU.SetActive(true);

		}


	}


	void TaskOnBackClick()

	{

		// do something on button click 
		paraIndex--;
		paragraphStorage();

		StartCoroutine(blinkingBox()); //method use for blinking red box

		showRedArrow();
		showResistorVideoNorm();
		paragraphStorageResistorVideo();
		showCartoon();
		showOhmFormula();
		showOhmTriangle();
		showEQU();

		showExample();

		nextBtn.interactable = true;

		//showResistorVideoNarrow();
	}

	void TaskOnNextClick()

	{

		// do something on button click 
		paraIndex++;
		paragraphStorage();

		// Show the red arrow. Make it rotate in the future.
		// redarrow.transform.Rotate(Vector.forward * -90);
		StartCoroutine(blinkingBox()); //method use for blinking red box

		showRedArrow();
		showResistorVideoNorm();
		paragraphStorageResistorVideo();
		showCartoon();
		//showResistorVideoNarrow();
		showOhmFormula();
		showOhmTriangle();
		showExample();
		showEQU();

		backBtn.interactable = true;
		if (paraIndex == 35)
		{

			nextBtn.interactable = false;

		}

	}


	void TaskOnHelpClick()
	{

		goIntructions.SetActive(true);

	}
void TaskOnCloseHelpClick()
{

		goIntructions.SetActive(false);
	}

	void TaskOnCloseHelpCurrentClick()
	{
		goHelpCurrentPanel.SetActive(false);

	}

	void TaskOnCloseHelpVoltageClick()
	{
		goHelpVoltagePanel.SetActive(false);

	}

}
