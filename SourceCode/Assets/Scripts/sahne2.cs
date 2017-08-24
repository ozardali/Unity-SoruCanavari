using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class sahne2 : MonoBehaviour {



	public string veriURL = "http://unity.ozardali.com/unityQuestion.php"; // php kodunuz

	// ANAHTAR KUTU VE SAHNE DEGiSiM KODLARı


	public static int anahtar=0;
	public static int kutu=0;
	public GameObject objeGenel;
	public Text anahtarSayi;
	public Text bilgiSayi;	
	public GameObject uyari;

	GameObject objeGenel2;

	// ANAHTAR KUTU BiTTi 

	public int i = 0;
	//string[] soru1=new string[4];
	public string[] soru4 = new string[6];
	public string[] soru5 = new string[6];
	public string[] soru6 = new string[6];

	// KUTULAR
	public GameObject kutu4ok;
	public GameObject kutu5ok;
	public GameObject kutu6ok;

	// kutu paneller

	public GameObject kutu4panel;
	public GameObject kutu5panel;
	public GameObject kutu6panel;
	// KUTU ACıKLAMA
	public Text kutu4label;
	public Text kutu5label;
	public Text kutu6label;


	void Start(){
		StartCoroutine(VeriGetir());
	}

	IEnumerator VeriGetir()
	{

		WWW sorulargelsin = new WWW(veriURL);
		yield return sorulargelsin;

		if (sorulargelsin.error != null)
		{
			Debug.Log ("veri gelmedi");
		}
		else
		{
			string[] parcalar = sorulargelsin.text.Split('!');
			foreach (string parca in parcalar)
			{
				//Debug.Log (parca);
			}
			System.Array.Copy(parcalar,18,soru4,0,6);
			System.Array.Copy(parcalar,24,soru5,0,6);
			System.Array.Copy(parcalar,30,soru6,0,6);
		}
	}
	void destroyKutu()
	{
		objeGenel2.gameObject.SetActive (false);
	}

	void OnTriggerEnter2D(Collider2D obje2)
	{
		//Debug.Log (obje1.gameObject.name);
		objeGenel2 = obje2.gameObject;

		if (obje2.tag == "kutu4") {

			kutu = kutu + 1;
			bilgiSayi.text = kutu.ToString();
			kutu4label.text= soru4[0];

			kutu4panel.gameObject.SetActive(true);
			//kutu1ok.gameObject.SetActive (true);
			destroyKutu ();

		}

		if (obje2.tag == "kutu5") {

			kutu = kutu + 1;
			bilgiSayi.text = kutu.ToString();
			kutu5label.text= soru5[0];

			kutu5panel.gameObject.SetActive(true);
			//kutu2ok.gameObject.SetActive (true);
			destroyKutu ();

		}

		if (obje2.tag == "kutu6") {

			kutu = kutu + 1;
			bilgiSayi.text = kutu.ToString();
			kutu6label.text= soru6[0];

			kutu6panel.gameObject.SetActive(true);
			//kutu3ok.gameObject.SetActive (true);
			destroyKutu ();

		}

		if (obje2.gameObject.tag == "kapi") 
		{

			if ((anahtar == 1) && (kutu ==3)){
				gitsahne ();
			}
			else {
				//Debug.Log ("Anahtarı almalı ve tüm kutuları okumalısın.");
				uyari.gameObject.SetActive (true);
			}
		}

		if (obje2.gameObject.tag == "anahtar") {

			anahtar = 1;
			anahtarSayi.text = "1";
			obje2.gameObject.SetActive (false);

		}
	}
	public static void gitsahne()
	{

		SceneManager.LoadScene(7);	

	}

}
