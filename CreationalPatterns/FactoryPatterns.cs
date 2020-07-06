using System;
using System.Collections.Generic;
using System.Text;

namespace CreationalPatterns
{
    public class FactoryPattern
    {
        public string PerformLogic(string ServiceType,string Servicename, ServiceBo obj)
        {
            AbstractFactory factory = FactoryProducer.GetFactory(ServiceType);
            // factory creates factory that can be Flash, Air or third party object.
            return factory?.GetService(Servicename)?.performServiceLogic(obj);
            // GetService returns Actual class of Service SD, Air, H3P,D3P or PR.
            // performServicelogic would perform logic of particular service.
        }
    }

    public class ServiceBo
    {

    }

    public abstract class AbstractFactory
    {
        public abstract IService GetService(string Servicename);
    }

    public interface IService
    {
        string performServiceLogic(ServiceBo obj);
    }



    public class PRService : IService
    {
        public string performServiceLogic(ServiceBo obj)
        {
            string t = "logic of PR Servce performed";
            return t;
        }
    }

    public class DRService : IService
    {
        public string performServiceLogic(ServiceBo obj)
        {
            string t = "logic of DR Servce performed";
            return t;
        }
    }

    public class AirService : IService
    {
        public string performServiceLogic(ServiceBo obj)
        {
            string t = "logic of AIR Servce performed";
            return t;
        }
    }

    public class SDService : IService
    {
        public string performServiceLogic(ServiceBo obj)
        {
            string t = "logic of SD Servce performed";
            return t;
        }
    }

    public class H3PService : IService
    {
        public string performServiceLogic(ServiceBo obj)
        {
            string t = "logic of H3P Servce performed";
            return t;
        }
    }

    public class D3Pservice : IService
    {
        public string performServiceLogic(ServiceBo obj)
        {
            string t = "logic of D3P Servce performed";
            return t;
        }
    }


    public class FlashServiceFactory : AbstractFactory
    {
        public override IService GetService(string Servicename)
        {
            IService service = null;
            switch (Servicename)
            {
                case "PR":
                    service = new PRService();
                    break;
                case "DR":
                    service = new DRService();
                    break;
                default:
                    service = null;
                    break;
            }
            return service;
        }

    }

    public class AirServiceFactory : AbstractFactory
    {
        public override IService GetService(string Servicename)
        {
            IService service = null;
            switch (Servicename)
            {
                case "AIR":
                    service = new AirService();
                    break;
                case "SD":
                    service = new SDService();
                    break;
                default:
                    service = null;
                    break;
            }
            return service;
        }

    }

    public class ThirdPartyService : AbstractFactory
    {
        public override IService GetService(string Servicename)
        {
            IService service = null;
            switch (Servicename)
            {
                case "H3P":
                    service = new H3PService();
                    break;
                case "D3P":
                    service = new D3Pservice();
                    break;
                default:
                    service = null;
                    break;
            }
            return service;
        }

    }

    public class FactoryProducer
    {
        public static AbstractFactory GetFactory(string serviceType)
        {
            AbstractFactory factory = null;
            switch (serviceType)
            {
                case "Air":
                    factory = new AirServiceFactory();
                    break;
                case "Flash":
                    factory = new FlashServiceFactory();
                    break;
                case "ThirdParty":
                    factory = new FlashServiceFactory();
                    break;
            }
            return factory;
        }

    }


}
