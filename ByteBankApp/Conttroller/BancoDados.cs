using bytebank;
using ByteBankApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBankApp.Conttroller
{
    public class BancoDados
    {
        private ContaCorrente[] contas = new ContaCorrente[100];
        //private Cliente[] clientes;
        //private int[] numAgencias;        
        
        public void addConta(ContaCorrente conta)
        {
            int i = 0;
            
            while (contas[i] != null)
            {
                i++;
            }
            contas[i] = conta;            
        }
        public ContaCorrente BuscarConta(string numeroConta)
        {            
            for (int i = 0; i < contas.Length; i++)
            {
                if (contas[i] != null && contas[i].ChavePixAleatoria == numeroConta)
                {
                    return contas[i];
                }                
            }
            return null;
        }
        public ContaCorrente BuscarConta(string user, string pwd)
        {
            for (int i = 0; i < contas.Length; i++)
            {                
                if (contas[i] != null)
                { 
                    if (contas[i].Cliente.UsrTitular == user)
                    {
                        if (contas[i].Cliente.PwdTitular == pwd) return contas[i];
                    }
                }
            }
            return null;
        }

    }
}
