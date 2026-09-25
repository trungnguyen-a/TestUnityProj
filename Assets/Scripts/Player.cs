using UnityEngine;

public class Player : MonoBehaviour
{
    public int level = 10;
    public string gender = "male";
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log("Player Start");
        Debug.Log("Player level" + level);
        Debug.Log("Player gender: " + gender);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
