using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class PlayerController : MonoBehaviour
{
 public Sprite ylos;
 public Sprite alas;
 public Sprite vasen;
 public Sprite oikea;
 private float v_speed = 2;
 private float h_speed = 4;
 SpriteRenderer s_r;


 void Start ()
 {
       s_r = GetComponent<SpriteRenderer>();
 }

void Update()
{
      Vector3 pos = transform.position;
 
      if (Input.GetKey ("w")) {
            pos.y += v_speed * Time.deltaTime;
            s_r.sprite = ylos;
      }
      if (Input.GetKey ("a")) {
            pos.x -= h_speed * Time.deltaTime;
            s_r.sprite = vasen;
      }
      if (Input.GetKey ("s")) {
            pos.y -= v_speed * Time.deltaTime;
            s_r.sprite = alas;
      }
      if (Input.GetKey ("d")) {
            pos.x += h_speed * Time.deltaTime;
            s_r.sprite = oikea;
      }

      transform.position = pos;
      // this.transform.rotation = Quaternion.Euler(new Vector3(10, -10, 0));
}
}

