using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace BeerlistService.Data
{
    public class DataSevice:IDisposable
    {
        private FileStream fileStream;

        public DataSevice(bool blocking)
        {

            bool success = false;
            int retry = 0;

            while (!success)
            {
                try
                {
                    //fileStream = File.Open("../data/data.json", FileMode.OpenOrCreate, FileAccess.ReadWrite, blocking ? FileShare.None : FileShare.Read);
                    fileStream = File.Open("Data/data.json", FileMode.OpenOrCreate, FileAccess.ReadWrite, blocking ? FileShare.None : FileShare.Read);
                    success = true;
                }
                catch (Exception ex)
                {
                    if (retry < 3)
                    {
                        Thread.Sleep(10);
                        retry++;
                    }else
                    {
                        throw new Exception("Data Access Problem", ex);
                    }
                    
                }
            }
            
        }


        public string SerializeObject<T>(T serializableObject)
        {
            string json = JsonConvert.SerializeObject(serializableObject);

            fileStream.SetLength(0);

            var writer = new StreamWriter(fileStream);
            writer.Write(json);
            writer.Flush();

            return json;
        }

        public T DeSerializeObject<T>()
        {
            var reader = new StreamReader(fileStream);

            string json = reader.ReadToEnd();

            T objekt = JsonConvert.DeserializeObject<T>(json);
            return objekt;
        }

        public void Dispose()
        {
            fileStream.Dispose();
        }
    }
}
