using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class sahneFinal : MonoBehaviour {

	public  Soru[] sorular;
	private static List<Soru> sorulmamisSorular;
	private Soru simdikiSoru;

	public Button yenidenBasla;
	public Text soruText;
	public Button buton1;
	public Button buton2;
	public Button buton3;

	public Text bittiTxt;
	public GameObject soruPaneli;
	public GameObject oyunBittiPaneli;

	public static int canavarHP = 100;
	public static int karakterHP = 100;
	public Text canavarCan;
	public Text karakterCan;

	void Start () {
		Button btn = yenidenBasla.GetComponent<Button> ();
		btn.onClick.AddListener (yeniden);
		if (sorulmamisSorular == null) {
			sorulmamisSorular = sorular.ToList<Soru> ();
		}

		if (sorulmamisSorular.Count <= 0) {
			oyunBitti ();
		} else {
			karakterCan.text = karakterHP.ToString();
			canavarCan.text = canavarHP.ToString();
			SoruSor ();
			//Debug.Log (sorulmamisSorular.Count ());
		}

	}

	void yeniden () 
	{
		sahne1.anahtar = 0;
		sahne1.kutu = 0;
		sahne2.anahtar = 0;
		sahne2.kutu = 0;
		sahne3.anahtar = 0;
		sahne3.kutu = 0;
		Application.Quit ();

	}

	void SoruSor ()
	{
		
		int soruIndexi = Random.Range (0, sorulmamisSorular.Count);
		simdikiSoru = sorulmamisSorular[soruIndexi];
		soruText.text = simdikiSoru.soru;

		buton1.GetComponentInChildren<Text> ().text = simdikiSoru.aSikki;
		buton2.GetComponentInChildren<Text> ().text = simdikiSoru.bSikki;
		buton3.GetComponentInChildren<Text> ().text = simdikiSoru.cSikki;


		sorulmamisSorular.RemoveAt (soruIndexi);




	}

	public void secenekA(){
		if (simdikiSoru.cevap == 1) {
			buton1.GetComponent<Image> ().color = Color.green;
			canavarHP = canavarHP - 10;
		} else {
			buton1.GetComponent<Image> ().color = Color.red;
			karakterHP= karakterHP-10;
		}

		StartCoroutine (sonrakiSoru());
	}

	public void secenekB(){
		if (simdikiSoru.cevap == 2) {
			buton2.GetComponent<Image> ().color = Color.green;
			canavarHP = canavarHP - 10;
		} else {
			buton2.GetComponent<Image> ().color = Color.red;
			karakterHP= karakterHP-10;
		}

		StartCoroutine (sonrakiSoru());
	}

	public void secenekC(){
		if (simdikiSoru.cevap == 3) {
			buton3.GetComponent<Image> ().color = Color.green;
			canavarHP = canavarHP - 10;
		} else {
			buton3.GetComponent<Image> ().color = Color.red;
			karakterHP= karakterHP-10;
		}

		StartCoroutine (sonrakiSoru());
	}

	IEnumerator sonrakiSoru(){
		yield return new WaitForSeconds (1);
		SceneManager.LoadScene (8);

	}

	public void oyunBitti(){
		if (canavarHP < karakterHP) {
			bittiTxt.text = "Tebrikler Oyunu Kazandınız.";
		
			yenidenBasla.gameObject.SetActive (true);
			soruPaneli.SetActive (false); 
			buton1.gameObject.SetActive (false);
			buton2.gameObject.SetActive (false);
			buton3.gameObject.SetActive (false);
			oyunBittiPaneli.SetActive (true);
			karakterCan.text = karakterHP.ToString ();
			canavarCan.text = canavarHP.ToString ();
		} else {
			bittiTxt.text = "Maalesef Oyunu Kaybettiniz.";
			yenidenBasla.gameObject.SetActive (true);

			soruPaneli.SetActive (false); 
			buton1.gameObject.SetActive (false);
			buton2.gameObject.SetActive (false);
			buton3.gameObject.SetActive (false);
			oyunBittiPaneli.SetActive (true);
			karakterCan.text = karakterHP.ToString ();
			canavarCan.text = canavarHP.ToString ();
		}
	}



}
