using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] 
    private AudioClip music;
    private void Start()
    {
        AudioManager.instance.PlayMusic(music);
    }

    public void CargarVRFake(string FakeVR)
    {
        SceneManager.LoadScene(FakeVR);
    }

    public void CargarImage(string TrackerImage)
    {
        SceneManager.LoadScene(TrackerImage);
    }

    public void CargarSurface(string TrackerSurface)
    {
        SceneManager.LoadScene(TrackerSurface);
    }

    public void PlayGame(string MainMenu)
    {
        SceneManager.LoadScene(MainMenu);
    }
    public void PortadaEscene(string Portada)
    {
        SceneManager.LoadScene(Portada);
    }
    public void SalirDelJuego()
    {
        Debug.Log("Saliendo del juego...");

        Application.Quit();
    }

}
