using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TopStudent.ExerciseJoy.Entities;

namespace TopStudent.ExerciseJoy.IDAL
{
    public interface IExponential
    {
        Exponential GetExponentialByID(string id, IDbConnection conn);
        
    }
}
