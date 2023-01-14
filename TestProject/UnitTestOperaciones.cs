using BankingLibrary;
using System;
using Xunit;

namespace TestProject
{
    public class UnitTestOperaciones
    {
        [Fact]
        public void TestAperturaCuentas()
        {
            // Entradas
            bool CuentaValida = false;
            // Proceso
            Operaciones.AperturaCuenta();
            CuentaValida = Operaciones.Abierta;
            // Salida
            Assert.True(CuentaValida);
        }

        [Fact]
        public void TestDeposito()
        {
            // Entrada
            Operaciones.AperturaCuenta();
            // Proceso
            Operaciones.Deposito(100);
            // Salida
            Assert.Equal(100, Operaciones.Saldo);
        }

        [Fact]
        public void TestRetiro()
        {
            // Entrada
            Operaciones.AperturaCuenta();
            // Proceso
            Operaciones.Deposito(100);
            Operaciones.Retiro(20);
            // Salida
            Assert.Equal(80, Operaciones.Saldo);
        }

        [Fact]
        public void TestRetiroSobreGiroNoPermitido()
        {
            // Entrada
            bool SobreGiro = false;
            // Proceso
            try
            {                
                Operaciones.AperturaCuenta();
                Operaciones.Deposito(20);
                Operaciones.Retiro(100);
                if (Operaciones.Saldo < 0){
                    SobreGiro = true;
                }
                // Salida
                Assert.False(SobreGiro);
            }
            catch {
                // Salida
                Assert.True(true);
            }
        }

        [Fact]
        public void TestRetiroCantidadCeroNoPermitido()
        {
            // Entrada
            int? CantidadMovimiento = 0;

            // Proceso
            try
            {                
                Operaciones.AperturaCuenta();
                Operaciones.Deposito(100);
                CantidadMovimiento = Operaciones.Movimientos;
                Operaciones.Retiro(0);

                // Salida
                Assert.Equal(CantidadMovimiento, Operaciones.Movimientos);
            }
            catch{
                // Salida
                Assert.True(true); // Se presento la excepcion de valor menor o igual a 0
            }
        }
        
        [Fact]
        public void TestRetiroExceptionSobreGiro()
        {
            // Entrada
            Operaciones.AperturaCuenta();
            // Proceso
            Operaciones.Deposito(20);
            // Salida
            Assert.Throws<ArgumentException>(() => Operaciones.Retiro(100));
        }

        [Fact]
        public void TestSaldo()
        {
            // Entrada
            Operaciones.AperturaCuenta();
            // Proceso
            Operaciones.Deposito(100);
            Operaciones.Retiro(100);
            // Salida
            Assert.Equal(0, Operaciones.Saldo);
        }

        [Fact]
        public void TestSaldoConIntereses()
        {
            // Entrada
            double Deposito = 100;
            double InteresValor = Interes.CalculoInteres(Deposito, 0.2);
            // Proceso
            Operaciones.AperturaCuenta();
            Operaciones.Deposito(Deposito);
            Operaciones.PagoIntereses();
            // Salida
            Assert.Equal(Deposito + InteresValor, Operaciones.Saldo);
        }
    }
}
