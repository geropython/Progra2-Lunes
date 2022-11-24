using UnityEngine;
using UnityEngine.SceneManagement;

namespace _Main._Resources.Scripts.Menu
{
    public class LevelManager : MonoBehaviour
    {
        public void StartGame()
        {
            SceneManager.LoadScene(1);
            Cursor.lockState = CursorLockMode.Locked;
        }

        //void Level2()
        //{
        //    SceneManager.LoadScene(2);
        //}

        //void Level3()
        //{
        //    SceneManager.LoadScene(3);
        //}

        public void MainMenu()
        {
            SceneManager.LoadScene(0);
        }
        public void QuitGame()
        {
            Debug.Log("Quit game");
            Application.Quit();
        }
    }
}
