namespace BankingLibrary
{
    public static class Interes
    {
        public static double CalculoInteres(double Monto, double Tasa)
        {
            // Entradas
            double Interes = 0;
            int Dias = 365;
            
            // Procesos
            if (Monto > 0)
            {
                Interes = (Monto * Tasa) / Dias;
            }

            // Salida
            return Interes;
        }
    }
}
