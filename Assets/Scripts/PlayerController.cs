using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    GameManager manager;
    SpawnManager spams;
    UIManager uiManager;

    CharacterController controller;
    Vector3 velo;
    Vector3 move;
    void Start()
    {
        spams = FindObjectOfType<SpawnManager>();
        manager = FindObjectOfType<GameManager>();
        uiManager = FindObjectOfType<UIManager>();
        controller = GetComponent<CharacterController>();

    }

    void FixedUpdate()
    {
        if (manager.isPlay)
        {
            controller.Move(move * (1.1f*Time.deltaTime) * 4);
        }
        
    }
    void OnMovement(InputValue Moveýnput)
    {
        Vector2 input = Moveýnput.Get<Vector2>();
         move = new Vector3(input.x, 0, input.y);
        if (move != Vector3.zero)
        {
            gameObject.transform.forward = move;
        }
       
        //velo.x = input.x;
        //velo.z = input.y;
        
    }

    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Collectable"))
        {
           
            other.gameObject.transform.position = new Vector3(-20, 0, -30);
            spams.spawnObject.Remove(other.gameObject);

            if (!spams.poolingObject.Contains(other.gameObject))
            {
                spams.poolingObject.Add(other.gameObject);
            }
           
            if (spams.spawnObject.Count==0)
            {
                spams.randomSpawnedTransforms.Clear();
                manager.checkCollectObject();
            }
            uiManager.ScoreBoard();   
            

            
           
        }
    }
}
