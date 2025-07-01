using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering;

public class ball : MonoBehaviour
{
  public Text info;
    private Vector3 b=new Vector3(0,3,-1);
    public GameObject player,player1;
    public Text t,t1;    
   public float fallSpeed = 5f; 
    public float jumpForce = 10f; 
    public float groundY = -2f; 
  private Rigidbody2D playerRb,player1Rb;
    public Rigidbody2D rb2d; 
    public GameObject gf;
 float t2=0; 

    void Start()
    {
      StartCoroutine(CountForDuration());
      playerRb= player.GetComponent<Rigidbody2D>();
      player1Rb= player1.GetComponent<Rigidbody2D>();
      
     
       
    }

    

    void Update()
{
   
}
 IEnumerator CountForDuration()
{
    while (t2 < 6)
    {
        t2 += Time.deltaTime;
        yield return null; // Wait for the next frame
    }

    info.enabled=false;
}

 player playerr;
  player1 pl1;


void OnTriggerExit2D(Collider2D collider){

 
 if(collider.gameObject.CompareTag("Messisut")){
  playerr=player.GetComponent<player>();

playerr.canShoot=false;

 }
if(collider.gameObject.CompareTag("Estetiksut")){
pl1=player1.GetComponent<player1>();
  pl1.canShoot=false;
}


}

void FixedUpdate(){

  if(this.transform.position.x<=-7.5&&this.transform.position.y<0.9){


int s=Int32.Parse(t1.text);
s++;
t1.text=s+"";
Vector3 v=new Vector3(4,-2,-1);
//-4,-2-1
player1.transform.position=v;
Vector3 v2=new Vector3(-4,-2,-1);
player.transform.position=v2;


this.transform.position=b;
rb2d.velocity=Vector2.zero;
}

if(this.transform.position.x>=7.5&&this.transform.position.y<0.9){
    Vector3 v=new Vector3(4,-2,-1);
//-4,-2-1
player1.transform.position=v;
Vector3 v2=new Vector3(-4,-2,-1);
player.transform.position=v2;
int s=Int32.Parse(t.text);
s++;
t.text=s+"";


this.transform.position=b;
rb2d.velocity=Vector2.zero;
rb2d.AddForce(Vector2.zero);
rb2d.constraints=RigidbodyConstraints2D.FreezeRotation;
rb2d.constraints=RigidbodyConstraints2D.None;



}


   
       
                      
        
       
                    
                
                
}

void OnCollisionEnter2D(Collision2D collision)
{

}



//y<0.46,x<-3.24
double y=0.46;
double xx=-3.24;
void OnTriggerEnter2D(Collider2D collider2D){
    Debug.Log("Tetikleyen: " + collider2D.name);
    
    if(collider2D.CompareTag("Messisut")){
        player.GetComponent<player>().canShoot = true;
    }
    if(collider2D.CompareTag("Estetiksut")){
        player1.GetComponent<player1>().canShoot = true;
    }
}




    }


