using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NVelocity;
using NVelocity.App;

namespace SPSUtil.AppCode
{
    public class NumberGenerator
    {
        public string NewNumberLegnth(int length)
        {
            return GetRandNumber(length);
        }



        public static string GetRandNumber(int lenght)
        {
            string randNumber = "";
            var ra = new Random(Guid.NewGuid().GetHashCode());
            for (int i = 0; i < lenght; i++)
            {
                int number = (ra.Next(11) - 1);

                if (number < 0)
                {
                    number = 0;
                }

                if (number > 9)
                {
                    number = 9;
                }

                randNumber += number.ToString();
            }
            return randNumber;
        }

        public static string ParseNVelocityTemplate(string template, Hashtable paramList)
        {
            System.Text.StringBuilder builder = new System.Text.StringBuilder(template);

            VelocityEngine vltEngine = new VelocityEngine();

            vltEngine.Init();

            VelocityContext vltContext = new VelocityContext();

            foreach (DictionaryEntry item in paramList)
            {
                vltContext.Put(item.Key.ToString(), item.Value);
            }

            System.IO.StringWriter vltWriter = new System.IO.StringWriter();

            vltEngine.Evaluate(vltContext, vltWriter, null, builder.ToString());

            return vltWriter.GetStringBuilder().ToString();
        }

    }
}
