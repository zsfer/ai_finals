using UnityEngine;
using UnityEngine.SceneManagement;

namespace Platformer
{
    public class MainMenu : MonoBehaviour
    {
        public void StartGame()
        {
            SceneManager.LoadScene("Stage");
        }
    }
}
