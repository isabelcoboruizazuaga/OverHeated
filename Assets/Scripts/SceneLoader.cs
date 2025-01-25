using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    public string sceneName; // El nombre de la escena a la que quieres hacer la transición

    public void LoadScene()
    {
        SceneManager.LoadScene(sceneName);
    }
}