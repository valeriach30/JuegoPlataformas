using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ganarJuego : MonoBehaviour
{
   
    
    private void Start(){
    }

    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.gameObject.name == "Bola"){
            Invoke("completarNivel", 0f);
        }
    }

    private void completarNivel(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
