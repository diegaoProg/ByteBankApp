using System;
using bytebank;
using ByteBankApp;
using ByteBankApp.Conttroller;
using ByteBankApp.View;

public class Programa
{
    public static void Main(string[] args)
    {
        try
        {
            BancoDados bd = new BancoDados();
            Tela tela = new Tela(bd);
            tela.home();
        }
        catch (NullReferenceException)
        {
            Tela.MensagemInvalida();
            throw;
        }
    }
}
