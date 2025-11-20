# 期中作業
高雄輕軌運量資料庫系統 (Kaohsiung Light Rail Data Importer)
這是一個使用 .NET 8.0 開發的主控台應用程式 (Console Application)，旨在示範如何將政府開放資料 (JSON) 透過 Entity Framework Core 匯入至 SQL Server LocalDB 資料庫，並執行基礎的數據查詢與統計。

📋 專案功能
JSON 資料解析：使用 System.Text.Json 讀取並反序列化高雄輕軌運量資料（處理中文欄位名稱）。

資料庫整合：使用 Entity Framework Core (EF Core) 建立與管理資料庫。

自動化遷移：透過 EF Core Migration 自動建立資料表結構。

資料寫入：具備檢查機制，防止重複寫入資料。

數據查詢：示範使用 LINQ 進行資料篩選、排序與統計（如：查詢特定月份運量、關鍵字搜尋）。

🛠️ 技術堆疊

開發語言：C# (.NET 8.0) 


資料庫 ORM：Entity Framework Core (8.0.22) 

資料庫引擎：SQL Server Express LocalDB

開發工具：Visual Studio 2022
