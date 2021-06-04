using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level2Manager : MonoBehaviour
{
	public GameObject CongratsText;
	public GameObject NowText;
	public GameObject WatchText;
	public GameObject Alien;
	public GameObject Level2Image;


	void Update() {
		if(((int)(Time.time - Time.deltaTime)) >= 0) {
			if(((int)(Time.time - Time.deltaTime)) < 3) {
				CongratsText.GetComponent<Text>().text = "Troposphere Complete!!!";
			}
		}
		if(((int)(Time.time - Time.deltaTime)) >= 3) {
			Destroy(CongratsText);
			if(((int)(Time.time - Time.deltaTime)) < 9) {
				NowText.GetComponent<Text>().text = "Now we have to tackle the second layer of Earth's atmosphere: The Stratosphere";
			}
		}
		if(((int)(Time.time - Time.deltaTime)) >= 9) {
			Destroy(NowText);
			if(((int)(Time.time - Time.deltaTime)) < 15) {
				WatchText.GetComponent<Text>().text = "Things are getting a little trickier, be careful!\n\nTIP: Press W/S and A/D to walk at an angle.";
			}
		}
		if(((int)(Time.time - Time.deltaTime)) >= 15) {
			Destroy(WatchText);
			Destroy(Alien);
			Destroy(Level2Image);
		}
	}
}


