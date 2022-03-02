using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour
{
    private float turnSpeed = 90f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, turnSpeed * Time.deltaTime, 0);
    }

    private void OnTriggerEnter(Collider other)
    {

        if (transform.CompareTag("Diamond_1"))
        {
            
            GameManager.Instance.IncrementScore(0);
        }

        else if (transform.CompareTag("Diamond_2"))
        {
            GameManager.Instance.IncrementScore(1);
        }

        Destroy(gameObject);
    }
}
