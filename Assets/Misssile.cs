using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class Misssile : MonoBehaviour
{
    Vector3 _initialPosition;
    Vector3 _initialLaunchPoint;
    float timeSinceLaunch;
    bool isLaunched = false;

    [SerializeField] private float _launchPower = 40;

    //float clicked = 0;
    //float clicktime = 0;
    //float clickdelay = 0.5f;

    float debutClick = 0;
    float finClick = 0;
    //int numClick = 0;

    private void Awake()
    {
        _initialPosition = transform.position;
        _initialLaunchPoint = transform.position + new Vector3(Input.GetAxis("Horizontal")+3, Input.GetAxis("Vertical") + 16, 0);
    }

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //GetComponent<LineRenderer>().enabled = true;
        //GetComponent<LineRenderer>().sortingLayerName = "Foreground";
        //GetComponent<LineRenderer>().SetPosition(0, transform.position);
        //GetComponent<LineRenderer>().SetPosition(1, _initialLaunchPoint);

        if (GetComponent<Rigidbody2D>().velocity.magnitude <= 0.1 && isLaunched == true)
        {
            timeSinceLaunch += Time.deltaTime;
        }

        if (transform.position.y > 21.53 || transform.position.y < -16.25 || transform.position.x < -25.9 || transform.position.x > 29.94 || timeSinceLaunch > 3)
        {
            string currentSceneName = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene(currentSceneName);
        }
    }

    private void OnMouseUp()
    {
        //Vector3 directionToInitialPosition = _initialLaunchPoint - transform.position;
        /*finClick = Time.time;

        if(Mathf.Abs(finClick - debutClick) < 0.5f)
        {
            numClick += 1;
            finClick = Time.time;
        }
        else
        {
            numClick = 0;
        }

        if(numClick == 2 && Time.time - debutClick < 0.5f)
        {
            Debug.Log("Double click!");
        }

        if (numClick > 2)
        {
            numClick = 0;
        }*/

        debutClick = Time.time;

        
        if(debutClick - finClick > 0.25f)
        {
            Vector3 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            newPosition.z = 0;

            Vector3 directionToInitialPosition = _initialLaunchPoint - newPosition;
            GetComponent<Rigidbody2D>().AddForce(directionToInitialPosition * _launchPower);
            GetComponent<Rigidbody2D>().gravityScale = 1.0f;
        }
        

        //GetComponent<LineRenderer>().enabled = false;

        isLaunched = true;
    }

    private void OnMouseDown()
    {

        finClick = Time.time;
        GetComponent<Rigidbody2D>().gravityScale = 0; //originally 1
        

        if(finClick - debutClick < 0.5f)
        {
            Debug.Log("Double CLick: " /*+ this.GetComponent<RectTransform>().name*/);
        }
        //clicked++;
        //if (clicked == 1) clicktime = Time.time;

        //if (clicked > 1 && Time.time - clicktime < clickdelay)
        //{
            //clicked = 0;
            //clicktime = 0;
            //Debug.Log("Double CLick: " /*+ this.GetComponent<RectTransform>().name*/);

        //}
        //else if (clicked > 2 || Time.time - clicktime > 1) clicked = 0;
    }

    private void OnMouseDrag()
    {
        Vector3 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //transform.position = new Vector3(newPosition.x, newPosition.y, 0);

        //newPosition.z = 0;

        //GetComponent<LineRenderer>().SetPosition(0, newPosition);
        //GetComponent<LineRenderer>().SetPosition(1, _initialLaunchPoint);
    }
}
