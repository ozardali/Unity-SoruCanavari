using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class karakterHareket : MonoBehaviour {
	public float hiz, maxHiz;
	public bool yerdeMi;
	public bool canJump =true;


	public Button ayarlar;
	public GameObject ayarPanel;
	public Button restart;
	public Button exit;
	//public Button music;


	Rigidbody2D agirlik;
	Animator animator;

	private bool walk=false;
		

	void Start () {

		Button restartbtn = restart.GetComponent<Button> ();
		restartbtn.onClick.AddListener (yenidenBasla);
		Button exitbtn = exit.GetComponent<Button> ();
		exitbtn.onClick.AddListener (CikisYap);

		Button ayarbtn = ayarlar.GetComponent<Button> ();
		ayarbtn.onClick.AddListener (panelAc);
	

		agirlik = GetComponent<Rigidbody2D> ();
		animator = GetComponent<Animator> ();
	}




	void Update () {
		
		if (Input.GetKeyDown (KeyCode.Space)) {
			canJump = false;

			//	Timer = 0f;
			gameObject.GetComponent<Rigidbody2D> ().AddForce (Vector2.up * 205);
			gameObject.GetComponent<Animator> ().SetTrigger ("jump");
		} 
		if (Input.GetKey (KeyCode.D)|| Input.GetKey(KeyCode.RightArrow)) {
			gameObject.GetComponent<SpriteRenderer> ().flipX = false;

			gameObject.GetComponent<Rigidbody2D> ().AddForce (Vector2.right * 5);

			if (walk == false) {
				walk = true;
				gameObject.GetComponent<Animator> ().SetBool ("walk", walk);

			}


		}
		else if (Input.GetKey (KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) {

			gameObject.GetComponent<SpriteRenderer> ().flipX = true;

			gameObject.GetComponent<Rigidbody2D> ().AddForce (Vector2.left * 5);

			if (walk == false) {
				walk = true;
				gameObject.GetComponent<Animator> ().SetBool ("walk", walk);

			}

		} else {
			walk = false;
			gameObject.GetComponent<Animator> ().SetBool ("walk", walk);
		}


	}
	void FixedUpdate () {
		float h = Input.GetAxis ("Horizontal");
		agirlik.AddForce (Vector2.right * h * hiz);
		// a ya basınca hız - ye dönüyor mathf abs ile hız +lanıyor
		animator.SetFloat ("speed", Mathf.Abs(h));
		animator.SetBool("yerde",yerdeMi);
		/*
		if (h > 0.1f) 
		{
			transform.localScale = new Vector2 (0.4f, 0.4f);
		}
		if (h < 0.1f) 
		{
			transform.localScale = new Vector2 (-0.4f, 0.4f);
		}
*/
		if (agirlik.velocity.x > maxHiz)
		{
			agirlik.velocity = new Vector2 (maxHiz, agirlik.velocity.y);
		}
		if (agirlik.velocity.x < -maxHiz)
		{
			agirlik.velocity = new Vector2 (-maxHiz, agirlik.velocity.y);
		}
	}
	public void CikisYap()

	{
		Application.Quit ();
	}
	public void yenidenBasla()
	{
		SceneManager.LoadScene(SceneManager.GetSceneAt(0).name);
		sahne1.anahtar = 0;
		sahne1.kutu = 0;

		sahne2.anahtar = 0;
		sahne2.kutu = 0;

		sahne3.anahtar = 0;
		sahne3.kutu = 0;
		Time.timeScale=1;
	}


	public void panelAc()

	{
		if(ayarPanel.activeSelf== true) {
		
			ayarPanel.SetActive (false);
			Time.timeScale=1;
		} else {
			
				Time.timeScale =0;

			ayarPanel.SetActive (true);
		}
	}


}
