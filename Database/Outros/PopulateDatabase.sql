-- Iserir dados para testes


---- CATEGORIAS

Insert into Categories(Name, Label, Image_URI) Values('construcao', 'Construção', 'construcao.jpg');
Insert into Categories(Name, Label, Image_URI) Values('eletrica', 'Elétrica', 'eletrica.jpg');
Insert into Categories(Name, Label, Image_URI) Values('hidraulica', 'Hidráulica', 'hidraulica.jpg');
Insert into Categories(Name, Label, Image_URI) Values('ferragens', 'Ferragens', 'ferragens.jpg');
Insert into Categories(Name, Label, Image_URI) Values('tintas', 'Tintas', 'tintas.jpg');
Insert into Categories(Name, Label, Image_URI) Values('ferramentas', 'Ferramentas', 'ferramentas.jpg');
Insert into Categories(Name, Label, Image_URI) Values('outros', 'Outros', 'outros.jpg');


---- PRODUTOS

Insert into Products(Name, Label, Description, Product_Mark, Price, Image_URI, Status, Stock_Qtd, Sold_Qtd, category_id) 
Values('massa-corrida-25kg', 'Massa Corrida 25Kg', 'Massa Corrida Coral c/ 25kg', 'Coral', 94.90, '../images/massa-corrida-25kg.jpg', 1, 20, 5, 1);

Insert into Products(Name, Label, Description, Product_Mark, Price, Image_URI, Status, Stock_Qtd, Sold_Qtd, category_id) 
Values('saco-de-areia', 'Saco de Areia', 'Saco de areia lavada de 20Kg', 's/ Marca', 10.90, '../images/saco-de-areia.jpg', 1, 20, 3, 1);

Insert into Products(Name, Label, Description, Product_Mark, Price, Image_URI, Status, Stock_Qtd, Sold_Qtd, category_id) 
Values('saco-de-pedra', 'Saco de Pedra', 'Saco de pedra com 20kg tipo nº 2', 's/ Marca', 9.90, '../images/saco-de-pedra.jpg', 0, 20, 0, 1);

Insert into Products(Name, Label, Description, Product_Mark, Price, Image_URI, Status, Stock_Qtd, Sold_Qtd, category_id) 
Values('fita-isolante', 'Fita Isolante', 'Fita isolande de alta isolação e fixação para todos os ambientes', '3M', 7.90, '../images/fita-isolante.jpg', 1, 7, 43, 2);

Insert into Products(Name, Label, Description, Product_Mark, Price, Image_URI, Status, Stock_Qtd, Sold_Qtd, category_id) 
Values('cabo-flexível 4mm', 'Cabo Flexível 4mm - 100 metros', 'Cabo de cobre com acabamento em PVC até 750V , diametro nominal 4mm', 'Cobrecom', 159.90, '../images/cabo-flexível-4mm.jpg', 0, 20, 0,2);

Insert into Products(Name, Label, Description, Product_Mark, Price, Image_URI, Status, Stock_Qtd, Sold_Qtd, category_id) 
Values('cola-pvc-tigre', 'Cola PVC Tigre', 'Cola para tubo PVC de fixação rápida e segura contra vazamento.', 'Tigre', 5.90, '../images/cola-pvc-tigre.jpg', 1, 39, 11, 3);

Insert into Products(Name, Label, Description, Product_Mark, Price, Image_URI, Status, Stock_Qtd, Sold_Qtd, category_id) 
Values('conexao-t-rosca3/4', 'Conexão T com rosca 3/4', 'Conexão em formato T c/ rosca 3/4 para toneiras', 'Tigre', 4.90, '../images/conexão-t-tigre.jpg', 1, 15, 5,3);

Insert into Products(Name, Label, Description, Product_Mark, Price, Image_URI, Status, Stock_Qtd, Sold_Qtd, category_id) 
Values('parafuso-drywall-25mm', 'Parafuso drywall 25mm', 'Parafuso para drywall ponta agulha cabeça trombeta 25mm 1000 unidades Placo', 'Placo', 62.90, '../images/parafuso-drywall-25mm.jpg', 1, 10, 0, 4);

