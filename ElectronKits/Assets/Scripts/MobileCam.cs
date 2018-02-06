using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class MobileCam : MonoBehaviour
{

	private bool camAvailable;
	private Texture defaultBackground;

	private WebCamTexture cameraTexture;

	public RawImage background;
	public AspectRatioFitter fit;
	public bool frontFacing;

	public Text rgbtext1,rgbtext2,rgbtext3,rgbtext4;
	public Text exactcolortext1,exactcolortext2,exactcolortext3;
	public Text resistorvalueonscreen;
	public Color color1, color2, color3, color4;

	public float firstbandcode = 0;
	public float secondbandcode = 0;
	public float thirdbandcode = 0;
	public float fourthbandcode = 0;
	public float resistorvalue = 0;

	// Use this for initialization
	void Start()
	{
		defaultBackground = background.texture;
		WebCamDevice[] devices = WebCamTexture.devices;

		if (devices.Length == 0)
			return;

		for (int i = 0; i < devices.Length; i++)
		{
			var curr = devices[i];

			if (curr.isFrontFacing == frontFacing)
			{
				cameraTexture = new WebCamTexture(curr.name, Screen.width, Screen.height);
				break;
			}
		}

		if (cameraTexture == null)
			return;

		cameraTexture.Play(); // Start the camera
		background.texture = cameraTexture; // Set the texture

		camAvailable = true; // Set the camAvailable for future purposes.




	}

	public float redElement(Color red)
	{
		return red.r;	}

	public float greenElement(Color green)
	{
		return green.g;	}

	public float blueElement(Color blue)
	{
		return blue.b;	}
	
	//-----------------------------------------------------------------Black Value = 0 
	public bool isBlack(Color color)
	{
		if (color.r < 0.06 && color.g < 0.06 && color.b < 0.06)
		{
			return true;
		}

		else
		{	
			return false;
		}	
	}

	//-----------------------------------------------------------------Brown Value = 1
	/*public bool isBrown(Color color)
	{
		if (color.r > 0.4 && color.g < 0.1 && color.b < 0.1)
		{
			return true;
		}

		else
		{
			return false;
		}	
	}
	*/

	//-----------------------------------------------------------------Red Value = 2
	public bool isRed(Color color)
	{
		if (color.r > 0.3 && color.r < 1 &&
			color.g< 0.25 &&
		   	color.b< 0.25)
		{
			return true;
		}

		else
		{
			return false;
		}
	}


	//-----------------------------------------------------------------Orange Value = 3
	public bool isOrange(Color color)
	{
		if (color.r > 0.4 && color.r < 1 &&
			color.g > 0.25  && color.g < 0.6 &&
		   	color.b< 0.3)
		{
			return true;
		}

		else
		{
			return false;
		}	
	}


	//-----------------------------------------------------------------Yellow Value = 4
	public bool isYellow(Color color)
	{
		if (color.r  >0.6 && color.r  <0.65 && 
		    color.g >0.78 && color.g <0.86 &&
		    color.b < 0.3)
		{
			return true;
		}

		else
		{
			return false;
		}
	}

	//-----------------------------------------------------------------Green Value = 5
	public bool isGreen(Color color)
	{
		if (color.r > 0.07 && color.r < 0.12 &&
			color.g > 0.4 && color.g < 0.45 &&
			color.b > 0.05 && color.b< 0.1)
		{
			return true;
		}

		else
		{
			return false;
		}	
	}

	//-----------------------------------------------------------------Blue Value = 6
	public bool isBlue(Color color)
	{
		if (color.r < 0.01 &&
			color.g < 0.06 &&
			color.b > 0.2 && color.b < 0.4)
		{
			return true;
		}

		else
		{
			return false;
		}	
	}

	//-----------------------------------------------------------------Violet Value = 7
	public bool isViolet(Color color)
	{
		if (color.r > 0.07 && color.r < 0.12 &&
			color.g > 0.4 && color.g < 0.45 &&
			color.b > 0.05 && color.b < 0.05)
		{
			return true;
		}

		else
		{
			return false;
		}	
	}

	//-----------------------------------------------------------------Grey Value = 8
	public bool isGrey(Color color)
	{
		if (color.r > 0.07 && color.r < 0.12 &&
			color.g > 0.4 && color.g < 0.45 &&
			color.b > 0.05 && color.b < 0.05)
		{
			return true;
		}

		else
		{
			return false;
		}	
	}

	//-----------------------------------------------------------------White Value = 9
	public bool isWhite(Color color)
	{
		if (color.r > 0.73 && color.r < 0.79 &&
			color.g > 0.74 && color.g < 0.79 &&
			color.b > 0.75 && color.b < 0.82)
		{
			return true;
		}

		else
		{
			return false;
		}	
	}

	//-----------------------------------------------------------------Gold Value
	public bool isGold(Color color)
	{
		if (color.r > 0.07 && color.r < 0.12 &&
			color.g > 0.4 && color.g < 0.45 &&
			color.b > 0.05 && color.b < 0.05)
		{
			return true;
		}

		else
		{
			return false;
		}	
	}

	//-----------------------------------------------------------------Silver Value
	public bool isSilver(Color color)
	{
		if (color.r > 0.07 && color.r < 0.12 &&
			color.g > 0.4 && color.g < 0.45 &&
			color.b > 0.05 && color.b < 0.05)
		{
			return true;
		}

		else
		{
			return false;
		}	
	}

	// Update is called once per frame
	void Update()
	{
		//IntPtr pointer = cameraTexture.GetNativeTexturePtr();
		//texture2d.UpdateExternalTexture(pointer);
		//var color = texture2d.GetPixelBilinear((float)0.5, (float)0.5);

		color1 = cameraTexture.GetPixel(956, 1621);
		color2 = cameraTexture.GetPixel(976, 1621);
		color3 = cameraTexture.GetPixel(996, 1621);
		color4 = cameraTexture.GetPixel(1016, 1621);
		//var color3 = cameraTexture.GetPixel(956, 1600);

		//int width = (cameraTexture.width);
		//int height = (cameraTexture.requestedHeight)/2;

		//Check if color is BLACK [0]
		//if (isBlack(color1) ==true)
		//{
		//	firstbandcode = 0;
		//	exactcolortext1.text = "The colour is: BLACK\nThis color represent: " + firstbandcode;
		//}

		firstbandcode= updateColorVal(color1);
		secondbandcode= updateColorVal(color2);
		thirdbandcode= updateColorVal(color3);
		fourthbandcode= updateColorVal(color4);

		exactcolortext1.text = showTextColor(color1,1);
		exactcolortext2.text = showTextColor(color2,2);
		exactcolortext3.text = showTextColor(color3, 3);


		if (thirdbandcode == 2)
		{

			resistorvalue=(firstbandcode+(secondbandcode*10))/10;
		}

		if (thirdbandcode == 3)
		{

			resistorvalue=(firstbandcode+(secondbandcode*10));
		}
		if (thirdbandcode == 4)
		{

			resistorvalue=(firstbandcode+(secondbandcode*10))*10;
		}

		if (thirdbandcode == 5)
		{

			resistorvalue=(firstbandcode+(secondbandcode*10))*100000;
		}
		if (thirdbandcode == 6)
		{

			resistorvalue=(firstbandcode+(secondbandcode*10))*1000000;
		}

		if (thirdbandcode == 7)
		{

			resistorvalue=(firstbandcode+(secondbandcode*10))*10000000;
		}

		resistorvalueonscreen.text = "The resistor value is:" + resistorvalue +" K OHM";

		//resistorValText.text = firstbandcode.ToString();

		/*Check if color is YELLOW [4]
		if (isYellow(color1) ==true)
		{
			firstbandcode = 4;
			exactcolortext1.text = "The colour is: YELLOW\nThis color represent: " + firstbandcode;
		}

		//Check if color is GREEN [5]
		if (isGreen(color1) ==true)
		{
			firstbandcode = 5;
			exactcolortext1.text = "The colour is: GREEN\nThis color represent: " + firstbandcode;
		}

		//Check if color is BLUE [6]
		if (isBlue(color1) ==true)
		{
			firstbandcode = 6;
			exactcolortext1.text = "The colour is: BLUE\nThis color represent: " + firstbandcode;
		}

		//Check if color is Violet [7]
		if (isViolet(color1) ==true)
		{
			firstbandcode = 7;
			exactcolortext1.text = "The colour is: Violet\nThis color represent: " + firstbandcode;
		}

		//Check if color is Grey [8]
		if (isGrey(color1) ==true)
		{
			firstbandcode = 8;
			exactcolortext1.text = "The colour is: GREY\nThis color represent: " + firstbandcode;
		}

		//Check if color is White [9]
		if (isWhite(color1) ==true)
		{
			firstbandcode = 9;
			exactcolortext1.text = "The colour is: WHITE\nThis color represent: " + firstbandcode;
		}

*/
		rgbtext1.text = "colour is: " + color1;
		rgbtext2.text = "colour is: " + color2;
		rgbtext3.text = "colour is: " + color3;
		rgbtext4.text = "colour is: " + color4;
		//+ width.ToString() + height.ToString();

		if (!camAvailable)
			return;

		float ratio = (float)cameraTexture.width / (float)cameraTexture.height;
		fit.aspectRatio = ratio; // Set the aspect ratio

		float scaleY = cameraTexture.videoVerticallyMirrored ? -1f : 1f; // Find if the camera is mirrored or not
		background.rectTransform.localScale = new Vector3(1f, scaleY, 1f); // Swap the mirrored camera

		int orient = -cameraTexture.videoRotationAngle;
		background.rectTransform.localEulerAngles = new Vector3(0, 0, orient);




	}



	public float updateColorVal(Color color) {
		//Check if color is BLACK [0]
		if (isBlack(color) ==true)
		{
			return 0;
		}

		/*if (isBrown(color) ==true)
		{
			return 1;
		}*/

		if (isRed(color) ==true)
		{
			return 2;
		}

		if (isOrange(color) ==true)
		{
			return 3;
		}

		if (isYellow(color) ==true)
		{
			return 4;
		}

		if (isGreen(color) ==true)
		{
			return 5;
		}

		return 999;

	}

	public string showTextColor(Color color, int bandIndex)
	{
		string showText;

		//Check if color is BLACK [0]
		if (isBlack(color) == true)
		{
			showText = "Band "+bandIndex + " colour is: BLACK!  This color represent: 0" ;
			return showText;
		}

		//Check if color is BROWN [1]
		/*if (isBrown(color) == true)
		{
			showText = "Band "+bandIndex + " colour is: BLACK!  This color represent: 0" ;
			return showText;
		}*/

		//Check if color is Red [2]
		if (isRed(color) == true)
		{
			showText = "Band "+bandIndex + " colour is: RED!  This color represent: 2" ;
			return showText;
		}
				
		//Check if color is Orange [3]
		if (isOrange(color) == true)
		{
			showText = "Band "+bandIndex + " colour is: Orange!  This color represent: 3" ;
			return showText;
		}
				
		/*Check if color is BLACK [0]
		if (isBlack(color) == true)
		{
			showText = "Band "+bandIndex + " colour is: BLACK!  This color represent: 0" ;
			return showText;
		}
				
		//Check if color is BLACK [0]
		if (isBlack(color) == true)
		{
			showText = "Band "+bandIndex + " colour is: BLACK!  This color represent: 0" ;
			return showText;
		}*/


		else
		{
			showText = "no color";
			return showText;
		}

	}



}



