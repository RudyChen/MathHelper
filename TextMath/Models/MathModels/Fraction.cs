using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Models.MathModels
{
    /// <summary>
    /// 分数
    /// </summary>
    [Serializable]
    public class Fraction: MathBase
    {
        private MathBase numerator;

        private MathBase denominator;

        public MathBase Denominator
        {
            get { return denominator; }
            set { denominator = value;}
        }
        
        public MathBase Numerator
        {
            get { return numerator; }
            set { numerator = value; }
        }

    }
}
