using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace REG_MARK_LIB
{
    public class Class1
    {
        public static List<char> simvol = new List<char>() { 'A', 'B', 'E', 'K', 'M', 'H', 'O', 'P', 'C', 'T', 'Y', 'X' };

        //Метод для проверки правильности номера знака
        public static bool CheckMark(string mark)
        {
            try
            {
                Regex regex = new Regex("^[ABEKMHOPCTYX]{1}[0-9]{3}[ABEKMHOPCTYX]{2}[0-9]{3}");
                bool a = regex.IsMatch(mark);
                if (a)
                {
                    string registNomer = mark.Substring(1, mark.Length - 6);
                    string registKod = mark.Substring(mark.Length - 3);
                    if (registKod == "000" || registNomer == "000")
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }

        }
        // Метод который выдаёт следующий знак в данной серии или создает следующую серию
        public static string GetNextMarkAfter(string mark)
        {
            try
            {
                string stringMark = "";
                string registNomer = mark.Substring(1, mark.Length - 6);
                if (registNomer == "999")
                {
                    registNomer = "001";

                    if (mark[5] == simvol[simvol.Count - 1])
                    {
                        if (mark[0] != simvol[simvol.Count - 1])
                        {
                            int indexSimvola = -1;
                            for (int i = 0; i < simvol.Count; i++)
                            {
                                if (simvol[i] == mark[0])
                                {
                                    indexSimvola = i;
                                }
                            }
                            stringMark = simvol[indexSimvola + 1] + registNomer + mark[4] + simvol[0] + mark[mark.Length - 3] + mark[mark.Length - 2] + mark[mark.Length - 1];
                        }
                        else
                        {
                            if (mark[4] == simvol[simvol.Count - 1])
                            {
                                stringMark = "error";
                            }
                            else
                            {
                                
                                int indexSimvola = -1;
                                for (int i = 0; i < simvol.Count; i++)
                                {
                                    if (simvol[i] == mark[4])
                                    {
                                        indexSimvola = i;
                                    }
                                }
                                stringMark = simvol[0] + registNomer + simvol[indexSimvola+1] + simvol[0] + mark[mark.Length - 3] + mark[mark.Length - 2] + mark[mark.Length - 1];
                            }

                        }

                    }
                    else
                    {

                        int indexSimvola = -1;
                        for (int i = 0; i < simvol.Count; i++)
                        {
                            if (simvol[i] == mark[5])
                            {
                                indexSimvola = i;
                            }
                        }
                        stringMark = mark[0] + registNomer + mark[4] + simvol[indexSimvola + 1] + mark[mark.Length - 3] + mark[mark.Length - 2] + mark[mark.Length - 1];
                    }

                }

                return stringMark;
            }
            catch
            {
                return "error";

            }
        }
        //Метод для проверки номера в диапозоне 
        public static string GetNextMarkAfterInRange(string prevMark, string rangeStart, string rangeEnd)
        {
            try
            {
                string kodRegion = prevMark.Substring(prevMark.Length - 3);
                string kodRegionStart = rangeStart.Substring(rangeStart.Length - 3);
                string kodRegionEnd = rangeEnd.Substring(rangeEnd.Length - 3);
                if (kodRegionStart != kodRegionEnd || kodRegionStart != kodRegion)
                {
                    return "out of stock";
                }
                bool a = false; // Входит ли данное число в диапозон
                string mark = rangeStart;
                while (mark != rangeEnd)
                {
                    if (mark == prevMark)
                    {
                        a = true;
                        break;
                    }
                    mark = GetNextMarkAfter(mark);
                }
                if (mark == prevMark)
                {
                    a = true;
                }
                string nextMark = prevMark;
                if (a == true)
                {
                    if (nextMark != rangeEnd)
                    {
                        nextMark = GetNextMarkAfter(nextMark);
                    }
                    else
                    {
                        return "out of stock";
                    }
                }
                else
                {
                    return "out of stock";
                }
                return nextMark;
            }
            catch
            {
                return "out of stock";
            }
        }
        public static int GetCombinationsCountInRange(string mark1, string mark2)
        {
            try
            {
                string kodRegion1 = mark1.Substring(mark1.Length - 3);
                string kodRegion2 = mark1.Substring(mark1.Length - 3);
                if (kodRegion1 != kodRegion2)
                {
                    return 0;
                }
                int count = 0;
                string nextMark = mark1;
                count++;
                while (nextMark != mark2)
                {
                    nextMark = GetNextMarkAfter(nextMark);
                    count++;
                }
                return count;
            }
            catch
            {
                return 0;
            }

        }
    }
}

