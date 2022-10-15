using ByteBankApp.Model;

namespace bytebank
{
    public class ContaCorrente
    {
        // ATRIBUTOS
        public Cliente Cliente { get; set; }
        public string ChavePixAleatoria { get; private set; }
        public int NumeroAgencia { get; private set; }
        public string NomeAgencia { get; private set; }
        public int NumeroConta { get; private set; }
        public double Saldo { get; set; }

        // CONSTRUTORES
        public ContaCorrente(Cliente cliente)
        {
            this.Cliente = cliente;
            this.Saldo = 0;
            string ChavePix = Guid.NewGuid().ToString();
            this.ChavePixAleatoria = ChavePix[..5];
            this.NumeroConta = new Random().Next(99999);
            this.NumeroAgencia = new Random().Next(9999);
            this.NomeAgencia = "Principal";
        }

        //MÉTODOS PARA MANIPULAÇÃO DO SALDO DA CONTA
        public bool Sacar(double saque, string senha)
        {
            if (saque > 0 && Saldo >= saque)
            {
                if (this.Cliente.PwdTitular == senha)
                {
                    this.Saldo -= saque;                    
                    return true;
                }
            }
            return false;
        }
        public bool Depositar(double deposito)
        {
            if (deposito > 0)
            {
                this.Saldo += deposito;
                return true;
            }
            else return false;
        }
        public bool Transferir(string senha, double valor, ContaCorrente destino)
        {
            
            if (this.Sacar(valor, senha))
            {
                destino.Depositar(valor);
                return true;
            }
            else return false;
        }
    }
}

