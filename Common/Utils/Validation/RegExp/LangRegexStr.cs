using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Utils.Validation.RegExp
{
    public static class LangRegexStr
    {
        //Kor - Korean, Eng - English
        public static string IsOnlyKor = @"[\u3130-\u3163]";
        public static string IsOnlyBigEng = @"[\uFF21-\uFF3A]";
        public static string IsOnlySmallEng = @"[\uFF41-\uFF5A]";
        public static string IsOnlyNum = @"[\uFF10-\uFF19]";

        //Language Combined
        public static string IsKorEngNum = @"/[^a-z|A-Z|0-9|ㄱ-ㅎ|가-힣|ㅏ-ㅣ]/g";
        public static string IsEngNum = @"/^[A-Za-z0-9+]*$/";
    }
}
