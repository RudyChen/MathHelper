using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Models.MathModels
{
    [DataContract]
    public enum MathTypeEnum
    {
        [EnumMember]
        MathText=0,
        [EnumMember]
        Exponential =1,
        [EnumMember]
        Fraction =2,
        [EnumMember]
        Logrithm =3,
        [EnumMember]
        Polynomial =4,
        [EnumMember]
        Radical =5
    }
}
