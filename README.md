## [PROSES INSTALASI Q-BISNIS]

Note: Pastikan Microsoft SQL Server Management Studio Ter-Install pada device user

IMPORT DATABASE:
-Run Microsoft SSMS
-Klik kanan pada folder Database di SMSS
-Klik Import Data-Tier Application
-Lalu pada setup import, bagian import setting, browse dan pilih file Q-BISNIS.bacpac di repository Phoenix
-Lalu pada bagian Database Setting, atur nama database menjadi Q-Bisnis
-Lalu next hingga proses import data selesai

SETUP APLIKASI
-Run file setup.exe dan tunggu hingga proses instalasi selesai

## [Run Aplikasi di VS19]
1. klik kanan di project Q-Bisnis
2. lalu manage NuGet Packages
3. Search Guna.UI2.Winform, pilih yang option teratas lalu lakukan instalasi
4. jika instalasi sudah selesai, klik kanan pada project Q-Bisnis lalu build
5. ketika proses build sudah selesai, maka anda dapat menjalankan program tersebut melalui Visual Studio 2019
