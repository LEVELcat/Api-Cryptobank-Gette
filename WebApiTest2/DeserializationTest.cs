using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace WebApiTest
{
    public class DeserializationTest
    {

        public void Main()
        {
            StreamReader streamReader = new StreamReader(@".\music.txt");
            var str = streamReader.ReadToEnd();
            streamReader.Close();
            streamReader.Dispose();


            var dynamicObj = JsonConvert.DeserializeObject<dynamic>(str);

            dynamic data = dynamicObj.data;

            List<dynamic> list = new List<dynamic>();

            foreach (var item in data)
            {
                list.Add(item);
            }

            foreach (dynamic item in list)
            {
                Console.WriteLine(item.symbol + "\t| " + item.name);



            }



            Console.ReadLine();
        }


    }
}
