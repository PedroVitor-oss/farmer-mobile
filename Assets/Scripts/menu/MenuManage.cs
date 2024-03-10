using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MenuManage : MonoBehaviour
{
    // Start is called before the first frame update
    public void Jogar(){
        SceneManager.LoadScene("Level1");
    }
    public void Opitions(){
        SceneManager.LoadScene("Opitions");
    }
    public void Inicio(){
        SceneManager.LoadScene("Menu");
    }
    public void Fechar(){
         Application.Quit();
    }
}
