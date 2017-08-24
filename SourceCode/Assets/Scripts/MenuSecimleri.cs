using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuSecimleri : MonoBehaviour {

	public void BolumAc (string BolumIsmi)
	{
		SceneManager.LoadScene(BolumIsmi);
	}

	public void CikisYap()

	{
		Application.Quit ();
	}

	public void Anasayfa()
	{
		SceneManager.LoadScene (1);
	}
	public void AnasayfaNoLog()
	{
		SceneManager.LoadScene (0);
	}

}
