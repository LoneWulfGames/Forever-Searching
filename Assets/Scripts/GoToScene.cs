using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToScene : MonoBehaviour {
    public Scene scene;
    public void SceneLoader()
    {
        SceneManager.LoadScene(scene.name);
    }

}
