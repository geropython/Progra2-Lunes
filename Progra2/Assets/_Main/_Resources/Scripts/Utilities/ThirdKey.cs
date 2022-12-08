using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace _Main._Resources.Scripts.Utilities
{
    public class ThirdKey : MonoBehaviour
    {
        [SerializeField] private GameObject SecondKey;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                SecondKey.SetActive(true);
                Debug.Log("Collected");
                Cursor.lockState = CursorLockMode.None;
                OnLevelChange?.Invoke();
                SceneManager.LoadScene("Level2");
            }
        }


        public static event Action OnLevelChange;
        //unity event
    }
}