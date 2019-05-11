CREATE SEQUENCE carro_id_seq;
CREATE TABLE "carro" (
  "id" int PRIMARY KEY NOT NULL DEFAULT nextval('carro_id_seq'),
  "nome" varchar,
  "descricao" varchar,
  "data_aquisicao" timestamp
);

CREATE TABLE "cliente" (
  "cpf" bigint PRIMARY KEY NOT NULL,
  "nome" varchar,
  "data_nascimento" timestamp
);

CREATE SEQUENCE aluguel_id_seq;
CREATE TABLE "aluguel" (
  "id" int PRIMARY KEY NOT NULL DEFAULT nextval('aluguel_id_seq'),
  "carro_id" int,
  "cliente_id" int,
  "vendedor_id" int,
  "data_inicio" timestamp,
  "data_fim" timestamp
);

CREATE TABLE "vendedor" (
  "cpf" bigint PRIMARY KEY NOT NULL,
  "nome" varchar,
  "qtd_vendas" int
);

ALTER SEQUENCE carro_id_seq
OWNED BY carro.id;

ALTER SEQUENCE aluguel_id_seq
OWNED BY aluguel.id;

ALTER TABLE "aluguel" ADD FOREIGN KEY ("carro_id") REFERENCES "carro" ("id");

ALTER TABLE "aluguel" ADD FOREIGN KEY ("cliente_id") REFERENCES "cliente" ("cpf");

ALTER TABLE "aluguel" ADD FOREIGN KEY ("vendedor_id") REFERENCES "vendedor" ("cpf");