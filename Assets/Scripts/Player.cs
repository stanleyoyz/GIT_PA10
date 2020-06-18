using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private Animation thisAnimation;
    
    
    Rigidbody rb;
    
    void Start()
    {
        thisAnimation = GetComponent<Animation>();
        thisAnimation["Flap_Legacy"].speed = 3;
        rb = GetComponent<Rigidbody>();
        
        
    }

    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            thisAnimation.Play();

            rb.velocity = Vector3.up * 3;
        }
        transform.position = new Vector3(0, Mathf.Clamp(transform.position.y, -11f, 3.6f), 0);
        

    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "obstacle")
        {
            print("you dieded");
            SceneManager.LoadScene("GameOver");
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "avoid")
        {
            print("game enjine");
            GameManager.thisManager.UpdateScore(1);
        }
    }
}