Insert into Products(Name, Label, Description, Product_Mark, Price, Image_URI, Status, Stock_Qtd, Sold_Qtd, category_id) 
Values('fechadura-externa-zamac', 'Fechadura externa de aço', 'Fechadura externa de aço zamac Stilo com espelho bronze latonada MGM', 'MGM', 53.90, '../images/fechadura-externa-zamac.jpg', 1, 2, 0, 4);

Insert into Products(Name, Label, Description, Product_Mark, Price, Image_URI, Status, Stock_Qtd, Sold_Qtd, category_id) 
Values('tinta-acrilica 3,6L',' Tinta Acrílica Nova Eco p/ Parede', 'Tinta Acrílica Nova Eco p/ Parede 3,6L Branco Neve Quartzolit', 'Quartzolit', 45.90, '../images/tinta-acrilica-quartzolit-3,6.jpg', 0, 20, 0, 5);

Insert into Products(Name, Label, Description, Product_Mark, Price, Image_URI, Status, Stock_Qtd, Sold_Qtd, category_id) 
Values('tinta-acrilica-rende-muito-fosca-20l', 'Tinta Coral Acrílica Rende Muito Fosca 20L', 'Tinta Coral Acrílica Rende Muito Fosca Branco 20 Litros', 'Coral', 359.90, '../images/tinta-acrilica-rende-muito-fosca-20l.jpg', 1, 10, 0, 5);

Insert into Products(Name, Label, Description, Product_Mark, Price, Image_URI, Status, Stock_Qtd, Sold_Qtd, category_id) 
Values('alicate-universal-gedore', 'Alicate Universal Gedore', 'Alicate universal multiuso com isolação de 1000V', 'Gedore', 60.90, '../images/alicate-universal-gedore.jpg', 1, 5, 0, 6);

Insert into Products(Name, Label, Description, Product_Mark, Price, Image_URI, Status, Stock_Qtd, Sold_Qtd, category_id) 
Values('espuma-expansiva', 'Espuma expansiva de poliuretano', 'Spray monocomponente, utilizada para fins domiciliares e profissionais.', 'Tekbond', 22.90, '../images/espuma-expansiva.jpg', 1, 20, 0, 7);

COMMIT;


---- USUARIOS

INSERT INTO AspNetUsers (Id, UserName, NormalizedUserName, Email, NormalizedEmail, EmailConfirmed, PasswordHash, SecurityStamp, ConcurrencyStamp, PhoneNumber, PhoneNumberConfirmed, TwoFactorEnabled, LockoutEnd, LockoutEnabled, AccessFailedCount)
VALUES ('{id}', 'admin', 'ADMIN', 'rodolfo@gmail.com', 'RODOLFO@GMAIL.COM', 1, '{passwordHash}','{securityStamp}', '{concurrencyStamp}', '11977777777', 1, 0,null, 0, 0);

INSERT INTO AspNetUserClaims (user_id, ClaimType, ClaimValue) VALUES ('{id}', 'MasterAdmin', 'AdministradorGeral');
INSERT INTO user_admins (user_admin_id, user_id, full_name, CPF, status)VALUES ('{id}', '{id}', 'RODOLFO CHAVES', '12345678910', 1);


--securityStamp = Guid.NewGuid().ToString();
--concurrencyStamp = Guid.NewGuid().ToString();
--id = Guid.NewGuid().ToString();
--hasher = new PasswordHasher<IdentityUser>();
--passwordHash = hasher.HashPassword(null, "Testes@123");

