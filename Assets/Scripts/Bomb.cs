using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Bomb : MonoBehaviour
{
    public GameObject Timer;
    public GameObject ExplosionAnimation;

    float explosion_delay = 4f;
    float explosion_radius = 1.42f;
    
    bool collided = false;

    void Start()
    {

    }

    void Update()
    {
        if (collided == true)
        {
            explosion_delay -= Time.deltaTime;
            int localtimer = (int)explosion_delay;
            Timer.GetComponent<MeshRenderer>().enabled = true;
            Timer.GetComponent<TextMesh>().text = localtimer.ToString();

            if (explosion_delay < 1)
            {
                Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, explosion_radius);
                foreach (Collider2D col in colliders)
                {
                    if (col.gameObject.GetComponent<Rigidbody2D>() != null)
                    {
                        Vector2 target = col.gameObject.transform.position;
                        Vector2 bomb = gameObject.transform.position;

                        Vector2 direction = 700f * (target - bomb);
                        GameObject animation = GameObject.Instantiate(ExplosionAnimation, transform.position, Quaternion.identity) as GameObject;
                        col.gameObject.GetComponent<Rigidbody2D>().AddForce(direction);

                        if (col.gameObject.tag != "Player" && col.gameObject.tag != "Bomb")
                        {
                            Destroy(col.gameObject, 0.2f);
                        }
                        Destroy(animation, 0.6f);
                        Destroy(this.gameObject);
                    }
                }
            }
        }
    }

    void OnCollisionEnter2D (Collision2D other)
    {
        collided = true;
    }
}