using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    private GameObject _enemy;

    private int prefabHeight = 3;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_enemy == null) {
            _enemy = Instantiate(enemyPrefab) as GameObject;
            //int x = Random.Range(-75, 75);
            int x = 10;
            int z = 10;
            //int z = Random.Range(-75, 75);
            _enemy.transform.position = new Vector3(x, prefabHeight, z);
            float angle = Random.Range(0, 360);
            _enemy.transform.Rotate(0, angle, 0);
        }
    }
}
