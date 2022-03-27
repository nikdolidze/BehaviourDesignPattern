namespace Strategy2
{
    public interface ISalesTaxStrategy
    {
        public decimal GetTaxFor(Order2 order);
    }
}
