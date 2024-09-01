using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    List<GameObject> gems = new List<GameObject>();

    public static GameManager instance;

    [Tooltip("game over text")]
    [SerializeField]
    GameObject goText;

    void Start()
    {
        goText.SetActive(false);
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }

        gems.AddRange(GameObject.FindGameObjectsWithTag("Gems"));
    }

    // Method to keep track of the gems
    public void DestroyGem(GameObject gem)
    {
        gems.Remove(gem);
        if(gems.Count == 0)
        {
            Debug.Log("Game Over");
            goText.SetActive(true);
        }
    }


}
