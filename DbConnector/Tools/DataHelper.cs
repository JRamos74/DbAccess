using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbConnector.Tools
{
    // C# ext class 
    public static class DataHelper
    {
        public static string AddXToString(this string input)
        {
            return input + "X";
        }

        public static string AddYToString(string input)
        {
            return input +"Y";
        }

        public static int Add10ToNumber(this int input)
        {
            return input + 10;
        }

        public static double GetDouble(this DataRow dr, string columnName)
        {
            double.TryParse(dr[columnName].ToString(), out double dbl);
            return dbl;
        }

        public static double GetDouble(this IDataReader reader, string columnName)
        {
            double.TryParse(reader[columnName].ToString(), out double dbl);
            return dbl;
        }

        public static T GetParamValue<T>(this IDbDataParameter[] dbParams, string paramName)
        {
            foreach(IDbDataParameter param in dbParams)
            {
                if (param.ParameterName.ToLower() == paramName.ToLower())
                    return (T)Convert.ChangeType(param.Value, typeof(T));
            }
            return default(T);
        }
    }

    public class Test
    {
        public void Tester()
        {
            int num = 20;
            num = num.Add10ToNumber();
            string _num = "test";
            DataHelper.AddYToString(_num);

            
        }
    }

}
