using HangmanLib;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace HangmanWinForm
{
    public partial class Form1 : Form
    {
        private HangmanGame game;

        public Form1()
        {
            InitializeComponent();
            LoadGame();
        }

        private void LoadGame()
        {
            // Đọc words.txt
            string[] rawWords = File.ReadAllLines("words.txt", Encoding.UTF8);
            List<string> cleanWords = new List<string>();
            foreach (string s in rawWords)
            {
                if (!IsNullOrWhiteSpace(s)) cleanWords.Add(s);
            }

            // Đọc hints.txt
            string[] rawHints = File.ReadAllLines("hints.txt", Encoding.UTF8);
            List<string> cleanHints = new List<string>();
            foreach (string s in rawHints)
            {
                if (!IsNullOrWhiteSpace(s)) cleanHints.Add(s);
            }

            // Khởi tạo game
            game = new HangmanGame(cleanWords, cleanHints);
            game.NewGame();   // ✅ bắt đầu ngay từ đầu
            UpdateUI();
        }

        private void UpdateUI()
        {
            lblWord.Text = game.GetMaskedWord();
            lblHint.Text = "Gợi ý: " + game.Hint;
            lblWrong.Text = "Sai: " + game.WrongGuesses + "/" + game.MaxWrong;
            panelHangman.Invalidate(); // 🔥 Vẽ lại panel mỗi lần update
        }

        private void btnGuess_Click(object sender, EventArgs e)
        {
            if (IsNullOrWhiteSpace(txtGuess.Text)) return;

            char c = txtGuess.Text[0];
            game.Guess(c);
            txtGuess.Clear();
            UpdateUI();

            if (game.IsWordGuessed())
            {
                MessageBox.Show("🎉 Bạn đã thắng! Từ đúng: " + game.Answer);
                game.NewGame();
                UpdateUI();
            }
            else if (game.IsGameOver())
            {
                MessageBox.Show("😢 Bạn đã thua! Từ đúng là: " + game.Answer);
                game.NewGame();
                UpdateUI();
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            game.NewGame();   // ✅ reset game
            UpdateUI();
        }

        private void panelHangman_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Pen pen = new Pen(Color.Black, 2);

            // Vẽ khung treo (luôn có)
            g.DrawLine(pen, 10, 240, 150, 240); // nền
            g.DrawLine(pen, 40, 240, 40, 20);   // trụ
            g.DrawLine(pen, 40, 20, 120, 20);   // thanh ngang
            g.DrawLine(pen, 120, 20, 120, 50);  // dây

            if (game != null)
            {
                // Vẽ hình người theo số lần sai
                if (game.WrongGuesses > 0) g.DrawEllipse(pen, 100, 50, 40, 40);   // đầu
                if (game.WrongGuesses > 1) g.DrawLine(pen, 120, 90, 120, 160);    // thân
                if (game.WrongGuesses > 2) g.DrawLine(pen, 120, 100, 90, 130);    // tay trái
                if (game.WrongGuesses > 3) g.DrawLine(pen, 120, 100, 150, 130);   // tay phải
                if (game.WrongGuesses > 4) g.DrawLine(pen, 120, 160, 90, 200);    // chân trái
                if (game.WrongGuesses > 5) g.DrawLine(pen, 120, 160, 150, 200);   // chân phải
            }
        }

        // Tự viết lại hàm IsNullOrWhiteSpace cho .NET 2.0
        private bool IsNullOrWhiteSpace(string s)
        {
            if (s == null) return true;
            return s.Trim().Length == 0;
        }
    }
}
