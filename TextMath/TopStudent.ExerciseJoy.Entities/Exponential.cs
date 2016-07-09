using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopStudent.ExerciseJoy.Entities
{
    [Serializable]
    public class Exponential
    {
        private string id;

        private string baseId;

        private string powerId;

        private int baseType;

        private int powerType;


        public int PowerType
        {
            get { return powerType; }
            set { powerType = value; }
        }


        public int BaseType
        {
            get { return baseType; }
            set { baseType = value; }
        }

        public string PowerID
        {
            get { return powerId; }
            set { powerId = value; }
        }


        public string BaseID
        {
            get { return baseId; }
            set { baseId = value; }
        }

        public string ID
        {
            get { return id; }
            set { id = value; }
        }

    }
}
