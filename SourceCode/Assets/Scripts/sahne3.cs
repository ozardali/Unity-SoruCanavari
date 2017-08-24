using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class sahne3 : MonoBehaviour {



	public string veriURL = "http://unity.ozardali.com/unityQuestion.php"; // php kodunuz

	// ANAHTAR KUTU VE SAHNE DEGiSiM KODLARı


	public static int anahtar=0;
	public static int kutu=0;
	public GameObject objeGenel;
	public Text anahtarSayi;
	public Text bilgiSayi;
	public GameObject uyari;


	// ANAHTAR KUTU BiTTi 

	public int i = 0;
	//string[] soru1=new string[4];
	public string[] soru7 = new string[6];
	public string[] soru8 = new string[6];
	public string[] soru9 = new string[6];
	public string[] soru10 = new string[6];
	GameObject objeGenel2;

	// KUTULAR
	public GameObject kutu7ok;
	public GameObject kutu8ok;
	public GameObject kutu9ok;
	public GameObject kutu10ok;
	// kutu paneller

	public GameObject kutu7panel;
	public GameObject kutu8panel;
	public GameObject kutu9panel;
	public GameObject kutu10panel;
	// KUTU ACıKLAMA
	public Text kutu7label;
	public Text kutu8label;
	public Text kutu9label;
	public Text kutu10label;



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
			System.Array.Copy(parcalar,36,soru7,0,6);
			System.Array.Copy(parcalar,42,soru8,0,6);
			System.Array.Copy(parcalar,48,soru9,0,6);
			System.Array.Copy(parcalar,54,soru10,0,6);
			Debug.Log(soru10[0]);
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

		if (obje2.tag == "kutu7") {

			kutu = kutu + 1;
			bilgiSayi.text = kutu.ToString();
			kutu7label.text= soru7[0];

			kutu7panel.gameObject.SetActive(true);
			//kutu1ok.gameObject.SetActive (true);
			destroyKutu ();

		}

		if (obje2.tag == "kutu8") {

			kutu = kutu + 1;
			bilgiSayi.text = kutu.ToString();
			kutu8label.text= soru8[0];

			kutu8panel.gameObject.SetActive(true);
			//kutu2ok.gameObject.SetActive (true);
			destroyKutu ();

		}

		if (obje2.tag == "kutu9") {

			kutu = kutu + 1;
			bilgiSayi.text = kutu.ToString();
			kutu9label.text= soru9[0];

			kutu9panel.gameObject.SetActive(true);
			//kutu3ok.gameObject.SetActive (true);
			destroyKutu ();

		}
		if (obje2.tag == "kutu10") {

			kutu = kutu + 1;
			bilgiSayi.text = kutu.ToString();
			kutu10label.text= soru10[0];

			kutu10panel.gameObject.SetActive(true);
			//kutu3ok.gameObject.SetActive (true);
			destroyKutu ();

		}

		if (obje2.gameObject.tag == "kapi") 
		{

			if ((anahtar == 1) && (kutu ==4)){
				gitsahne ();
			}
			else {
				Debug.Log ("Anahtarı almalı ve tüm kutuları okumalısın.");
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

		SceneManager.LoadScene(8);	

	}

}
