#pragma strict

var mainMenu : boolean = true;
var about : boolean;
var exit : boolean;
var MyGUISkin : GUISkin;
var MyGUISkin2 : GUISkin;

var clickSound : AudioClip;



function OnGUI() {
	GUILayout.BeginArea(new Rect(Screen.width/2-120, Screen.height/2-50, 200, 300), "");
	
	GUI.skin = MyGUISkin;
	
	GUILayout.Label("Main Menu");
	
	
	if(mainMenu == true) {
		if(GUILayout.Button("New Game")) {
			audio.PlayOneShot(clickSound);
			
			Application.LoadLevel(2);
			
		}
		
		if(GUILayout.Button("About")) {
			audio.PlayOneShot(clickSound);
			about = true;
			mainMenu = false;
		}
		
		if(GUILayout.Button("Quit")) {
			audio.PlayOneShot(clickSound);
			Application.Quit();
		}
	}
	
	if(about == true) {
	    GUI.skin = MyGUISkin2;
		GUILayout.Label("About");
		//GUILayout.Space(5);
		GUILayout.Label("This game is made by Black Raven Games Studio.");
		
		if(GUILayout.Button("Back")) {
			audio.PlayOneShot(clickSound);
			mainMenu = true;
			about = false;
		}
	}
	
	
	
	GUILayout.EndArea();
}