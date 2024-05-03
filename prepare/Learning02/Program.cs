using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

public class DiaryEntry
{
    public string Prompt { get; set; }
    public string Response { get; set; }
    public DateTime Date { get; set; }
}

public class Diary
{
    private List<DiaryEntry> entries;

    public Diary()
    {
        entries = new List<DiaryEntry>();
    }

    public void WriteNewEntry()
    {
        Console.WriteLine("Escreva uma nova entrada:");
        Random rnd = new Random();
        string[] prompts = {
            "Quem foi a pessoa mais interessante com quem interagi hoje?",
            "Qual foi a melhor parte do meu dia?",
            "Como eu vi a mão do Senhor em minha vida hoje?",
            "Qual foi a emoção mais forte que senti hoje?",
            "Se eu tivesse uma coisa que pudesse fazer hoje, o que seria?"
        };
        string prompt = prompts[rnd.Next(prompts.Length)];
        Console.WriteLine($"Prompt: {prompt}");
        Console.Write("Resposta: ");
        string response = Console.ReadLine();
        entries.Add(new DiaryEntry { Prompt = prompt, Response = response, Date = DateTime.Now });
    }

    public void DisplayDiary()
    {
        foreach (var entry in entries)
        {
            Console.WriteLine($"Data: {entry.Date.ToShortDateString()}");
            Console.WriteLine($"Prompt: {entry.Prompt}");
            Console.WriteLine($"Resposta: {entry.Response}");
            Console.WriteLine();
        }
    }

    public void SaveDiary(string fileName)
    {
        if (Path.GetExtension(fileName).ToLower() == ".csv")
            SaveAsCSV(fileName);
        else
            Console.WriteLine("Formato de arquivo não suportado. Por favor, use a extensão .csv.");
    }

    private void SaveAsCSV(string fileName)
    {
        try
        {
            using (StreamWriter writer = new StreamWriter(fileName))
            {
                writer.WriteLine("Date,Prompt,Response");
                foreach (var entry in entries)
                {
                    writer.WriteLine($"{entry.Date.ToShortDateString()},\"{entry.Prompt}\",\"{entry.Response}\"");
                }
            }
            Console.WriteLine("Diário salvo com sucesso em formato CSV!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ocorreu um erro ao salvar o diário: {ex.Message}");
        }
    }

    public void LoadDiary(string fileName)
    {
        entries.Clear();
        try
        {
            using (StreamReader reader = new StreamReader(fileName))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] parts = line.Split(',');
                    DateTime date = DateTime.Parse(parts[0].Trim());
                    string prompt = parts[1].Trim().Trim('"');
                    string response = parts[2].Trim().Trim('"');
                    entries.Add(new DiaryEntry { Prompt = prompt, Response = response, Date = date });
                }
            }
            Console.WriteLine("Diário carregado com sucesso!");
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("Esse arquivo não existe. Por favor, escreva o nome de um arquivo existente.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ocorreu um erro ao carregar o diário: {ex.Message}");
        }
    }
}

public class Program
{
    static void Main(string[] args)
    {
        Diary diary = new Diary();

        while (true)
        {
            Console.WriteLine("Selecione uma opção:");
            Console.WriteLine("1. Escrever uma nova entrada");
            Console.WriteLine("2. Exibir o diário");
            Console.WriteLine("3. Salvar o diário em um arquivo");
            Console.WriteLine("4. Carregar o diário de um arquivo");
            Console.WriteLine("5. Sair");

            int choice;
            while (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > 5)
            {
                Console.WriteLine("Opção inválida. Por favor, escolha uma opção válida.");
            }

            switch (choice)
            {
                case 1:
                    diary.WriteNewEntry();
                    break;
                case 2:
                    diary.DisplayDiary();
                    break;
                case 3:
                    Console.Write("Digite o nome do arquivo para salvar: ");
                    string saveFileName = Console.ReadLine();
                    diary.SaveDiary(saveFileName);
                    break;
                case 4:
                    string loadFileName;
                    do
                    {
                        Console.Write("Digite o nome do arquivo para carregar: ");
                        loadFileName = Console.ReadLine();
                        diary.LoadDiary(loadFileName);
                    } while (!File.Exists(loadFileName));
                    break;
                case 5:
                    Console.WriteLine("Saindo do programa...");
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Essa opção não existe. Por favor, escreva uma opção existente.");
                    break;
            }
        }
    }
}
