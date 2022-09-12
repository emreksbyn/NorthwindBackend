namespace Core.CrossCuttingConcerns.Logging
{
    public class LogParameter
    {
        // Product product = ....

        // Product
        public string Type { get; set; }

        // product 
        public string Name { get; set; }

        // product nesnesinin icinde bulunanlar.
        public object Value { get; set; }
    }
}