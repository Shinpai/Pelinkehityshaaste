using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class PlayerController : MonoBehaviour
{
 public Sprite ylos, alas, vasen, oikea;
 private float v_speed;
 private float h_speed;
 SpriteRenderer s_r;
 Animator tori;
 SceneAloitus GO_manager;
 private string last_pressed;
 public GameObject bulletPrefab;
 public Transform bulletSpawn;
 public SceneAloitus game_manager;
 private int xp_counter, death_counter;

void Awake (){
      s_r = GetComponent<SpriteRenderer>();
      tori = GetComponent<Animator>();
      bulletSpawn = transform.Find("bulletSpawn");
      bulletPrefab = Resources.Load("Prefabs/bulletPrefab") as GameObject;
      game_manager = SceneAloitus._singleton;

      rof = 1.5f;
      death_counter = 0;
      v_speed = 2;
      h_speed = 4;
      skaala = new Vector3(1,1,1);  
}
void Update()
{
      if (gameObject == null){
            Debug.Log("#5");
            game_manager.restart(true);
      }

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
private float rof;

private void OnGUI() {
      if (game_manager.xp >= 100){
            rof = .5f;
            GUI.Label(new Rect(10, 30, 150, 50),"@100: ROF upgrade");
      }
       
      if (game_manager.xp >= 300){
            skaala = new Vector3(2,2,2);
            GUI.Label(new Rect(10, 50, 120, 30),"@300: Suuremmat luodit");
      }
}
private float nextFireTime;   
private Vector3 skaala;
private void shoot_projectile(){
      int bspeed = 50;
      if (Time.time > nextFireTime){
            GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity) as GameObject;
            bullet.transform.localScale = skaala;
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
            game_manager.sounds[2].Play();
            nextFireTime = Time.time + rof;
            if (bullet != null)
                  Destroy(bullet, 1f);
    }
}

private void OnCollisionEnter2D(Collision2D col) {
      if(col.gameObject.name == "ylaTaso")
            Debug.Log("#6");
            game_manager.xp += 100;
            game_manager.restart(false);
}
}

