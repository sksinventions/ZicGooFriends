using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Utils.Validation.RegExp
{
    public static class SignUpRegexStr
    {
        //xx_y == Language_Minimum number of each components
        //Sp == Special letter
        //Any == Big or small
        public static string BigSmallEngNumSp_8 = @"/^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$/";
        public static string EngNumSp_8 = @"/^(?=.*[A-Za-z])(?=.*\d)(?=.*[@$!%*#?&])[A-Za-z\d@$!%*#?&]{8,}$/";

        //
        public static string Email = @"/^[0-9a-zA-Z]([-_.]?[0-9a-zA-Z])*@[0-9a-zA-Z]([-_.]?[0-9a-zA-Z])*.[a-zA-Z]{2,3}$/i";
    }
}
