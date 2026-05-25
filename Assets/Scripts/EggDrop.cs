using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggDrop : MonoBehaviour //AM
{
  
    public GameObject eggPrefab; // stores the egg prefab
    public GameObject dropPoint; // stores the eggdrop point
    public int spawnTime; // publically stores the egg spawn rate
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnEgg", 0f, spawnTime); // calls the spawnegg function every spawnTime
    } // end of start

   void SpawnEgg()
    {
        Instantiate(eggPrefab, dropPoint.transform.position, dropPoint.transform.rotation); // spawns egg at the drop point position
    } // end of spawnegg
 
} // end of class AM
