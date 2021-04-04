using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchCharacterFour : MonoBehaviour
{
	// referenses to controlled game objects
	public GameObject avatar1, avatar2;

	// variable contains which avatar is on and active
	int whichAvatarIsOn = 1;

	// Use this for initialization
	void Start()
	{

		int choosenSkin = PlayerPrefs.GetInt("Skin");
		if (choosenSkin == 5)
		{
			avatar1.gameObject.SetActive(false);
			avatar2.gameObject.SetActive(true);
		}
	}

	// public method to switch avatars by pressing UI button
	public void SwitchAvatar()
	{

		// processing whichAvatarIsOn variable
		switch (whichAvatarIsOn)
		{

			// if the first avatar is on
			case 1:

				whichAvatarIsOn = 2;
				PlayerPrefs.SetInt("Skin", 5);

				// disable the first one and anable the second one
				avatar1.gameObject.SetActive(false);
				avatar2.gameObject.SetActive(true);
				break;

			// if the second avatar is on
			case 2:

				// then the first avatar is on now
				whichAvatarIsOn = 1;
				PlayerPrefs.SetInt("Skin", 1);

				// disable the second one and anable the first one
				avatar1.gameObject.SetActive(true);
				avatar2.gameObject.SetActive(false);
				break;
		}
	}
}
