using UnityEditor.UIElements;
using UnityEngine;

namespace SourFruits.WitchGame
{
    public class Plant : MonoBehaviour
    {
        public float growthPercentStart = 1f;
        public float growthPerTick = 0.15f;
        [SerializeField]
        private float growthPercent;

        /*
         * growth stages
         * germination seedling vegetative bud flowering ripening
         * seed; sprout; seedling; vegitative; budding; flowering; ripening;
         *
         * 0 growth development
         * 1 leaf develop-ment
         * 2 3 4 stem elongation and flowerbud development
         * 5 flowering
         * 6 seed development
         * 7 ripening
         */

        private int[,] germinationEstablishment = new int[0, 15];
        private struct Stage
        {
            public Stage(string _name)
            {
                name = _name;
            }

            public string name { get; }
        }
        /* Sunflower
         * 
         * 1: 0 - 5
         * 2: 5 - 15
         * 3: 15 - 20
         * 4: 20 - 35
         * 5: 35 - 45
         * 6: 45 - 55
         * 7: 55 - 65
         * 8: 65 - 70
         * 9: 70 - 75
         * 10: 75 - 85
         * 11: 85 - 95
         * 12: 95 - 105
         * 13: 105 - 125
         * 14: 125 - 130?
         * 
         * Germination and establishment of seeding 
         *      stage 1 - 3
         *      day 0 -  15
         * Weed control critical 
         *      stage 1 - 5.5
         *      day 0 -  40: 
         *  Leaf development 
         *      stage 3 - 5
         *      day 15 - 35
         * Top fertilisation 
         *      stage 4 - 5
         *      day 20 -  35
         * Flowerbud stage
         *      stage 5 - 8
         *      day 35 -  65
         * Critical moisture need
         *      stage 6 - 11
         *      day 45 -  85
         * Flowering stage
         *      stage 8 - 10.5
         *      day 65 -  80
         * Period for disease detection
         *      stage 8 - 11.5
         *      day 65 -  90
         * Seed development
         *      stage 10.5 - 15
         *      day 80 - 130
         * Pysialogically ripe
         *      stage 12.5 - 13.5
         *      day 100 - 110
         * Ripe for harvest
         *      stage 13.5 - 15
         *      day 110 - 130
        */

        //[SerializeField]
        //private float quality;
        //private bool isLuminescent = false;

        // grow status: seed, sprout, plant, bloom, dead
        // quality
        // temp
        // rootQuality

        void Start()
        {
            //growthPercent.SetValue(0.01f);
            growthPercent = growthPercentStart;
        }

        void Update()
        {
            GrowthCycle();

            print($"{name} growth: {growthPercent.ToString("#.##")}%");
        }

        private void GrowthCycle()
        {
            growthPercent += growthPerTick * Time.deltaTime;

            switch (growthPercent)
            {
                case < 1.00f:
                    // under 100%
                    break;
                case >= 1.00f:
                    growthPercent = 1.00f;
                    break;

            }
            if (growthPercent < 1.00f)
            {
                growthPercent += growthPerTick * Time.deltaTime;
            }
            else
            {
                growthPercent = 1.00f;
                growthPerTick = 0.00f;
            }
        }

        private void OnMouseDown()
        {
            print("Harvesting " + name);
            Destroy(gameObject);
        }
    }
}