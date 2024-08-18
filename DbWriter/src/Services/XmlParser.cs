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
            return XElement.Load(pathFile).Elements("order").Select(o => new XOrder
            {
                No = Int32.Parse(o.Element("no").Value),
                RegDate = DateTime.Parse(o.Element("reg_date").Value),
                Sum = Decimal.Parse(o.Element("sum").Value, CultureInfo.InvariantCulture),
                User = new XUser 
                { 
                    Name = o.Element("user").Element("fio").Value, 
                    Email = o.Element("user").Element("email").Value
                },
                Products = o.Elements("product").Select(p => new XProduct
                {
                    Quantity = Int32.Parse(p.Element("quantity").Value),
                    Name = p.Element("name").Value,
                    Price = Decimal.Parse(p.Element("price").Value, CultureInfo.InvariantCulture)
                }).ToList()
            }).ToList();
        }
    }
}
