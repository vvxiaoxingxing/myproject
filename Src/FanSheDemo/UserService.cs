using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FanSheDemo
{
    public class UserService
    {
        public  async Task InitAsync()
        {
            string a = "1";
            string b = "2";
            var han =  new Func<string, string, Task<bool>>(GetSDMPData<bool>);
             await han.TryHandler(a,b, (a,b,ex) =>
            {
                
            });
        }


        private  async Task<bool> GetSDMPData<T>(string url, string param)
        {
            
            return true;
        }

    }
}
