using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public delegate void LevelDelegate();
public class Player : MonoBehaviour
{
    
    public Slider slider;
    float currentSliderValue;
    [SerializeField] float sizeY;
    [SerializeField] float sizeZ;
    [SerializeField] float maxSize = 4.0f;
    [SerializeField] float minSize = 1.0f;

    [SerializeField] Color purple;
    [SerializeField] Color red;
    [SerializeField] Color green;
    [SerializeField] Color orange;

    [SerializeField] GameObject Tracker;
    [SerializeField] GameObject rangePlane;
    [SerializeField] GameObject Tracker2;
    [SerializeField] GameObject rangePlane2;
    [SerializeField] GameObject Tracker3;
    [SerializeField] GameObject rangePlane3;

    public bool isGameOver = false;
    public GameObject restartScreen;
    public GameObject gameWinScreen;

    public GameObject tunnel1;
    public GameObject tunnel2;
    public GameObject Pause;


    public bool Win = false;

    [SerializeField] float speed = 10.0f;

     Mesh playerMesh;

    enum callLevel
        {
        LEVEL1,
        LEVEL2,
        LEVEL3
    }
    public int currLevel;

      private void Start()
    {
        rangePlane.SetActive(false);
        Tracker.SetActive(false);
        rangePlane2.SetActive(false);
        Tracker2.SetActive(false);
        rangePlane3.SetActive(false);
        Tracker3.SetActive(false);

        playerMesh = GetComponent<MeshFilter>().mesh;
       

    }

    void Update()
    {
        if(!isGameOver)
        {
            transform.Translate(Vector3.right*Time.deltaTime*speed);
            SliderInput();
        }
        if(isGameOver)
        {
          
            restartScreen.SetActive(true);
            Pause.SetActive(false);


        }
        if(transform.position.y < -3 )
        {
            isGameOver = true;
        }

        GameWIN();
        Level1 l = new Level1();
   


    }


    public void GameWIN()
    {
        if (transform.position.x > -60)
        {
            
            Win = true;
            Pause.SetActive(false);
            gameWinScreen.SetActive(true);

        }
    }


    public void SliderInput()
    {
        currentSliderValue =  slider.value;

        if ((currentSliderValue <= slider.maxValue && currentSliderValue >= slider.minValue))
        {
            Vector3 Scale = new Vector3(minSize, maxSize * currentSliderValue, minSize +(3.6f-maxSize * currentSliderValue));
           
            Vector3 nn = new Vector3(Scale.x, Mathf.Clamp(Scale.y, 0.6f, 4), Mathf.Clamp(Scale.z, 1.0f, 4.0f));
            transform.localScale = nn;

        }
        slider.value = Mathf.Clamp(slider.value, 0.1f, 1);
    }

    //public void ShapeChanger()
    //{
    //    float Area = minSize * yPos* zPos;
    //    zPos = Area *4 /3 *(yPos*yPos);
    //    Vector3 newScale = new Vector3(minSize, yPos, zPos);
    //    Debug.Log("ok");
    //}


    public void OnTriggerEnter(Collider other)
    {

        if(other.tag == "purple")
        {
            transform.GetComponent<Renderer>().material.color = purple; 
        }

        if (other.tag == "red")
        {
            transform.GetComponent<Renderer>().material.color = red;

        }

        if (other.tag == "green")
        {
            transform.GetComponent<Renderer>().material.color = green;
        }

        if (gameObject.GetComponent<Renderer>().material.color != green && other.tag ==  "WallGreen")
        {
            //Destroy(gameObject);

            isGameOver = true;
        }

        if (gameObject.GetComponent<Renderer>().material.color != red && other.tag ==  "WallRed")
        {
            //Destroy(gameObject);
            isGameOver = true;
        }

        if (gameObject.GetComponent<Renderer>().material.color != purple &&other.tag ==  "WallPurple")
        {
           // Destroy(gameObject);
            isGameOver = true;
        }

        if (gameObject.GetComponent<Renderer>().material.color != orange &&other.tag ==  "WallYellow")
        {
            // Destroy(gameObject);
            isGameOver = true;
        }

        if (other.tag == "Obs")
        {
            //Destroy(gameObject);
            isGameOver = true;
        }
        
        if (other.tag == "1stPass")
        {
            Tracker.SetActive(true);
            rangePlane.SetActive(true);
        }

        if(other.tag == "2ndPass")
        {
            Tracker2.SetActive(true);
            rangePlane2.SetActive(true);
        }

        if( other.tag == "3rdPass")
        {
            Tracker3.SetActive(true);
            rangePlane3.SetActive(true);
        }

        if(other.tag == "4thPass")
        {
            tunnel1.SetActive(true);
        }

        if(other.tag == "5thPass")
        {
            tunnel2.SetActive(true);
        }

        if((other.tag == "circleShape") || other.tag == "capsuleShape" || other.tag == "cubeShape" || other.tag == "cylinderShape")
        {
            this.GetComponent<MeshFilter>().mesh = other.gameObject.GetComponent<MeshFilter>().mesh;
            this.GetComponent<MeshCollider>().sharedMesh = other.gameObject.GetComponent<MeshFilter>().mesh;
        }
        //if ((other.tag == "capsuleShape"))
        //{
        //    this.GetComponent<MeshFilter>().mesh = other.gameObject.GetComponent<MeshFilter>().mesh;
        //    this.GetComponent<MeshCollider>().sharedMesh = other.gameObject.GetComponent<MeshFilter>().mesh;
        //}
        //if(other.tag == "cubeShape")
        //{
        //    this.GetComponent<MeshFilter>().mesh = other.gameObject.GetComponent<MeshFilter>().mesh;
        //    this.GetComponent<MeshCollider>().sharedMesh = other.gameObject.GetComponent<MeshFilter>().mesh;
        //}

        if(other.tag == "FinishLine")
        {
            GameWIN();
        }
    }


    private void OnDestroy()
    {
        this.GetComponent<MeshFilter>().mesh = playerMesh;
    }
}

public class Level1 : Player
{
    [SerializeField] float sizeY;
    [SerializeField] float sizeZ;
    [SerializeField] float maxSize = 4.0f;
    [SerializeField] float minSize = 1.0f;

    public bool isGameOver = false;
    public GameObject restartScreen;
    public GameObject gameWinScreen;

    public GameObject Pause;

    public bool Win = false;

    [SerializeField] float speed = 10.0f;

}

