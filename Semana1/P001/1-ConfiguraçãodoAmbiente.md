Problema: Como você pode verificar se o .NET SDK está corretamente instalado em 
seu sistema?

R: No ambiente Ubuntu 22.04 WSL no qual estou trabalhando os comandos são:
    dotnet --list-sdks e dotnet --list-runtimes para ver quais versões estão instaladas.

Como remover e atualizar?

    remover: sudo apt-get remove --purge dotnet-sdk-<version> (substitua <version> pela versão que deseja remover).

    Atualizar: sudo apt-get update && \ sudo apt-get install -y dotnet-sdk-7.0