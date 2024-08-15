namespace DbWriter.src.DTO
{
    public class XOrder
    {
        public int No { get; set; }
        public DateTime RegDate { get; set; }
        public double Sum { get; set; }
        public XUser User { get; set; }
        public List<XProduct> Products { get; set; } = new List<XProduct>();

        public override string ToString()
        {
            string res = 
                $"Заказ №{No} - {Sum} - {RegDate}\n" +
                $"Пользователя {User.Name} | {User.Email}\n" +
                $"Товары:\n";

            foreach (XProduct p in Products)
            {
                res += $"\t{p.Name} x{p.Quantity}  ({p.Price}): {p.Quantity*p.Price}\n";
            }

            return res;
        }
    }
}
