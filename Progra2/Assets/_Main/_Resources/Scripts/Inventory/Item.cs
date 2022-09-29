using UnityEngine;
using UnityEngine.SceneManagement;
namespace _Main._Resources.Scripts.Inventory
{
    public class Item : MonoBehaviour
    {
        [SerializeField] private GameObject KeyIcon;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                KeyIcon.SetActive(true);
                SceneManager.LoadScene("Level 1");
                Debug.Log("Collected");
                Destroy(this.gameObject);
            }
        }
    }
}
