using Dsw2025Ej8.Domain;
using Dsw2025Ej8.Ex;

namespace Dsw2025Ej8
{
    internal class Program
    {
        static void Main(string[] args)
        {


            var cajaDeAhorro1 = new CajaDeAhorro("56478", 1000.00m, new[] { "Juan", "Ana" })
            {
                TasaDeInteres = 0.03m,

            };

            var cajaDeAhorro2 = new CajaDeAhorro("56479", 2000.00m, new[] { "Pedro", "Maria" })
            {
                TasaDeInteres = 0.04m,
            };

            var cuentaCorriente1 = new CuentaCorriente("56181", 1500.00m, new[] { "Jose", "Elvira" }, 0.05m) // 4to parametro comision
            {
                LimiteDeDescubierto = 700m
            };
            var cuentaCorriente2 = new CuentaCorriente("56502", 2500.00m, new[] { "Adan", "Eva" }, 0.7m) // 4to parametro comision
            {
                LimiteDeDescubierto = 1000m
            };

            try
            {
                cajaDeAhorro1.Depositar(6000m);
                cajaDeAhorro2.Depositar(1000m);
                cuentaCorriente1.Depositar(3450m);
                cuentaCorriente2.Depositar(40m);

                cajaDeAhorro1.Retirar(200m);
                cajaDeAhorro2.Retirar(500m);
                cuentaCorriente1.Retirar(1000m);
                cuentaCorriente2.Retirar(1500m);
            }
            catch (MontoNoValido ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (CuentaNoActiva ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (SaldoInsuficiente ex)
            {
                Console.WriteLine(ex.Message);
            }

            var cuentas = new CuentaBancaria[] { cajaDeAhorro1, cajaDeAhorro2, cuentaCorriente1, cuentaCorriente2 };

            foreach (var cuenta in cuentas)
            {
                var resumen = new
                {
                    Numero = cuenta.Numero,
                    Tipo = cuenta.GetType().Name,
                    Saldo = cuenta.Saldo
                };
                Console.WriteLine($"Número: {resumen.Numero}, Tipo: {resumen.Tipo}, Saldo: {resumen.Saldo}");
            }


        }
    }
}
