using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DigiBank.Classes
{
    public class Layout
    {
        private static List<Pessoa> pessoas = new List<Pessoa>();
        public static int opcao = 0;
        public static void TelaPrincipal()
        {
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.ForegroundColor = ConsoleColor.White;

            Console.Clear();

            Console.WriteLine("                                                                                  ");
            Console.WriteLine("                   Digite a opção desejada:                            ");
            Console.WriteLine("                  ::::::::::::::::::::::::::::::::::::                  ");
            Console.WriteLine("                    1 - Criar Conta                                         ");
            Console.WriteLine("                  ::::::::::::::::::::::::::::::::::::                  ");
            Console.WriteLine("                    2 - Entrar com CPF e Senha                       ");
            Console.WriteLine("                  ::::::::::::::::::::::::::::::::::::                  ");

            opcao = int.Parse(Console.ReadLine());

            switch (opcao)
            {
                case 1:
                    TelaCriarConta();
                    break;
                case 2:
                    TelaLogin();
                    break;
                default:
                    Console.WriteLine("Opção inválida!");
                    break;
            }
        }

        private static void TelaCriarConta()
        {
            Console.Clear();

            Console.WriteLine("                                                                                  ");
            Console.WriteLine("                   Digite seu nome:                                       ");
            string nome = Console.ReadLine();
            Console.WriteLine("                  ::::::::::::::::::::::::::::::::::::                  ");
            Console.WriteLine("                   Digite o CPF:                                             ");
            string cpf = Console.ReadLine();
            Console.WriteLine("                  ::::::::::::::::::::::::::::::::::::                  ");
            Console.WriteLine("                   Digite sua senha:                                       ");
            string senha = Console.ReadLine();
            Console.WriteLine("                  ::::::::::::::::::::::::::::::::::::                  ");

            Console.WriteLine(nome);
            Console.WriteLine(cpf);

            //Criar Conta
            ContaCorrente contaCorrente = new ContaCorrente();

            Pessoa pessoa = new Pessoa();

            pessoa.SetNome(nome);
            pessoa.SetCPF(cpf);
            pessoa.SetSenha(senha);

            pessoa.Conta = contaCorrente;

            pessoas.Add(pessoa);

            Console.Clear();

            Console.WriteLine("                  Conta Cadastrada com sucesso!                   ");
            Console.WriteLine("                  ::::::::::::::::::::::::::::::::::::                  ");

            //Aguarda 2 segundos para ir para a tela logada
            Thread.Sleep(1500);

            TelaContaLogada(pessoa);
        }

        private static void TelaLogin()
        {
            Console.Clear();

            Console.WriteLine("                                                                                  ");
            Console.WriteLine("                   Digite o CPF:                                             ");
            string cpf = Console.ReadLine();
            Console.WriteLine("                  ::::::::::::::::::::::::::::::::::::                  ");
            Console.WriteLine("                   Digite sua senha:                                      ");
            string senha = Console.ReadLine();
            Console.WriteLine("                  ::::::::::::::::::::::::::::::::::::                  ");

            //Logar no sistema
            Pessoa pessoa = pessoas.FirstOrDefault(x => x.CPF == cpf && x.Senha == senha);

            if(pessoa != null)
            {
                TelaBoasVindas(pessoa);
                TelaContaLogada(pessoa);
            }
            else
            {
                Console.Clear();
                Console.WriteLine("                  Pessoa não cadastrada!                               ");
                Console.WriteLine("                  ::::::::::::::::::::::::::::::::::::                  ");
                Console.WriteLine();
                Console.WriteLine();
            }
        }

        private static void TelaBoasVindas(Pessoa pessoa)
        {
            string msgBoasVindas =
                $"{pessoa.Nome} | Banco: {pessoa.Conta.GetCodigoBanco()}  | " +
                $"Agência: {pessoa.Conta.GetNumeroAgencia()} | Conta: {pessoa.Conta.GetNumeroConta()}";

            Console.WriteLine("");
            Console.WriteLine($"       Seja bem vindo, {msgBoasVindas} ");
            Console.WriteLine("");
        }

        private static void TelaContaLogada(Pessoa pessoa)
        {
            Console.Clear();

            TelaBoasVindas(pessoa);

            Console.WriteLine("                  Digite a opção desejada:                                ");
            Console.WriteLine("                  ::::::::::::::::::::::::::::::::::::                     ");
            Console.WriteLine("                  1 - Realizar um Depósito                                ");
            Console.WriteLine("                  ::::::::::::::::::::::::::::::::::::                     ");
            Console.WriteLine("                  2 - Realizar um Saque                                    ");
            Console.WriteLine("                  ::::::::::::::::::::::::::::::::::::                     ");
            Console.WriteLine("                  3 - Consultar Saldo                                        ");
            Console.WriteLine("                  ::::::::::::::::::::::::::::::::::::                     ");
            Console.WriteLine("                  4 - Extrato                                                    ");
            Console.WriteLine("                  ::::::::::::::::::::::::::::::::::::                     ");
            Console.WriteLine("                  5 - Sair                                                         ");
            Console.WriteLine("                  ::::::::::::::::::::::::::::::::::::                     ");

            opcao = int.Parse(Console.ReadLine());

            switch(opcao){
                case 1:
                    TelaDeposito(pessoa);
                    break;
                case 2:
                    TelaSaque(pessoa);
                    break;
                case 3:
                    TelaSaldo(pessoa);
                    break;
                case 4:
                    TelaExtrato(pessoa);
                    break;
                case 5:
                    TelaPrincipal();
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("                  Opção inválida!                                         ");
                    Console.WriteLine("                  ::::::::::::::::::::::::::::::::::::                 ");
                    break;
            }
        }

        public static void TelaDeposito(Pessoa pessoa)
        {
            Console.Clear();

            TelaBoasVindas(pessoa);

            Console.WriteLine("                  Digite o valor do depósito:                              ");
            double valor = double.Parse(Console.ReadLine());
            Console.WriteLine("                  ::::::::::::::::::::::::::::::::::::                     ");

            pessoa.Conta.Deposita(valor);

            Console.Clear();

            TelaBoasVindas(pessoa);

            Console.WriteLine("                                                                                     ");
            Console.WriteLine("");
            Console.WriteLine("                  Depósito realizado com sucesso!                     ");
            Console.WriteLine("                  ::::::::::::::::::::::::::::::::::::                     ");
            Console.WriteLine("");
            Console.WriteLine("");

            OpcaoVoltarLogado(pessoa);
        }

        public static void TelaSaque(Pessoa pessoa)
        {
            Console.Clear();

            TelaBoasVindas(pessoa);
            Console.WriteLine("                  Digite o valor do saque:                                 ");
            double valor = double.Parse(Console.ReadLine());
            Console.WriteLine("                  ::::::::::::::::::::::::::::::::::::                     ");

           bool okSaque = pessoa.Conta.Saca(valor);
            Console.Clear();

            TelaBoasVindas(pessoa);

            Console.WriteLine("                                                                                     ");
            Console.WriteLine("");

            

            if (okSaque)
            {
                Console.WriteLine("                  Saque realizado com sucesso!                        ");
                Console.WriteLine("                  ::::::::::::::::::::::::::::::::::::                     ");
            }
            else
            {
                Console.WriteLine("                  Saldo insuficiente!                                         ");
                Console.WriteLine("                  ::::::::::::::::::::::::::::::::::::                     ");
            }

            Console.WriteLine("");
            Console.WriteLine("");

            Console.Clear();

            Thread.Sleep(300);
            Console.WriteLine("                  Saque realizado com sucesso!                        ");
            Console.WriteLine("                  ::::::::::::::::::::::::::::::::::::                     ");
            Console.WriteLine("                                                                                      ");

            bool sacarNovamente = false;

            do
            {

                Console.WriteLine("               Deseja realizar um novo saque? \n1 - SIM \n2 - NÃO ");
                Console.WriteLine("               ::::::::::::::::::::::::::::::::::::                               ");
                int opcaoNovoSaque = int.Parse(Console.ReadLine());
                

                if (opcaoNovoSaque == 1)
                {
                    sacarNovamente = true;
                    TelaSaque(pessoa);
                    Console.WriteLine("           Saque realizado com sucesso!                        ");
                    Console.WriteLine("           ::::::::::::::::::::::::::::::::::::                     ");
                    Console.WriteLine("                                                                               ");
                }
                else
                    sacarNovamente = false;
            } while (sacarNovamente == true);

            Console.Clear();

            OpcaoVoltarLogado(pessoa);

        }

        public static void TelaSaldo(Pessoa pessoa)
        {
            Console.Clear();
            TelaBoasVindas(pessoa);

            Console.WriteLine($"                  Seu saldo é: {pessoa.Conta.ConsultarSaldo()}  ");
            Console.WriteLine("                    ::::::::::::::::::::::::::::::::::::                      ");

            OpcaoVoltarLogado(pessoa);
        }

        public static void TelaExtrato(Pessoa pessoa)
        {
            Console.Clear();
            TelaBoasVindas(pessoa);

            if (pessoa.Conta.Extrato().Any())
            {
                //Mostrar extrato
                double total = pessoa.Conta.Extrato().Sum(x => x.Valor);

                foreach (Extrato extrato in pessoa.Conta.Extrato())
                {
                    Console.WriteLine("                                                                                                                      ");
                    Console.WriteLine("                                                                                                                      ");
                    Console.WriteLine($"                Data e horário: {extrato.Data.ToString("dd/MM/yyyy HH:mm:ss")}    ");
                    Console.WriteLine($"                Tipo de Movimentação: {extrato.Descricao}                                     ");
                    Console.WriteLine($"                Valor: {extrato.Valor}                                                                    ");
                    Console.WriteLine("                  ::::::::::::::::::::::::::::::::::::                                                     ");
                }

                Console.WriteLine("                                                                                     ");
                Console.WriteLine("                                                                                     ");
                Console.WriteLine($"                  SUB TOTAL: {total}                                     ");
                Console.WriteLine("                  ::::::::::::::::::::::::::::::::::::                     ");
            }
            else
            {
                Console.WriteLine("                  Não há extrato a ser exibido!!                         ");
                Console.WriteLine("                  ::::::::::::::::::::::::::::::::::::                     ");
            }
            

            OpcaoVoltarLogado(pessoa);
        }

        private static void OpcaoVoltarLogado(Pessoa pessoa)
        {
            Console.WriteLine("                  Escolha uma opção abaixo:                            ");
            Console.WriteLine("                  ::::::::::::::::::::::::::::::::::::                     ");
            Console.WriteLine("                  1 - Voltar para minha conta                            ");
            Console.WriteLine("                  ::::::::::::::::::::::::::::::::::::                     ");
            Console.WriteLine("                  2 - Sair                                                         ");
            Console.WriteLine("                  ::::::::::::::::::::::::::::::::::::                     ");

            opcao = int.Parse(Console.ReadLine());

            if (opcao == 1)
                TelaContaLogada(pessoa);
            else
                TelaPrincipal();
        }

        public static void OpcaoDeslogado(Pessoa pessoa)
        {
            Console.WriteLine("                  Escolha uma opção abaixo:                            ");
            Console.WriteLine("                  ::::::::::::::::::::::::::::::::::::                     ");
            Console.WriteLine("                  1 - Voltar para menu principal                         ");
            Console.WriteLine("                  ::::::::::::::::::::::::::::::::::::                     ");
            Console.WriteLine("                  2 - Sair e fechar a conta                                 ");
            Console.WriteLine("                  ::::::::::::::::::::::::::::::::::::                     ");

            opcao = int.Parse(Console.ReadLine());

            if (opcao == 1)
                TelaPrincipal();
            
            else
            {
                Console.WriteLine("                   Opção inválida!                                            ");
                Console.WriteLine("                  ::::::::::::::::::::::::::::::::::::                     ");
            }



        }
    }
}
