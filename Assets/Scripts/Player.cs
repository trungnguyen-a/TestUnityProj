using UnityEngine;

public class Player : MonoBehaviour
{
    public int level = 10;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log("Player Start");
        Debug.Log("Player level" + level);
     
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
