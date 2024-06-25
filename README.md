# VaccinationCenter API

## Aplicação para o gerenciamento de postos de vacinação e de vacinas.


### Foi utilizado nesse projeto:

- [.NET 6]
- [Entity Framework Core]
- [SQL Server]
- [Migration]
- [DTOs]


#### Clone o repositorio:
git clone https://github.com/raafaelpc/VaccinationCenterAPI.git

#### Abra no Visual Studio Code.

#### Configure as ConnectionStrings em appsettings.json:
![image](https://github.com/raafaelpc/VaccinationCenterAPI/assets/80062189/6625abbf-21be-49fd-810c-fa29520c93a1)

#### Suba as migrations:
Update-Database
ou
dotnet ef database update

#### Inicie o projeto.

## Utilize o Swagger para chegar e testar os endpoints da API
![image](https://github.com/raafaelpc/VaccinationCenterAPI/assets/80062189/d47df1ce-8cfe-4f86-94f5-789855c7f3f4)


## Check de validações

● O sistema deve impedir a duplicação de postos com o mesmo nome. ✔
![image](https://github.com/raafaelpc/VaccinationCenterAPI/assets/80062189/12354f3d-6b06-4f36-8eef-677007bce827)



● Um posto de vacinação pode ter várias vacinas associadas. ✔

● Postos de vacinação que possuem vacinas associadas não podem ser excluídos. ✔
![image](https://github.com/raafaelpc/VaccinationCenterAPI/assets/80062189/3c46b391-8ebd-4481-b45b-ac2caa1c419f)


● Cada vacina deve ter um nome, fabricante, lote, quantidade e data de validade.  ✔

● A data de validade da vacina deve ser uma data futura.  ✔
![image](https://github.com/raafaelpc/VaccinationCenterAPI/assets/80062189/5335420d-3868-46a4-88ab-216d3f6bcbed)


● Vacinas não podem ter o mesmo lote. ✔
![image](https://github.com/raafaelpc/VaccinationCenterAPI/assets/80062189/64e73294-0c9e-4e90-8f14-5f0497a8b792)

