using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using HangmanLib;

namespace HangmanGameweb
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        private static HangmanGame game;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                StartNewGame();
            }
        }

        private void StartNewGame()
        {
            string wordFile = Server.MapPath("words.txt");
            string hintFile = Server.MapPath("hints.txt");

            List<string> words = new List<string>(File.ReadAllLines(wordFile, Encoding.UTF8));
            List<string> hints = new List<string>(File.ReadAllLines(hintFile, Encoding.UTF8));

            game = new HangmanGame(words, hints);
            game.NewGame();
            UpdateUI();
            lblResult.Text = ""; // reset thông báo
        }

        private void UpdateUI()
        {
            string masked = game.GetMaskedWord();

            // Tạo hiển thị: mỗi ký tự 1 gạch riêng, khoảng trắng thì bỏ qua
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < masked.Length; i++)
            {
                char c = masked[i];
                if (c == ' ')
                {
                    sb.Append("&nbsp;&nbsp;&nbsp;"); // khoảng trắng giữa từ
                }
                else
                {
                    if (i > 0) sb.Append("&nbsp;"); // cách giữa các ký tự
                    sb.Append(c); // '_' hoặc chữ cái đã đoán
                }
            }

            lblWord.Text = sb.ToString();
            lblHint.Text = "Gợi ý: " + game.Hint;
            lblWrong.Text = "Sai: " + game.WrongGuesses + "/" + game.MaxWrong;
            hfWrong.Value = game.WrongGuesses.ToString();
        }

        protected void btnGuess_Click(object sender, EventArgs e)
        {
            if (game.IsGameOver())
            {
                lblResult.Text = "👉 Bấm 'Chơi tiếp' để bắt đầu câu mới!";
                return;
            }

            if (string.IsNullOrEmpty(txtGuess.Text)) return;

            char c = txtGuess.Text[0];
            game.Guess(c);
            txtGuess.Text = "";

            if (game.IsWordGuessed())
            {
                lblResult.Text = "🎉 Bạn đã thắng! Từ đúng: " + game.Answer;
            }
            else if (game.IsGameOver())
            {
                lblResult.Text = "💀 Bạn đã thua! Từ đúng là: " + game.Answer;
            }

            UpdateUI();
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            StartNewGame(); // reset game khi bấm "Chơi tiếp"
        }
    }
}
