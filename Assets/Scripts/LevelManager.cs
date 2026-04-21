using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField]
    private GameObject pauseMenu;

    private bool abierto = false;

    public void BotonMenu()
    {
        abierto = !abierto;
        pauseMenu.SetActive(abierto);

        // Pausar el juego cuando el menú está abierto
        Time.timeScale = 0f;
    }

    public void ResumeGame()
    {
        abierto = false;
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }

    public void Salir(string MainMenu)
    {
        SceneManager.LoadScene(MainMenu);
    }
}

