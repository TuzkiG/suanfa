using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace suanfa
{
    class HashCS
    {


        public static int HashFunc(string key, int tableSize)
        {
            int hashVal = 0;
            for (int i = 0; i < key.Length; i++)
            {
                hashVal = 37 * hashVal + key[i];
            }
            hashVal %= tableSize;

            if (hashVal < 0)
                hashVal += tableSize;

            return hashVal;
        }
    }
}
