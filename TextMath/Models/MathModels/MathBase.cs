using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Models.MathModels
{
    [Serializable]
    public class MathBase
    {
        private MathTypeEnum mathType=MathTypeEnum.MathText;

        public MathTypeEnum MathType
        {
            get { return mathType; }
            set { mathType = value; }
        }

    }
}
