using UnityEngine;
using TMPro;

using System.Collections;
public class moonment : MonoBehaviour
{
    public float speed = 300f;
    public float movent = 0f;
    public new Collider2D collider;
    public GameObject gamovr;
    public GameObject exp;
    public GameObject gen;
    public GameObject canv;
    public AudioClip dead;
    public AudioClip musgameovr;
    void Update()
    {
        movent = Input.GetAxisRaw("Horizontal");
        transform.RotateAround(Vector3.zero, Vector3.forward, movent * speed * Time.deltaTime);
        transform.Rotate(new Vector3(0, 0, 45) * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Coin")
        {}
        else if (collider.gameObject.tag == "Speed")
        {
            StartCoroutine(sped());
        }
        else
        {StartCoroutine(boom());}
    }
    IEnumerator boom()
    {
        Instantiate(exp, gameObject.transform);
        speed = 0f;
        canv.GetComponent<AudioSource>().Stop();
        gen.GetComponent<AudioSource>().PlayOneShot(dead);
        yield return new WaitForSeconds(0.7f);
        gamovr.SetActive(true);
        gen.GetComponent<AudioSource>().PlayOneShot(musgameovr);
        Time.timeScale = 0;
        Destroy(gameObject);
    }
    IEnumerator sped()
    {
        speed = 450f;
        yield return new WaitForSeconds(30f);
        speed = 300f;
    }
}