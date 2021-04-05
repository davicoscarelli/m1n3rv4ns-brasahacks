using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchCharacterScript : MonoBehaviour
{

	// referenses to controlled game objects
	public GameObject avatar1, avatar2, avatar3, avatar4;

	// variable contains which avatar is on and active
	int whichAvatarIsOn = 1;

	// Use this for initialization
	void Start()
	{

		int choosenSkin = PlayerPrefs.GetInt("Skin");
		if (choosenSkin == 1 || choosenSkin == null) // original(1)
		{
			avatar1.gameObject.SetActive(true);
			avatar2.gameObject.SetActive(false);
			avatar3.gameObject.SetActive(false);
			avatar4.gameObject.SetActive(false);
		}
		if (choosenSkin == 2) //mario
		{
			avatar1.gameObject.SetActive(false);
			avatar2.gameObject.SetActive(true);
			avatar3.gameObject.SetActive(false);
			avatar4.gameObject.SetActive(false);
		}
		if (choosenSkin == 3) //minecraft
		{
			avatar1.gameObject.SetActive(false);
			avatar2.gameObject.SetActive(false);
			avatar3.gameObject.SetActive(true);
			avatar4.gameObject.SetActive(false);
		}
		if (choosenSkin == 4) //pokemon
		{
			avatar1.gameObject.SetActive(false);
			avatar2.gameObject.SetActive(false);
			avatar3.gameObject.SetActive(false);
			avatar4.gameObject.SetActive(true);
		}
	}

	// public method to switch avatars by pressing UI button
	public void SwitchAvatar()
	{
		whichAvatarIsOn = 1;
		PlayerPrefs.SetInt("Skins", 1);
		avatar1.gameObject.SetActive(true);
		avatar2.gameObject.SetActive(false);
		avatar3.gameObject.SetActive(false);
		avatar4.gameObject.SetActive(false);
	}

	public void SwitchAvatarTwo()
	{
		whichAvatarIsOn = 2;
		PlayerPrefs.SetInt("Skin", 2);
		avatar1.gameObject.SetActive(false);
		avatar2.gameObject.SetActive(true);
		avatar3.gameObject.SetActive(false);
		avatar4.gameObject.SetActive(false);

	}
	public void SwitchAvatarThree()
	{
		whichAvatarIsOn = 3;
		PlayerPrefs.SetInt("Skin", 3);
		avatar1.gameObject.SetActive(false);
		avatar2.gameObject.SetActive(false);
		avatar3.gameObject.SetActive(true);
		avatar4.gameObject.SetActive(false);
	}
	public void SwitchAvatarFour()
	{
		whichAvatarIsOn = 4;
		PlayerPrefs.SetInt("Skin", 4);
		avatar1.gameObject.SetActive(false);
		avatar2.gameObject.SetActive(false);
		avatar3.gameObject.SetActive(false);
		avatar4.gameObject.SetActive(true);
	}
}