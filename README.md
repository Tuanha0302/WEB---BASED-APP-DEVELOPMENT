# WEB-BASED-APP-DEVELOPMENT
## THÔNG TIN CÁ NHÂN
### Họ và tên: Ngụy Đình Tuấn Hà
### Mã số sinh viên: K225480106011
### Lớp: K58.KTP.K01
## BÀI TẬP VỀ NHÀ SỐ 01
## TÓM TẮT YÊU CÀU:
## TẠO SOLUTION GỒM CÁC PROJECT SAU:
#### 1. Class library (.NET Framework 2.0)
- DLL đa năng bắt buộc sử dụng .NET Framework 2.0: giải bài toán bất kỳ, độc lạ càng tốt, phải có dấu ấn cá nhân trong kết quả, biên dịch ra DLL.
- DLL độc lập — không đọc/ghi file, nó nhận input truyền vào thuộc tính của nó, và trả về dữ liệu thông qua thuộc tính khác, hoặc thông qua giá trị trả về của hàm.
#### 2. Console App (.NET Framework 2.0)
- Bắt buộc sử dụng .NET Framework 2.0
- Sử dụng được DLL trên: nhập được input, gọi DLL, hiển thị kết quả, phải có dấu ấn cá nhân.
- Biên dịch ra EXE.
#### 3. Windows Form Application
- Bắt buộc sử dụng .NET Framework 2.0
- Sử dụng được DLL đa năng trên, kéo các control vào để có thể lấy đc input, gọi DLL truyền input để lấy được kết quả, hiển thị kết quả ra window form, phải có dấu ấn cá nhân
- Biên dịch ra EXE.
#### 4. WEB
- Web đơn giản, bắt buộc sử dụng .NET Framework 2.0
- Sử dụng web server là IIS, dùng file hosts để tự tạo domain, gắn domain này vào iis.
- File index.html có sử dụng html css js để xây dựng giao diện nhập được các input cho bài toán, dùng mã js để tiền xử lý dữ liệu, js để gửi lên backend.
- Backend là api.aspx, trong code của api.aspx.cs thì lấy được các input mà js gửi lên, rồi sử dụng được DLL đa năng trên. Kết quả gửi lại json cho client, js phía client sẽ nhận được json này hậu xử lý để thay đổi giao diện theo dữ liệu nhận được.
- Project web này biên dịch ra DLL, phải kết hợp với IIS mới chạy được.
## BÀI TOÁN: Tạo trò chơi đoán chữ mang tên HangmanGame 
### Bước 1:
- Mở Visual Studio 2022
- Chọn File -> New -> Project
- Gõ Blank Solution trong thanh tìm kiếm rồi chọn mục đó, bấm Next
- Đặt tên Solution và tạo: HangmanGame -> Create
<img width="1273" height="839" alt="Ảnh chụp màn hình 2025-09-28 142510" src="https://github.com/user-attachments/assets/a51e9e52-f1d8-4d44-a128-22f4a7c8cdee" />

### Bước 2: Tạo Class Library
- Chọn View -> Solution Explorer, click chuột phải vào tên solution vừa tạo, chọn Add -> New Project
- Tìm Class Library (.NET Framwork) rồi sau đó chọn Next
- Đặt tên cho project đó là: HangmanLib
- Ở ngay mục Framwork chọn .NET Framwork 2.0
<img width="1265" height="844" alt="image" src="https://github.com/user-attachments/assets/26e2216e-ed82-44a1-81b5-55027a2a7940" />

#### Build DLL
- Tạo 1 class mới mang tên HangmanGame.cs
- Sau đó gán code vào HangmanGame -> Ctrl + S
- Nháy chuột phải vào project -> Build (hoặc Ctrl+Shift+B)
- Kết quả: Trong folder bin\Debug (hoặc Release), sẽ có file HangmanLib.dll. Đây là DLL độc lập, copy dùng ở các project khác
<img width="1714" height="910" alt="image" src="https://github.com/user-attachments/assets/8594ccf7-c0fb-4bb7-81df-4ea27d320bc0" />

### Bước 3: Tạo Console App
- Tạo Project: tương tự bước 2, Đặt tên project là HangmanConsole -> Create
<img width="1274" height="850" alt="image" src="https://github.com/user-attachments/assets/8e8568d1-981f-4020-8077-1aca32a09a99" />
- Sau khi tạo xong, nháy chuột phải vào Project chọn Add -> Reference -> Project -> HangmanLib (Project 1) -> OK
<img width="982" height="683" alt="image" src="https://github.com/user-attachments/assets/dfacf62a-b7f4-4911-a692-b752850c97d7" />

### Thêm file word
- Thêm file words.txt và hints.txt vào thư mục bin/Debug trong HangmanConsole
- Click chuột phải vào thư mục Debug -> Add -> Add New Item... -> TEXT File -> Open rồi đặt tên như trên
<img width="1704" height="904" alt="image" src="https://github.com/user-attachments/assets/75dd301d-f9da-4300-97b6-dd7f3f601fd5" />

- Trong words.txt:
  - HANOI
  - MATH
  - LAPTRINH
- Trong hints.txt:
  - Thủ đô của Việt Nam
  - Môn học
  - Kỹ năng viết code
    
