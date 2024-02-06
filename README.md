﻿# Calabonga.Results

## Описание

Данный nuget-пакет является продолжением другого пакета `OperationResultCore`, который уже исчерпал свои возможности и пришло время двигаться дальше. В старой версии был только один недостаток, который перекрывал все остальные плюсы - невозможность десериализовать объект из строки. Для выполнения десериализации приходилось реализовывать конверторы. В новом nuget-пакете `Calabonga.Result` реализация стандарта RFC7807 построена по стилю на язык rust. При этом всё максимально упрощено для удобства.

## English
Some helpful Results as an implementation of RFC7807. In other words, it's simple wrapper for result operation for any returned data from API backend implemented on Rust-style approach.

## Version history

### 2024-02-06 v1.0.0

* First release
* Summaries added
* Unit-testing project prepared

### 2024-02-05 v1.0.0-beta.1

* First community preview
* Base functionality implemented
* Huge refactoring of the OperationResult nuget package