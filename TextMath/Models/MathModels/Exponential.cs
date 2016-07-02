using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Models.MathModels
{
    /// <summary>
    /// 指数
    /// </summary>
    [Serializable]
   public class Exponential:MathBase
    {
        private MathBase baseNumber;

        private MathBase power;

        /// <summary>
        /// 底数
        /// </summary>
        public MathBase BaseNumber
        {
            get { return baseNumber; }
            set { baseNumber = value; }
        }
       
        /// <summary>
        /// 幂
        /// </summary>
        public MathBase Power
        {
            get { return power; }
            set { power = value; }
        }

    }
}
