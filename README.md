# test0-dotnet-postgresql

Пакет .Net 8.0:

    https://dotnet.microsoft.com/ru-ru/download/dotnet/8.0

База данных:

    PostgreSQL

# Параметры подключения к базе данных указываются в перемененные среды ОС:
    DB_STRING 
    Server=192.168.1.66;Port=6661;Username=postgres;password=1;database=postgres
    https://remontka.pro/environment-variables-windows/

# База данных должна быть не пуста.

# Сборка проекта:
В каталоге проекта ".\test0-dotnet-postgresql\test0-dotnet-postgresql" выполнить команду:

    dotnet run

# В консоли перейти по ссылке "localhost:{port}": 
    http://localhost:5099