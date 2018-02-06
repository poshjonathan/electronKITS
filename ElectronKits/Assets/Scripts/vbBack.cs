using UnityEngine;
using Vuforia;

public class vbBack : MonoBehaviour, IVirtualButtonEventHandler {

	public static int paraReadIndex=0;

	private GameObject vb_Back;
	public TextMesh showtext;

	public static bool backBtn; // to transfer information to other script

	bool currentstate_5;
	// Use this for initialization
	void Start () {

		vb_Back = GameObject.Find("vbBack");
		vb_Back.GetComponent<VirtualButtonBehaviour>().RegisterEventHandler(this);
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	public void OnButtonPressed(VirtualButtonAbstractBehaviour vb)
	{
		paraReadIndex = vbNext.paraReadIndex;//get latest paraIndex Value
		paraReadIndex--;
		displayParagraph();
		vbNext.paraReadIndex = paraReadIndex;//update latest paraIndex Value
	}

	public void OnButtonReleased(VirtualButtonAbstractBehaviour vb)
	{
		}

	public void displayParagraph()
	{
		if (paraReadIndex == 1)
		{
			showtext.text = "Place a resistor card beside this tutorial\ncard.We can see that there are multiple\ncolor bands on the resistor.";
		}
		if (paraReadIndex == 2)
		{
			showtext.text = "Determine if this resistor has 4 color \nbands or 5 color bands.The first band is \nthe on left while the last band is on \nthe right.";
		}

		if (paraReadIndex == 3)
		{
			showtext.text = "Read the color sequence that must be \ndecoded to determine resistance. \nRead the bands from left to right. ";
		}

		if (paraReadIndex == 4)
		{
			showtext.text = "Use the Color Chart Card to determine \nthe color code of each color.";
		}
	}
}
