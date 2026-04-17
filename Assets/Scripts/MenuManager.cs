using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
   
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

   
    public void SalirDelJuego()
    {
        Debug.Log("Saliendo del juego...");

        Application.Quit();
    }

}
