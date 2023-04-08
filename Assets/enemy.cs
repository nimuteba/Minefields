using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class enemy : MonoBehaviour
{

    [SerializeField] public float field;
    [SerializeField] public float force;
    public LayerMask leLayer;

    [SerializeField] public GameObject explosionAnim;
    //[SerializeField] public LevelManager levelManager;

    public int score = 1;

    private void ExplosionEffect()
    {
        //print("Here");
        Collider2D[] stuffs = Physics2D.OverlapCircleAll(transform.position, field, leLayer);
        //print("Number of objects around: " + stuffs.Length);

        foreach(Collider2D stuff in stuffs)
        {
            //if (stuff.GetComponent<Misssile>() != null)
            //{
                //print("Object name: "+stuff.name);
                Vector3 line = stuff.transform.position - transform.position;
                stuff.GetComponent<Rigidbody2D>().AddForce(line * force);

                //levelManager = GetComponent<LevelManager>();
                //levelManager.scoreCount++;

            if(stuff.name == "enemy" || stuff.name == "enemy (1)" || stuff.name == "hollow box" || stuff.name == "hollow box (1)")
            {
                score += 11;
                Debug.Log("update score");
                break;
            }
            break;

            //}
        }

        GameObject InGameExplosion = Instantiate(explosionAnim, transform.position, Quaternion.identity);
        Destroy(InGameExplosion, 10);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //using StreamWriter file = new("C:\\Users\natha\\Minefields\\Assets\\normals.txt", append: true);
        //file.WriteLineAsync("Fourth line");
        //Debug.Log("Normal.x: " + collision.contacts[0].normal.x + "\n" + "Normal.y: " + collision.contacts[0].normal.y + "\n\n");
        //print("Wha");

        if (collision.contacts[0].normal.y < -0.2)
        {
            ExplosionEffect();
            Destroy(gameObject);
            
        }

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, field);
    }

    public int GetScore()
    {
        return this.score;
    }
}
