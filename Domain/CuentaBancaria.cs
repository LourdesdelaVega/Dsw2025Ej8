namespace Dsw2025Ej8.Domain;
using Dsw2025Ej8.Ex;

public class CuentaBancaria
{
    public TipoCuenta Tipo { get; }
    public string Numero { get; }
    public decimal Saldo { get; set; }
    public Estado EstadoBancario { get; set; }
    public decimal TasaDeInteres { get; init; }
    public decimal LimiteDeDescubierto { get; init; }
    public decimal Comision { get; set; }
    public string[] Titulares { get; }

    public CuentaBancaria(string numero, decimal saldo, TipoCuenta tipo, string[] titulares)
    {
        Numero = numero;
        Saldo = saldo;
        Tipo = tipo;
        EstadoBancario = Estado.Activa;
        Titulares = titulares;
    }



    public virtual void Depositar(decimal monto)
    {

    }

    public virtual void Retirar(decimal monto)
    {


    }

    public void ValidarMonto(decimal monto)
    {

        if (monto <= 0)
        {
            throw new MontoNoValido();

        }

    }

    public void ValidarEstado(Estado estado)
    {
        if (estado != Estado.Activa)
        {
            throw new CuentaNoActiva(EstadoBancario);
        }
    }

}