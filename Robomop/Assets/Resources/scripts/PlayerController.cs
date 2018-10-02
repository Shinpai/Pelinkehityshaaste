using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class PlayerController : MonoBehaviour
{
 public Sprite ylos, alas, vasen, oikea;
 private float v_speed = 2;
 private float h_speed = 4;
 SpriteRenderer s_r;
 Animator tori;
 SceneAloitus GO_manager;

void Start (){
      s_r = GetComponent<SpriteRenderer>();
      tori = GetComponent<Animator>();
}
void Update()
{
      Vector3 pos = transform.position;
 
      if (Input.GetKey ("w")) {
            pos.y += v_speed * Time.deltaTime;
            tori.SetTrigger("walk_w");
            s_r.sprite = ylos;
      }
      else if (Input.GetKey ("a")) {
            pos.x -= h_speed * Time.deltaTime;
            tori.SetTrigger("walk_a");
            s_r.sprite = vasen;
      }
      else if (Input.GetKey ("s")) {
            pos.y -= v_speed * Time.deltaTime;
            tori.SetTrigger("walk_s");
            s_r.sprite = alas;
      }
      else if (Input.GetKey ("d")) {
            pos.x += h_speed * Time.deltaTime;
            tori.SetTrigger("walk_d");
            s_r.sprite = oikea;
      }

      transform.position = pos;
      transform.rotation = Quaternion.Euler(0,0,0);
}

private void OnCollisionEnter2D(Collision2D col) {
      if(col.gameObject.name == "keskiTaso")
            Debug.Log("osuit seinään");
      else if(col.gameObject.name == "ylaTaso")
            FindObjectOfType<SceneAloitus>().restart();
            Debug.Log("voitit pelin");          
}
}

