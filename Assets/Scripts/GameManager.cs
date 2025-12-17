
using UnityEngine;
using UnityEngine.UI; // ‘Text’ needs to reference the UnityEngine.UI library
using UnityEngine.SceneManagement; // Scenes are referenced via UnityEngine.SceneManagement 

public class GameManager : MonoBehaviour

{
    [SerializeField] private Player player; // assign in Inspector
    [SerializeField] private Enemy[] enemies; // Supports multiple enemies!

    public string level; // Add variables at the top of your scripts


    void Start()
    {


        Debug.Log("Battle Start!");


    }



    private void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void EndGame()
    {
        SceneManager.LoadScene(level);
    }



}


