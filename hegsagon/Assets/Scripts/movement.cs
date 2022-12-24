using UnityEngine;
using TMPro;

using System.Collections;
public class movement : MonoBehaviour
{
    public float speed = 300f;
    public float movent = 0f;
    public int coins = 0;
    public TMP_Text cointxt;
    public new Collider2D collider;
    public GameObject gamovr;
    public GameObject exp;
    public GameObject gen;
    public GameObject canv;
    public AudioClip gameover;
    public AudioClip dead;
    public GameObject pan;
    void Update()
    {
        movent = Input.GetAxisRaw("Horizontal");
        transform.RotateAround(Vector3.zero, Vector3.forward, movent * speed * Time.deltaTime);
        transform.Rotate(new Vector3(0, 0, 45) * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Coin")
        {
            Destroy(collider.gameObject);
            coins += 1;
            cointxt.text = coins + ":Coins";
            Debug.Log("coin");
        }
        else if (collider.gameObject.tag == "Speed")
        {
            Destroy(collider.gameObject);
            StartCoroutine(sped());
        }
        else
        {
            StartCoroutine(boom());
        }
    }
    IEnumerator boom()
    {
        speed = 0f;
        Destroy(pan);
        Instantiate(exp, gameObject.transform);
        canv.GetComponent<AudioSource>().Stop();
        gen.GetComponent<AudioSource>().PlayOneShot(dead);
        yield return new WaitForSeconds(0.7f);
        Destroy(gameObject);
        gen.GetComponent<AudioSource>().PlayOneShot(gameover);
        gamovr.SetActive(true);
        Time.timeScale = 0;
    }
    IEnumerator sped()
    {
        speed = 450f;
        yield return new WaitForSeconds(30f);
        speed = 300f;
    }
}