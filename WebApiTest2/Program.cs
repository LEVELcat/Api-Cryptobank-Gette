using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net.Http;
using System.Net.Http.Headers;
using WebApiTest;

namespace WebApiTest2
{
    public static class Programm
    {
        public static void Main()
        {

            PrototypeMain();
            //DebugMain();
        }



        public static void PrototypeMain()
        {
            TimeSpan time = new TimeSpan(0);
            int count = 0;
            for (count = 0; count < 100; count++)
            {
                DateTime dateTime = DateTime.Now;

                StreamReader streamReader = new StreamReader(@".\music.txt");
                var str = streamReader.ReadToEnd();
                streamReader.Close();
                streamReader.Dispose();

                List<PtototypeNameSpace.JsonGet.APIData> aPIDatas = PtototypeNameSpace.JsonGet.APIData.ConvertJsonToAPIDatas(str);

                DateTime dateTime1 = DateTime.Now;

                time = time.Add(dateTime1.Subtract(dateTime));

                //Console.WriteLine(dateTime1.Subtract(dateTime).TotalSeconds);
            }
            Console.WriteLine("Среднее время выполнения");
            Console.WriteLine(time.TotalSeconds / count);

            Console.WriteLine();
            time = new TimeSpan(0);

            for (int i = 0; i < count; i++)
            {
                DateTime dateTime = DateTime.Now;

                DateTime dateTime1 = DateTime.Now;
                time = time.Add(dateTime1.Subtract(dateTime));
            }
            Console.WriteLine("Среднее время выполнения (контроль)");
            Console.WriteLine(time.TotalSeconds / count);
        }




        public static void DebugMain()
        {
            //WebTest webTest = new WebTest();
            //webTest.Main();

            DeserializationTest deserializationTest = new DeserializationTest();
            deserializationTest.Main();
        }




    }
}