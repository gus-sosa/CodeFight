using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace GroupingDishes
{
    class Program
    {
        string[][] groupingDishes(string[][] dishes)
        {
            var hash = new Dictionary<string, List<string>>();
            foreach (string[] dish in dishes)
            {
                var nameDish = dish[0];
                var ingredients = dish.Skip(1);
                foreach (var ingredient in ingredients)
                {
                    if (!hash.ContainsKey(ingredient))
                        hash[ingredient] = new List<string>();
                    hash[ingredient].Add(nameDish);
                }
            }

            var list = new List<string[]>();

            var dishComparer = new DishComparison();
            foreach (string hashKey in hash.Keys)
                if (hash[hashKey].Count >= 2)
                {
                    hash[hashKey].Sort(dishComparer);
                    list.Add(new[] { hashKey }.Concat(hash[hashKey].ToArray()).ToArray());
                }

            list.Sort(new IngredientComparison());
            return list.ToArray();
        }

        class DishComparison : IComparer<string>
        {
            public int Compare(string x, string y)
            {
                return StringComparer.Ordinal.Compare(x, y);
            }
        }

        class IngredientComparison : IComparer<string[]>
        {
            public int Compare(string[] x, string[] y)
            {
                return StringComparer.Ordinal.Compare(x[0], y[0]);
            }
        }

        static void Main(string[] args)
        {
            var p = new Program();
            var result = p.groupingDishes(new[]
            {new[]{"dSaLKJGbxlxcBBv kMNOmzdojCluYeCb","zjxwKcRmpQTPSPRUKLfAhkIXxfzniZjsDfaKOJOcVDaxAnCF"},
                new[]{"R GBgXIv","fPhNHIdOTeKPnqaIPAYXScGrDyGWwlqktYtyOzondayKp","xJ hfufIWL","YduFVZrZEeqVmvACdSTdQd uMswBcadvet","WHYOLUzwSHKUuCNry"},
                new[]{"kvHxWutzASOCBHV","wpzmQKLROsw ","sxgFkhrwFKB","reRqP TFlpmiQa GoZTuErWVB","LA","BGQgMdEGXutmmE InKtapSHbwZlPHrvPwbSmRWclamnTW","QgBClPTxsIpAl","SWbXtEIFeVqoUgtSfXKcVmnwDrijLYsPeXfUauFVbBkbEmGDa"},
                new[]{"Hgpu","fvORUPNvHmBtpKpbTRbmdXzicYOZotLmfoLmQIqBInPnbCFN","WHYOLUzwSHKUuCNry"},
                new[]{"gZxWYomyYO","fvORUPNvHmBtpKpbTRbmdXzicYOZotLmfoLmQIqBInPnbCFN","YduFVZrZEeqVmvACdSTdQd uMswBcadvet","XxRAIFwrGmaarKfz","yJffViKwbqCATxHcQFDLgMX","poEnqRtrANh","QgBClPTxsIpAl","dyqdvHDdflvzxVAGRyxWPMBtIDJhv paNyJbWab"},
                new[]{"rMSYkYkFKlcdBTrUpCTdFgEIdgdTOcEucJdPqiLUWUZNjcoL","YduFVZrZEeqVmvACdSTdQd uMswBcadvet","QgBClPTxsIpAl","fPhNHIdOTeKPnqaIPAYXScGrDyGWwlqktYtyOzondayKp","udzzsbLVValZOWpRLhUKumkROw","dyqdvHDdflvzxVAGRyxWPMBtIDJhv paNyJbWab","WHYOLUzwSHKUuCNry","LA","fvORUPNvHmBtpKpbTRbmdXzicYOZotLmfoLmQIqBInPnbCFN"},
                new[]{"GrWh ROg zHXhYguurdcGjNAv","dyqdvHDdflvzxVAGRyxWPMBtIDJhv paNyJbWab","YduFVZrZEeqVmvACdSTdQd uMswBcadvet","AQglifKDgZIivthzfoWRklaKs","UcIBqQckdEJgLeWMlaRPlqfkhVRXjtZHAYDVRhPsFqPOuEVN","LA","MWhqbkFrSTnOuWKexjPewdd AOISBnSCilJ","QgBClPTxsIpAl"},
                new[]{"dLuvsltPzUjfXkynBCMgxBUTXhVCd","udzzsbLVValZOWpRLhUKumkROw","BGQgMdEGXutmmE InKtapSHbwZlPHrvPwbSmRWclamnTW","BjRRCVKznaySRzyAuNxAbkSYTmcUGlvOND","wpzmQKLROsw ","qLKOIfeBowxWwxPJWrWjtVXMkG NXOLxYxvCKoAagSHYRxVgK","WdfleYASWwVMQKoBINhwpjDbVBEaOOogkKMZ","AQglifKDgZIivthzfoWRklaKs","qRUsCllaFzNWuXIMvbOsNtTTAlbR"},
                new[]{"jOubIROdYWOKxwbZTLDueBiln","fTUBneoUSWxFERZjwPMrAQq","NPuomEOeOXBiozrNZXlXcKKB","ibogPWJoEbermlJfuizYaE","zpNFvjef mpEbEqy rdudPTGpzo n FwxTA"},
                new[]{"BiNYUHMFrRoSICZ","ufYAxvBidQjinsDCurHyjlzRHrOQ MbIVKGLwAq","nvHaaRJdHgRIgXXQteAchX MKldBbM","TdBMoUrYiEcJPlERejkAQdxYMTatLYXX","qLKOIfeBowxWwxPJWrWjtVXMkG NXOLxYxvCKoAagSHYRxVgK"}});
            PrintResult(result);
        }

        private static void PrintResult(string[][] result)
        {
            Console.Write("[");
            for (var i = 0; i < result.Length; i++)
            {
                var row = result[i];
                Console.WriteLine($"[{row.Aggregate("", (acc, curr) => $"{acc},{curr}").Remove(0, 1)}]{(i == result.Length - 1 ? "" : ",")}");
            }
            Console.Write("]");
        }
    }
}
