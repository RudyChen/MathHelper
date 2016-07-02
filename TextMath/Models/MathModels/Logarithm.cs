using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Models.MathModels
{
    /// <summary>
    /// 对数
    /// </summary>
    [Serializable]
    public class Logarithm:MathBase
    {
        private MathBase baseNumber;

        private MathBase realNumber;
        
        public MathBase RealNumber
        {
            get { return realNumber; }
            set { realNumber = value; }
        }

        public MathBase BaseNumber
        {
            get { return baseNumber; }
            set { baseNumber = value; }
        }

    }
}
