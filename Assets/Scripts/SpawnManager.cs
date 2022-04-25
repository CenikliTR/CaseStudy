using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class SpawnManager : MonoBehaviour
{

    //[SerializeField] GameObject spawnObject;
    [SerializeField] public GameObject plane;
    [SerializeField] public List<GameObject> poolingObject = new List<GameObject>();
    [SerializeField] public List<GameObject> spawnObject = new List<GameObject>();
    Vector3 randomSpawnLine;
    [SerializeField] public List<Vector3> randomSpawnedTransforms = new List<Vector3>();
    public int _randomSpawnCount;
    void Awake()
    {

    }
    void Start()
    {
        
    }


    void Update()
    {

    }



    public void SpawnLine()
    {
        Vector3 planeSize = plane.GetComponent<Transform>().localScale; //plane ayarlarý için gerekli deðil düzenle
        planeSize = (planeSize * 10) / 2;
        //Debug.Log(planeSize);

        randomSpawnLine = new Vector3(UnityEngine.Random.Range(planeSize.x * -1,planeSize.x),0.5f,
            UnityEngine.Random.Range(planeSize.z * -1, planeSize.z));

        if (!randomSpawnedTransforms.Contains(randomSpawnLine))
        {
            
            if (randomSpawnedTransforms.Count > 0)
            {
                float _randomDistance = Vector3.Distance(randomSpawnLine, randomSpawnedTransforms.Last());
                if (_randomDistance > 4f) 
                {
                    randomSpawnedTransforms.Add(randomSpawnLine);
                }

            }
            else
            {
                randomSpawnedTransforms.Add(randomSpawnLine);
            }

        }
    }

    public IEnumerator Spawn()
    {
        
        Debug.Log("obje spam");
        for (int i = 0; i < _randomSpawnCount; i++)
        {
            Debug.Log(_randomSpawnCount);
            yield return new WaitForSeconds(1);
            poolingObject[i].transform.SetPositionAndRotation(randomSpawnedTransforms[i], Quaternion.identity);
            spawnObject.Add(poolingObject[i]);   
        }
        for (int j = 0; j < spawnObject.Count; j++)
        {
            if (spawnObject.Count==0)
            {
                continue;
            }
            poolingObject.Remove(spawnObject[j]);
        }
    }

}
