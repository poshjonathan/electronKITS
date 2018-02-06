using UnityEngine;
using Vuforia;

public class vbNext : MonoBehaviour ,IVirtualButtonEventHandler
{
	public static int paraReadIndex=0;

	private GameObject vb_Next;

	public TextMesh showtext;
	public static bool nextBtn;

	// Use this for initialization
	void Start()
	{

		vb_Next = GameObject.Find("vbNext");
		vb_Next.GetComponent<VirtualButtonBehaviour>().RegisterEventHandler(this);
	}

	// Update is called once per frame
	void Update()
	{
		

	}

	public void OnButtonPressed(VirtualButtonAbstractBehaviour vb)
	{

		paraReadIndex++;
		displayParagraph();
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
