using UnityEngine;
using System.Collections;

public class ScreenFadeOut : MonoBehaviour
{
	public float fadeSpeed = 0.5f;          // Speed that the screen fades to and from black.
	
	
	public static bool endOfGame = false;      // Whether or not the scene is still fading in.

	void Update ()
	{
		// If the scene is starting...
		if(endOfGame)
			// ... call the StartScene function.
			EndScene();
		else 
			guiTexture.enabled = false;
	}

	void FadeToBlack ()
	{
		// Lerp the colour of the texture between itself and black.
		guiTexture.color = Color.Lerp(guiTexture.color, Color.black, fadeSpeed * Time.deltaTime);
	}
	
	public void EndScene ()
	{
		// Make sure the texture is enabled.
		guiTexture.enabled = true;
		
		// Start fading towards black.
		FadeToBlack();
	}

	void Start() {
		guiTexture.color = Color.clear;
		endOfGame = false;
		guiTexture.enabled = false;
	}
}