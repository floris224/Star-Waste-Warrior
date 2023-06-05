using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public class TestScript : MonoBehaviour
    {
        public TestTrashValue trashValue;

        private void Start()
        {
            // Create ValueTrash objects
            //ValueTrash trash1 = new ValueTrash("Trash A", 10);
            //ValueTrash trash2 = new ValueTrash("Trash B", 15);
           // ValueTrash trash3 = new ValueTrash("Trash C", 5);

            // Add ValueTrash objects to the collectedGarbage list
           // trashValue.AddGarbage(trash1);
           // trashValue.AddGarbage(trash2);
           // trashValue.AddGarbage(trash3);

            // Calculate and output the total value
            int totalValue = trashValue.CalculateTotalValue();
            Debug.Log("Total Value: " + totalValue);
        }
    }
