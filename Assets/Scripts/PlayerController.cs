using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour
{

    public GameObject Instantiater;
    public GameObject Bomb;
    public GameObject[] BackImages;
    public GameObject Tank;

    public Canvas GameplayCanvas;
    public Canvas LevelChoosingCanvas;

    float f_lastX = 0.0f;
    float f_difX = 0.5f;
    float f_steps = 0.0f;
    int i_direction = 1;

    // Use this for initialization
    void Start()
    {
        PlayerPrefs.SetInt("Shoot", 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameObject.FindGameObjectWithTag("BackImage"))
        {
            Instantiate(BackImages[Random.Range(0, BackImages.Length)], new Vector3(0, 0, 7), Quaternion.identity);
        }

        if (GameplayCanvas.enabled == true && !Tank.GetComponent<Rigidbody2D>())
        {
            Tank.AddComponent<Rigidbody2D>();
            Tank.GetComponent<Rigidbody2D>().mass = 10000;
        }
        else if (GameplayCanvas.enabled == false)
        {
            Destroy(Tank.GetComponent<Rigidbody2D>());
            if (LevelChoosingCanvas.enabled == true)
            {
                Tank.transform.position = new Vector3(-6.3f, 3, 0);
            }
        }

        if (Time.timeScale == 1)
        {
            if (PlayerPrefs.GetInt("Shoot") == 1)
            {
                PlayerPrefs.SetInt("Shoot", 0);
                GameObject bomb = Instantiate(Bomb, Instantiater.transform.position, Quaternion.identity) as GameObject;
                bomb.GetComponent<Rigidbody2D>().velocity = Instantiater.transform.right.normalized * PlayerPrefs.GetFloat("Force");
                Destroy(bomb.gameObject, 10);
            }

            if (!EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId))
            {
                if (Input.GetMouseButtonDown(0))
                {
                    f_difX = 0.0f;
                }
                else if (Input.GetMouseButton(0))
                {
                    f_difX = Mathf.Abs(f_lastX - Input.GetAxis("Mouse Y"));

                    if (f_lastX < Input.GetAxis("Mouse Y"))
                    {

                        if (transform.eulerAngles.z < 95 | transform.eulerAngles.z > 300)
                        {
                            i_direction = -1;
                            transform.Rotate(Vector3.forward, f_difX);
                        }
                    }

                    if (f_lastX > Input.GetAxis("Mouse Y"))
                    {
                        if (transform.eulerAngles.z < 150 | transform.eulerAngles.z > 345)
                        {
                            i_direction = 1;
                            transform.Rotate(Vector3.forward, -f_difX);
                        }
                    }

                    f_lastX = -Input.GetAxis("Mouse Y");
                }
            }
        }
    }
}