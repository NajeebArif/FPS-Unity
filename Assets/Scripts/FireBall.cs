using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{
    public float speed = 20.0f;
    public int damage = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, 0, speed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other) {
        PlayerCharacter playerCharacter = other.GetComponent<PlayerCharacter>();
        if(playerCharacter != null) {
            Debug.Log("Player Hurt.");
            playerCharacter.hurt(damage);
        }
        Destroy(this.gameObject);
    }
}
