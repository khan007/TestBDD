using System;
using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow;

namespace TestBDD.Transform
{
    [Binding]
    public class Transforms
    {
        private static ProductCode product;
       
        [StepArgumentTransformation(@"product (.*)")]
        public ProductCode ProductConvertToProductCode(string productName)
        {
            if (product == null)
            {
                product = new ProductCode();
            }
            //Guid result = new Guid();
            //if (product == "HMS Plus 100")
            //{

            //}
            //result = new Guid("CC52408C-6464-11E0-A34B-BBDDDED72085");
            //return result;

            return ProductCode.GetProductGuid(productName);
        }
    }

    public class ProductCode
    {
        static List<ProductCode> products = new List<ProductCode>();
        public string ProductName { get; private set; }
        public string GUID { get; private set; }

        public ProductCode()
        {
            products.Add(HmsPlus100);
            products.Add(EaglePremier);
        }

        private ProductCode(string productName, string guid)
        {
            ProductName = productName;
            GUID = guid;
        }

        public static ProductCode GetProductGuid(string productName)
        {   
            return products.FirstOrDefault(x => x.ProductName == productName);
        }

        public static ProductCode HmsPlus100 = new ProductCode("HMS Plus 100", "F0C7C874-D6B2-4528-BB80-63FDD58B5725");

        public static ProductCode EaglePremier = new ProductCode("Eagle Premier Series", "ADC4E4ED-379F-427F-860D-1A1984BB9100");
    }
}
