using System;
using System.Threading;

namespace Pokedex.Data
{
    class CachedData<T>
    {

        public string Url { get; }
        public DateTime LastCall { get; set; }
        private T value;
        public T Value {
            get{
                return value;
            }
            set{
                this.value = value;
                this.LastCall = DateTime.Now;
            }
        }

        public CachedData(string url, T value){
            this.Url = url;
            this.LastCall = DateTime.Now;
            this.Value = value;
        }

        public Boolean NeedRefresh() { return (DateTime.Now - LastCall).TotalSeconds > 60; }
    }
}