INSERT INTO AspNetUsers (Id, UserName, NormalizedUserName, Email, NormalizedEmail, EmailConfirmed, PasswordHash, SecurityStamp, ConcurrencyStamp, PhoneNumber, PhoneNumberConfirmed, TwoFactorEnabled, LockoutEnd, LockoutEnabled, AccessFailedCount)
VALUES ('{id}', 'productadmin', 'PRODUCTADMIN', 'productadmin@gmail.com', 'PRODUCTADMIN@GMAIL.COM', 1, '{passwordHash}','{securityStamp}', '{concurrencyStamp}', '11966666666', 1, 0,null, 0, 0);

INSERT INTO AspNetUserClaims (user_id, ClaimType, ClaimValue) VALUES ('{id}', 'ProductAdmin', 'AdministradorDeProdutos');
INSERT INTO user_admins (user_admin_id, user_id, full_name, CPF, status)VALUES ('{id}', '{id}', 'PRODUCT ADMIN', '33333333333', 1);


--securityStamp = Guid.NewGuid().ToString();
--concurrencyStamp = Guid.NewGuid().ToString();
--id = Guid.NewGuid().ToString();
--hasher = new PasswordHasher<IdentityUser>();
--passwordHash = hasher.HashPassword(null, "Testes@123");

INSERT INTO AspNetUsers (Id, UserName, NormalizedUserName, Email, NormalizedEmail, EmailConfirmed, PasswordHash, SecurityStamp, ConcurrencyStamp, PhoneNumber, PhoneNumberConfirmed, TwoFactorEnabled, LockoutEnd, LockoutEnabled, AccessFailedCount)
VALUES ('{id}', 'clientadmin', 'CLIENTADMIN', 'clientadmin@gmail.com', 'CLIENTADMIN@GMAIL.COM', 1, '{passwordHash}','{securityStamp}', '{concurrencyStamp}', '11977777777', 1, 0,null, 0, 0);

INSERT INTO AspNetUserClaims (user_id, ClaimType, ClaimValue) VALUES ('{id}', 'ClientAdmin', 'AdministradorDeCLientes');
INSERT INTO user_admins (user_admin_id, user_id, full_name, CPF, status)VALUES ('{id}', '{id}', 'CLIENTADMIN', '44444444444', 1);


--securityStamp = Guid.NewGuid().ToString();
--concurrencyStamp = Guid.NewGuid().ToString();
--id = Guid.NewGuid().ToString();
--hasher = new PasswordHasher<IdentityUser>();
--passwordHash = hasher.HashPassword(null, "Testes@123");

INSERT INTO AspNetUsers (Id, UserName, NormalizedUserName, Email, NormalizedEmail, EmailConfirmed, PasswordHash, SecurityStamp, ConcurrencyStamp, PhoneNumber, PhoneNumberConfirmed, TwoFactorEnabled, LockoutEnd, LockoutEnabled, AccessFailedCount)
VALUES ('{id}', 'selleradmin', 'SELLERADMIN', 'selleradmin@gmail.com', 'SELLERADMIN@GMAIL.COM', 1, '{passwordHash}','{securityStamp}', '{concurrencyStamp}', '11977777777', 1, 0,null, 0, 0);

INSERT INTO AspNetUserClaims (user_id, ClaimType, ClaimValue) VALUES ('{id}', 'SellerAdmin', 'AdministradorDeVendedores');
INSERT INTO user_admins (user_admin_id, user_id, full_name, CPF, status)VALUES ('{id}', '{id}', 'SELLERADMIN', '55555555555', 1);


--securityStamp = Guid.NewGuid().ToString();
--concurrencyStamp = Guid.NewGuid().ToString();
--id = Guid.NewGuid().ToString();
--hasher = new PasswordHasher<IdentityUser>();
--passwordHash = hasher.HashPassword(null, "Testes@123");

