using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project_otchislenie
{
    public class Http
    {
        HttpClient client = new HttpClient();

        public Http() 
        {
            client.BaseAddress = new Uri("http://10.0.2.2:5246");
        }

        //public async void Check
        //{
           
        //}
    }
}
