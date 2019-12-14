#undef DEBUG

using UnityEngine;

namespace FLLib {
    public class Roll {
        public float chance;
        public float incrementOnRoll;  
           
        private readonly float maxChance;
        private readonly float scaleBy;    
        private readonly RollIncrementTypeEnum rollIncrementType;
        
        public Roll(float chance=0, float maxChance=100,float incrementOnRoll=0, RollIncrementTypeEnum rollIncrementType=RollIncrementTypeEnum.None,float scaleBy=0) {

            this.chance = chance;
            this.maxChance = maxChance;
            this.incrementOnRoll = incrementOnRoll;
            this.rollIncrementType = rollIncrementType;
            this.scaleBy = scaleBy;
        }

        public bool roll() {
            if (chance >= maxChance) {
                return true;
            }

            float rolled = Random.Range(0, maxChance);
            
            #if DEBUG
            var oldChance = chance;
            #endif
            
            bool result= rolled < chance;

            increment();
                                    
            #if DEBUG
            Debug.Log("Rolled "+rolled+" out of "+ maxChance + " with a chance of "+oldChance+" (chance increased to "+chance+")");
            #endif

            return result;
        }

        public float increment() {
            switch (rollIncrementType) {
                case RollIncrementTypeEnum.Absolute:
                    chance += incrementOnRoll;
                    break;
                case RollIncrementTypeEnum.Percentage:
                    chance += chance*incrementOnRoll/maxChance;
                    break;
                case RollIncrementTypeEnum.AbsoluteScaling:
                    chance += incrementOnRoll;
                    incrementOnRoll += scaleBy;
                    break;
                case RollIncrementTypeEnum.PercentageScaling:
                    chance += incrementOnRoll;
                    incrementOnRoll += incrementOnRoll*scaleBy/maxChance;
                    break;
            }

            return chance / maxChance;
        }

        public override string ToString() {
            var percent = chance / maxChance;
            return percent>100?100+"%":percent+"%";
        }
    }
}