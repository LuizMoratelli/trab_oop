CREATE TABLE "carro" (
  "id" int PRIMARY KEY,
  "nome" varchar,
  "descricao" varchar,
  "data_aquisicao" varchar
);

CREATE TABLE "cliente" (
  "cpf" int PRIMARY KEY,
  "nome" varchar,
  "data_nascimento" timestamp
);

CREATE TABLE "aluguel" (
  "id" int PRIMARY KEY,
  "carro_id" int,
  "cliente_id" int,
  "vendedor_id" int,
  "data_inicio" timestamp,
  "data_fim" timestamp
);

CREATE TABLE "vendedor" (
  "cpf" int PRIMARY KEY,
  "nome" varchar,
  "qtd_vendas" int,
  "total_vendas" double
);

ALTER TABLE "aluguel" ADD FOREIGN KEY ("carro_id") REFERENCES "carro" ("id");

ALTER TABLE "aluguel" ADD FOREIGN KEY ("cliente_id") REFERENCES "cliente" ("cpf");

ALTER TABLE "aluguel" ADD FOREIGN KEY ("vendedor_id") REFERENCES "vendedor" ("cpf");