#### Build & Run
- Click chuột phải vào Project HangmanConsole chọn Build
- Cho code vào Program.cs
- Run code (F5 hoặc Ctrl + F5)
<img width="1715" height="909" alt="image" src="https://github.com/user-attachments/assets/48ef29d4-cc07-4fd9-8c59-8f6a366b7575" />
<img width="1469" height="764" alt="image" src="https://github.com/user-attachments/assets/76426333-3564-4532-b49e-7365794af58b" />

### Bước 4: Tạo Windows Form Application
- Em đã thiết kế ra một Wndow Form với giao diện cơ bản
- Tạo project mới tương tự như hai bước trên, đặt tên là HangmanWinForm
- Sau khi tạo xong, nháy chuột phải vào Project chọn Add -> Reference -> Project -> HangmanLib (Project 1) -> OK
<img width="1266" height="840" alt="image" src="https://github.com/user-attachments/assets/61232ead-602e-4606-8b55-7615338e48a1" />

#### Thiết kế đồ họa
<img width="1711" height="907" alt="image" src="https://github.com/user-attachments/assets/bbaee114-9ae7-420e-9e7d-6eb0adedc3ed" />

#### Build & Run
- Click chuột phải vào Project HangmanConsole chọn Build
- Cho code vào Form1.cs
- Run code (F5 hoặc Ctrl + F5)
<img width="1715" height="914" alt="image" src="https://github.com/user-attachments/assets/08e25c66-90f3-4223-b7a2-4fa1a2ac1b2a" />
<img width="1716" height="910" alt="image" src="https://github.com/user-attachments/assets/2a79d8c0-eafb-4a13-815f-78a39f8fca6b" />

### Bước 5: Tạo Web
- Tạo project chọn Add -> New Project -> ASP.NET Web Application (.NET Framework) -> Đặt tên là HangmanGameweb
- Chọn .NET Framework 2.0 -> create
<img width="1270" height="849" alt="image" src="https://github.com/user-attachments/assets/b6f14330-9ade-4b46-86dc-452c57ea3ff1" />

- Trong template, chọn Empty Web Application (không dùng MVC) -> OK
- Sau khi tạo xong, thêm reference đến dll
#### Tạo file index.html
- Nháy chuột phải Project -> Add -> New Item -> HTML Page -> Đặt tên HtmlPage1.html
- Tạo file HtmlPage1.html với HTML + CSS để hiển thị giao diện, và JavaScript để xử lý sự kiện
<img width="1711" height="907" alt="image" src="https://github.com/user-attachments/assets/433ec395-8cb9-4f28-b176-780ade0e7368" />

#### Tạo file api.aspx
- Nháy chuột phải Project -> Add -> New Item -> WebForm -> Đặt tên api.aspx
- Mở WebForm1.aspx, để trống nội dung markup, thêm code cho file.
- Mở WebForm1.aspx -> WebForm1.aspx.cs để thêm code vào
<img width="1709" height="913" alt="image" src="https://github.com/user-attachments/assets/8c6a327c-f6d9-41e6-ba6c-f6bbde3e437e" />

#### Build & Run
<img width="1919" height="1019" alt="image" src="https://github.com/user-attachments/assets/3e325d5c-dbe7-4c26-891a-452c63080487" />

### Cấu hình IIS và domain
- Mở Control Panel -> Programs -> Turn Windows features on or off -> Tick Internet Information Services -> OK
- Mở IIS Manager -> Add Website -> Đặt:
  - Sitename: HangmanGameweb
  - Physical path: thư mục Hangmangame
  - Binding: type: http ; IP Address: All Unassigned ; Port: 80
  - Hostname: hangman.local -> OK
<img width="962" height="1020" alt="image" src="https://github.com/user-attachments/assets/d47c6650-b5d3-4112-812f-5873dc757e60" />
- Thêm domain vào file hosts:
  - Notepad -> Run as Administrator
  - Open file C:\Windows\System32\drivers\etc\hosts
  - Thêm dòng 127.0.0.1 hangman.local
<img width="1429" height="787" alt="image" src="https://github.com/user-attachments/assets/016b9820-ac92-4727-8972-c9adf2ff518d" />

- Cấu hình Application Pool
<img width="1919" height="1023" alt="Ảnh chụp màn hình 2025-09-28 162451" src="https://github.com/user-attachments/assets/202cdf60-f012-4b53-a4e4-af5715f400dd" />

- Mở trình duyệt gõ: http://hangman.local để chạy web
<img width="1919" height="1077" alt="Ảnh chụp màn hình 2025-09-28 162204" src="https://github.com/user-attachments/assets/648fd17a-20df-49b9-bdae-e065f83c1afd" />
<img width="1919" height="1026" alt="Ảnh chụp màn hình 2025-09-28 163805" src="https://github.com/user-attachments/assets/5ee8feb9-97e6-4e3c-802b-56225e171a9b" />
<img width="1919" height="1021" alt="Ảnh chụp màn hình 2025-09-28 163813" src="https://github.com/user-attachments/assets/ed26934b-d76d-4461-980d-7a4fd930fc6f" />
<img width="1919" height="1026" alt="Ảnh chụp màn hình 2025-09-28 163842" src="https://github.com/user-attachments/assets/09092383-1dcd-41f7-bd68-a700d2ca1816" />








