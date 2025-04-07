# 🛠️ Sistema de Gestão de Equipamentos e Chamados

## 📌 Introdução

Este projeto é uma aplicação **console em C#** que simula um sistema de controle de equipamentos e gerenciamento de chamados. Permite cadastrar, editar, excluir e visualizar equipamentos e chamados.

## 🧰 Tecnologias Utilizadas
![.NET](https://img.shields.io/badge/.NET-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)
![C#](https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=c-sharp&logoColor=white)
![Visual Studio](https://img.shields.io/badge/Visual_Studio-5C2D91?style=for-the-badge&logo=visual-studio&logoColor=white)
![Console App](https://img.shields.io/badge/Console_App-000000?style=for-the-badge&logo=windows-terminal&logoColor=white)

---

## 🚀 Funcionalidades

✅ **Equipamentos**
- Cadastro com nome, número de série, fabricante, preço e data de aquisição.
- Edição e exclusão de equipamentos.
- Listagem com todos os dados registrados.

✅ **Chamados**
- Cada chamado contém título, descrição, equipamento relacionado e data de abertura.
- Cálculo automático dos dias em aberto.
- Funcionalidades de cadastro, edição, exclusão e visualização.

✅ **Interface Console**
- Menus interativos separados para gestão de equipamentos e de chamados.

---

## 🎮 Como Usar

1. **Iniciar o programa**
   - Escolha entre **Gestão de Equipamentos** ou **Gestão de Chamados**.

2. **Navegar pelas opções**
   - Cadastrar, editar, excluir ou visualizar os registros.

3. **Gerenciar Chamados**
   - Associar chamados a equipamentos cadastrados.
   - Informar data de abertura e acompanhar dias em aberto.

4. **Encerrar ou continuar**
   - Pode alternar entre menus ou encerrar o sistema.

---

## 📄 Estrutura do Código

### `Program.cs`
- Ponto de entrada da aplicação. Controla o menu principal e direciona para os módulos de equipamentos e chamados.

### `MenuPrincipal.cs`
- Exibe o menu inicial da aplicação.

### `TelaEquipamento.cs`
- Responsável pela interface e lógica de cadastro, edição, exclusão e visualização de equipamentos.

### `TelaChamado.cs`
- Gerencia as operações com chamados: cadastrar, editar, excluir e visualizar.
- Permite associar equipamentos aos chamados.

### `Equipamento.cs`
- Representa a entidade de um equipamento, com suas informações principais como nome, número de série, fabricante, preço e data de aquisição.

### `Chamado.cs`
- Modelo da entidade chamado, com cálculo de dias em aberto.

### `GeradorIds.cs`
- Gera identificadores únicos para os registros de equipamentos.

---
## 🛠 Como utilizar:
🚀 Passo a Passo

1. Clone o repositório ou baixe o código fonte.
2. Abra o terminal ou prompt de comando e navegue até a pasta raiz
3. Utilize o comando abaixo para restaurar as dependências do projeto

```
dotnet restore
```
4. Em seguida, compile a solução o comando:
```
dotnet build --configuration Release
```
5. Para executar o projeto compilando em tempo real
```
dotnet run --project GestaoDeEquipamentos
```
6. Para executar o arquivo compilado, navegue até a pasta: ./GestaoDeEquipamentos/bin/Release/net8.0/ e execute o arquivo:
```
GestaoDeEquipamentos.ConsoleApp.exe
```

