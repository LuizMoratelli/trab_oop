#!/bin/bash
psql -Upostgres locar < ./docker-entrypoint-initdb.d/database.sql