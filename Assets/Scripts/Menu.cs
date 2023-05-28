using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Menu : MonoBehaviour
{
    private int _buildIndexSceneGame3 = 1;
    private int _buildIndexSceneGame4 = 2;
    private int _buildIndexSceneGame5 = 3;
    private int _buildIndexSceneMenu = 0;
    public static int gameSize;


    public void StartGameFor3()
    {
        SceneManager.LoadScene(_buildIndexSceneGame3);
        gameSize = 9;
    }
    public void StartGameFor4()
    {
        SceneManager.LoadScene(_buildIndexSceneGame4);
        gameSize = 16;
    }
    public void StartGameFor5()
    {
        SceneManager.LoadScene(_buildIndexSceneGame5);
        gameSize = 25;
    }

    public void MenuSelect()
    {
        SceneManager.LoadScene(_buildIndexSceneMenu);
    }

    public void ExitGame()
    {
       #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
        #else
                Application.Quit();
        #endif

    }


}
