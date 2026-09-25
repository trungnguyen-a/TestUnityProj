using JetBrains.Annotations;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public string nameType = "Goblin";
    public int level = 25;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log("enemy name: " + nameType);
        Debug.Log("enemy level: " + level);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
