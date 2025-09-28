using System;
using System.Collections.Generic;

namespace HangmanLib
{
    public class HangmanGame
    {
        private readonly List<string> _words;
        private readonly List<string> _hints;
        private readonly Random _rand = new Random();

        private readonly List<char> _guessed = new List<char>();

        public string Answer { get; private set; }
        public string Hint { get; private set; }
        public int WrongGuesses { get; private set; }
        public int MaxWrong { get; private set; }

        public HangmanGame(IEnumerable<string> words, IEnumerable<string> hints)
        {
            _words = new List<string>(words);
            _hints = new List<string>(hints);
            MaxWrong = 6;
        }

        public void NewGame()
        {
            int index = _rand.Next(_words.Count);
            Answer = _words[index];
            Hint = _hints[index];
            _guessed.Clear();
            WrongGuesses = 0;
        }

        public bool Guess(char c)
        {
            c = Char.ToLower(c);

            if (_guessed.Contains(c))
                return false;

            _guessed.Add(c);

            if (!Answer.ToLower().Contains(c.ToString()))
            {
                WrongGuesses++;
                return false;
            }

            return true;
        }

        public string GetMaskedWord()
        {
            char[] masked = new char[Answer.Length];
            for (int i = 0; i < Answer.Length; i++)
            {
                char c = Char.ToLower(Answer[i]);
                if (_guessed.Contains(c))
                    masked[i] = Answer[i];
                else
                    masked[i] = '_';
            }
            return new string(masked);
        }

        public bool IsGameOver()
        {
            return WrongGuesses >= MaxWrong || IsWordGuessed();
        }

        public bool IsWordGuessed()
        {
            foreach (char c in Answer.ToLower())
            {
                if (!_guessed.Contains(c))
                    return false;
            }
            return true;
        }

        // ====== THÊM HÀM BỔ SUNG (để Form1.cs không báo lỗi) ======

        // Cho Form1 gọi thay vì NewGame()
        public void StartNew()
        {
            NewGame();
        }

        // Cho Form1 gọi để hiển thị chữ có gạch dưới
        public string DisplayWord()
        {
            return GetMaskedWord();
        }

        // Cho Form1 gọi khi thắng
        public bool IsWon()
        {
            return IsWordGuessed();
        }

        // Cho Form1 gọi khi thua
        public bool IsLost()
        {
            return WrongGuesses >= MaxWrong;
        }
    }
}
