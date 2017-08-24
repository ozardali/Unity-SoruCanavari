using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class register : MonoBehaviour
{

	// REGiSTER FORMU //



	public GameObject kayitform;
	public Button kapa;

	// Textboxlar
	public Text durum;
	public Text kontrol2;



	public InputField registerusername;
	public InputField registersifre;


	public Button kayitol;


	public string RegisterIs="";

	IEnumerator BaglantiKontrol()		{
		WWW www3;
		www3 = new WWW("http://unity.ozardali.com/baglanti.txt");
		yield return www3;
		if (www3.error != null) {
			durum.text = "Ağ Bağlantısı Pasif";

		} else {

			durum.text = "Ağ Bağlantısı Mevcut";
		}

	}	

	void Start()
	{	
		StartCoroutine (BaglantiKontrol ());

		Button register4 = kayitol.GetComponent<Button> ();
		register4.onClick.AddListener (() => KayitSQL (registerusername.text, registersifre.text));
		Button btn7 = kapa.GetComponent<Button> ();
		btn7.onClick.AddListener (CikisYap);


	}


	public void CikisYap()

	{
		Application.Quit ();
	}

	void KayitSQL(string registerusername, string registersifre)
	{

		if (registerusername == "") {
			kontrol2.text = "Kullanıcı Adı Boş";
		} else if (registersifre == "") {
			kontrol2.text = "Şifre alanı boş";
		} else {

			string url2 = "http://unity.ozardali.com/unityRegister.php?username=" + registerusername + "&sifre=" + registersifre;
			WWW wregister = new WWW (url2);
			StartCoroutine (Connect (wregister));
		}


	}

	IEnumerator Connect(WWW wregister)
	{
		yield return wregister;
		if (wregister.error == null) {
			RegisterIs = wregister.text[0].ToString ();	

			if (RegisterIs == "1") {
				kontrol2.text = "Kayit Basarili";
				durum.text = "Ağ Bağlantısı Mevcut";
				yield return new WaitForSeconds(2);
				SceneManager.LoadScene(0);

			} 
			else {
				kontrol2.text = "Kayit Basarisiz";
			}

		}
		else {
			kontrol2.text = "Ag Baglantisi Pasif";
			durum.text = "Ağ Bağlantısı Pasif";
		}
	}
}