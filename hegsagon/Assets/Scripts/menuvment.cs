using UnityEngine;
public class menuvment : MonoBehaviour
{
    void Update()
    {transform.Rotate(new Vector3(0, 0, 45) * Time.deltaTime);}
}