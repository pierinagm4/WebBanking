using BankingLibrary;
using Xunit;

namespace TestProject
{
    public class UnitTestInteres
    {
        [Fact]
        public void TestInteres1()
        {
            //Entrada
            double Monto = 100;
            double Tasa = 0.2;

            // Procesos
            double Resultado = Interes.CalculoInteres(Monto, Tasa);

            // Salida
            Assert.Equal(0.0548, Resultado, 4);
        }

        [Fact]
        public void TestInteres2()
        {
            // Cuando es 0
            double Monto = 0;
            double Tasa = 0.2;
            double Resultado = Interes.CalculoInteres(Monto, Tasa);
            Assert.Equal(0, Resultado, 4);
        }

        [Fact]
        public void TestInteres3()
        {
            // Cuando el valor es negativo
            double Monto = -100;
            double Tasa = 0.2;
            double Resultado = Interes.CalculoInteres(Monto, Tasa);
            Assert.Equal(0, Resultado, 4);
        }
    }
}
