using System;
using System.Collections.Generic;

class CacaPalavras
{
    static char[,] grade;
    static int tamanho = 10;
    static List<string> palavras = new List<string> { "ALGORITIMO", "LOGICA", "CODIGO", "MOUSE", "TECLADO" };
    static HashSet<string> encontradas = new HashSet<string>();
    static Random rnd = new Random();

    static void Main()
    {
        GerarGrade();
        InserirPalavras();
        MostrarGrade();

        Console.WriteLine("\nBem-vindo ao Caça-Palavras!");
        Console.WriteLine("Tente encontrar as palavras da lista:");
        Console.WriteLine(string.Join(", ", palavras));

        while (encontradas.Count < palavras.Count)
        {
            string entrada = LerEntrada();
            VerificarEncontrada(entrada);
        }

        Console.WriteLine("\n🎉 Fim do jogo!");
        Console.WriteLine("Palavras: " + string.Join(", ", palavras));
        Console.WriteLine($"Total de acertos: {encontradas.Count}");
        Console.WriteLine("Parabéns, você encontrou todas!");
    }

    // 1. Criação da Grade
    static void GerarGrade()
    {
        grade = new char[tamanho, tamanho];
        for (int i = 0; i < tamanho; i++)
        {
            for (int j = 0; j < tamanho; j++)
            {
                grade[i, j] = (char)('A' + rnd.Next(0, 26));
            }
        }
    }

    // 2. Inserção das Palavras
    static void InserirPalavras()
    {
        foreach (string palavra in palavras)
        {
            bool horizontal = rnd.Next(2) == 0;
            int linha = rnd.Next(tamanho);
            int coluna = rnd.Next(tamanho);

            if (horizontal && coluna + palavra.Length <= tamanho)
            {
                for (int i = 0; i < palavra.Length; i++)
                {
                    grade[linha, coluna + i] = palavra[i];
                }
            }
            else if (!horizontal && linha + palavra.Length <= tamanho)
            {
                for (int i = 0; i < palavra.Length; i++)
                {
                    grade[linha + i, coluna] = palavra[i];
                }
            }
        }
    }

    // 3. Exibição da Grade
    static void MostrarGrade()
    {
        Console.WriteLine("\nGrade do Caça-Palavras:\n");
        for (int i = 0; i < tamanho; i++)
        {
            for (int j = 0; j < tamanho; j++)
            {
                Console.Write(grade[i, j] + " ");
            }
            Console.WriteLine();
        }
    }

    // 4. Ler Entrada com validação
    static string LerEntrada()
    {
        string entrada = "";
        try
        {
            Console.Write("\nDigite uma palavra encontrada: ");
            entrada = Console.ReadLine().ToUpper();

            if (string.IsNullOrWhiteSpace(entrada))
                throw new Exception("Entrada vazia não é válida!");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Erro: " + ex.Message);
        }
        return entrada;
    }

    // 5. Verificação da palavra
    static void VerificarEncontrada(string palavra)
    {
        if (palavras.Contains(palavra))
        {
            if (encontradas.Contains(palavra))
            {
                Console.WriteLine("⚠️ Você já encontrou essa palavra antes!");
            }
            else
            {
                encontradas.Add(palavra);
                Console.WriteLine("✅ Palavra encontrada! Pontos: " + encontradas.Count);
            }
        }
        else
        {
            Console.WriteLine("❌ Palavra não está na lista.");
        }
    }
}
