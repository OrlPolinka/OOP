using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Json;
using System.Xml;
//using System.Runtime.Serialization.Formatters.Soap;
using System.Text;
using System.Text.Json;
using System.Xml.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;
using lab13;

namespace lab13
{
    class Program
    {
        static void Main(string[] args)
        {
            TVProgpram tVProgpram1 = new TVProgpram("tv1", 2005);
            TVProgpram tVProgpram2 = new TVProgpram("tv2", 2020);


            //1

            ////////////////////////////////////////////////////////////////////////////////////////////
            //BinaryFormatter bf = new BinaryFormatter();
            //using(FileStream fs = new FileStream("points.bin", FileMode.OpenOrCreate))
            //{
            //    bf.Serialize(fs, tVProgpram1);
            //}

            //using(FileStream fs = new FileStream("points.bin", FileMode.OpenOrCreate))
            //{
            //    TVProgpram atVProgpram = (TVProgpram)bf.Deserialize(fs);
            //    Console.WriteLine(atVProgpram);
            //}


            ////////////////////////////////////////////////////////////////////////////////////////////
            //SoapFormatter formatter = new SoapFormatter();
            //using(FileStream fs = new FileStream("tv.soap", FileMode.OpenOrCreate)) 
            //{
            //    formatter.Serialize(fs, tVPogram1);
            //}
            //using (FileStream fs = new FileStream("tv.soap", FileMode.OpenOrCreate))
            //{
            //    TVProgpram newtv = (TVProgpram)formatter.Deserialize(fs);
            //    Console.WriteLine(newtv);
            //}


            /////////////////////////////////////////////////////////////////////////////////////////////
            string json = JsonSerializer.Serialize(tVProgpram1);
            Console.WriteLine(json);
            TVProgpram? newtvprogram = JsonSerializer.Deserialize<TVProgpram>(json);
            Console.WriteLine(newtvprogram);
            Console.WriteLine();


            ////////////////////////////////////////////////////////////////////////////////////////////
            XmlSerializer xSer = new XmlSerializer(typeof(TVProgpram));
            using (FileStream fs = new FileStream("tvs.xml", FileMode.OpenOrCreate))
            {
                xSer.Serialize(fs, tVProgpram1);
            }
            using (FileStream fs = new FileStream("tvs.xml", FileMode.OpenOrCreate))
            {
                TVProgpram tvxml = xSer.Deserialize(fs) as TVProgpram;
                Console.WriteLine(tvxml);
            }
            Console.WriteLine();


            //2

            ////////////////////////////////////////////////////////////////////////////////////////////
            TVProgpram[] tv = new TVProgpram[] { tVProgpram1, tVProgpram2 };
            DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(TVProgpram[]));
            using (FileStream fs = new FileStream("TVs.json", FileMode.OpenOrCreate))
            {
                jsonFormatter.WriteObject(fs, tv);
            }
            using (FileStream fs = new FileStream("TVs.json", FileMode.OpenOrCreate))
            {
                TVProgpram[] newTV = (TVProgpram[])jsonFormatter.ReadObject(fs);
                foreach (TVProgpram program in newTV)
                {
                    Console.WriteLine(program);
                }
            }
            Console.WriteLine();

            //3

            ///////////////////////////////////////////////////////////////////////////////////////////
            TVProgpram tVProgpram3 = new TVProgpram("tv3", 2022);
            TVProgpram tVProgpram4 = new TVProgpram("tv4", 2000);
            TVProgpram tVProgpram5 = new TVProgpram("tv5", 2016);
            TVProgpram tVProgpram6 = new TVProgpram("tv6", 1998);
            TVProgpram tVProgpram7 = new TVProgpram("tv7", 2007);

            List<TVProgpram> programs = new List<TVProgpram>
            {
                tVProgpram3,
                tVProgpram4,
                tVProgpram5,
                tVProgpram6,
                tVProgpram7
            };

            XmlSerializer xs = new XmlSerializer(typeof(List<TVProgpram>));
            using (FileStream fs = new FileStream("programs.xml", FileMode.OpenOrCreate))
            {
                xs.Serialize(fs, programs);
            }
            XmlDocument doc = new XmlDocument();
            doc.Load("programs.xml");
            XmlNodeList names = doc.SelectNodes("//ArrayOfTVProgpram/TVProgpram/Name");
            Console.WriteLine("Все названия программ:");
            foreach(XmlNode name in names)
            {
                Console.WriteLine(name.InnerText);
            }

            XmlNodeList newprograms = doc.SelectNodes("//ArrayOfTVProgpram/TVProgpram[Year > 2010]");
            Console.WriteLine("Все программы после 2010 года:");
            foreach(XmlNode program in newprograms)
            {
                Console.WriteLine(program["Name"].InnerText + " (" + program["Year"].InnerText + ")");
            }
            Console.WriteLine();


            //4

            ////////////////////////////////////////////////////////////////////////////////////////////////////////
            XDocument tvDoc = new XDocument(
                new XElement("TVPrograms",
                    new XElement("TVProgram",
                        new XElement("Name", "tv1"),
                        new XElement("Year", "2005")
                    ),
                    new XElement("TVProgram",
                        new XElement("Name", "tv2"),
                        new XElement("Year", "2024")
                    ),
                    new XElement("TVProgram",
                        new XElement("Name", "tv3"),
                        new XElement("Year", "1998")
                    ),
                    new XElement("TVProgram",
                        new XElement("Name", "tv4"),
                        new XElement("Year", "2020")
                    ),
                    new XElement("TVProgram",
                        new XElement("Name", "tv5"),
                        new XElement("Year", "2016")
                    )
                )
            );

            tvDoc.Save("TVProgram.xml");
            var allNameTV = tvDoc.Descendants("TVProgram").Select(tv => tv.Element("Name")?.Value);
            Console.WriteLine("Названия всех программ:");
            foreach (var program in allNameTV)
            {
                Console.WriteLine(program);
            }

            Console.WriteLine();
            var more2010tv = tvDoc.Descendants("TVProgram").Where(tv=>(int)tv.Element("Year") > 2010).Select(tv => new
            {
                Name = tv.Element("Name")?.Value,
                Year = tv.Element("Year")?.Value
            });
            Console.WriteLine("Все программы после 2010 года:");
            foreach (var program in more2010tv)
            {
                Console.WriteLine(program);
            }
        }
    }
}