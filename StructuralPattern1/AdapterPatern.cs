using Newtonsoft.Json;
using System;
using System.Xml;

namespace StructuralPattern1
{
    /// <summary>
    /// Adaptee class.
    /// </summary>
    public class DriverLocation
    {
        /// <summary>
        /// Service method : this method return json string.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public string GetDriverLocation(DriverRequestBo obj)
        {
            string str = "{ DriverId :'1234','Longitude':'23.45','Latitude':'54.45'}";
            return str;
        }
    }

    public interface IClinetXml
    {
        XmlDocument GetDriverLocation(DriverRequestBo obj); 
    }

    public class DriverRequestBo
    {
       
    }

    /// <summary>
    /// Adapter class.
    /// </summary>
    public class Service : IClinetXml
    {
        public XmlDocument GetDriverLocation(DriverRequestBo obj)
        {
            DriverLocation driverLocation = new DriverLocation();
            string str = driverLocation.GetDriverLocation(obj);
            XmlDocument doc = JsonConvert.DeserializeXmlNode(str, "DriverLocation", true);
            return doc;
        }
    }
}
