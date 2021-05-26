using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialManager : MonoBehaviour
{
	public GameObject taskText;
	public GameObject commandText;
	private int popUpIndex;

	void Update() {

		float movementHori = 0;
		float movementVert = 0;

		movementHori = Input.GetAxis("Horizontal");
		movementVert = Input.GetAxis("Vertical");

		if(popUpIndex == 0) {
			taskText.GetComponent<Text>().text = "Try Going Left!";
			commandText.GetComponent<Text>().text = "Use the 'A' Key";
			if(movementHori < 0) {
				taskText.GetComponent<Text>().text = "Try Going Right!";
				commandText.GetComponent<Text>().text = "Use the 'D' Key";
				popUpIndex++;
			}
		}
		else if(popUpIndex == 1) {
			if(movementHori > 0) {
				taskText.GetComponent<Text>().text = "Try Moving Forward!";
				commandText.GetComponent<Text>().text = "Use the 'W' Key";
				popUpIndex++;
			}
		}
		else if(popUpIndex == 2) {
			if(movementVert > 0) {
				taskText.GetComponent<Text>().text = "Try Moving Backwards!";
				commandText.GetComponent<Text>().text = "Use the 'S' Key";
				popUpIndex++;
			}
		}
		else if(popUpIndex == 3) {
			if(movementVert < 0) {
				taskText.GetComponent<Text>().text = "Try Jumping!";
				commandText.GetComponent<Text>().text = "Press the Space Bard";
				popUpIndex++;
			}
		}
		else if(popUpIndex == 4) {
			if(Input.GetButtonDown("Jump")) {
				taskText.GetComponent<Text>().fontSize = 10;
				commandText.GetComponent<Text>().fontSize = 9;
				commandText.GetComponent<Text>().color = new Color(1f, 0f, 0f);
				taskText.GetComponent<Text>().text = "Good job! You've figured out all the needed commands!";
				commandText.GetComponent<Text>().text = "When you're done exploring head to the finish line";
				popUpIndex++;
			}
		}
	}
}
