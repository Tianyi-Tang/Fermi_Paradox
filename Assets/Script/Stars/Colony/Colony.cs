using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colony : MonoBehaviour
{
    private CivilizationSO owner;
    private int totalResource;
    private List<PlanetHabitation> habitations;
    private int resourceAddingSum;

    public void changeResourceAdding(int changeValue) {
        resourceAddingSum += changeValue;
    }




    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {

    }

}
