<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="HangmanGameweb.WebForm1" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Hangman Game Web</title>
    <style>
        body {
            background-color: #d4edda; /* xanh lá nhạt */
            font-family: Arial, sans-serif;
            text-align: center;
            margin-top: 30px;
        }

        h1 {
            color: #155724; /* xanh đậm */
            font-size: 36px;
            margin-bottom: 20px;
        }

        .game-container {
            display: inline-block;
            padding: 20px;
            background-color: #fff3cd; /* vàng nhạt */
            border: 2px solid #ffeeba;
            border-radius: 10px;
            box-shadow: 2px 2px 8px rgba(0, 0, 0, 0.2);
        }

        .label {
            font-size: 20px;
            font-weight: bold;
            margin: 10px 0;
            color: #155724;
        }

        #lblWrong {
            color: red;
        }

        .btn {
            margin: 5px;
            padding: 8px 16px;
            background-color: #28a745; /* xanh lá */
            color: white;
            border: none;
            border-radius: 5px;
            cursor: pointer;
            font-size: 16px;
        }

        .btn:hover {
            background-color: #218838;
        }

        canvas {
            border: 2px solid #155724;
            margin-top: 15px;
            background-color: #fff;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <h1>🎮 Trò chơi đoán chữ</h1>
        <div class="game-container">
            <asp:Label ID="lblWord" runat="server" CssClass="label" /><br />
            <asp:Label ID="lblHint" runat="server" CssClass="label" /><br />
            <asp:Label ID="lblWrong" runat="server" /><br />
            <asp:TextBox ID="txtGuess" runat="server" MaxLength="1"></asp:TextBox><br />
            <asp:Button ID="btnGuess" runat="server" Text="Đoán" CssClass="btn" OnClick="btnGuess_Click" />
            <asp:Button ID="btnReset" runat="server" Text="Chơi tiếp" CssClass="btn" OnClick="btnReset_Click" /><br />
            <asp:Label ID="lblResult" runat="server" CssClass="label" /><br />

            <canvas id="hangmanCanvas" width="200" height="200"></canvas>
            <asp:HiddenField ID="hfWrong" runat="server" />
        </div>
    </form>

    <script type="text/javascript">
        var canvas = document.getElementById("hangmanCanvas");
        var ctx = canvas.getContext("2d");

        function drawBase() {
            ctx.beginPath();
            ctx.moveTo(10, 190);
            ctx.lineTo(190, 190);
            ctx.moveTo(50, 190);
            ctx.lineTo(50, 20);
            ctx.lineTo(120, 20);
            ctx.lineTo(120, 40);
            ctx.stroke();
        }

        function drawMan(stage) {
            switch (stage) {
                case 1: // đầu
                    ctx.beginPath();
                    ctx.arc(120, 55, 15, 0, Math.PI * 2, true);
                    ctx.stroke();
                    break;
                case 2: // thân
                    ctx.beginPath();
                    ctx.moveTo(120, 70);
                    ctx.lineTo(120, 120);
                    ctx.stroke();
                    break;
                case 3: // tay trái
                    ctx.beginPath();
                    ctx.moveTo(120, 80);
                    ctx.lineTo(100, 100);
                    ctx.stroke();
                    break;
                case 4: // tay phải
                    ctx.beginPath();
                    ctx.moveTo(120, 80);
                    ctx.lineTo(140, 100);
                    ctx.stroke();
                    break;
                case 5: // chân trái
                    ctx.beginPath();
                    ctx.moveTo(120, 120);
                    ctx.lineTo(100, 150);
                    ctx.stroke();
                    break;
                case 6: // chân phải
                    ctx.beginPath();
                    ctx.moveTo(120, 120);
                    ctx.lineTo(140, 150);
                    ctx.stroke();
                    break;
            }
        }

        function redrawHangman() {
            ctx.clearRect(0, 0, canvas.width, canvas.height);
            drawBase();

            var wrong = parseInt(document.getElementById("<%= hfWrong.ClientID %>").value) || 0;
            for (var i = 1; i <= wrong; i++) {
                drawMan(i);
            }
        }

        // chạy khi trang load lần đầu
        window.onload = function () {
            redrawHangman();
        };

        // bắt sự kiện sau mỗi postback (kể cả nút "Đoán" và "Chơi lại")
        if (typeof (Sys) !== "undefined") {
            Sys.WebForms.PageRequestManager.getInstance().add_endRequest(function () {
                redrawHangman();
            });
        }
    </script>
</body>
</html>
