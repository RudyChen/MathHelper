using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Models.MathModels
{
    /// <summary>
    /// 根式
    /// </summary>
    [Serializable]
    public class Radical:MathBase
    {
        private MathBase rootIndex;

        /// <summary>
        /// 根指数
        /// </summary>
        public MathBase RootIndex
        {
            get { return rootIndex; }
            set { rootIndex = value; }
        }

        private MathBase radicand;
        /// <summary>
        /// 被开方数
        /// </summary>
        public MathBase Radicand
        {
            get { return radicand; }
            set { radicand = value; }
        }

    }
}
