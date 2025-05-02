using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dsw2025Ej8.Ex;

namespace Dsw2025Ej8.Domain
{
    public class CuentaCorriente : CuentaBancaria
    {
        public CuentaCorriente(string numero, decimal saldo, string[] titulares, decimal comision)
           : base(numero, saldo, TipoCuenta.CuentaCorriente, titulares)
        {


        }

        public override void Depositar(decimal monto)
        {
            ValidarMonto(monto);
            ValidarEstado(EstadoBancario);

            monto -= monto * Comision;
            Saldo += monto;

        }


        public override void Retirar(decimal monto)
        {
            ValidarMonto(monto);
            ValidarEstado(EstadoBancario);

            if (Saldo - monto >= -LimiteDeDescubierto)
            {
                Saldo -= monto;
            }
            if (Saldo < monto)
            {
                EstadoBancario = Estado.Suspendida;
                throw new SaldoInsuficiente();
            }



        }
    }




}
