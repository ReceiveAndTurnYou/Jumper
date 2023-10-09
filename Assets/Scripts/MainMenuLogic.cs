using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuLogic : MonoBehaviour
{
    [SerializeField] private GameObject canv;
    
    public void StartGame()
    {
        SceneManager.LoadScene("Game");        
    }
}
