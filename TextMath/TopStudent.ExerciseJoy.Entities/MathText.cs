using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopStudent.ExerciseJoy.Entities
{
    [Serializable]
   public class MathText
    {
        private string id;

        private string text;


        public string Text
        {
            get { return text; }
            set { text = value; }
        }

        public string ID
        {
            get { return id; }
            set { id = value; }
        }

    }
}
