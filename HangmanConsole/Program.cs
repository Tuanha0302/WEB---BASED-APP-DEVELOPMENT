using System;
using System.Collections.Generic;
using System.IO;
using HangmanLib;

namespace HangmanConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.InputEncoding = System.Text.Encoding.UTF8;

            List<string> words = new List<string>();
            List<string> hints = new List<string>();

            try
            {
                foreach (string line in File.ReadAllLines("words.txt"))
                    if (!string.IsNullOrEmpty(line)) words.Add(line.Trim().ToUpper());

                foreach (string line in File.ReadAllLines("hints.txt"))
                    if (!string.IsNullOrEmpty(line)) hints.Add(line.Trim());

                if (words.Count == 0 || hints.Count == 0 || words.Count != hints.Count)
                {
                    Console.WriteLine("❌ Lỗi: File words.txt và hints.txt không hợp lệ!");
                    return;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("❌ Lỗi khi đọc file: " + ex.Message);
                return;
            }

            HangmanGame game = new HangmanGame(words, hints);
            game.NewGame();

            Console.WriteLine("===== Trò chơi Hangman =====");
            Console.WriteLine("Gợi ý: " + game.Hint);
            Console.WriteLine("Bạn có tối đa " + game.MaxWrong + " lần sai.\n");

            while (!game.IsGameOver())
            {
                Console.WriteLine("Từ hiện tại: " + game.GetMaskedWord());
                Console.Write("Nhập một chữ cái: ");
                string input = Console.ReadLine();
                if (string.IsNullOrEmpty(input)) continue;

                char guess = input[0];
                if (game.Guess(guess))
                    Console.WriteLine("✅ Đoán đúng!");
                else
                    Console.WriteLine("❌ Sai rồi. Tổng số sai: " + game.WrongGuesses);

                Console.WriteLine();
            }

            if (game.IsWordGuessed())
                Console.WriteLine("🎉 Chúc mừng! Bạn đã đoán đúng: " + game.Answer);
            else
                Console.WriteLine("💀 Bạn đã thua! Từ đúng là: " + game.Answer);

            Console.WriteLine("Nhấn Enter để thoát...");
            Console.ReadLine();
        }
    }
}
