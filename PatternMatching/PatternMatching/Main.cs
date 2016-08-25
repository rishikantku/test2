using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternMatching
{
    class PatMatching
    {
        public static void Main()
        {
            PatMatching ob = new PatMatching();
            int[] prefix = new int[20];
            ob.computePrefix("abcdabca",prefix);

            if (ob.KMPSearch("ABABABCABABABCABABABC", "ABABAC"))
                Console.WriteLine("Found pattern ABABAC in string ABABABCABABABCABABABC");
            else
                Console.WriteLine("Pattern not found");
            
            
        }

        void computePrefix(String substr,int[] prefix)
        {
            int i = 0, j=1;
            while(j < substr.Length)
            {
                if(substr[i] == substr[j])
                {
                    prefix[j] = 1 + i;
                    i++;
                    j++;
                }
                else
                {
                    if (i == 0)
                    {
                        prefix[i] = 0;
                        j++;
                    }
                    else
                        i = prefix[i - 1];
                }
            }
        }

       bool KMPSearch(String str1, String str2)
       {
            bool ret = false;

            int[] prefix = new int[20];
            computePrefix(str2, prefix);

           int i = 0, j = 0;
            while(i < str1.Length)
            {
                if (j == str2.Length - 1)
                {
                    ret = true;
                    break;
                }
                if(str1[i] == str2[j])
                {
                    i++;
                    j++;
                }
                else
                {
                    if (j == 0)
                        i++;
                    else
                        j = prefix[j - 1];
                }
            }
            
           
           return ret;
        }
    }
}
