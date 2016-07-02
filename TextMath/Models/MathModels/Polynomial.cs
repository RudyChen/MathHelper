using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Models.MathModels
{
    /// <summary>
    /// 多项式
    /// </summary>
    [Serializable]
    public class Polynomial:MathBase
    {
        private List<MathBase> items = new List<MathBase>();

        public List<MathBase> Items
        {
            get { return items; }
            set { items = value; }
        }
    }
}
