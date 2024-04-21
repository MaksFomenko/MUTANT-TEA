using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToAnotherScene : MonoBehaviour
{
    [Header("Номер сцени")]
    public int sceneNumber; 
     public void PlayGame(string sceneName)
     {
         Debug.Log("Play");
         SceneManager.LoadScene(sceneNumber);
     }
}