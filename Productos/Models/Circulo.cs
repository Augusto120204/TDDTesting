namespace Productos.Models
{
    public class Circulo
    {
        public double Radio { get; set; }

        public double CalcularArea()
        {
            return Math.Round(Math.PI * Math.Pow(Radio, 2), 2);
        }
    }
}
