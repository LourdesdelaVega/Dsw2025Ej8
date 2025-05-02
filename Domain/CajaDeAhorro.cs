using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dsw2025Ej8.Ex;

namespace Dsw2025Ej8.Domain
{
    public class CajaDeAhorro : CuentaBancaria
    {
        public CajaDeAhorro(string numero, decimal saldo, string[] titulares)
            : base(numero, saldo, TipoCuenta.CajaDeAhorro, titulares)
        {

        }

        public override void Depositar(decimal monto)
        {
            ValidarMonto(monto);
            ValidarEstado(EstadoBancario);
            Saldo += monto;
            AplicarInteres();

        }
        public override void Retirar(decimal monto)
        {
            ValidarMonto(monto);
            ValidarEstado(EstadoBancario);

            Saldo -= monto;

        }


        public void AplicarInteres()
        {

            Saldo += Saldo * TasaDeInteres;
        }

    }

}