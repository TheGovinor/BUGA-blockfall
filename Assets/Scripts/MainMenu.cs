using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour {
	public Button joinIP;
	public Button joinLAN;
	public Button host;
	public Button connect;
	public InputField input;

	// Use this for initialization
	void Start () {
		input.gameObject.SetActive (false);
		connect.gameObject.SetActive (false);
	}
	
	public void OnHost()
	{
		SceneManager.LoadScene ("MultiLobby");
	}
	public void OnJoin()
	{
		joinLAN.gameObject.SetActive (false);
		joinIP.gameObject.SetActive (false);
		host.gameObject.SetActive (false);
		input.gameObject.SetActive (true);
		connect.gameObject.SetActive (true);
	}
	public void JoinServer ()
	{
		try {
			Network.Connect (input.text, 25000);
		} finally {
			Network.Connect ("127.0.0.1", 25000);
		}
	}
}
