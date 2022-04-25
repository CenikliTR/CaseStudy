using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    SpawnManager spam;
    UIManager uiManager;
    public bool isPlay = false; 
    private void Awake()
    {
        spam = GetComponent(typeof(SpawnManager)) as SpawnManager;
        uiManager = FindObjectOfType<UIManager>();
    }

    void Start()
    {
        spam._randomSpawnCount = UnityEngine.Random.RandomRange(1, 6);
        while (spam._randomSpawnCount > spam.randomSpawnedTransforms.Count)
        {
            spam.SpawnLine();
        }

        StartCoroutine(spam.Spawn());
    }

    
    void Update()
    {
        EndGame();
    }
    public void EndGame()
    {
        if (uiManager.score >= 100)
        {
            isPlay = false;
            uiManager.FinishScreen();
        }
    }


    public void checkCollectObject()
    {
            while (spam._randomSpawnCount > spam.randomSpawnedTransforms.Count)
            {
                spam.SpawnLine();
            }
            StartCoroutine(spam.Spawn());

    }
}
