using DbWriter.src.DTO;
using DbWriter.src.Interfaces;
using System.Globalization;
using System.Xml.Linq;

namespace DbWriter.src.Services
{
    public class XmlParser : IXmlParser
    {
        public IEnumerable<XOrder> Read(string pathFile)
        {
            XDocument xDocument;

            try
            {
                xDocument = XDocument.Load(pathFile);
            }
            catch(Exception ex)
            {
                return null;
            }
            
            var query = xDocument.Element("orders")
                .Elements("order")
                .Select(o => new
                {
                    no = o.Element("no"),
                    regDate = o.Element("reg_date"),
                    sum = o.Element("sum"),
                    user = o.Element("user"),
                    products = o.Elements("product")
                });

            List<XOrder> xorders = new List<XOrder>();

            foreach (var item in query)
            {
                Console.WriteLine(item);

                List<XProduct> products = new List<XProduct>();

                foreach(var product in item.products)
                {
                    products.Add(new XProduct()
                    {
                        Quantity = Convert.ToInt32(product.Element("quantity")?.Value),
                        Name = product.Element("name")?.Value,
                        Price = double.Parse(product.Element("price")?.Value, CultureInfo.InvariantCulture)
                    });
                }

                XUser user = new XUser() 
                { 
                    Name = item.user.Element("fio")?.Value,
                    Email = item.user.Element("email")?.Value
                };

                XOrder order = new XOrder()
                {
                    No = Convert.ToInt32(item.no?.Value),
                    RegDate = Convert.ToDateTime(item.regDate?.Value),
                    Sum = double.Parse(item.sum?.Value, CultureInfo.InvariantCulture),
                    User = user,
                    Products = products
                };

                xorders.Add(order);
            }

            return xorders;
        }
    }
}
