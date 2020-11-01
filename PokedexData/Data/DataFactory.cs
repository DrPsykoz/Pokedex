using Newtonsoft.Json;
using Pokedex.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Pokedex
{
    public class DataFactory<T>
    {

        private static Dictionary<string, CachedData<T>> DATA_CACHE = new Dictionary<string, CachedData<T>>();
        private static WebClient webClient = new WebClient();

        public List<T> GetCachedData()
        {
            List<CachedData<T>> values = new List<CachedData<T>>(DATA_CACHE.Values);
            return values.Select(x => x.Value).ToList();
        }

        public Task<T[]> GetDataList(string[] urls)
        {
            T[] datas = new T[urls.Length];

            for (int i = 0; i < urls.Length; i++)
                datas[i] = GetData(urls[i]);

            return Task.FromResult(datas);
        }

        public T GetData(string url)
        {
            CachedData<T> data = null;
            DATA_CACHE.TryGetValue(url, out data);

            if (data == null || data.NeedRefresh())
            {
                string json = GetJSON(url);
                if (json == null)
                {
                    new Exception("Impossible de recuperer la data via l'API, url = " + url);
                    return default;
                }


                T value = JsonConvert.DeserializeObject<T>(json);

                if (data == null)
                {
                    CachedData<T> dataParsed = new CachedData<T>(url, value);
                    DATA_CACHE.Add(url, dataParsed);
                    data = dataParsed;
                }
                else
                    data.Value = value;
            }

            return data.Value;
        }

        private string GetJSON(string url)
        {
            try
            {
                return webClient.DownloadString(new Uri(url));
            }
            catch (Exception e)
            {
                return null;
            }
        }


    }
}
