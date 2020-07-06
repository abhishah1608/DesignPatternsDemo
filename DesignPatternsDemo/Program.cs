using CreationalPatterns;
using StructuralPattern1;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace DesignPatternsDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            // The code provided will print ‘Hello World’ to the console.
            // Press Ctrl+F5 (or go to Debug > Start Without Debugging) to run your app.
            ProtoTypeDemo protoTypeDemo = new ProtoTypeDemo();
            protoTypeDemo.Init();
            FactoryPattern pattern = new FactoryPattern();
            string str = pattern.PerformLogic("Air", "SD", null);
            Console.WriteLine(str);
            Service service = new Service();
            XmlDocument doc = service.GetDriverLocation(null);
            StringWriter stringWriter = new StringWriter();
            XmlTextWriter xmlTextWriter = new XmlTextWriter(stringWriter);

            doc.WriteTo(xmlTextWriter);

            string xml= stringWriter.ToString();

            Console.WriteLine(xml);
            Console.ReadKey();
           
             
        }
    }
}
