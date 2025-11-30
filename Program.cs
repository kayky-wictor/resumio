
using System;
using System.Collections.Generic;

class SistemaLogistica
{
    static void Main(string[] args)
    {
        // Estrutura para armazenar as encomendas
        // Chave: código de rastreamento | Valor: código de barras
        Dictionary<string, string> registros = new Dictionary<string, string>();

        bool ativo = true;

        while (ativo)
        {
            ExibirMenu();
            string escolha = Console.ReadLine();
            Console.WriteLine();

            switch (escolha)
            {
                case "1":
                    CadastrarEncomenda(registros);
                    break;

                case "2":
                    ConsultarPorRastreamento(registros);
                    break;

                case "3":
                    ConsultarPorCodigoBarras(registros);
                    break;

                case "4":
                    ativo = false;
                    break;

                default:
                    MostrarMensagem("Opção inválida. Tente novamente.", ConsoleColor.Red);
                    break;
            }
        }

        Console.WriteLine("Aplicação finalizada.");
    }

    static void ExibirMenu()
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("\n==== MENU DO SISTEMA LOGÍSTICO ====");
        Console.ResetColor();
        Console.WriteLine("1 - Cadastrar encomenda");
        Console.WriteLine("2 - Buscar por código de rastreamento");
        Console.WriteLine("3 - Buscar por código de barras");
        Console.WriteLine("4 - Encerrar sistema");
        Console.Write("Selecione uma opção: ");
    }

    static void CadastrarEncomenda(Dictionary<string, string> dados)
    {
        Console.Write("Informe o código de rastreamento: ");
        string rastreamento = Console.ReadLine();

        if (dados.ContainsKey(rastreamento))
        {
            MostrarMensagem("Código de rastreamento já existente no sistema.", ConsoleColor.Red);
            return;
        }

        Console.Write("Informe o código de barras: ");
        string barras = Console.ReadLine();

        if (dados.ContainsValue(barras))
        {
            MostrarMensagem("Este código de barras já está associado a outra encomenda.", ConsoleColor.Red);
            return;
        }

        dados.Add(rastreamento, barras);
        MostrarMensagem("Encomenda cadastrada com sucesso.", ConsoleColor.Green);
    }

    static void ConsultarPorRastreamento(Dictionary<string, string> dados)
    {
        Console.Write("Digite o código de rastreamento: ");
        string codigo = Console.ReadLine();

        if (dados.TryGetValue(codigo, out string barras))
        {
            MostrarMensagem($"Código de barras associado: {barras}", ConsoleColor.Green);
        }
        else
        {
            MostrarMensagem("Nenhum registro encontrado para este código.", ConsoleColor.Yellow);
        }
    }

    static void ConsultarPorCodigoBarras(Dictionary<string, string> dados)
    {
        Console.Write("Digite o código de barras: ");
        string codigo = Console.ReadLine();

        foreach (KeyValuePair<string, string> registro in dados)
        {
            if (registro.Value == codigo)
            {
                MostrarMensagem($"Código de rastreamento correspondente: {registro.Key}", ConsoleColor.Green);
                return;
            }
        }

        MostrarMensagem("Código de barras não localizado no sistema.", ConsoleColor.Yellow);
    }

    static void MostrarMensagem(string texto, ConsoleColor cor)
    {
        Console.ForegroundColor = cor;
        Console.WriteLine(texto);
        Console.ResetColor();
    }
}
