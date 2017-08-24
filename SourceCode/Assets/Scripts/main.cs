using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net.Sockets;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class main : MonoBehaviour
{

	// LOGİN - REGiSTER FORMU //
	public Button giris;
	public GameObject butonlar;
	public GameObject loginform;

	public Button kayit;
	public GameObject kayitform;

	public Button kapa;

	// Textboxlar
	public Text durum;
	public Text kontrol;
	public Text kontrol2;


	public InputField username;
	public InputField sifre;




	public Button girisyap;

	public string LoginIs="";


	IEnumerator BaglantiKontrol()		{
		WWW www;
		www = new WWW("http://unity.ozardali.com/baglanti.txt");
		yield return www;
		if (www.error != null) {
			durum.text = "Ağ Bağlantısı Pasif";

		} else {

			durum.text = "Ağ Bağlantısı Mevcut";
		}

	}	

		void Start()
	{	
		StartCoroutine (BaglantiKontrol ());
		Button btn = giris.GetComponent<Button> ();
		btn.onClick.AddListener (GirisForm);

		Button btn2 = kayit.GetComponent<Button> ();
		btn2.onClick.AddListener (KayitForm);

		Button btn3 = girisyap.GetComponent<Button> ();
		btn3.onClick.AddListener (() => GirisSQL (username.text, sifre.text));

		Button btn4 = kapa.GetComponent<Button> ();
		btn4.onClick.AddListener (CikisYap);

	
	}
	public void CikisYap()

	{
		Application.Quit ();
	}
		void GirisForm()
		{
		
		butonlar.gameObject.SetActive (false);
		loginform.gameObject.SetActive (true);

		}

		void KayitForm()
		{
		SceneManager.LoadScene(2);	
		}

	void GirisSQL(string username, string sifre)
	{


		if (username == "") {
			kontrol.text = "Kullanıcı Adı Boş";
		} else if (sifre == "") {
			kontrol.text = "Şifre alanı boş";
		} else {

			string url = "http://unity.ozardali.com/unityLogin.php?username=" + username + "&sifre=" + sifre;
			WWW www2 = new WWW (url);
			StartCoroutine (Connect (www2));
		}

	}


	IEnumerator Connect(WWW www2)
	{
		yield return www2;
		if (www2.error == null) {
			LoginIs = www2.text[0].ToString ();	

			if (LoginIs == "1") {
				kontrol.text = "Giris Basarili";
				durum.text = "Ağ Bağlantısı Mevcut";
				yield return new WaitForSeconds(2);
				SceneManager.LoadScene(1);




			} else {
				kontrol.text = "Bilgiler Yanlis";
			}
		} else {
			kontrol.text = "Ag Baglantisi Pasif";
			durum.text = "Ağ Bağlantısı Pasif";
		}
	}
}