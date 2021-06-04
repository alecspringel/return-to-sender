using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level3Manager : MonoBehaviour
{
	public GameObject CongratsText;
	public GameObject NowText;
	public GameObject Alien;
	public GameObject Level3Image;


	void Update() {
		if(((int)(Time.time - Time.deltaTime)) >= 0) {
			if(((int)(Time.time - Time.deltaTime)) < 3) {
				CongratsText.GetComponent<Text>().text = "Only one more level until I'm back to my spaceship!!";
			}
		}
		if(((int)(Time.time - Time.deltaTime)) >= 3) {
			Destroy(CongratsText);
			if(((int)(Time.time - Time.deltaTime)) < 9) {
				NowText.GetComponent<Text>().text = "Lastly we have: The Exosphere, the most intense level of the atmosphere yet... Good Luck to us both!";
			}
		}
		if(((int)(Time.time - Time.deltaTime)) >= 9) {
			Destroy(NowText);
			Destroy(Alien);
			Destroy(Level3Image);
		}
	}
}
