# 📚 Sistem Informasi Perpustakaan API

## 📌 Deskripsi Project

Project ini merupakan REST API untuk sistem informasi perpustakaan yang dibuat menggunakan C# dengan ASP.NET Core.
API ini mendukung operasi CRUD untuk mengelola data buku, anggota, dan peminjaman.

---

## 🛠️ Teknologi yang Digunakan

* C#
* ASP.NET Core Web API
* PostgreSQL
* Dapper
* Swagger (Swashbuckle)

---

## 🗄️ Database

Database yang digunakan adalah PostgreSQL dengan nama:

```
paa_tm
```

### Tabel:

* anggota
* buku
* peminjaman

---

## ⚙️ Cara Menjalankan Project

### 1. Clone repository

```
git clone https://github.com/username/perpustakaan-api.git
```

### 2. Buka di Visual Studio

### 3. Install NuGet Package

* Dapper
* Npgsql
* Swashbuckle.AspNetCore

### 4. Setup Database

* Buat database di PostgreSQL:

```
paa_tm
```

* Import file:

```
database.sql
```

### 5. Jalankan Project

Klik:

```
Run / F5
```

---

## 🌐 Endpoint API

| Method | URL            | Keterangan       |
| ------ | -------------- | ---------------- |
| GET    | /api/buku      | Ambil semua buku |
| GET    | /api/buku/{id} | Detail buku      |
| POST   | /api/buku      | Tambah buku      |
| PUT    | /api/buku/{id} | Update buku      |
| DELETE | /api/buku/{id} | Hapus buku       |

---

## 📊 Format Response

### Sukses

```
{
  "status": "success",
  "data": {...}
}
```

### Error

```
{
  "status": "error",
  "message": "Data tidak ditemukan"
}
```

---

## 🎥 Video Presentasi

Link video:

```
https://youtu.be/wxfJrbyjKZg?si=BV1m_tGrB7dI-Yw3
```

---

## 👤 Author

Nama: Putra Akbar Maulana
NIM: 242410102070
Kelas: PAA ( A )
