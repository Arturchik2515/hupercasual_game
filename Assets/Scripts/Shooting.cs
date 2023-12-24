using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField] GameObject bullet;
    [SerializeField] GameObject player;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);
            mousePos.z = 0;
            float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;

            GameObject newBullet = Instantiate(bullet, transform.position, Quaternion.identity);

            newBullet.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }

   
    void OnTriggerEnter2D(Collider2D collision)
    {   
        if(collision.tag == "Player")
        {
            Destroy(player);
            print("Поражение");
        }
    }


    }

}
