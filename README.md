# 作業

# 高雄輕軌運量資料庫系統 (Kaohsiung Light Rail Data Importer)

這是一個使用 .NET 8.0 開發的主控台應用程式 (Console Application)，旨在示範如何將政府開放資料 (JSON) 透過 Entity Framework Core 匯入至 SQL Server LocalDB 資料庫，並執行基礎的數據查詢與統計。

# 📋 專案功能

JSON 資料解析：使用 System.Text.Json 讀取並反序列化高雄輕軌運量資料（處理中文欄位名稱）。

資料庫整合：使用 Entity Framework Core (EF Core) 建立與管理資料庫。

自動化遷移：透過 EF Core Migration 自動建立資料表結構。

資料寫入：具備檢查機制，防止重複寫入資料。

數據查詢：示範使用 LINQ 進行資料篩選、排序與統計（如：查詢特定月份運量、關鍵字搜尋）。

# 📂 專案結構

LightRailApp/

├── App\_Data/

│   └── data.json           # 來源資料檔

├── Migrations/             # EF Core 自動產生的資料庫遷移紀錄

├── LightRailDbContext.cs   # 資料庫連線設定 (DbContext)

├── LightRailEntity.cs      # 資料庫實體模型 (Schema)

├── LightRailJsonModel.cs   # JSON 對應模型 (含中文屬性對應)

├── Program.cs              # 主程式邏輯 (讀取、寫入、查詢)

└── LightRailApp.csproj     # 專案設定檔

🌐 網頁版擴充功能 (Web MVC)



可視化查詢介面：提供乾淨的 Web 介面，取代黑底白字的指令視窗。



搜尋：支援依照「年份」與「月份」進行條件篩選。



排序：可依照「搭乘人數」進行排序。



資料管理：直接在網頁上新增、修改或刪除特定月份的運量資料。


🔗 資料來源

政府資料開放平臺

