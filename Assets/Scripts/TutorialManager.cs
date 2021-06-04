using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialManager : MonoBehaviour
{
	public GameObject taskText;
	public GameObject commandText;
	public GameObject introImage;
	public GameObject warningText;
	public GameObject safetyLandingText;
	public GameObject GreetingsText;
	public GameObject IntroduceText;
	public GameObject InfoText;
	public GameObject Alien;
	public GameObject SecondIntroImage;
	public GameObject CrashText;
	public GameObject HelpText;
	public GameObject YesNoText;
	private int popUpIndex;

	public bool pauseTimer = false;
	public float clockTime;
	public float t;

	void Start()
    	{
        		t = clockTime;
	}

	void Update() {
        		if (!pauseTimer) {
            		t += Time.deltaTime;
        		}

		float movementHori = 0;
		float movementVert = 0;

		movementHori = Input.GetAxis("Horizontal");
		movementVert = Input.GetAxis("Vertical");

		if(((int)(t%60)) < 5) {
			if(((int)(t%60))%2 == 0) {
				warningText.GetComponent<Text>().text = "WARNING";
			}
			else {
				warningText.GetComponent<Text>().text = "";
			}
		}
		if(((int)(t%60)) >= 5) {
			Destroy(warningText);
			if(((int)(t%60)) < 15) {
				safetyLandingText.GetComponent<Text>().text = "Martian N0. 410, Your spaceship has ran out of fuel. Prepare for emergency landing.\n\nlocation: Area51";
			}
		}
		if(((int)(t%60)) >= 15) {
			Destroy(introImage);
			Destroy(safetyLandingText);
			if(((int)(t%60)) < 27) {
				GreetingsText.GetComponent<Text>().text = "Greetings Earthling!";
				IntroduceText.GetComponent<Text>().text = "I come in peace!!!\nAllow me to introduce myself....";
				InfoText.GetComponent<Text>().text = "\n\n\nName: Martian no. 410\nPlanet: 0x7E5\njob: galaxy explorer\nstatus: lost\n";
			}
		}
		if(((int)(t%60)) >= 27) {
			Destroy(GreetingsText);
			Destroy(IntroduceText);
			Destroy(InfoText);
			if(((int)(t%60)) < 35) {
				CrashText.GetComponent<Text>().text = "My spaceship has just crash landed here. Area51 is no place for any alien....";
			}
		}
		if(((int)(t%60)) >= 35) {
			Destroy(CrashText);
			if(((int)(t%60)) < 42) {
				HelpText.GetComponent<Text>().text = "i need your help to get me through the different levels of the atmosphere to my other spaceship before i get caught!";
			}
		}
		if(((int)(t%60)) >= 42) {
			Destroy(HelpText);
			if(((int)(t%60)) < 48) {
				YesNoText.GetComponent<Text>().text = "What do you say..........";
			}
		}
		if(((int)(t%60)) >= 48) {
			Destroy(YesNoText);
			Destroy(Alien);
			Destroy(SecondIntroImage);
		}
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
