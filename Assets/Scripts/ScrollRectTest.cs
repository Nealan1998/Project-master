using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollRectTest : MonoBehaviour
{
    public float moveSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*if(Input.GetAxisRaw("Vertical") == 1 | Input.GetAxisRaw("Vertical") == -1)
        { 
            
        }*/

        this.gameObject.transform.position = new Vector2(this.gameObject.transform.position.x, this.gameObject.transform.position.y + (Input.GetAxisRaw("Vertical") * moveSpeed)); 
    }
}
