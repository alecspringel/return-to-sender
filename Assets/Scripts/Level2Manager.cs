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
				CongratsText.GetComponent<Text>().text = "Troposphere Complete!!!";
			}
		}
		if(((int)(t%60)) >= 3) {
			Destroy(CongratsText);
			if(((int)(t%60)) < 9) {
				NowText.GetComponent<Text>().text = "Now we have to tackle the second layer of Earth's atmosphere: The Stratosphere";
			}
		}
		if(((int)(t%60)) >= 9) {
			Destroy(NowText);
			if(((int)(t%60)) < 15) {
				WatchText.GetComponent<Text>().text = "Things are getting a little trickier, be careful!\n\nTIP: You move faster while jumping.";
			}
		}
		if(((int)(t%60)) >= 15) {
			Destroy(WatchText);
			Destroy(Alien);
			Destroy(Level2Image);
		}
	}
}


