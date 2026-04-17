# game-shelf# 🎮 Game Shelf

A personal game library to track your gaming journey — what you've played, what you're playing, and what's next in the queue.

## 🛠️ Tech Stack

| Layer       | Technology                        |
|-------------|-----------------------------------|
| Frontend    | Angular + Angular Material        |
| Backend     | ASP.NET Core Web API (C#)         |
| Database    | SQL Server                        |
| Auth        | JWT + ASP.NET Identity            |

## ✨ Features

- 📋 Game catalog with cover, genre, platform, developer and release year
- 🎯 Game status tracking: `Playing`, `Completed`, `On Queue`, `Abandoned`, `Want to Play`
- ⭐ Personal rating and review
- ⏱️ Hours played tracking
- ❤️ Favorites list
- 🔍 Filters by status, platform, genre and rating
- 📊 Personal dashboard with stats

## 🚀 Roadmap

- [ ] External API integration (RAWG / IGDB)
- [ ] Public profile page
- [ ] Achievements / Badges system
- [ ] Charts by genre, platform and year
- [ ] Wishlist with deal alerts

## Database Migrations Structure

This project follows the same migration strategy:

- `Database/Migrations/ApplyDbMigrations.ps1`: migration runner script.
- `Database/Migrations/NextRelease/migrations.json`: ordered list of SQL scripts for the next release.
- `Database/Migrations/NextRelease/release-manual-tasks.txt`: release checklist.
- `Database/SQL/...`: SQL scripts referenced by `migrations.json`.

## Running Locally

### Backend

```powershell
cd Backend/GameShelf.Server
dotnet restore
dotnet run
```

### Frontend

```powershell
cd Frontend
npm install
npm start
```

## Migrations Workflow

1. Create SQL scripts in `Database/SQL/...`.
2. Add script paths to `Database/Migrations/NextRelease/migrations.json` in execution order.
3. Run `Database/Migrations/ApplyDbMigrations.ps1` against the target environment.
4. Validate manual release steps in `release-manual-tasks.txt`.

If `migrations.json` is empty, no scripts will be applied.