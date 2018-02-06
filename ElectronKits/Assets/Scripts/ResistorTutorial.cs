using UnityEngine;
using System.Collections;
using Vuforia;
using UnityEngine.UI;



//This script can detect the presence of the target & input text or other instruction depending on the target's presence.
public class ResistorTutorial : MonoBehaviour, ITrackableEventHandler
{

	private TrackableBehaviour mTrackableBehaviour;

	private bool mShowGUIButton = false;
	//private Rect mButtonRect = new Rect(Screen.width-150, Screen.height-1200 , 100, 900);

	private Rect mButtonRectNext = new Rect((Screen.width-360), Screen.height/2, 400, 400);
  	private Rect mButtonRectBack = new Rect((Screen.width-Screen.width), Screen.height / 2, 400, 400);

	public TextMesh showParagraph, showParagraphResistorVideo;
	public int paraIndex = 0;

	private GUIStyle guiStyle = new GUIStyle();
	public Texture iconNext, iconBack;

	private GameObject redarrowAmercian, redarrowInt, resistorRedBox, text3DAmercian, text3DInt;
	private GameObject vidPlaneResistNorm, resistorNormPic, vidPlaneResistNarrow, resistorNarrowPic;
	private GameObject text3DExplain1, text3DExplain2, resistorRedBox1, addtionalTextbox;

	void Start()
	{	
		//Find red arrow game object:
		redarrowAmercian = GameObject.Find("redPointer_Amercian");
		redarrowInt= GameObject.Find("redPointer_Int");

		resistorRedBox = GameObject.Find("resistorRedBox");

		text3DAmercian = GameObject.Find("3D_Text_Amercian_std");
		text3DInt = GameObject.Find("3D_Text_int_std");

		vidPlaneResistNorm = GameObject.Find("videoPlaneResistorNorm");
		resistorNormPic = GameObject.Find("currentFlowNorm");

		vidPlaneResistNarrow= GameObject.Find("videoPlaneResistorNarrow");
		resistorNarrowPic = GameObject.Find("currentFlowNarrow");

		text3DExplain1 = GameObject.Find("3D_Text_explain_1");

		resistorRedBox1 = GameObject.Find("resistorRedBox_1");
		addtionalTextbox = GameObject.Find("AdditionalTextBox");

		mTrackableBehaviour = GetComponent<TrackableBehaviour>();
		if (mTrackableBehaviour)
		{
			mTrackableBehaviour.RegisterTrackableEventHandler(this);
		}

	}



	public void OnTrackableStateChanged(
									TrackableBehaviour.Status previousStatus,
									TrackableBehaviour.Status newStatus)
	{
		if (newStatus == TrackableBehaviour.Status.DETECTED ||
			newStatus == TrackableBehaviour.Status.TRACKED)
		{
			mShowGUIButton = true;

		}
		else
		{
			mShowGUIButton = false;
		}
	}



	void OnGUI()// This is like the update function. Have to insert function here to update in real time
	{

		if (mShowGUIButton)
		{
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

			if (paraIndex < 6 || paraIndex > 9 )
			{
				vidPlaneResistNorm.GetComponent<Renderer>().enabled = false;
				resistorNormPic.GetComponent<Renderer>().enabled = false;

			}

			if (paraIndex < 7 || paraIndex > 12 )
			{
				text3DExplain1.GetComponent<Renderer>().enabled = false;
				addtionalTextbox.GetComponent<Renderer>().enabled = false;
			}
			if (paraIndex < 10 || paraIndex > 12 )
			{
				vidPlaneResistNarrow.GetComponent<Renderer>().enabled = false;
				resistorNarrowPic.GetComponent<Renderer>().enabled = false;
				resistorRedBox1.GetComponent<Renderer>().enabled = false;

			}

			//guiStyle.fontSize = 50; //change the font size
			//guiStyle.normal.textColor = Color.white; //set text color

			//GUIContent to use own texture
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

			else
			{


			}


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

		if (paraIndex >= 3 && paraIndex<=5)
		{

			showParagraph.text = "3. These are the standard\nsymbols for resistor.\n";

		}

		if (paraIndex == 6)
		{

			showParagraph.text = "4. To explain the\ndefinition more clearly\nwe use the example\nof water flowing\nto a tube.";

		}

	}

	public void paragraphStorageResistorVideo()
	{
		if (paraIndex== 7)
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
		if (paraIndex >= 6 && paraIndex<=9)
		{
			vidPlaneResistNorm.GetComponent<Renderer>().enabled = true;
			resistorNormPic.GetComponent<Renderer>().enabled = true;
		}

		if (paraIndex >= 7 && paraIndex<=12)
		{
			text3DExplain1.GetComponent<Renderer>().enabled = true;
			addtionalTextbox.GetComponent<Renderer>().enabled = true;
		}
		if (paraIndex >= 10 && paraIndex <= 12 )
		{
			vidPlaneResistNarrow.GetComponent<Renderer>().enabled = true;
			resistorNarrowPic.GetComponent<Renderer>().enabled = true;
			StartCoroutine(blinkingBox1());
		}

	}
}
