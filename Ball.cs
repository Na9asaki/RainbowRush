using UnityEngine;

public class Ball : MonoBehaviour
{
    public int ID { get; private set; }

    public void Init()
    {
        ID = ObjectGeneration.CountObject;
        GetComponent<MeshRenderer>().material.SetColor("_ColorTint", Random.ColorHSV());
    }

    public void Delete()
    {
        Destroy(gameObject);
    }
}
