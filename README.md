# SkynetBooking

This is the example project which I used as a **code-along example** example for a talk on **end-to-end testing**. The solution illustrates common e2e testing pitfalls and practices (validation vs. system behaviour, API contract drift, real vs. in-memory data, auth, test data, assertions, and more).

## Run

```bash
# Apply migrations
./scripts/ApplyMigrations.ps1

# API (from repo root)
# F5 Debug in Visual Studio

# OR 

# Run via CLI (from repo root)
dotnet run --project SkynetBooking.WebAp
```

## Scripts

- `scripts/ApplyMigrations.ps1` — apply EF Core migrations to the database
- `scripts/AddMigration.ps1` — add a new migration
