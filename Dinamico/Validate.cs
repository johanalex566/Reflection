using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dinamico
{
    public partial class Reflection
    {
        public bool ValidateParameter()
        {
            if (dirFail.Length > 3)
            {
                typesParamsEnterUser = new List<Type>();

                param = dirFail[3];

                arrayParam = param.Split(",".ToArray());


                if (param[0].ToString() == "{")
                {
                    arrayParam = param.Split(" ".ToArray());

                    countParam = param.Split(" ".ToArray()).Count();

                    typesParamsEnterUser.Add(param.GetType());
                }
                else
                {
                    countParam = param.Split(",".ToArray()).Count();

                    arrayParam = param.Split(",".ToArray());

                    foreach (var prm in param.Split(",".ToArray()))
                    {
                        isNumeric = float.TryParse(prm.ToString(), out num);

                        if (isNumeric)
                        {
                            typeValue = num;

                            typesParamsEnterUser.Add(num.GetType());

                            continue;
                        }

                        typesParamsEnterUser.Add(param.GetType());
                    }
                }
                return true;
            }
            return false;
        }

    }
}
