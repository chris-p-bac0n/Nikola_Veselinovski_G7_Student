using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise1
{
    public static class PetStore
    {
        public static string PrintsPets<T>(List<T> list)
        {
            string info = string.Empty;

            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].GetType )
                info += $"{i + 1}. {list[i]}\n";
            }

            return info;
        }
    }
}
