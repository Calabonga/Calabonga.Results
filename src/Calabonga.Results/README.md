# Calabonga.Results

## Описание

Данный nuget-пакет является продолжением другого пакета `OperationResultCore`, который уже исчерпал свои возможности и пришло время двигаться дальше. В старой версии был только один недостаток, который перекрывал все остальные плюсы - невозможность универсально реагировать на тип возвращаемого результата и десереализация из строки. Для выполнения десериализации приходилось реализовывать конверторы. В новом nuget-пакете `Calabonga.Result` реализация стандарта RFC7807 построена по стилю на язык rust. При этом всё максимально упрощено для удобства, таким образом, десериализация никогда не требуется (или почти никогда).
## English
Some helpful Results as an implementation of RFC7807. In other words, it's simple wrapper for result operation for any returned data from API backend implemented on Rust-style approach.

## Version history

### 2024-06-03 v1.1.0

* Root namespace renamed from Calabonga.Results to Calabonga.OperationResults
* Add some summaries for properties and methods

### 2024-02-06 v1.0.2

* First release
* Summaries added
* Unit-testing project prepared

### 2024-02-05 v1.0.0-beta.1

* First community preview
* Base functionality implemented
* Huge refactoring of the OperationResult nuget package