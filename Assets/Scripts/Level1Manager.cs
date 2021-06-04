using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level1Manager : MonoBehaviour
{
	public GameObject CongratsText;
	public GameObject NowText;
	public GameObject WatchText;
	public GameObject Alien;
	public GameObject Level1Image;

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

		if(((int)(t%60)) >= 0) {
			if(((int)(t%60)) < 3) {
				CongratsText.GetComponent<Text>().text = "You got me out of area51!!!";
			}
		}
		if(((int)(t%60)) >= 3) {
			Destroy(CongratsText);
			if(((int)(t%60)) < 9) {
				NowText.GetComponent<Text>().text = "Now we are onto the first layer of the atmosphere: The Troposphere";
			}
		}
		if(((int)(t%60)) >= 9) {
			Destroy(NowText);
			if(((int)(t%60)) < 15) {
				WatchText.GetComponent<Text>().text = "Let's be sure we don't run out of time, and help me collect shooting stars as treasures to bring home.";
			}
		}
		if(((int)(t%60)) >= 15) {
			Destroy(WatchText);
			Destroy(Alien);
			Destroy(Level1Image);
		}
	}
}

