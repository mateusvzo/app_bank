using System;
using System.Collections.Generic;

namespace video_aula_rosen
{
    class Program
    {
        static void Main(string[] args)
        {
            
            int opcao = 0;
            List<Cliente> clientes = new List<Cliente>();
            List<Conta> contas = new List<Conta>();

            while (opcao != 9)
            {
                try
                {
                    Console.WriteLine("|--------------------------------|");
                    Console.WriteLine("| Escolha a operacao desejada:   |");
                    Console.WriteLine("| 1 - Cadastrar cliente          |");
                    Console.WriteLine("| 2 - Criar conta                |");
                    Console.WriteLine("| 3 - Listar Clientes            |");
                    Console.WriteLine("| 4 - Listar Contas              |");
                    Console.WriteLine("| 5 - Sacar                      |");
                    Console.WriteLine("| 6 - Depositar                  |");
                    Console.WriteLine("| 7 - Transferir                 |");
                    Console.WriteLine("| 8 - Saldo Geral                |");
                    Console.WriteLine("| 9 - Encerrar aplicacao         |");
                    Console.WriteLine("|--------------------------------|");
                    opcao = int.Parse(Console.ReadLine());

                    switch (opcao)
                    {
                        case 1:
                            Console.WriteLine("Entre com o nome do cliente: ");
                            String nome = Console.ReadLine();

                            Console.WriteLine("Entre com o email do cliente: ");
                            String email = Console.ReadLine();

                            Console.WriteLine("Entre com o cpf do cliente: ");
                            String cpf = Console.ReadLine();

                            Console.WriteLine("Entre com a data de nascimento do cliente: ");
                            int anoNascimento = int.Parse(Console.ReadLine());

                            Cliente cliente = new Cliente(nome, anoNascimento, cpf);
                            cliente.Email = email;
                            clientes.Add(cliente);
                            Console.WriteLine("Cliente cadastrado com sucesso!");
                            break;

                        case 2:
                            Console.WriteLine("Entre com o numero da conta: ");
                            long numeroConta = long.Parse(Console.ReadLine());
                            Console.WriteLine("Entre com o cpf do titular da conta: ");
                            String cpfTitular = Console.ReadLine();
                            Cliente titularNovaConta = null;

                            if (cpfTitular.Length != 11)
                            {
                                Console.WriteLine("O CPF deve possuir 11 digitos!");
                                break;
                            }

                            foreach (Cliente c in clientes)
                            {
                                if (c.Cpf == cpfTitular)
                                {
                                    titularNovaConta = c;
                                }
                            }

                            if (titularNovaConta == null)
                            {
                                break;
                            }

                            Conta conta = new Conta(numeroConta, titularNovaConta);
                            contas.Add(conta);
                            Console.WriteLine("Conta criada com sucesso");

                            break;

                        case 3:
                            Console.WriteLine("LISTAGEM DE CLIENTES");
                            foreach (Cliente c in clientes)
                            {
                                Console.WriteLine("Nome: {0} - Email: {1} - Ano de nascimento: {2} - Cpf: {3}",
                                    c.Nome, c.Email, c.AnoNascimento, c.Cpf);
                            }
                            break;

                        case 4:
                            Console.WriteLine("LISTAGEM DE CONTAS");
                            foreach (Conta c in contas)
                            {
                                Console.WriteLine("Numero: {0} - Saldo: {1} - Nome do titular: {2} - Saldo:{3}", c.Numero, c.Saldo, c.Titular.Nome, c.Saldo);
                            }
                            break;

                        case 5:
                            Conta contaOperacaoSaque = null;
                            Console.WriteLine("Entre com o cpf do titular da conta: ");
                            String cpfOperacaoSaque = Console.ReadLine();
                            int indexCliente = -1;

                            if (cpfOperacaoSaque.Length != 11)
                            {
                                Console.WriteLine("O CPF deve possuir 11 digitos!");
                                break;
                            }

                            for (int i = 0; i < contas.Count; i++)
                            {
                                if (contas[i].Titular.Cpf == cpfOperacaoSaque.Trim())
                                {
                                    contaOperacaoSaque = contas[i];
                                    indexCliente = i;
                                }
                            }

                            if (indexCliente == -1)
                            {
                                Console.WriteLine("Conta nao encontrada");
                                break;
                            }

                            Console.WriteLine("Entre com o valor do saque: ");
                            decimal valor = decimal.Parse(Console.ReadLine());
                            contaOperacaoSaque.Sacar(valor);
                            contas[indexCliente] = contaOperacaoSaque;

                            Console.WriteLine("Saque efetuado com sucesso");
                            break;

                        case 6:
                            Conta contaOperacaoDeposito = null;
                            Console.WriteLine("Entre com o cpf do titular da conta: ");
                            String cpfCliente = Console.ReadLine();
                            int indexClienteOperacaoDeposito = 0;

                            if (cpfCliente.Length != 11)
                            {
                                Console.WriteLine("O CPF deve possuir 11 digitos!");
                                break;
                            }

                            for (int i = 0; i < contas.Count; i++)
                            {
                                if (contas[i].Titular.Cpf == cpfCliente)
                                {
                                    contaOperacaoDeposito = contas[i];
                                    indexClienteOperacaoDeposito = i;
                                }
                            }

                            if (contaOperacaoDeposito == null)
                            {
                                Console.WriteLine("Conta nao encontrada");
                                break;
                            }

                            Console.WriteLine("Entre com o valor do deposito: ");
                            decimal valorDeposito = decimal.Parse(Console.ReadLine());
                            contaOperacaoDeposito.Depositar(valorDeposito);
                            contas[indexClienteOperacaoDeposito] = contaOperacaoDeposito;
                            Console.WriteLine("Deposito realizado com sucesso!");

                            break;

                        case 7:
                            Conta contaAtual = null;
                            Conta contaDestino = null;
                            Console.WriteLine("Entre com o cpf do titular da conta atual: ");
                            String cpfAtual = Console.ReadLine();
                            Console.WriteLine("Entre com o cpf do titular da conta destino: ");
                            String cpfDestino = Console.ReadLine();

                            int indexContaAtual = 0;
                            int indexContaDestino = 0;

                            for (int i = 0; i < contas.Count; i++)
                            {
                                if (contas[i].Titular.Cpf == cpfAtual)
                                {
                                    contaAtual = contas[i];
                                    indexContaAtual = i;
                                }

                                if (contas[i].Titular.Cpf == cpfDestino)
                                {
                                    contaDestino = contas[i];
                                    indexContaDestino = i;
                                }
                            }

                            if (contaAtual == null)
                            {
                                Console.WriteLine("Conta nao encontrada");
                                break;
                            }

                            if (contaDestino == null)
                            {
                                Console.WriteLine("Conta destino nao encontrada");
                                break;
                            }

                            Console.WriteLine("Entre com o valor do deposito: ");
                            decimal valorParaDeposito = decimal.Parse(Console.ReadLine());
                            contaAtual.Sacar(valorParaDeposito);
                            contaDestino.Depositar(valorParaDeposito);

                            contas[indexContaAtual] = contaAtual;
                            contas[indexContaDestino] = contaDestino;
                            Console.WriteLine("Transferencia no valor de {0} realizada com sucesso", valorParaDeposito);
                            break;

                        case 8:
                            Console.WriteLine("Saldo geral: {0}", Conta.saldoGeral);
                            break;

                        case 9:
                            Console.WriteLine("Programa finalizado");
                            break;

                        default:
                            Console.WriteLine("Opcao inexistente");
                            break;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                    
            }

        }

        public void CriarConta() { }
    }
}
