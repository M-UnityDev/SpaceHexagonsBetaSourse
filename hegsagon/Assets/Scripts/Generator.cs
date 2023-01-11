using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using TMPro;
public class Generator : MonoBehaviour
{
    public float scr1;
    public float spwnrt = 2f;
    public GameObject hexpref;
    public GameObject coinpref;
    public GameObject spdpref;
    public GameObject pan;
    public GameObject canv;
    public bool pause = false;
    public float nxttimetispwn = 0f;
    public TMP_Text score;
    public Vector3 center;
    public AudioClip auc;
    void Start()
    {
        StartCoroutine(coin());
        StartCoroutine(spdspwn());
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pause = !pause;
            pan.SetActive(pause);
            if (pause == false)
            {
                Time.timeScale = 1;
                canv.GetComponent<AudioSource>().volume = 1f;
            }
            else
            {
                Time.timeScale = 0;
                canv.GetComponent<AudioSource>().volume = 0.25f;
            }
        }
        if (Time.time >= nxttimetispwn)
        {
            Instantiate(hexpref, Vector3.zero, Quaternion.identity);
            nxttimetispwn = Time.time + 1f * spwnrt;
            scr1 += 1;
            score.text = "Score: " + scr1;
        }
    }
    public void extbtn()
    {
        GetComponent<AudioSource>().PlayOneShot(auc);
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
    }
    public void resumbtn()
    {
        GetComponent<AudioSource>().PlayOneShot(auc);
        Time.timeScale = 1;
        canv.GetComponent<AudioSource>().volume = 1f;
        pause = !pause;
        pan.SetActive(pause);
    }
    public void restartbtn()
    {
        GetComponent<AudioSource>().PlayOneShot(auc);
        SceneManager.LoadScene("Game");
        Time.timeScale = 1;
        canv.GetComponent<AudioSource>().volume = 1f;
    }
    IEnumerator coin()
    {
        Vector2 pos = center + new Vector3(Random.Range(-15f, 15f), Random.Range(-15f, 15f));
        yield return new WaitForSeconds(5f);
        Instantiate(coinpref, pos, Quaternion.identity);
        StartCoroutine(coin());
    }
    IEnumerator spdspwn()
    {
        Vector2 pos = center + new Vector3(Random.Range(-15f, 15f), Random.Range(-15f, 15f));
        yield return new WaitForSeconds(15f);
        Instantiate(spdpref, pos, Quaternion.identity);
        StartCoroutine(spdspwn());
    }
    public void puse()
    {
        pause = !pause;
        pan.SetActive(pause);
        if (pause == false)
        {
            Time.timeScale = 1;
            canv.GetComponent<AudioSource>().volume = 1f;
        }
        else
        {
            Time.timeScale = 0;
            canv.GetComponent<AudioSource>().volume = 0.25f;
        }
    }
}