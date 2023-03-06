using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

namespace SourFruits.WitchGame
{
    /// <summary>
    /// Class <c>Plant</c> Base plant class.
    /// </summary>
    public class Plant : MonoBehaviour
    {        
        public float startDay = 1;        
        public float dayPerTick = 0.0175f; // make dayPerTick modular & subscribe to it? have a default value otherwise

        [SerializeField]
        private float currentDay;                
        private bool isGrowing = false;
        
        //[SerializeField]
        //private float quality;
        //private bool isLuminescent = false;

        /// <summary>
        /// Method <c>Plant</c> 
        /// </summary>
        public Plant()
        {
            // plant type
            // start day (might implement clipping in future)
        }

        void Start()
        {
            isGrowing = true;
            currentDay = startDay;
        }

        void Update()
        {
            GrowthCycle();
            QualityAdjustment();

        }

        /// <summary>
        /// Method <c>GrowthCycle</c> Handles plant growth.
        /// </summary>
        private void GrowthCycle()
        {
            if (isGrowing)
            {
                // generic, will move to json or sqlite
                switch (currentDay)
                {                
                    // growing
                    case < 100.00f:
                        currentDay += dayPerTick * Time.deltaTime;
                        print($"{name} growth: {currentDay.ToString("#.##")}%");
                        break;
                    // complete growing
                    case >= 100.00f:
                        currentDay = 100.00f;
                        print("Harvest time");
                        isGrowing = false;
                        break;
                }
            }
        }

        /// <summary>
        /// Method <c>QualityAdjustment</c> Handles plant quality adjustments.
        /// </summary>
        private void QualityAdjustment()
        {
            // todo: impementation
        }

        private void OnMouseDown()
        {
            print("Harvesting " + name);
            Destroy(gameObject);
        }
    }
}