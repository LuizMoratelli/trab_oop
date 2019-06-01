CREATE SEQUENCE carro_id_seq;
CREATE TABLE "carro" (
  "id" int PRIMARY KEY NOT NULL DEFAULT nextval('carro_id_seq'),
  "nome" varchar,
  "descricao" varchar,
  "data_aquisicao" timestamp
);

CREATE SEQUENCE cliente_id_seq;
CREATE TABLE "cliente" (
  "id" int PRIMARY KEY NOT NULL DEFAULT nextval('cliente_id_seq'),
  "cpf" varchar,
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

CREATE SEQUENCE vendedor_id_seq;
CREATE TABLE "vendedor" (
  "id" int PRIMARY KEY NOT NULL DEFAULT nextval('vendedor_id_seq'),
  "cpf" varchar,
  "nome" varchar,
  "qtd_vendas" int
);

ALTER SEQUENCE carro_id_seq
OWNED BY carro.id;

ALTER SEQUENCE aluguel_id_seq
OWNED BY aluguel.id;

ALTER SEQUENCE cliente_id_seq
OWNED BY cliente.id;

ALTER SEQUENCE vendedor_id_seq
OWNED BY vendedor.id;

ALTER TABLE "aluguel" ADD FOREIGN KEY ("carro_id") REFERENCES "carro" ("id");

ALTER TABLE "aluguel" ADD FOREIGN KEY ("cliente_id") REFERENCES "cliente" ("id");

ALTER TABLE "aluguel" ADD FOREIGN KEY ("vendedor_id") REFERENCES "vendedor" ("id");