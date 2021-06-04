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
				CongratsText.GetComponent<Text>().text = "Only one more level until I'm back to my spaceship!!";
			}
		}
		if(((int)(t%60)) >= 3) {
			Destroy(CongratsText);
			if(((int)(t%60)) < 9) {
				NowText.GetComponent<Text>().text = "Lastly we have: The Exosphere, the most intense level of the atmosphere yet... Good Luck to us both!";
			}
		}
		if(((int)(t%60)) >= 9) {
			Destroy(NowText);
			Destroy(Alien);
			Destroy(Level3Image);
		}
	}
}
