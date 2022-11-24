using UnityEngine;
using UnityEngine.SceneManagement;
namespace _Main._Resources.Scripts.Utilities
{
    public class SecondKeyItem : MonoBehaviour
    {
        [SerializeField] private GameObject SecondKey;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                SecondKey.SetActive(true);
                SceneManager.LoadScene("WinScreen");
                Debug.Log("Collected");
                Destroy(this.gameObject);
                Cursor.lockState = CursorLockMode.None;
            }
        }
    
    
    
    
    }
}
