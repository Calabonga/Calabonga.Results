# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## Правила проекта

- @rules/code-styles.md — рекомендации по синтаксису C#, null-safety, неизменяемости, порядку членов класса, async и обработке ошибок (в т.ч. использовать `Calabonga.Results` вместо исключений).
- @rules/conventions.md — соглашения об именовании CQRS-классов (команды, запросы, обработчики, view-модели).
- @rules/testing.md — стандарты тестирования: xUnit 3+/Moq/AutoFixture, `WebApplicationFactory` для интеграционных тестов, шаблон именования тестов.
- @rules/workflow.md — рабочий процесс Git: ветки, формат коммитов, `dotnet test` перед коммитом, атомарные коммиты.

## Обзор

`Calabonga.Results` (nuget-пакет, ID `Calabonga.Results`, корневое пространство имён `Calabonga.OperationResults`) — обёртка для результата операции в стиле Rust (`Result<T, E>`), реализующая идею RFC7807 без необходимости десериализации сообщений об ошибке из строки. Репозиторий состоит из одной библиотеки (`src/Calabonga.Results`) и проекта unit-тестов (`src/Calabonga.Results.Tests`, xUnit). Таргетируется `netstandard2.1`, тесты — `net8.0`. Публикуется автоматически в NuGet через GitHub Actions при пуше в `main`.

## Команды

```bash
# restore + сборка (решение целиком)
dotnet restore src/Calabonga.Results.sln
dotnet build src/Calabonga.Results.sln --configuration Release

# запуск unit-тестов
dotnet test src/Calabonga.Results.Tests/Calabonga.Results.Tests.csproj
```

Сборка `Calabonga.Results.csproj` в любой конфигурации создаёт nuget-пакет (`GeneratePackageOnBuild=true`) — обычный `dotnet build` уже пакует библиотеку, отдельная команда `dotnet pack` не нужна.

## Архитектура

Библиотека — набор из четырёх файлов в `src/Calabonga.Results/`:

- [Operation.cs](../src/Calabonga.Results/Operation.cs) — основные типы `Operation<T>`, `Operation<T, T1>`, `Operation<T, T1, T2>`, `Operation<T, T1, T2, T3>`. `readonly struct` с полями `Result`, `Ok` и (начиная с двухпараметрового варианта) `Error`. Неявные операторы (`implicit operator`) конвертируют `T`, `SuccessResult<T>` и `ErrorResult<T>` в нужный `Operation<...>`, а сам `Operation<...>` — в `bool` (через `Ok`), что позволяет писать `if (sut)`.
- [OperationEmpty.cs](../src/Calabonga.Results/OperationEmpty.cs) — те же варианты (0–3 типа ошибок), но без поля `Result`: `OperationEmpty`, `OperationEmpty<T>`, `OperationEmpty<TError1, TError2>`, `OperationEmpty<T, T1, T2>`. Используется, когда операция не возвращает значение, но может завершиться ошибкой.
- [SuccessResult.cs](../src/Calabonga.Results/SuccessResult.cs) / [ErrorResult.cs](../src/Calabonga.Results/ErrorResult.cs) — промежуточные (DTO) структуры-маркеры. Их поля `Result`/`Error` объявлены `internal` — снаружи сборки они не читаются напрямую, только через неявное приведение к `Operation<...>`.
- [OperationHelpers.cs](../src/Calabonga.Results/OperationHelpers.cs) — статический класс `Operation` (не путать со структурами `Operation<...>`) с фабричными методами `Operation.Result()`, `Operation.Result<T>(value)`, `Operation.Error()`, `Operation.Error<T>(error)`. Это единственный публичный способ создать `SuccessResult`/`ErrorResult<T>`, которые затем неявно приводятся к нужному `Operation<...>`.

Типичный паттерн использования (см. [ResultFixture.cs](../src/Calabonga.Results.Tests/ResultFixture.cs)):

```csharp
Operation<int, string> DoWork(int arg)
{
    if (arg < 0)
    {
        return Operation.Error("Error");
    }
    return Operation.Result(arg);
}
```

или можно проще:

```csharp
Operation<int, string> DoWork(int arg)
{
    if (arg < 0)
    {
        return Operation.Error("Error");
    }
    return arg;
}
```

### Что важно знать

- В `Operation<T, T1, T2, T3>` оператор `implicit operator Operation<T, T1, T2, T3>(ErrorResult<T1> result)` ([Operation.cs:197](../src/Calabonga.Results/Operation.cs:197)) исторически передавал в конструктор саму структуру `result` вместо `result.Error`, из-за чего `Error` для первого типа ошибки содержал бы `ErrorResult<T1>` целиком, а не значение ошибки (асимметрично веткам для `T2`/`T3`). Баг исправлен; регрессия покрыта тестом `GetResultOrOneOfThreeErrors_Should_ReturnFirstErrorTypeValue_When_ArgumentEquals200` в [OperationResultTests.cs](../src/Calabonga.Results.Tests/OperationResultTests.cs).
- `Result`/`Error` в `SuccessResult`/`ErrorResult<T>` намеренно `internal` — библиотека не даёт создавать `Operation<...>` напрямую из этих DTO вне сборки, только через `Operation.Result(...)`/`Operation.Error(...)` и неявные операторы. Не убирайте модификатор `internal`, не проверив, не нарушает ли это задуманный API.
- Пакет издаётся из `Calabonga.Results.csproj`, но корневой namespace — `Calabonga.OperationResults` (переименован в v1.1.0, см. [README.md](../README.md)); не путайте имя пакета/решения с namespace при поиске типов.
- В `.csproj` версия пакета (`<Version>`) и changelog в [src/Calabonga.Results/README.md](../src/Calabonga.Results/README.md) (упаковывается в nuget) обновляются вручную при каждом релизе — публикация в GitHub Actions ([`.github/workflows/main.yml`](../.github/workflows/main.yml)) срабатывает при каждом push в `main` и требует секрет `NUGET_API_KEY`; повторная публикация той же версии пропускается флагом `--skip-duplicate`.
- Тестовый проект переведён на `xunit.v3` ([Calabonga.Results.Tests.csproj](../src/Calabonga.Results.Tests/Calabonga.Results.Tests.csproj)) и использует `AutoFixture` для генерации тестовых данных — в соответствии с [testing.md](../.claude/rules/testing.md). `Moq` намеренно не подключён: в проекте нет интерфейсов/внешних зависимостей для мокирования (`Operation<...>` — value-типы); добавляйте пакет только когда появится реальная необходимость мокировать что-то.
- `xunit.v3` — тестовый проект теперь самостоятельный исполняемый файл (`<OutputType>Exe</OutputType>`) и запускается как MTP-приложение (Microsoft.Testing.Platform), а не через VSTest. Из-за этого `dotnet test` на .NET 10 SDK требует секцию `"test": { "runner": "Microsoft.Testing.Platform" }` в [global.json](../global.json) в корне репозитория — без неё команда падает с ошибкой `MTP error` о неподдерживаемом VSTest-таргете. CI ([`.github/workflows/main.yml`](../.github/workflows/main.yml)) из-за этого также переведён на .NET 10 SDK (`dotnet-version: 10.0.x`) — на более старом SDK новый режим `dotnet test` недоступен.
