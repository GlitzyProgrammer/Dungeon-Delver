using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordController : MonoBehaviour
{
    private GameObject sword;
    private Dray dray;   

    void Start()
    {
        // Find the Sword child of SwordController
        Transform swordT = transform.Find("Sword");
        if (swordT == null)
        {
            Debug.LogError("Could not find Sword child of SwordController.");
            return;
        }
        sword = swordT.gameObject;

        // Check if the sword GameObject is found
        if (sword == null)
        {
            Debug.LogError("Sword GameObject could not be found.");
            return;
        }

        // Find the Dray component on the parent of SwordController
        dray = GetComponentInParent<Dray>();
        if (dray == null)
        {
            Debug.LogError("Could not find parent component Dray.");
            return;
        }

        // Deactivate the sword
        sword.SetActive(false);
    }

    void Update()
    {
        // Ensure dray is not null before using it
        if (dray == null)
        {
            Debug.LogError("Dray component is missing.");
            return;
        }

        // Rotate the sword based on the facing direction of Dray
        transform.rotation = Quaternion.Euler(0, 0, 90 * dray.facing);

        // Activate the sword only during attack mode
        sword.SetActive(dray.mode == Dray.eMode.attack);
    }
}

