using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ball : MonoBehaviour
{
    private Rigidbody rb;
    public float force;
    public float speed;

    private Transform nextPlatform;
    public Transform firstPlatform, secondPlatform;
    public bool toTheNextPlatform = false;

    public ObjectRotation obj_1;
    public ObjectRotation obj_2;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        nextPlatform = secondPlatform;
    }
    private void FixedUpdate()
    {
        if (!toTheNextPlatform)
            rb.AddForce(0, -force * Time.fixedDeltaTime, 0);
        if (toTheNextPlatform)
            transform.position = Vector3.MoveTowards(transform.position, nextPlatform.position, speed * Time.fixedDeltaTime);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Next"))
        {
            nextPlatform = secondPlatform;
            toTheNextPlatform = true;
            obj_1.isItActive = false;
            obj_1.restart.SetActive(false);
            transform.parent = null;
            rb.isKinematic = true;
            StartCoroutine(delayEnableKinematic());
        }

        if (other.CompareTag("Next_1"))
        {
            nextPlatform = firstPlatform;
            toTheNextPlatform = true;
            obj_2.isItActive = false;
            obj_2.restart.SetActive(false);
            transform.parent = null;
            rb.isKinematic = true;
            StartCoroutine(delayEnableKinematic());
        }

        if(other.CompareTag("Restart"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Land"))
        {
            toTheNextPlatform = false;
            obj_1.isItActive = true;
            obj_1.restart.SetActive(true);
            transform.parent = obj_1.gameObject.transform;
        }
        if (collision.gameObject.CompareTag("Land_1"))
        {
            toTheNextPlatform = false;
            obj_2.isItActive = true;
            obj_2.restart.SetActive(true);
            transform.parent = obj_2.gameObject.transform;
        }
    }
    IEnumerator delayEnableKinematic()
    {
        yield return new WaitForSeconds(0.5f);
        rb.isKinematic = false;
    }
}
