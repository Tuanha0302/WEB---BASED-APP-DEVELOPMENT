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
