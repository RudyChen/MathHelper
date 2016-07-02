using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.MathModels
{
    /// <summary>
    /// 数学文本
    /// </summary>
    [Serializable]
   public class MathText: MathBase
    {
        private string text;

        public string Text
        {
            get { return text; }
            set { text = value; }
        }

    }
}
