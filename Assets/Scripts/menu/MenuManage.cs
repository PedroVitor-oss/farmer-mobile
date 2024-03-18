using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;


public class MenuManage : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject MenuOpitions;
    [SerializeField] private GameObject Confimation;
    [SerializeField] private string NextLevel;


    public void Jogar(){
        SceneManager.LoadScene(NextLevel);
    }
    public void OpenOptions(){
        MenuOpitions.SetActive(true);
    }
    public void CloseOptions(){
        MenuOpitions.SetActive(false);
    }
    public void OpenConfirm(){
        Confimation.SetActive(true);
    }
    public void CloseConfirm(){
        Confimation.SetActive(false);
    }
    public void Inicio(){
        SceneManager.LoadScene("Menu");
    }
    public void Fechar(){
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
         Application.Quit();
    }
}
