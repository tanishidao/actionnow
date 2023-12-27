using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEngine.GraphicsBuffer;

public class DeadReload : MonoBehaviour
{
    public GameObject ResPos;
    public GameObject Player;
    private GameObject target;
    private bool Respowened;

    // Start is called before the first frame update
    void Start()
    {
        Player.transform.position = ResPos.transform.position;
        Respowened = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Respowened == true && Input.GetKeyDown(KeyCode.E))
        {
            Player.transform.position = ResPos.transform.position;
            Respowened = false;
        }
    }

    //public void OnCollisionEnter(Collision collision)
    //{
    //    Debug.Log("touch1");
    //    if (collision.gameObject == Player)
    //    {
    //        Player.transform.position = ResPos.transform.position;
    //        Debug.Log("touch2");
    //    }
    //}
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == Player)
        {
            target = other.gameObject;
            target.GetComponent<CharacterController>().enabled = false;
            Player.transform.position = ResPos.transform.position;
            Respowened = true;
         
            Invoke("ResetC", 0.5f);
        }
    }
    void ResetC()
    {
        target.GetComponent<CharacterController>().enabled = true;
    }
}
