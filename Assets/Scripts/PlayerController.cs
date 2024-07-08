using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float speed = 20f;
    public float xRange = 15f;
    public GameObject projectilePrefab;
    public GameObject famerObj;
    public GameObject gostObj;
    public PlayerInput pInput;
    public Slider GhostTimeSlider;
    private float horizontalInput;
    private float verticalInput;
    private bool ghost = false;
    public int quantPizza = 16;
    private float ghostTime = 5;

    // Start is called before the first frame update
    void Start()
    {
        pInput = GetComponent<PlayerInput>();
    }

    // Update is called once per frame
    void Update()
    {
        //float horizontalInput = Input.GetAxis("Horizontal");
        // movimenta o player para esquerda e direita a partir da entrada do usu�rio
        Vector3 move  = new Vector3(horizontalInput,0 ,verticalInput);
        transform.Translate(move * speed * Time.deltaTime  );
        // transform.Translate(Vector3.forward * speed * Time.deltaTime * verticalInput);
        // mant�m o player dentro dos limites do jogo (eixo x)
        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }
        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }

        if(!famerObj.active){
            ghostTime-=Time.deltaTime;
        }else if(ghostTime<5){
            ghostTime+=Time.deltaTime;
        }
        
        GhostTimeSlider.value = ghostTime;
        
        if(ghostTime<=0){
                            famerObj.SetActive(true);

        }
       
        
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("MAMAMIA");
        if(other.gameObject.tag == "pizzabox")
        {
            quantPizza+=8;
            Destroy(other.gameObject);
        }
    }

    /* ------------- Send Mensage ------------- */
    void OnMove(InputValue value){
        horizontalInput = value.Get<Vector2>().x;
        verticalInput = value.Get<Vector2>().y;
    }
    void OnFire(InputValue value){
      if(value.isPressed && quantPizza>0){
            Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
            quantPizza--;
      }
    }
   
    public void  OnGhost(InputValue value){
        if(value.isPressed ){
                
                //gostObj.SetActive(true);
                famerObj.SetActive(false);
            }else{
                //gostObj.SetActive(false);
                famerObj.SetActive(true);
                
        }
    }





    

    /* ------------- UNVOK UINTY EVENT ------------- */
    // public void MoveEvent(InputAction.CallbackContext value){
    //     horizontalInput = value.ReadValue<Vector2>().x;
    //     verticalInput = value.ReadValue<Vector2>().y;
    // }

    // public void FireEvent(InputAction.CallbackContext value){    
    //     Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
    //  }
  
    // public void  GhostEvent(InputAction.CallbackContext text){
    //     //me jeito
    //     if(ghost){
    //         Debug.Log("desativar ghost");
    //        // gostObj.SetActive(false);
    //             famerObj.SetActive(true);
    //         ghost = false;          
    //     }else{
    //         Debug.Log("ativar ghost");
    //        // gostObj.SetActive(true);
    //             famerObj.SetActive(false);
    //         ghost = true;
    //     }
    // }

   


}
