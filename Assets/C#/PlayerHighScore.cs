using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.C_
{
    [Serializable]
    public class PlayerHighScore
    {
        [SerializeField]
        public string playerName { get; set; }
        [SerializeField]
        public int score { get; set; }
    }
}
