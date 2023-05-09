using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Linkedin_m
{
    [CreateAssetMenu(fileName ="AvailableDeathData",menuName = "Data/NewDeathData")]
    public class DeathData : ScriptableObject
    {
        public List<BodySections> ListBodySections = new List<BodySections>();
        public RuntimeAnimatorController runTimeAnimator;
    }

}


