using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {

    public Transform playerSpawnPoints; // roditelj spawn pointova
    public GameObject flare;
    public Slider slider;
    public GameObject zombie;
    private OptionsController optionsController;
    public Text mojtext;
    public LevelManager levelManager;
    public  bool reSpawn = false;
    public Image Fill;


    private Transform[] spawnPoints;
    private bool lastRespawnToggle = false;
    private Vector3 heliposition;
    private float health = 100;
    private Color orange = Color.white; // this is chandeg in start function to orange because Color.orange doesnt egzist
    private Color red = Color.red;
    private Color green = Color.green;

    // Use this for initialization
    void Start () {
        spawnPoints = playerSpawnPoints.GetComponentsInChildren<Transform>();
        optionsController = FindObjectOfType<OptionsController>();
        print(optionsController);
        //print(spawnPoints.Length);       
        slider.value = health;
        SetOrangeColor();
        Diff();
	}
	
	// Update is called once per frame
	void Update () {
		if(lastRespawnToggle != reSpawn) // obadvoje false na početku
        {
            ReSpawn();
            reSpawn = false;
        }
        else
        {
            lastRespawnToggle = reSpawn;
        }


        

        if(slider.value <= 50f && slider.value > 30f)
        {
            Fill.color = orange;
            
        }
        else if(slider.value <= 30f)
        {
            Fill.color = red;
        }
        else if(slider.value > 50f)
        {
            Fill.color = green;
        }

        Lose();


        //if(transform.position.y <= 11f)
        //{
        //    mojtext.text = "Gotovo";
        //}
    }
    public void Lose()
    {
        if (transform.position.y <=12f)
        {
            health = 0;
            mojtext.text = "HM...TRY AGAIN?";
            Invoke("LoseScreen", 3);
            //na canvasu se prikazuje GameOver i nakon 3 sekunde loada se lose Screen
        }
        if (health == 0)
        {
            mojtext.text = "SECOND CHANCE?";
            Invoke("LoseScreen", 3);
            //na canvasu se prikazuje GameOver i nakon 3 sekunde loada se lose Screen
        }
    }

    public void LoseScreen()
    {
        levelManager.LoadLevel(5);
    }

    public void Win(float a)
    {
        

        if(a == 0)
        {
            mojtext.text = "YOU WIN! YOU DID IT!";
            Invoke("WinScreen", 3);
        }



    }

    public void WinScreen()
    {
        levelManager.LoadLevel(4);
    }


    
    public void Diff()
    {
        float difficulty = optionsController.Difficulty();
        if (difficulty == 2f)
        {
            for(int i = 1; i <= difficulty; i++)
            {
                Instantiate(zombie, transform.position, transform.rotation);
            }
        }
    
    }
  
    void SetOrangeColor()
    {        
        orange.r = 239;
        orange.g = 149;
        orange.b = 0;
    }


    private void ReSpawn()
    {
        int i = Random.Range(1, spawnPoints.Length); // počinjemo od 1 zato jer je element u arrayu na indexu 0 parent, childreni pocinju od 1 
        transform.position = spawnPoints[i].transform.position;  // postavljamo trenutni game object a to je Player na random poziciju tj jednu od 3 random izabranih spawn pointova
    }


    void OnFindClearArea()
    {
        Invoke("DropFlare", 3f);
    }


    void DropFlare()
    {
        Instantiate(flare, transform.position, transform.rotation);
        heliposition = transform.position;  
       
    
    }

    public Vector3 FlarePosition()
    {
        return heliposition;
    }

    private float timewhenentered = 0;
    //private void OnTriggerEnter(Collider other) //kad zombie uhvati playera,player gubi 10hp 
    //{
    //    if (other.gameObject.tag == "Zombie")
    //    {
    //        timewhenentered = Time.time;
    //        health = health - 10;
    //        slider.value = health;
    //        //print("zombie");
    //        //print("I just enteret trigger at : "+timewhenentered);
    //        //print("Health: " +health);

    //    }
    //}


    private void OnCollisionEnter(Collision other)
    {
        
            if (other.gameObject.tag == "Zombie")
            {
                timewhenentered = Time.time;
                health = health - 10;
                slider.value = health;
                //print("zombie");
                //print("I just enteret trigger at : "+timewhenentered);
                //print("Health: " +health);

            }
        
    }

    //private void OnTriggerStay(Collider other) // nakon 5 sekundi u triggeru player gubi 1hp i nakon toga opet svakih 5 sekundi gubi 1hp
    //{
    //    if (other.gameObject.tag == "Zombie")
    //    {
    //        float inTime = Time.time;
    //        //print("Staying in trigger: "+inTime);
    //        if ((inTime- timewhenentered) >= 5f)
    //        {
    //            health = health - 5;
    //            slider.value = health;
    //            timewhenentered = inTime;
    //            //print("*** "+health);           
    //        }
    //    }
    //}



}
