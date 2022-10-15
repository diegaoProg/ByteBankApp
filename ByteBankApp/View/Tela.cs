using bytebank;
using ByteBankApp.Conttroller;
using ByteBankApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBankApp.View
{
    public class Tela
    {
        // ATRIBUTOS
        private BancoDados bd;
        
        // CONSTRUTORES
        public Tela(BancoDados bd)
        {
            this.bd = bd;
        }

        /** MÉTODOS PARA IMPRESSÃO NA TELA
         * 
         * Os métodos abaixo são responsáveis por printar a tela de interação com usuário
         * VIEW        
         */
        public void home()
        {
            Console.WriteLine("----------------------------------");
            Console.WriteLine("-----  # B Y T E  B A N K #  -----");
            Console.WriteLine("-----Bem vindo ao ByteBankApp-----");
            Console.WriteLine("-                                -");
            Console.WriteLine("-                                -");
            Console.WriteLine("- Digite o numero correspondente -");
            Console.WriteLine("-                                -");
            Console.WriteLine("-     1. Nova Conta Corrente     -");
            Console.WriteLine("-     2. Abrir Conta Existente   -");
            Console.WriteLine("-     0. Encerrar ByteBankApp    -");
            Console.WriteLine("-                                -");
            Console.WriteLine("-                                -");
            Console.WriteLine("-                                -");
            Console.WriteLine("-                                -");
            Console.WriteLine("----------------------------------");
            Console.WriteLine("---------- by diegaoProg ---------");
            Console.WriteLine("----------------------------------");

            ConsoleKeyInfo key = Console.ReadKey();

            Console.Clear();

            switch (key.KeyChar)
            {
                case '1':                    
                    novaConta();
                    break;
                case '2':
                    Console.WriteLine("----------------------------------");
                    Console.WriteLine("-         FAÇA SEU LOGIN         -");
                    login();
                    break;
                case '0':
                    Console.WriteLine("----------------------------------");
                    Console.WriteLine("-    BYTEBANK APP ENCERRADO!     -");
                    Console.WriteLine("----------------------------------");
                    break;
                default:
                    MensagemInvalida();
                    home();
                    break;
            }
        }
        public void novaConta()
        {
            // TELA 1
            Console.WriteLine("----------------------------------");
            Console.WriteLine("-      CRIANDO NOVA CONTA...     -");
            Console.WriteLine("----------------------------------");
            Console.WriteLine("-----  # B Y T E  B A N K #  -----");
            Console.WriteLine("----- Bem vindo ao ByteBankApp-----");
            Console.WriteLine("-                                -");
            Console.WriteLine("-                                -");
            Console.WriteLine("-                                -");
            Console.WriteLine("-    Digite seu nome:            -");
            Console.WriteLine("-                                -");
            Console.WriteLine("-                                -");
            Console.WriteLine("-                                -");
            Console.WriteLine("-    Digite seu cpf:             -");
            Console.WriteLine("-                                -");
            Console.WriteLine("-                                -");
            Console.WriteLine("-                                -");
            Console.WriteLine("----------------------------------");
            Console.WriteLine("---------- by diegaoProg ---------");
            Console.WriteLine("----------------------------------");

            string titular = Console.ReadLine();
            string cpf = Console.ReadLine();

            Console.Clear();

            Cliente cliente1 = new Cliente(titular, cpf);
            if (!cliente1.CpfValidado)
            {
                Console.WriteLine("----------------------------------");
                Console.WriteLine("-    C P F    I N V Á L I D O    -");
                novaConta();
            }

            else
            {
                // TELA 2                
                Console.WriteLine("----------------------------------");
                Console.WriteLine("-   CRIANDO SENHA DE ACESSO...   -");
                Console.WriteLine("----------------------------------");
                Console.WriteLine("-----  # B Y T E  B A N K #  -----");
                Console.WriteLine("-----Bem vindo ao ByteBankApp-----");
                Console.WriteLine("-                                -");
                Console.WriteLine("-                                -");
                Console.WriteLine("-                                -");
                Console.WriteLine("-    Crie seu usuario:           -");
                Console.WriteLine("-                                -");
                Console.WriteLine("-                                -");
                Console.WriteLine("-                                -");
                Console.WriteLine("-    Crie sua senha:             -");
                Console.WriteLine("-                                -");
                Console.WriteLine("-                                -");
                Console.WriteLine("-                                -");
                Console.WriteLine("----------------------------------");
                Console.WriteLine("---------- by diegaoProg ---------");
                Console.WriteLine("----------------------------------");

                string usr = Console.ReadLine();
                string pwd = Console.ReadLine();

                Console.Clear();

                cliente1.CriarSenha(usr, pwd);
                ContaCorrente conta1 = new ContaCorrente(cliente1);
                
                Console.WriteLine("----------------------------------");
                Console.WriteLine("-     DEPOSITE VALOR INICIAL     -");

                telaDeposito(conta1);
            }
        }

        public void login()
        {
            
            Console.WriteLine("----------------------------------");
            Console.WriteLine("-----  # B Y T E  B A N K #  -----");
            Console.WriteLine("-----Bem vindo ao ByteBankApp-----");
            Console.WriteLine("-                                -");
            Console.WriteLine("-                                -");
            Console.WriteLine("-    Login:                      -");
            Console.WriteLine("-                                -");
            Console.WriteLine("-    Senha:                      -");
            Console.WriteLine("-                                -");
            Console.WriteLine("-                                -");
            Console.WriteLine("-                                -");
            Console.WriteLine("-                                -");
            Console.WriteLine("-                                -");
            Console.WriteLine("-                                -");
            Console.WriteLine("----------------------------------");
            Console.WriteLine("---------- by diegaoProg ---------");
            Console.WriteLine("----------------------------------");

            string usuario = Console.ReadLine();
            string senha = Console.ReadLine();

            Console.Clear();

            //selecionar conta por usrTitular e pwdTitular
            if (bd.BuscarConta(usuario, senha) != null) exibirConta(bd.BuscarConta(usuario, senha));
            else
            {
                Console.Clear();
                Console.WriteLine("----------------------------------");                                
                Console.WriteLine("- USUÁRIO E/OU SENHA INCORRETOS! -");                
                Console.WriteLine("----------------------------------");
                Console.WriteLine("----------------------------------");
                Console.WriteLine("-----  # B Y T E  B A N K #  -----");
                Console.WriteLine("-----Bem vindo ao ByteBankApp-----");
                Console.WriteLine("-                                -");
                Console.WriteLine("-                                -");
                Console.WriteLine("-    1. Tentar novamente         -");
                Console.WriteLine("-    0. Voltar à tela inicial    -");
                Console.WriteLine("-                                -");
                Console.WriteLine("-                                -");
                Console.WriteLine("-                                -");
                Console.WriteLine("-                                -");
                Console.WriteLine("----------------------------------");
                Console.WriteLine("---------- by diegaoProg ---------");
                Console.WriteLine("----------------------------------");
                
                ConsoleKeyInfo key = Console.ReadKey();

                Console.Clear();

                switch (key.KeyChar)
                {
                    case '1':                        
                        login();
                        break;                    
                    case '0':                        
                        home();
                        break;
                    default:
                        MensagemInvalida();
                        login();
                        break;
                }
                                
            }
        }

        public void exibirConta(ContaCorrente conta)
        {
            Console.WriteLine("----------------------------------");
            Console.WriteLine("-----  # B Y T E  B A N K #  -----");
            Console.WriteLine("-----Bem vindo ao ByteBankApp-----");            
            Console.WriteLine("-                                -");
            Console.WriteLine("-    Titular: " + conta.Cliente.NomeTitular + "        -");
            Console.WriteLine("-                                -");
            Console.WriteLine("-    Agência: " + conta.NumeroAgencia + " " + conta.NomeAgencia + "      -");
            Console.WriteLine("-                                -");
            Console.WriteLine("-    Conta: " + conta.NumeroConta + "                -");
            Console.WriteLine("-                                -");
            Console.WriteLine("-    Chave Pix: " + conta.ChavePixAleatoria + "            -");
            Console.WriteLine("-                                -");
            Console.WriteLine("-    Saldo: R$" + conta.Saldo + "             -");
            Console.WriteLine("-                                -");
            Console.WriteLine("-                                -");
            Console.WriteLine("-    Digite 1 para depositar     -");
            Console.WriteLine("-    Digite 2 para sacar         -");
            Console.WriteLine("-    Digite 3 para transferir    -");
            Console.WriteLine("-    Digite 0 para sair          -");
            Console.WriteLine("----------------------------------");
            Console.WriteLine("---------- by diegaoProg ---------");
            Console.WriteLine("----------------------------------");

            ConsoleKeyInfo key = Console.ReadKey();

            bd.addConta(conta);

            Console.Clear();

            switch (key.KeyChar)
            {
                case '0':                    
                    home();
                    break;
                case '1':                    
                    telaDeposito(conta);
                    break;
                case '2':                    
                    telaSaque(conta);
                    break;
                case '3':
                    TelaTransferencia(conta);
                    break;
                default:
                    MensagemInvalida();
                    exibirConta(conta);
                    break;
            }
        }

        private void TelaTransferencia(ContaCorrente conta)
        {
            // TELA 1
            Console.WriteLine("----------------------------------");
            Console.WriteLine("-----  # B Y T E  B A N K #  -----");
            Console.WriteLine("-----Bem vindo ao ByteBankApp-----");
            Console.WriteLine("-                                -");
            Console.WriteLine("-                                -");
            Console.WriteLine("-                                -");
            Console.WriteLine("-   Digite a chave pix da conta  -");
            Console.WriteLine("-   destino da transferência:    -");
            Console.WriteLine("-                                -");
            Console.WriteLine("-                                -");
            Console.WriteLine("-                                -");
            Console.WriteLine("-                                -");
            Console.WriteLine("-                                -");
            Console.WriteLine("-                                -");
            Console.WriteLine("----------------------------------");
            Console.WriteLine("---------- by diegaoProg ---------");
            Console.WriteLine("----------------------------------");

            string ChavePix = Console.ReadLine();

            Console.Clear();

            ContaCorrente ContaDestino = bd.BuscarConta(ChavePix);
            if (ContaDestino == null)
            {
                Console.WriteLine("----------------------------------");
                Console.WriteLine("-  CONTA DESTINO NÃO ENCONTRADA  -");
                Console.WriteLine("----------------------------------");
                Console.WriteLine("-----  # B Y T E  B A N K #  -----");
                Console.WriteLine("-----Bem vindo ao ByteBankApp-----");
                Console.WriteLine("-                                -");
                Console.WriteLine("-                                -");
                Console.WriteLine("-    1. Tentar novamente         -");
                Console.WriteLine("-    0. Voltar à tela inicial    -");
                Console.WriteLine("-                                -");
                Console.WriteLine("-                                -");
                Console.WriteLine("-                                -");
                Console.WriteLine("-                                -");
                Console.WriteLine("----------------------------------");
                Console.WriteLine("---------- by diegaoProg ---------");
                Console.WriteLine("----------------------------------");

                ConsoleKeyInfo key = Console.ReadKey();

                Console.Clear();

                switch (key.KeyChar)
                {
                    case '1':
                        TelaTransferencia(conta);
                        break;
                    case '0':
                        home();
                        break;
                    default:
                        MensagemInvalida();
                        exibirConta(conta);
                        break;
                }
            }
            else
            {
                // TELA 2
                Console.WriteLine("----------------------------------");
                Console.WriteLine("-----  # B Y T E  B A N K #  -----");
                Console.WriteLine("-----Bem vindo ao ByteBankApp-----");
                Console.WriteLine("-                                -");
                Console.WriteLine("-                                -");
                Console.WriteLine("-                                -");
                Console.WriteLine("-   Digite valor a transferir:   -");
                Console.WriteLine("-                                -");
                Console.WriteLine("-   Digite a senha para          -");
                Console.WriteLine("-   confirmar a transferencia:   -");
                Console.WriteLine("-                                -");
                Console.WriteLine("-                                -");
                Console.WriteLine("-                                -");
                Console.WriteLine("-                                -");
                Console.WriteLine("----------------------------------");
                Console.WriteLine("---------- by diegaoProg ---------");
                Console.WriteLine("----------------------------------");

                double transferencia = Convert.ToDouble(Console.ReadLine());
                string senha = Console.ReadLine();
                
                Console.Clear();

                if (conta.Transferir(senha, transferencia, ContaDestino))
                {
                    Console.WriteLine("----------------------------------");
                    Console.WriteLine("- TRANSFERÊNCIA FEITA COM SUCESSO -");
                }
                else
                {
                    Console.WriteLine("----------------------------------");
                    Console.WriteLine("-  TRANSFERÊNCIA NÃO CONCLUIDA   -");
                }
                exibirConta(conta);

            }
        }
        public void telaSaque(ContaCorrente conta)
        {
            Console.WriteLine("----------------------------------");
            Console.WriteLine("-----  # B Y T E  B A N K #  -----");
            Console.WriteLine("-----Bem vindo ao ByteBankApp-----");
            Console.WriteLine("-                                -");
            Console.WriteLine("-                                -");
            Console.WriteLine("-                                -");
            Console.WriteLine("-   Digite valor para saque:     -");
            Console.WriteLine("-                                -");
            Console.WriteLine("-                                -");
            Console.WriteLine("-   Digite sua senha para        -");
            Console.WriteLine("-   confirmar o saque:           -");
            Console.WriteLine("-                                -");
            Console.WriteLine("-                                -");
            Console.WriteLine("-                                -");
            Console.WriteLine("----------------------------------");
            Console.WriteLine("---------- by diegaoProg ---------");
            Console.WriteLine("----------------------------------");

            double saque = Convert.ToDouble(Console.ReadLine());
            string senha = Console.ReadLine();

            Console.Clear();

            if (conta.Sacar(saque, senha))
            {
                Console.WriteLine("----------------------------------");
                Console.WriteLine("-  SAQUE CONCLUÍDO COM SUCESSO   -");
            }
            else
            {
                Console.WriteLine("----------------------------------");
                Console.WriteLine("-      SALDO INSUFICIENTE!       -");
            }

            exibirConta(conta);
        }
        public void telaDeposito(ContaCorrente conta)
        {
            Console.WriteLine("----------------------------------");
            Console.WriteLine("-----  # B Y T E  B A N K #  -----");
            Console.WriteLine("-----Bem vindo ao ByteBankApp-----");
            Console.WriteLine("-                                -");
            Console.WriteLine("-                                -");
            Console.WriteLine("-                                -");
            Console.WriteLine("-  Digite valor para deposito:   -");
            Console.WriteLine("-                                -");
            Console.WriteLine("-                                -");
            Console.WriteLine("-                                -");
            Console.WriteLine("-                                -");
            Console.WriteLine("-                                -");
            Console.WriteLine("-                                -");
            Console.WriteLine("-                                -");
            Console.WriteLine("----------------------------------");
            Console.WriteLine("---------- by diegaoProg ---------");
            Console.WriteLine("----------------------------------");
            
            double deposito = Convert.ToDouble(Console.ReadLine());

            Console.Clear();

            if (conta.Depositar(deposito))
            {

                Console.WriteLine("----------------------------------");
                Console.WriteLine("- DEPOSITO CONCLUÍDO COM SUCESSO -");                
            }
            else
            {

                Console.WriteLine("----------------------------------");
                Console.WriteLine("-  NÃO FOI POSSÍVEL DEPOSITAR!   -");                
            }

            exibirConta(conta);
        }
        public static void MensagemInvalida()
        {
            Console.WriteLine("----------------------------------");
            Console.WriteLine("-       I N V Á L I D O          -");
            Console.WriteLine("----------------------------------");
        }
    }
}

