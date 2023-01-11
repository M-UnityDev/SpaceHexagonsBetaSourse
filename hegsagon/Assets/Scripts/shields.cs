using System.Collections;
using UnityEngine;
public class shields : MonoBehaviour
{
    void Start()
    {StartCoroutine(disapear());}
    IEnumerator disapear()
    {
        yield return new WaitForSeconds(30f);
        Destroy(gameObject);
    }
}