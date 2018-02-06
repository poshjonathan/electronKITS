using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//NOTE TO SELF: THE STRING_DATABASE COMPONENT HAS TO BE AT THE BOTTOM!FOUND OUT AT HOSPITAL
public class string_database : MonoBehaviour {

	public static string correct_string, correct_string_22k;
	public static string wrong_string;
	public static string whats_string;	

	// Use this for initialization
	void Start () {

		correct_string = "<b><color=green>Correct! Well Done!</color></b>";
		correct_string_22k = "<b><color=green>Correct!\nThis is a 22 KΩ resistor!</color></b>";

		wrong_string = "<b><color=red>Wrong! Try Again!</color></b>";

		whats_string = "What is the value\nof this resistor?";



	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