INSERT INTO AspNetUsers (Id, UserName, NormalizedUserName, Email, NormalizedEmail, EmailConfirmed, PasswordHash, SecurityStamp, ConcurrencyStamp, PhoneNumber, PhoneNumberConfirmed, TwoFactorEnabled, LockoutEnd, LockoutEnabled, AccessFailedCount)
VALUES ('{id}', 'vendedor', 'VENDEDOR', 'Vendedor@gmail.com', 'VENDEDOR@GMAIL.COM', 1, '{passwordHash}','{securityStamp}', '{concurrencyStamp}', '11988888888', 1, 0,null, 0, 0);

INSERT INTO AspNetUserClaims (user_id, ClaimType, ClaimValue) VALUES ('{id}', 'Seller', 'Vendedor');
INSERT INTO user_sellers (user_seller_id, user_id, fantasy_name, CNPJ, Street, Number, zip_code, Complemnt, District, City, State, status)VALUES ('{id}', '{id}', 'Depósito São Caetano', '11111111111111', 'Alamenda São Caetano', '1234','09560500', '', 'Centro', 'São Caetano do Sul', 'SP', 1);


--securityStamp = Guid.NewGuid().ToString();
--concurrencyStamp = Guid.NewGuid().ToString();
--id = Guid.NewGuid().ToString();
--hasher = new PasswordHasher<IdentityUser>();
--passwordHash = hasher.HashPassword(null, "Testes@123");

INSERT INTO AspNetUsers (Id, UserName, NormalizedUserName, Email, NormalizedEmail, EmailConfirmed, PasswordHash, SecurityStamp, ConcurrencyStamp, PhoneNumber, PhoneNumberConfirmed, TwoFactorEnabled, LockoutEnd, LockoutEnabled, AccessFailedCount)
VALUES ('{id}', 'cliente', 'CLIENTE', 'Cliente@gmail.com', 'CLIENTE@GMAIL.COM', 1, '{passwordHash}','{securityStamp}', '{concurrencyStamp}', '11999999999', 1, 0,null, 0, 0);

INSERT INTO AspNetUserClaims (user_id, ClaimType, ClaimValue) VALUES ('{id}', 'Client', 'Cliente');
INSERT INTO user_clients (user_client_id, user_id, full_name, CPF, Street, Number, zip_code, Complemnt, District, City, State, status)VALUES ('{id}', '{id}', 'João da Silva', '12312312312', 'Rua Amazonas', '1234','09540204', '', 'Oswaldo Cruz', 'São Caetano do Sul', 'SP', 1);

COMMIT;


{
  "userName": "rodolfo",
  "email": "rodolfo@teste.com",
  "password": "Testes@123",
}

{
  "userName": "cliente",
  "email": "cliente@teste.com",
  "password": "Testes@123",
}

{
  "userName": "vendedor",
  "email": "vendedor@teste.com",
  "password": "Testes@123",
}

{
  "userName": "rodolfo",
  "fullName": "Rodolfo Chaves",
  "email": "rodolfo@teste.com",
  "password": "Testes@123",
  "cpf": "12345678910",
  "typeAdmin": 5
}

{
  "userName": "rodolfo1",
  "email": "rodolfo@teste.com",
  "password": "Testes@123"
}

{
  "userName": "rodolfo2",
  "email": "rodolfo@teste.com",
  "password": "Testes@123"
}

{
  "userName": "rodolfo3",
  "email": "rodolfo@teste.com",
  "password": "Testes@123"
}


{
  "userName": "cliente",
  "email": "cliente@teste.com",
  "password": "Testes@123",
  "fullName": "Cliente Teste",
  "cpf": "12345678911",
  "typeClient": 0,
  "street": "teste",
  "addressNumber": "123",
  "zipCode": "08400123",
  "district": "teste",
  "city": "teste",
  "state": "sp"
}


{
  "userName": "vendedor",
  "email": "vendedor@teste.com",
  "password": "Testes@123",
  "fantasyName": "vendedor Teste",
  "cnpj": "12345678911",
  "typeSeller": 0,
  "street": "teste",
  "addressNumber": "123",
  "zipCode": "08400123",
  "district": "teste",
  "city": "teste",
  "state": "sp"
}