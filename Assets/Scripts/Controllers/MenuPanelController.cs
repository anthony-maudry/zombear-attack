using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuPanelController : MonoBehaviour {
	
	const string DISPLAY_MENU_BOOL = "DisplayMenu";
	const int VOLUME_MUTIPLIER = 8;

	public static bool IsMenuDisplayed = false;

	public AudioSource backgroundMusic;
	public Slider musicSlider;
	public Toggle musicToggle;

	private GameObject menuPanelCanvas;
	private Animator menuPanelAnimator;

	void Awake () {
		menuPanelCanvas = GameObject.FindGameObjectWithTag ("MenuPanelCanvas");
		menuPanelAnimator = menuPanelCanvas.GetComponent<Animator> ();
		SetNotDisplayed ();
	}

	void Start () {
		musicSlider.value = backgroundMusic.volume * VOLUME_MUTIPLIER;
	}

	void ClosePanel () {
		menuPanelAnimator.SetBool (DISPLAY_MENU_BOOL, false);
		SetDisplayed (false);
	}

	void TogglePanel () {
		bool displayed = menuPanelAnimator.GetBool (DISPLAY_MENU_BOOL);
		menuPanelAnimator.SetBool (DISPLAY_MENU_BOOL, !displayed);
		SetDisplayed (!displayed);
	}

	void SetDisplayed (bool displayed) {
		if (displayed) {
			IsMenuDisplayed = true;
		} else {
			Invoke ("SetNotDisplayed", 0.5f);
		}
	}

	void SetNotDisplayed () {
		IsMenuDisplayed = false;
	}

	public void Update () {
		if (Input.GetKeyDown (KeyCode.Escape)) {
			TogglePanel ();
		}
	}
	
	public void OnClickCloseButton () {
		ClosePanel ();
	}

	public void OnClickRestartButton () {
		
		SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
	}

	public void OnClickQuitButton () {
		ClosePanel ();
		#if UNITY_EDITOR 
		EditorApplication.isPlaying = false;
		#else 
		Application.Quit();
		#endif
	}

	public void OnMusicSliderValueChanged (float value) {
		backgroundMusic.volume = musicSlider.value / VOLUME_MUTIPLIER;
	}

	public void OnMusicToggleChanged (bool musicOn) {
		if (musicToggle.isOn) {
			backgroundMusic.Play ();
		} else {
			backgroundMusic.Stop ();
		}
	}
}
