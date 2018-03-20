using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundPlay : MonoBehaviour
{

	private GameManagerScript GMS;

	public AudioSource correct_sound, wrong_sound;

private GameObject correctText, wrongText;


	// Use this for initialization
	void Start()
	{

		GMS = GameObject.Find("GameManager").GetComponent<GameManagerScript>();
			correctText = GameObject.Find("CorrectText");
		correctText.SetActive(false);

		wrongText = GameObject.Find("WrongText");
		wrongText.SetActive(false);

	}

	// Update is called once per frame
	void Update()
	{

	}

	public void soundWrongNow()
	{


			wrong_sound.Play();
	
	}

	public void soundCorrectNow()
	{

			correct_sound.Play();


	}

	public void showCorrectText()
	{

		correctText.SetActive(true);

	}

public void hideCorrectText()
{

	correctText.SetActive(false);

}

public void showWrongText()
{

wrongText.SetActive(true);

}

public void hideWrongText()
{

wrongText.SetActive(false);

}





}
