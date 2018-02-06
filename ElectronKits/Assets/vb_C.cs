using UnityEngine;
using Vuforia;

public class vb_C : MonoBehaviour, IVirtualButtonEventHandler
{
	private GameObject vbutton_C;

	public TextMesh showAnswer, showAnswer1, showAnswer22k,showAnswer1_5k,showAnswer1k;

	private GameObject explain_textbox22k, explain_textbox1_5k,explain_textbox1k;

	public static bool card22kTracked = false, card1_5kTracked = false, card1kTracked = false;
	public static bool sendCorrectAns22k = false, sendCorrectAns1_5k = false, sendCorrectAns1k = false;

	public GameObject correctBell, wrongBuzz, wrongOhNO;

	// Use this for initialization
	void Start()
	{
		vbutton_C = GameObject.Find("vb_C");
		vbutton_C.GetComponent<VirtualButtonBehaviour>().RegisterEventHandler(this);

		explain_textbox22k= GameObject.Find("Select_text22k");
		explain_textbox1_5k = GameObject.Find("Select_text1_5k");
		explain_textbox1k = GameObject.Find("Select_text1k");

		correctBell = GameObject.Find("correctBell");
		wrongBuzz= GameObject.Find("wrongBuzz");
		wrongOhNO = GameObject.Find("wrongOhNo");

	}

	// Update is called once per frame
	void Update()
	{

	}

	public void OnButtonPressed(VirtualButtonAbstractBehaviour vb)
	{
		card22kTracked = custom22kResistorTracker.resistor_22k;//Get answer from tracker class! (Answer is Option A)
		card1_5kTracked = custom1_5kResistanceTracker.resistor_1_5k;//Get answer from tracker class! (Answer is Option B)
		card1kTracked = Custom1kResistanceTracker.resistor_1k;//Get answer from tracker class! (Answer is Option D)

		//Check answer for 22K Resistor:
		if (card22kTracked == true)
		{
			showAnswer.text = "<b><color=red><size=200>C</size>   is  INCORRECT!</color></b>";//Answer is A
			showAnswer1.text = "<b><color=red><size=200>C</size>   is  INCORRECT!</color></b>";//Answer is A
			showAnswer22k.text = "<b><color=red><size=200>C</size>  is  INCORRECT!\n Try Again!</color></b>";//Answer is A

			explain_textbox22k.GetComponent<Renderer>().enabled = true;

			show_option.getCorrectAns22k = false;

			wrongBuzz.GetComponent<AudioSource>().Play();
		}

		//Check answer for 1.5K Resistor:
		if (card1_5kTracked == true)
		{
			showAnswer.text = "<b><color=red><size=200>C</size>   is  INCORRECT!</color></b>";//Answer is B
			showAnswer1.text = "<b><color=red><size=200>C</size>   is  INCORRECT!</color></b>";//Answer is B
			showAnswer1_5k.text = "<b><color=red><size=200>C</size>  is  INCORRECT!\n Try Again!</color></b>";

			explain_textbox1_5k.GetComponent<Renderer>().enabled = true;

			show_option.getCorrectAns1_5k = false;

			wrongBuzz.GetComponent<AudioSource>().Play();
		}


		//Check answer for 1K Resistor:
		if (card1kTracked == true)
		{
			showAnswer.text = "<b><color=red><size=200>C</size>   is  INCORRECT!</color></b>"; //Answer is D
			showAnswer1.text = "<b><color=red><size=200>C</size>   is  INCORRECT!</color></b>"; //Answer is D
			showAnswer1k.text = "<b><color=red><size=200>C</size>  is  INCORRECT!\n Try Again!</color></b>";  //Answer is D

			explain_textbox1k.GetComponent<Renderer>().enabled = true;

			show_option.getCorrectAns1k = false;

			wrongOhNO.GetComponent<AudioSource>().Play();
		}

	}

	public void OnButtonReleased(VirtualButtonAbstractBehaviour vb)
	{

	}


}
