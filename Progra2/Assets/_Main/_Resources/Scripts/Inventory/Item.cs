using System;
using UnityEngine;
using UnityEngine.SceneManagement;
namespace _Main._Resources.Scripts.Inventory
{
    public class Item : MonoBehaviour
    {
        [SerializeField] private GameObject Key;
        [SerializeField] private string _levelToLoad;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                Key.SetActive(true);
                Debug.Log("Collected");
                Cursor.lockState = CursorLockMode.None;
                OnLevelChange?.Invoke();
                SceneManager.LoadScene(_levelToLoad);
            }
        }


        public static event Action OnLevelChange;
        //unity event
    }
}
