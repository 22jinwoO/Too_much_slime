using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.AddForce(transform.up,ForceMode2D.Impulse);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            print("키보드 눌림");
            Time.timeScale = 0;
            
        }

        

        if (Input.GetKeyDown(KeyCode.S))
            Time.timeScale = 1;
    }
}
