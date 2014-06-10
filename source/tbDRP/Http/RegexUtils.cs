using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace tbDRP.Http
{
    public class RegexGroupResult
    {
        public GroupCollection collection;

        public Group this[string name]
        {
            get
            {
                if (collection != null)
                    return collection[name];
                else
                    return null;

            }
        }
    }

    public static class RegexUtils
    {
        private static Regex regex;

        public static string Replace(string input, string pattern, string replacement)
        {
            return Regex.Replace(input, pattern, replacement);
        }

        public static GroupCollection Match(string input, string pattern)
        {
            regex = new Regex(pattern, RegexOptions.IgnoreCase);

            Match match = regex.Match(input);
            return match.Groups;
        }

        public static List<RegexGroupResult> MatchCollection(string input, string pattern)
        {
            regex = new Regex(pattern, RegexOptions.IgnoreCase);

            MatchCollection matchcollection = regex.Matches(input);
            List<RegexGroupResult> list = new List<RegexGroupResult>();

            foreach (Match m in matchcollection)
            {
                RegexGroupResult tmp = new RegexGroupResult();
                tmp.collection = m.Groups;

                list.Add(tmp);
            }

            return list;
        }

        public static string[][] MatchCollectionArray(string input, string pattern)
        {
            regex = new Regex(pattern, RegexOptions.IgnoreCase);

            MatchCollection matchcollection = regex.Matches(input);
            List<string[]> list = new List<string[]>();

            foreach (Match m in matchcollection)
            {
                List<string> grougs = new List<string>();

                foreach (Group g in m.Groups)
                {
                    grougs.Add(g.Value);
                }

                list.Add(grougs.ToArray());
            }

            return list.ToArray();
        }
    }
}
