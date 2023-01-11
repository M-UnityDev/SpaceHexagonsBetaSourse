using UnityEngine;
using TMPro;
using System.Collections;
public class moonment : MonoBehaviour
{
    public float speed = 300f;
    private float movent = 0f;
    public new Collider2D collider;
    public TMP_Text cointxt;
    public GameObject exp;
    public GameObject gen;
    public movement earth;
    public AudioClip dead;
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
        {}
        else
        {StartCoroutine(boom());}
    }
    IEnumerator boom()
    {
        Instantiate(exp, gameObject.transform);
        speed = 0f;
        earth.coins = earth.coins - 10;
        cointxt.text = earth.coins + " :Coins";
        Debug.Log("-10");
        gen.GetComponent<AudioSource>().PlayOneShot(dead);
        yield return new WaitForSeconds(0.7f);
        Destroy(gameObject);
    }
}