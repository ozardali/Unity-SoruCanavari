using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UnityStandardAssets._2D
{
    public class Restarter : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.tag == "Player")
            {
                SceneManager.LoadScene(SceneManager.GetSceneAt(0).name);
				sahne1.anahtar = 0;
				sahne1.kutu = 0;

				sahne2.anahtar = 0;
				sahne2.kutu = 0;

				sahne3.anahtar = 0;
				sahne3.kutu = 0;
            }
        }
    }
}
