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
klik kanan di project, lalu manage NuGet Packages. search Guna.UI2.Winform, lalu instal. silakan run project.
