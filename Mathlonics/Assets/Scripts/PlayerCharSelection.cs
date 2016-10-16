using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class PlayerCharSelection : MonoBehaviour {

	public List<Sprite> PlayerImages;
	public Image SelectedImage;
	public int imageIndex = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void PlayerNextImage()
	{
		if (imageIndex <= PlayerImages.Count - 1) 
		{
			imageIndex++;
		}
		if (imageIndex > PlayerImages.Count - 1) 
		{
			imageIndex = 0;
		}

		SelectedImage.sprite = PlayerImages [imageIndex];
	}

	public void PlayerPreviousImage()
	{
		if (imageIndex >= 0) 
		{
			imageIndex--;
		}
		if (imageIndex < 0) 
		{
			imageIndex = PlayerImages.Count - 1;
		}

		SelectedImage.sprite = PlayerImages [imageIndex];
	}
}
