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
 private string last_pressed;
 public GameObject bulletPrefab;
 public Transform bulletSpawn;
 public SceneAloitus _singleton;

void Awake (){
      s_r = GetComponent<SpriteRenderer>();
      tori = GetComponent<Animator>();
      bulletSpawn = transform.Find("bulletSpawn");
      bulletPrefab = Resources.Load("Prefabs/bulletPrefab") as GameObject;
      _singleton = GetComponent<SceneAloitus>();
}
void Update()
{
      if (gameObject == null)
            _singleton.restart();

      Vector3 pos = transform.position;
 
      if (Input.GetKey ("w")) {
            pos.y += v_speed * Time.deltaTime;
            tori.SetTrigger("walk_w");
            s_r.sprite = ylos;
            last_pressed = "w";
      }
      else if (Input.GetKey ("a")) {
            pos.x -= h_speed * Time.deltaTime;
            tori.SetTrigger("walk_a");
            s_r.sprite = vasen;
            last_pressed = "a";
      }
      else if (Input.GetKey ("s")) {
            pos.y -= v_speed * Time.deltaTime;
            tori.SetTrigger("walk_s");
            s_r.sprite = alas;
            last_pressed = "s";
      }
      else if (Input.GetKey ("d")) {
            pos.x += h_speed * Time.deltaTime;
            tori.SetTrigger("walk_d");
            s_r.sprite = oikea;
            last_pressed = "d";
      }
      if (Input.GetKey ("space")){
            shoot_projectile();
      }

      transform.position = pos;
      transform.rotation = Quaternion.Euler(0,0,0);
}
private float nextFireTime;   
private void shoot_projectile(){
      int bspeed = 50;
      if (Time.time > nextFireTime){
            GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity) as GameObject;
            switch (last_pressed)
            {
                case "w":
                  bullet.transform.position = bullet.transform.position + transform.up;
                  bullet.GetComponent<Rigidbody2D>().AddForce(transform.up * bspeed);
                  break;
                case "s":
                  bullet.transform.position = bullet.transform.position - transform.up;
                  bullet.GetComponent<Rigidbody2D>().AddForce(-transform.up * bspeed);
                  break;
                case "a":
                  bullet.transform.position = bullet.transform.position - transform.right;
                  bullet.GetComponent<Rigidbody2D>().AddForce(-transform.right * bspeed);
                  break;
                case "d":
                  bullet.transform.position = bullet.transform.position + transform.right;
                  bullet.GetComponent<Rigidbody2D>().AddForce(transform.right * bspeed);
                  break;
                default:
                  break;
            }
            nextFireTime = Time.time + 1f;
            Destroy(bullet, 2f);
    }
}

private void OnCollisionEnter2D(Collision2D col) {
      if (col.gameObject.name == "bulletPrefab")
            return;
      else if(col.gameObject.name == "ylaTaso")
            _singleton.xp += 100;
            FindObjectOfType<SceneAloitus>().restart();
}
}

