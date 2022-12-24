using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(disapear());
    }
    void Update()
    {transform.Rotate(new Vector3(0, 45, 0) * Time.deltaTime);}
    IEnumerator disapear()
    {
        yield return new WaitForSeconds(10f);
        Destroy(gameObject);
    }
}
