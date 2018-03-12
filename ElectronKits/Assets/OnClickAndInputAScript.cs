using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnClickAndInputAScript : MonoBehaviour
{

	public TextMesh inputA_current, inputA_next;
	private bool bInput_current = false, bInput_next = true;
	public static int iInput_current, iInput_next;

	public AudioSource click_sound;

	private GameManagerScript chkClick;

	void Start()
	{
		convertToNum();
		inputA_current.text = iInput_current.ToString();
		inputA_next.text = iInput_next.ToString();


		chkClick = GameObject.Find("GameManager").GetComponent<GameManagerScript>();

	}

	void OnMouseDown()
	{


		bInput_current = !bInput_current;
		bInput_next = !bInput_next;

		convertToNum();
		inputA_current.text = iInput_current.ToString();
		inputA_next.text = iInput_next.ToString();

		click_sound.Play();

		chkClick.checkBtnClick = true;

	}

	void convertToNum()
	{
		if (bInput_current == true)
		{
			iInput_current = 1;
		}
		else
		{
			iInput_current = 0;
		}

		if (bInput_next == true)
		{
			iInput_next = 1;
		}

		else
		{
			iInput_next = 0;
		}

	}
}
