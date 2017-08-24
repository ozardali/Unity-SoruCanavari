using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class sahne1 : MonoBehaviour {
	public string veriURL = "http://unity.ozardali.com/unityQuestion.php"; // php kodunuz

	// ANAHTAR KUTU VE SAHNE DEGiSiM KODLARı


	public  static int anahtar=0;
	public static int kutu=0;
	public GameObject objeGenel;
	public Text anahtarSayi;
	public GameObject uyari;


	// ANAHTAR KUTU BiTTi 


	public int i = 0;
	//string[] soru1=new string[4];
	public string[] soru1 = new string[6];
	public string[] soru2 = new string[6];
	public string[] soru3 = new string[6];
	GameObject objeGenel1;
	public Text bilgiSayi;	
	// KUTULAR
	public GameObject kutu1ok;
	public GameObject kutu2ok;
	public GameObject kutu3ok;

	// kutu paneller

	public GameObject kutu1panel;
	public GameObject kutu2panel;
	public GameObject kutu3panel;
	// KUTU ACıKLAMA
	public Text kutu1label;
	public Text kutu2label;
	public Text kutu3label;



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
			System.Array.Copy(parcalar,0,soru1,0,6);
			System.Array.Copy(parcalar,6,soru2,0,6);
			System.Array.Copy(parcalar,12,soru3,0,6);
		}
	}
	void destroyKutu()
	{
		objeGenel1.gameObject.SetActive (false);
	}

	void OnTriggerEnter2D(Collider2D obje1)
	{
		//Debug.Log (obje1.gameObject.name);
		objeGenel1 = obje1.gameObject;

		if (obje1.tag == "kutu1") {

			kutu = kutu + 1;
			bilgiSayi.text = kutu.ToString();
			kutu1label.text= soru1[0];

			kutu1panel.gameObject.SetActive(true);
			//kutu1ok.gameObject.SetActive (true);
			destroyKutu ();

		}

		if (obje1.tag == "kutu2") {

			kutu = kutu + 1;
			bilgiSayi.text = kutu.ToString();
			kutu2label.text= soru2[0];

			kutu2panel.gameObject.SetActive(true);
			//kutu2ok.gameObject.SetActive (true);
			destroyKutu ();

		}

		if (obje1.tag == "kutu3") {

			kutu = kutu + 1;
			bilgiSayi.text = kutu.ToString();
			kutu3label.text= soru3[0];

			kutu3panel.gameObject.SetActive(true);
			//kutu3ok.gameObject.SetActive (true);
			destroyKutu ();

		}



		if (obje1.gameObject.tag == "kapi") 
		{

			if ((anahtar == 1) && (kutu ==3)){
				gitsahne ();
			}
			else {
				//Debug.Log ("Anahtarı almalı ve tüm kutuları okumalısın.");
				uyari.gameObject.SetActive (true);
			}
		}

		if (obje1.gameObject.tag == "anahtar") {

			anahtar = 1;
			anahtarSayi.text = "1";
			obje1.gameObject.SetActive (false);

		}
	}


	public static void gitsahne()
	{

		SceneManager.LoadScene(6);	

	}



}
